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
    public partial class CatalogoSubcategorias : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtsubcategorias = new DataTable();
        BindingSource _bssubcategorias = new BindingSource();
        ModelosManager.CLS.ProductoSubcategorias _subcategorias = new ModelosManager.CLS.ProductoSubcategorias();
        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();

        public CatalogoSubcategorias (int _pidcategoria = 0)
        {
            _categorias = new ModelosManager.CLS.ProductoCategorias(_pidcategoria);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtsubcategorias = _subcategorias.ObtenerPorIDCategoria(_categorias.IDCategoria.Valor.TextoToEntero());
                _bssubcategorias.DataSource = _dtsubcategorias;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bssubcategorias;

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
                CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _subcategorias, Iniciar);
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
                _bssubcategorias.Filter = string.Format("NombreSubcategoria LIKE '%{0}%'", txbBuscarTexto.Text);
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
                CatalogoSubcategoriasEditor _editor = new CatalogoSubcategoriasEditor(_categorias.IDCategoria.Valor.TextoToEntero());
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
                CatalogoSubcategoriasEditor _editor = new CatalogoSubcategoriasEditor(_categorias.IDCategoria.Valor.TextoToEntero(), _row["IDSubcategoria"].TextoToEntero());
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
