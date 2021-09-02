using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using ModelosManager;

namespace VistasManager.UI
{
    public partial class BuscadorVarios : Estilos.FormDialogos
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        CLS.Enumeraciones.DIALOGO _dialogo = CLS.Enumeraciones.DIALOGO.NINGUNO;
        ModelosManager.CLS.OrdenesPrendas _prendas = new ModelosManager.CLS.OrdenesPrendas();
        ModelosManager.CLS.OrdenesInstituciones _institutos = new ModelosManager.CLS.OrdenesInstituciones();
        ModelosManager.CLS.OrdenesPersonas _personas = new ModelosManager.CLS.OrdenesPersonas();
        ModelosManager.CLS.OrdenesVendedores _vendedores = new ModelosManager.CLS.OrdenesVendedores();

        EntityManager.DataBase _db = new EntityManager.DataBase();

        public ModelosManager.CLS.OrdenesVendedores Vendedores
        {
            get { return _vendedores; }
            set { _vendedores = value; }
        }

        public ModelosManager.CLS.OrdenesPersonas Personas
        {
            get { return _personas; }
            set { _personas = value; }
        }

        public ModelosManager.CLS.OrdenesInstituciones Institutos
        {
            get { return _institutos; }
            set { _institutos = value; }
        }

        public ModelosManager.CLS.OrdenesPrendas Prendas
        {
            get { return _prendas; }
            set { _prendas = value; }
        }

        DataTable _dtdatos = new DataTable();
        BindingSource _bsdatos = new BindingSource();


