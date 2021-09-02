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
using EntityManager;

namespace VistasManager.UI
{
    public partial class DocumentosTrasladosGuardar : Estilos.FormEditores
    {
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.PersonasNombres _clientes = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.BodegasNombres _bodegaorigen = new ModelosManager.CLS.BodegasNombres();
        ModelosManager.CLS.BodegasNombres _bodegadestino = new ModelosManager.CLS.BodegasNombres();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate bool RefresarFormularioExterno(ModelosManager.CLS.DocumentosEncabezados _doc);
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        ErrorProvider _seterror = new ErrorProvider();

        DataTable _dtclientes = new DataTable();
        BindingSource _bsclientes = new BindingSource();

        private bool _ok = false;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public DocumentosTrasladosGuardar(int _pidbodegaorigen, int _pidbodegadestino)
        {
            //_clientes = new ModelosManager.CLS.PersonasNombres(_pidpersona);
            _bodegaorigen = new ModelosManager.CLS.BodegasNombres(_pidbodegaorigen);
            _bodegadestino = new ModelosManager.CLS.BodegasNombres(_pidbodegadestino);
            InitializeComponent();
            Iniciar();
        }

        public DocumentosTrasladosGuardar(ModelosManager.CLS.DocumentosEncabezados _pdoc)
        {
            _documento = _pdoc;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                if (_documento.Existe)
                {
                    IDDocumento.Text = _documento.IDDocumento.Valor.ToString();
                    FechaDocumento.Value = Convert.ToDateTime(_documento.FechaDocumento.Valor.ToString());
                    NumeroDocumento.Text = _documento.NumeroDocumento.Valor.ToString();
                    Comentario.Text = _documento.Comentario.Valor.ToString();
                }
                else
                {
                    Comentario.Text = "TRASLADO DE BODEGA";
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
                if (Validaciones())
                {
                    grupoInformacion.Sincronizar(_documento);

                    _documento.Operacion.Valor = "TRASLADO";
                    _documento.Estado.Valor = "APLICADO";
                    _documento.Documento.Valor = "N/A";
                    _documento.DiasPlazo.Valor = 0;
                    _documento.FormaPago.Valor = "N/A";

                    if (doRefrescarFormularioExterno != null)
                    {
                        _ok = doRefrescarFormularioExterno(_documento);
                        Close();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool Validaciones()
        {
            int _errores = 0;
            try
            {
                if (NumeroDocumento.Text.EsNOE())
                {
                    _seterror.SetError(NumeroDocumento, "No es válido");
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

        //private void cbbClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        IDPersona.Text = cbbClientes.SelectedValue.ToString();
        //        NombreTitular.Text = cbbClientes.Text;
        //    }
        //    catch (Exception _err)
        //    {
        //        Herramientas.Log.Registrar(_err.ToString());
        //    }
        //}
    }
}
