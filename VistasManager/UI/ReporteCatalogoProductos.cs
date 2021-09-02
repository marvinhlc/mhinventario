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
    public partial class ReporteCatalogoProductos : Estilos.FormEditores
    {
        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();
        ModelosManager.CLS.ProductoSubcategorias _subcategorias = new ModelosManager.CLS.ProductoSubcategorias();

        DataTable _dtcategorias = new DataTable();
        DataTable _dtsubcategorias = new DataTable();
        BindingSource _bssubcategorias = new BindingSource();

        public ReporteCatalogoProductos()
        {
            InitializeComponent();
            Datos();
        }

        private void Datos()
        {
            try
            {
                _dtcategorias = _categorias.Todo();
                _dtsubcategorias = _subcategorias.Todo();
                _bssubcategorias.DataSource = _dtsubcategorias;

                cbbCategoria.DataSource = _dtcategorias;
                cbbCategoria.DisplayMember = "NombreCategoria";
                cbbCategoria.ValueMember = "IDCategoria";
                cbbCategoria.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarCategoria_CheckedChanged(object sender, EventArgs e)
        {
            cbbCategoria.Enabled = ckbActivarCategoria.Checked;
            cbbCategoria.Focus();
        }

        private void ckbActivarSubcategoria_CheckedChanged(object sender, EventArgs e)
        {
            cbbSubcategoria.Enabled = ckbActivarSubcategoria.Checked;
            cbbSubcategoria.Focus();
        }

        private void cbbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _bssubcategorias.Filter = string.Format("NombreCategoria = '{0}'", cbbCategoria.Text);

                cbbSubcategoria.DataSource = _bssubcategorias;
                cbbSubcategoria.DisplayMember = "NombreSubcategoria";
                cbbSubcategoria.ValueMember = "IDSubcategoria";
                cbbSubcategoria.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            string _categoria = "TODO";
            string _subcategoria = "TODO";

            try
            {
                if (ckbActivarCategoria.Checked)
                {
                    _categoria = cbbCategoria.Text;
                }
                if (ckbActivarSubcategoria.Checked)
                {
                    _subcategoria = cbbSubcategoria.Text;
                }

                _tabla = ModelosManager.CLS.Consultas.CatalogoProductos(_categoria, _subcategoria);

                VistasManager.REPORTES.CatalogoProductos _repo = new REPORTES.CatalogoProductos();
                _repo.SetDataSource(_tabla);

                if (_pformato == "VP")
                {
                    VistaPrevia _vp = new VistaPrevia(_repo);
                    _vp.MdiParent = this.MdiParent;
                    _vp.Show();
                }
                if (_pformato == "XLS")
                {
                    _repo.ToExcel(this);
                }
                if (_pformato == "PDF")
                {
                    _repo.ToPDF(this);
                }
                if (_pformato == "PRINT")
                {
                    _repo.PrintToPrinter(0, false, 1, 0);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            GenerarReporte("XLS");
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            GenerarReporte("PDF");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarReporte("PRINT");
        }
    }
}