        public BuscadorVarios(CLS.Enumeraciones.DIALOGO _pdialogo)
        {
            _dialogo = _pdialogo;
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            string _header1 = string.Empty;
            string _header2 = string.Empty;

            try
            {
                if (_dialogo == CLS.Enumeraciones.DIALOGO.TIPO_PRENDA)
                {
                    _dtdatos = _prendas.Todo();
                    _header1 = "IDPrenda";
                    _header2 = "NombrePrenda";
                    this.Text = "BUSCAR PRENDA";
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.INSTITUCION)
                {
                    _dtdatos = _institutos.Todo();
                    _header1 = "IDInstitucion";
                    _header2 = "NombreInstitucion";
                    this.Text = "BUSCAR INSTITUCION";
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE)
                {
                    _dtdatos = _personas.Todo();
                    _header1 = "IDPersona";
                    _header2 = "NombrePersona";
                    this.Text = "BUSCAR COSTURERA/SASTRE";
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.VENDEDOR)
                {
                    _dtdatos = _vendedores.Todo();
                    _header1 = "IDVendedor";
                    _header2 = "NombreVendedor";
                    this.Text = "BUSCAR VENDEDOR";
                }

                _bsdatos.DataSource = _dtdatos;

                dgvDatos.ColumnCount = 2;
                dgvDatos.Columns[0].Name = _header1;
                dgvDatos.Columns[0].DataPropertyName = _header1;
                dgvDatos.Columns[0].Width = 60;
                dgvDatos.Columns[1].Name = _header2;
                dgvDatos.Columns[1].DataPropertyName = _header2;
                dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = _bsdatos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSeleccionar.Text.Equals("Seleccionar"))
                {
                    DataRow _row = dgvDatos.CurrentRow.ToDataRow();
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.TIPO_PRENDA)
                        _prendas = new ModelosManager.CLS.OrdenesPrendas(_row);
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.INSTITUCION)
                        _institutos = new ModelosManager.CLS.OrdenesInstituciones(_row);
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE)
                        _personas = new ModelosManager.CLS.OrdenesPersonas(_row);
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.VENDEDOR)
                        _vendedores = new ModelosManager.CLS.OrdenesVendedores(_row);

                    Close();
                }
                else
                {
                    AgregarNuevoItem();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSeleccionar.PerformClick();
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
                lblBarraEstado.Text = string.Format("{0} registros", _bsdatos.List.Count);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dialogo == CLS.Enumeraciones.DIALOGO.TIPO_PRENDA)
                    _bsdatos.Filter = string.Format("NombrePrenda LIKE '%{0}%'", txbBuscarTexto.Text);
                if (_dialogo == CLS.Enumeraciones.DIALOGO.INSTITUCION)
                    _bsdatos.Filter = string.Format("NombreInstitucion LIKE '%{0}%'", txbBuscarTexto.Text);
                if (_dialogo == CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE)
                    _bsdatos.Filter = string.Format("NombrePersona LIKE '%{0}%'", txbBuscarTexto.Text);
                if (_dialogo == CLS.Enumeraciones.DIALOGO.VENDEDOR)
                    _bsdatos.Filter = string.Format("NombreVendedor LIKE '%{0}%'", txbBuscarTexto.Text);

                if (_bsdatos.List.Count == 0)
                {
                    btnSeleccionar.Image = VistasManager.Properties.Resources.disk;
                    btnSeleccionar.Text = "Agregar";
                }
                else
                {
                    btnSeleccionar.Image = VistasManager.Properties.Resources.add;
                    btnSeleccionar.Text = "Seleccionar";
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void AgregarNuevoItem()
        {
            int _id = 0;

            try
            {
                if (btnSeleccionar.Text.Equals("Agregar"))
                {
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.TIPO_PRENDA)
                    {
                        ModelosManager.CLS.OrdenesPrendas _nuevo = new ModelosManager.CLS.OrdenesPrendas();
                        _nuevo.NombrePrenda.Valor = txbBuscarTexto.Text;
                        _id = _db.Insertar(_nuevo);
                    }
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.INSTITUCION)
                    {
                        ModelosManager.CLS.OrdenesInstituciones _nuevo = new ModelosManager.CLS.OrdenesInstituciones();
                        _nuevo.NombreInstitucion.Valor = txbBuscarTexto.Text;
                        _id = _db.Insertar(_nuevo);
                    }
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE)
                    {
                        ModelosManager.CLS.OrdenesPersonas _nuevo = new ModelosManager.CLS.OrdenesPersonas();
                        _nuevo.NombrePersona.Valor = txbBuscarTexto.Text;
                        _id = _db.Insertar(_nuevo);
                    }
                    if (_dialogo == CLS.Enumeraciones.DIALOGO.VENDEDOR)
                    {
                        ModelosManager.CLS.OrdenesVendedores _nuevo = new ModelosManager.CLS.OrdenesVendedores();
                        _nuevo.NombreVendedor.Valor = txbBuscarTexto.Text;
                        _id = _db.Insertar(_nuevo);
                    }
                }
                if (_id > 0)
                {
                    txbBuscarTexto.Clear();
                    CargarDatos();
                    MessageBox.Show("El registro fué creado satisfactoriamente", "AGREGAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AgregarNuevoItem();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            EntityManager.Entidad _entidad = null;
            bool _ok = false;

            try
            {
                if (_dialogo == CLS.Enumeraciones.DIALOGO.TIPO_PRENDA)
                {
                    _entidad = new ModelosManager.CLS.OrdenesPrendas();
                    _ok = _sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_PRENDA, true);
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.INSTITUCION)
                {
                    _entidad = new ModelosManager.CLS.OrdenesInstituciones();
                    _ok = _sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_INSTITUCION, true);
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE)
                {
                    _entidad = new ModelosManager.CLS.OrdenesPersonas();
                    _ok = _sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_COSTURERA_SASTRE, true);
                }
                if (_dialogo == CLS.Enumeraciones.DIALOGO.VENDEDOR)
                {
                    _entidad = new ModelosManager.CLS.OrdenesVendedores();
                    _ok = _sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_VENDEDOR, true);
                }

                if (_ok)
                    CLS.ExtensionesLocales.EliminarRegistro(dgvDatos, _entidad, CargarDatos);

            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
