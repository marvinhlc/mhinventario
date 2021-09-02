using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using EntityManager;
using Herramientas;

namespace VistasManager.UI
{
    public partial class GastosControlEditor : Estilos.FormEditores
    {
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void InsertExterno(ModelosManager.CLS.Gastos _nuevo);
        public event InsertExterno doInsertExterno;
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void UpdateExterno(ModelosManager.CLS.Gastos _registro);
        public event UpdateExterno doUpdateExterno;

        DataTable _dtclasificaciones = new DataTable();
        BindingSource _bsclasificaciones = new BindingSource();

        ModelosManager.CLS.Gastos _gasto = new ModelosManager.CLS.Gastos();
        ModelosManager.CLS.GastosClasificaciones _clasificaciones = new ModelosManager.CLS.GastosClasificaciones();

        ErrorProvider _error = new ErrorProvider();

        public GastosControlEditor()
        {
            InitializeComponent();
            Iniciar();
        }

        public GastosControlEditor(DataRow _prow)
        {
            _gasto = new ModelosManager.CLS.Gastos(_prow);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _error.Clear();

                if (_gasto.Existe)
                {
                    groupBox1.Mapear(_gasto);
                }
                else
                {
                    Numero.Clear();
                    Importe.ToMonto(0);
                    Descripcion.Clear();
                    Clasificacion.Clear();
                    Fecha.Focus();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    groupBox1.Sincronizar(_gasto);

                    if (doUpdateExterno != null)
                    {
                        doUpdateExterno(_gasto);
                        Close();
                    }
                    if (doInsertExterno != null)
                    {
                        doInsertExterno(_gasto);
                        _gasto = new ModelosManager.CLS.Gastos();
                        Iniciar();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool ValidarDatos()
        {
            int _errores = 0;
            _error.Clear();

            try
            {
                if (Numero.Text.EsNOE())
                {
                    _error.SetError(Numero, "Datos no válido");
                    _errores++;
                }
                if (Clasificacion.Text.EsNOE())
                {
                    _error.SetError(Clasificacion, "Datos no válido");
                    _errores++;
                }
                if (Descripcion.Text.EsNOE())
                {
                    _error.SetError(Descripcion, "Datos no válido");
                    _errores++;
                }
                if (Importe.Text.TextoToDouble() <= 0)
                {
                    _error.SetError(Importe, "Datos no válido");
                    _errores++;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_errores == 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Fecha_Enter(object sender, EventArgs e)
        {
            //Fecha.Open();
        }

        private void btnSeleccionarClasificacion_Click(object sender, EventArgs e)
        {
            try
            {
                GastosControlClasificaciones _selector = new GastosControlClasificaciones();
                _selector.doEnviarExterno += RecibirClasificacion;
                _selector.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void RecibirClasificacion(ModelosManager.CLS.GastosClasificaciones _seleccionado)
        {
            try
            {
                Clasificacion.Text = _seleccionado.Descripcion.Valor.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
