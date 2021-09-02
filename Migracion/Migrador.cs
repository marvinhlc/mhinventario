using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Herramientas;

namespace Migracion
{
    public partial class Migrador : Form
    {
        string _fichero;
        StreamReader _reader;
        ListaProductos _lista = new ListaProductos();
        Registro _registro = new Registro();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();

        int _progreso = 0;
        int _conteo = 0;
        int _total = 0;

        Timer _timer = new Timer();

        public Migrador()
        {
            InitializeComponent();

            BarraProgreso.Visible = false;
            lblBarraProgreso.Visible = false;

            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            try
            {
                BarraProgreso.Value = _progreso;
                lblBarraProgreso.Text = string.Format("{0}%", _progreso);
                this.Refresh();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Progreso()
        {
            if (_progreso > 0)
            {
                if (BarraProgreso.Visible == false)
                {
                    BarraProgreso.Maximum = 100;
                    BarraProgreso.Minimum = 0;
                    BarraProgreso.Visible = true;
                    lblBarraProgreso.Visible = true;
                }
            }
            else
            {
                BarraProgreso.Visible = false;
                lblBarraProgreso.Visible = false;
            }

            _progreso = (_conteo * 100) / _total;

            BarraProgreso.Value = _progreso;
            lblBarraProgreso.Text = string.Format("{0}%", _progreso);
        }

        private void btnSeleccionarCSV_Click(object sender, EventArgs e)
        {
            LeerFichero();
        }

        private void LeerFichero()
        {
            try
            {
                _timer.Start();

                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = _lista;

                _fichero = btnSeleccionarCSV.CallOpenFileDialog();
                lblNombreFichero.Text = _fichero;
                if (File.Exists(_fichero))
                {
                    _lista.Clear();
                    _total = File.ReadAllLines(_fichero).Count();
                    _conteo = 0;

                    using (_reader = new StreamReader(_fichero, Encoding.Default, true))
                    {
                        
                        string _linea;
                        while ((_linea = _reader.ReadLine()) != null)
                        {
                            if (_conteo > 0)
                            {
                                string[] _campos = _linea.Split(';');
                                _registro = new Registro(_campos);

                                _lista.Add(_registro);
                            }

                            _conteo++;
                        }

                        _progreso = 0;
                    }
                }

                _timer.Stop();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Sincronizar("SINCRONIZAR_PRECIOS");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Sincronizar("CREAR_REGISTROS");
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            Sincronizar("SINCRONIZAR_CATEGORIAS");
        }

        private void btnCostos_Click(object sender, EventArgs e)
        {
            Sincronizar("SINCRONIZAR_COSTOS");
        }

        private void Sincronizar(string _tarea)
        {
            EntityManager.Transaccion _transac = new EntityManager.Transaccion();
            StringBuilder _sb = new StringBuilder();

            try
            {
                if (_lista.Count > 0)
                {
                    foreach (Registro _reg in _lista)
                    {
                        if (_tarea.Equals("SINCRONIZAR_PRECIOS"))
                            _sb.Append(_reg.SincronizarPrecios());
                        if (_tarea.Equals("CREAR_REGISTROS"))
                            _sb.Append(_reg.CrearRegistros());
                        if (_tarea.Equals("SINCRONIZAR_CATEGORIAS"))
                            _sb.Append(_reg.SincronizarCategorias());
                        if (_tarea.Equals("SINCRONIZAR_COSTOS"))
                            _sb.Append(_reg.SincronizarCostos());
                    }

                    _transac.AnexarPreSql(_sb.ToString());
                    if (_transac.Procesar() > 0)
                    {
                        MessageBox.Show("La base de datos se ha sincronizado correctamente.", "SINCRONIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                lblTotalRegistros.Text = string.Format("{0} registros", _lista.Count());
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

    }
}
