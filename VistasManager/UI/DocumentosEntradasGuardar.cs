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
    public partial class DocumentosEntradasGuardar : Estilos.FormEditores
    {
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.PersonasNombres _proveedor = new ModelosManager.CLS.PersonasNombres();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate bool RefresarFormularioExterno(ModelosManager.CLS.DocumentosEncabezados _doc);
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        ErrorProvider _seterror = new ErrorProvider();

        private bool _ok = false;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public DocumentosEntradasGuardar(int _pidpersona = 0)
        {
            _proveedor = new ModelosManager.CLS.PersonasNombres(_pidpersona);
            InitializeComponent();
            Iniciar();
        }

        public DocumentosEntradasGuardar(ModelosManager.CLS.DocumentosEncabezados _pdoc)
        {
            _documento = _pdoc;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                FormaPago.FormaPago();
                Documento.TipoDocumento();

                if (_documento.Existe)
                {
                    _proveedor = new ModelosManager.CLS.PersonasNombres(_documento.IDPersona.Valor.TextoToEntero());
                    grupoInformacion.Mapear(_documento);
                }
                else
                {
                    IDPersona.Text = _proveedor.IDPersona.Valor.ToString();
                    NombreTitular.Text = _proveedor.NombrePersona.Valor.ToString();
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

                    _documento.Operacion.Valor = "ENTRADA";
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
    }
}
