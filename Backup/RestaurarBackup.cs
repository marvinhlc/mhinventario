using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Backup
{
    public partial class RestaurarBackup : Form
    {
        Sesion.CLS.ConfigApp _configapp = new Sesion.CLS.ConfigApp();
        private int _progreso = 0;

        const int _TIME_OUT_CONNECTION = 0;
        const int _INTERVALO_PROGRESO = 50;

        string _fichero = string.Empty;
        string _connexion = string.Empty;

        string _currentTableName = "";
        int curBytes;
        int totalBytes;

        Timer timer1;
        BackgroundWorker _bw;
        MySqlConnection _conn;
        MySqlCommand _command;
        MySqlBackup _backup;

        public RestaurarBackup()
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
                timer1.Stop();
                CloseConnection();

                if (_backup.LastError == null)
                {
                    BarraProgreso.Value = totalBytes;
                    _progreso = 100;
                    lblTextoProgreso.Text = string.Format("Progreso: {0}%", _progreso);
                    lblInfo.Text = string.Format("Bytes: {0}", totalBytes);
                }

                this.Refresh();
                MessageBox.Show("Se ha finalizado la restauración del backup satisfactoriamente.", "RESTAURAR BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _backup.ImportFromFile(_fichero);
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
                BarraProgreso.Maximum = totalBytes;
                if (curBytes < BarraProgreso.Maximum)
                    MostrarProgreso();
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
                if (curBytes > 0)
                    BarraProgreso.Value = curBytes;
                lblTextoProgreso.Text = string.Format("Progreso: {0}%", _progreso);
                lblInfo.Text = string.Format("Bytes: {0}", curBytes);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void EjecutarRestaurarBackup()
        {
            try
            {
                _connexion = ConfigurationManager.ConnectionStrings[cbbConexiones.Text].ToString();

                _fichero = txbRutaOrigen.Text;

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
                    _backup.ImportInfo.IntervalForProgressReport = _INTERVALO_PROGRESO;
                    _backup.ImportProgressChanged += ProgresoBackup;

                    _bw.RunWorkerAsync();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ProgresoBackup(object sender, ImportProgressArgs e)
        {
            try
            {
                totalBytes = (int)e.TotalBytes;
                curBytes = (int)e.CurrentBytes;

                _progreso = (curBytes * 100) / totalBytes;
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message);
            }
        }

        private void Iniciar()
        {
            try
            {
                cbbConexiones.Conexiones();
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
                txbRutaOrigen.Text = btnSeleccionarRuta.CallOpenFileDialog();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
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

        private void btnHacerBackup_Click(object sender, EventArgs e)
        {
            EjecutarRestaurarBackup();
        }
    }
}
