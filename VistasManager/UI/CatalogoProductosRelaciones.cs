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

namespace VistasManager.UI
{
    public partial class CatalogoProductosRelaciones : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.PersonasNombres _proveedores = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.ProductoProveedores _relacion = new ModelosManager.CLS.ProductoProveedores();

        DataTable _dtproveedores = new DataTable();
        BindingSource _bsproveedores = new BindingSource();
        DataTable _dtrelaciones = new DataTable();
        BindingSource _bsrelaciones = new BindingSource();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoProductosRelaciones(int _pid = 0)
        {
            _producto = new ModelosManager.CLS.ProductoNombres(_pid);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                txbIDProdcuto.Text = _producto.IDProducto.Valor.ToString();
                txbNombreProducto.Text = _producto.NombreProducto.Valor.ToString();

                _dtproveedores = _proveedores.TodosProveedores();
                _bsproveedores.DataSource = _dtproveedores;

                cbbProveedores.ComboBox.DisplayMember = "NombrePersona";
                cbbProveedores.ComboBox.ValueMember = "IDPersona";
                cbbProveedores.ComboBox.DataSource = _bsproveedores;
                cbbProveedores.ComboBox.SelectedIndex = 0;

                _dtrelaciones = ModelosManager.CLS.Consultas.ProveedoresRalacionadosConProductos(_producto.IDProducto.Valor.TextoToEntero());
                _bsrelaciones.DataSource = _dtrelaciones;
                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsrelaciones;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _relacion, Iniciar);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Guardar()
        {
            try
            {
                _relacion = new ModelosManager.CLS.ProductoProveedores();
                _relacion.IDProducto.Valor = txbIDProdcuto.Text.TextoToEntero();
                _relacion.IDPersona.Valor = cbbProveedores.ComboBox.SelectedValue.TextoToEntero();

                if (_bd.Insertar(_relacion) > 0)
                {
                    Iniciar();
                    this.Notificar(Extensiones._NOTIFICADORES.REGISTRO_GUARDADO);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCatalogo.Notificar(BarraEstado);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
