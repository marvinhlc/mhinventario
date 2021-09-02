using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace Backup
{
    public partial class HacerBackup : Form
    {
        Sesion.CLS.ConfigApp _configapp = new Sesion.CLS.ConfigApp();
        private int _progreso = 0;

        const int _TIME_OUT_CONNECTION = 0;
        const int _INTERVALO_PROGRESO = 50;

        string _fichero = string.Empty;
        string _connexion = string.Empty;

        string _currentTableName = "";
        int _totalRowsInCurrentTable = 0;
        int _totalRowsInAllTables = 0;
        int _currentRowIndexInCurrentTable = 0;
        int _currentRowIndexInAllTable = 0;
        int _totalTables = 0;
        int _currentTableIndex = 0;

        Timer timer1;
        BackgroundWorker _bw;
        MySqlConnection _conn;
        MySqlCommand _command;
        MySqlBackup _backup;

        public HacerBackup()
        {
            InitializeComponent();
            Iniciar();

            timer1 = new Timer();
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;

            _bw = new BackgroundWorker();
            _bw.DoWork += _bw_DoWork;
            _bw.RunWorkerCompleted += _bw_RunWorkerCompleted;
        }

        private void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CloseConnection();
                if (_totalRowsInAllTables > 0)
                    BarraProgreso.Value = _totalRowsInAllTables;
                else
                    BarraProgreso.Value = BarraProgreso.Maximum;
                _progreso = 100;

                lblTextoProgreso.Text = string.Format("Progreso: {0}%", _progreso);
                lblInfo.Text = string.Format("Tabla: {0}", _currentTableName);

                this.Refresh();
                timer1.Stop();
                MessageBox.Show("Se ha finalizado el backup satisfactoriamente.", "BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _backup.ExportToFile(_fichero);
            }
            catch (Exception _err)
            {
                CloseConnection();
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void CloseConnection()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
            }

            if (_command != null)
                _command.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BarraProgreso.Maximum = _totalRowsInAllTables;
                if (_currentRowIndexInAllTable < BarraProgreso.Maximum)
                {
                    MostrarProgreso();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void MostrarProgreso()
        {
            try
            {
                if (_currentRowIndexInAllTable > 0)
                    BarraProgreso.Value = _currentRowIndexInAllTable;
                lblTextoProgreso.Text = string.Format("Progreso: {0}%", _progreso);
                lblInfo.Text = string.Format("Tabla: {0}", _currentTableName);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Iniciar()
        {
            try
            {
                cbbConexiones.Conexiones();
                txbRutaDelSistema.Text = _configapp.RUTA_DESTINO_BACKUP.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnHacerBackup_Click(object sender, EventArgs e)
        {
            EjecutarBackup();
        }

        private void EjecutarBackup()
        {
            try
            {
                _connexion = ConfigurationManager.ConnectionStrings[cbbConexiones.Text].ToString();

                if (RutaDestino1.Checked)
                {
                    _fichero = string.Format(
                        txbRutaDelSistema.Text, 
                        DateTime.Now.Year, 
                        DateTime.Now.Month, 
                        DateTime.Now.Day,
                        DateTime.Now.Hour,
                        DateTime.Now.Minute
                        );
                }
                if (RutaDestino2.Checked)
                {
                    _fichero = txbRutaDistinta.Text;
                }

                linkFicheroSalida.Text = _fichero;

                if (_fichero.NoNOE())
                {
                    _conn = new MySqlConnection(_connexion);
                    _command = new MySqlCommand();
                    _backup = new MySqlBackup();

                    timer1.Start();

                    _command.Connection = _conn;
                    _command.CommandTimeout = _TIME_OUT_CONNECTION;
                    _conn.Open();

                    _backup.Command = _command;
                    _backup.ExportInfo.IntervalForProgressReport = _INTERVALO_PROGRESO;
                    _backup.ExportInfo.GetTotalRowsBeforeExport = true;
                    _backup.ExportProgressChanged += ProgresoBackup;
                   
                    _bw.RunWorkerAsync();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ProgresoBackup(object sender, ExportProgressArgs e)
        {
            try
            {
                _currentRowIndexInAllTable = (int)e.CurrentRowIndexInAllTables;
                _currentRowIndexInCurrentTable = (int)e.CurrentRowIndexInCurrentTable;
                _currentTableIndex = e.CurrentTableIndex;
                _currentTableName = e.CurrentTableName;
                _totalRowsInAllTables = (int)e.TotalRowsInAllTables;
                _totalRowsInCurrentTable = (int)e.TotalRowsInCurrentTable;
                _totalTables = e.TotalTables;

                _progreso = (_currentRowIndexInAllTable * 100) / _totalRowsInAllTables;
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message);
            }
        }

        private void cbbConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _key = string.Empty;
            try
            {
                _key = cbbConexiones.Text;
                lblCadenaConexion.Text = ConfigurationManager.ConnectionStrings[_key].ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog _dialogo = new SaveFileDialog();
                if (_dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txbRutaDistinta.Text = _dialogo.FileName.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void RutaDestino2_CheckedChanged(object sender, EventArgs e)
        {
            btnSeleccionarRuta.Enabled = true;
        }

        private void RutaDestino1_CheckedChanged(object sender, EventArgs e)
        {
            btnSeleccionarRuta.Enabled = false;
        }

        private void linkFicheroSalida_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string path = linkFicheroSalida.Text;
                var pi = new ProcessStartInfo(path)
                {
                    Arguments = Path.GetFileName(path),
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetDirectoryName(path),
                    FileName = path,
                    Verb = "OPEN"
                };
                Process.Start(pi);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
