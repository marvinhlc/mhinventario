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
    public partial class DocumentosSalidasGuardar : Estilos.FormEditores
    {
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.PersonasNombres _clientes = new ModelosManager.CLS.PersonasNombres();

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

        public DocumentosSalidasGuardar(int _pidpersona = 0)
        {
            _clientes = new ModelosManager.CLS.PersonasNombres(_pidpersona);
            InitializeComponent();
            Iniciar();
        }

        public DocumentosSalidasGuardar(ModelosManager.CLS.DocumentosEncabezados _pdoc)
        {
            _documento = _pdoc;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                //_dtclientes = _clientes.TodosClientes();
                //_bsclientes.DataSource = _dtclientes;

                //cbbClientes.DataSource = _bsclientes;
                //cbbClientes.DisplayMember = "NombrePersona";
                //cbbClientes.ValueMember = "IDPersona";
                //cbbClientes.SelectedIndex = 0;

                FormaPago.FormaPago();
                Documento.TipoDocumento();

                if (_documento.Existe)
                {
                    grupoInformacion.Mapear(_documento);
                    grupoCliente.Mapear(_documento);
                }

                if (_clientes.Existe)
                {
                    IDPersona.Text = _clientes.IDPersona.Valor.ToString();
                    NombreTitular.Text = _clientes.NombrePersona.Valor.ToString();
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
                    grupoCliente.Sincronizar(_documento);

                    _documento.Operacion.Valor = "SALIDA";
                    _documento.Estado.Valor = "APLICADO";

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
                if (IDPersona.Text.EsNOE())
                {
                    _seterror.SetError(IDPersona, "No es válido");
                    _errores++;
                }
                if (NombreTitular.Text.EsNOE())
                {
                    _seterror.SetError(NombreTitular, "No es válido");
                    _errores++;
                }
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
