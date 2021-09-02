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
    public partial class CatalogoProductos : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();

        public CatalogoProductos()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtproductos = _productos.TodoFullBusqueda();
                _bsproductos.DataSource = _dtproductos;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsproductos;
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
                _bsproductos.Filter = string.Format("FullBusqueda LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _productos, Iniciar);
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

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                UI.CatalogoProductosEditor _editor = new CatalogoProductosEditor();
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                UI.CatalogoProductosEditor _editor = new CatalogoProductosEditor(_row["IDProducto"].TextoToEntero());
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRelaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_RELACIONES_PRODUCTOS_PROVEEDORES, true))
                {
                    DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                    UI.CatalogoProductosRelaciones _relaciones = new CatalogoProductosRelaciones(_row["IDProducto"].TextoToEntero());
                    _relaciones.doRefrescarFormularioExterno += Iniciar;
                    _relaciones.ShowDialog(this);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.PRODUCTOS_ESCALA_PRECIOS, true))
                {
                    DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                    UI.CatalogoProductosPrecios _precios = new CatalogoProductosPrecios(_row["IDProducto"].TextoToEntero());
                    _precios.doRefrescarFormularioExterno += Iniciar;
                    _precios.ShowDialog(this);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
