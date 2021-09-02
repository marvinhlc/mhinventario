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
    public partial class DocumentosInventarioGuardar : Estilos.FormEditores
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

        public DocumentosInventarioGuardar(int _piddocumento = 0)
        {
            _documento = new ModelosManager.CLS.DocumentosEncabezados(_piddocumento);
            InitializeComponent();
            Iniciar();
        }

        public DocumentosInventarioGuardar(ModelosManager.CLS.DocumentosEncabezados _pdoc)
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
                    grupoInformacion.Mapear(_documento);
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

                    _documento.IDPersona.Valor = 0;
                    _documento.NombreTitular.Valor = string.Empty;
                    _documento.FormaPago.Valor = "N/A";
                    _documento.DiasPlazo.Valor = 0;
                    _documento.Operacion.Valor = "INVENTARIO";
                    _documento.Documento.Valor = "N/A";
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
