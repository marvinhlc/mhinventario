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
    public partial class CatalogoCategorias : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtcategorias = new DataTable();
        BindingSource _bscategorias = new BindingSource();
        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();

        public CatalogoCategorias()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtcategorias = _categorias.Todo("NombreCategoria");
                _bscategorias.DataSource = _dtcategorias;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bscategorias;

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _categorias, Iniciar);
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
                _bscategorias.Filter = string.Format("NombreCategoria LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoCategoriasEditor _editor = new CatalogoCategoriasEditor();
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
                CatalogoCategoriasEditor _editor = new CatalogoCategoriasEditor(_row["IDCategoria"].TextoToEntero());
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
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
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_SUBCATEGORIAS, true))
                {
                    DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                    CatalogoSubcategorias _subc = new CatalogoSubcategorias(Convert.ToInt32(_row["IDCategoria"]));
                    _subc.ShowDialog(this);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
