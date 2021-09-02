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
using VistasManager.CLS;

namespace VistasManager.UI
{
    public partial class DocumentosComprasGuardar : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new DataBase();
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.PersonasNombres _proveedor = new ModelosManager.CLS.PersonasNombres();

        //DELEGADO PARA OPERACIONES EXTERNAS
        //public delegate bool RefresarFormularioExterno(ModelosManager.CLS.DocumentosEncabezados _doc);
        //public event RefresarFormularioExterno doRefrescarFormularioExterno;

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        ErrorProvider _seterror = new ErrorProvider();

        DataTable _dtpersonas = new DataTable();
        BindingSource _bspersonas = new BindingSource();

        private bool _ok = false;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public DocumentosComprasGuardar(int _pidpersona = 0)
        {
            _proveedor = new ModelosManager.CLS.PersonasNombres(_pidpersona);
            InitializeComponent();
            Iniciar();
        }

        public DocumentosComprasGuardar(ModelosManager.CLS.DocumentosEncabezados _pdoc)
        {
            _documento = _pdoc;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtpersonas = _proveedor.TodosProveedores();
                _bspersonas.DataSource = _dtpersonas;

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

        private void RefrescarFormularioPrincipal()
        {
            if (doRefrescarFormularioExterno != null)
                doRefrescarFormularioExterno();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool _abrireditor = false;
            try
            {
                if (Validaciones())
                {
                    grupoInformacion.Sincronizar(_documento);

                    _documento.Operacion.Valor = "COMPRA";
                    _documento.Estado.Valor = "APLICADO";

                    if (_documento.Existe)
                    {
                        _bd.Actualizar(_documento);
                        _abrireditor = false;
                    }
                    else
                    {
                        _abrireditor = (_bd.Insertar(_documento) > 0);
                        _documento.IDDocumento.Valor = _bd.UltimoID;
                    }

                    if (doRefrescarFormularioExterno != null)
                        doRefrescarFormularioExterno();

                    if (_abrireditor)
                    {
                        DocumentosComprasEditor _editor = new DocumentosComprasEditor(_documento.IDDocumento.Valor.TextoToEntero());
                        _editor.doRefrescarFormularioExterno += RefrescarFormularioPrincipal;
                        _editor.ShowDialog(this);
                    }

                    Close();
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

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            btnBuscarProveedores.BuscadorProveedores(this, ObtenerIDProveedor);
        }

        private void ObtenerIDProveedor(ModelosManager.CLS.PersonasNombres _ppersona)
        {
            if (_ppersona.Existe)
            {
                IDPersona.Text = _ppersona.IDPersona.Valor.ToString();
                NombreTitular.Text = _ppersona.NombrePersona.Valor.ToString();
                FechaDocumento.Focus();
            }
        }

        private void FechaDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                IDDocumento.Focus();
        }

        private void NumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FormaPago.Focus();
        }

        private void FormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DiasPlazo.Focus();
        }

        private void DiasPlazo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Documento.Focus();
        }

        private void Documento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Comentario.Focus();
        }

        private void FormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormaPago.Text.Equals("CONTADO") || FormaPago.Text.Equals("N/A"))
            {
                DiasPlazo.Value = 0;
                DiasPlazo.Enabled = false;
            }
            else
            {
                DiasPlazo.Value = 0;
                DiasPlazo.Enabled = true;
            }
        }

        private void IDPersona_TextChanged(object sender, EventArgs e)
        {
            BuscarPersona();
        }

        private void IDPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarPersona();
        }

        private void BuscarPersona()
        {
            try
            {
                NombreTitular.Clear();
                if (IDPersona.Text.NoNOE())
                {
                    _bspersonas.Filter = string.Format("FullBuscar LIKE '%{0}%'", IDPersona.Text);
                    DataRowView _row = _bspersonas.Current as DataRowView;
                    NombreTitular.Text = _row["NombrePersona"].ToString();
                }
            }
            catch (Exception _err)
            {
                NombreTitular.Clear();
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
