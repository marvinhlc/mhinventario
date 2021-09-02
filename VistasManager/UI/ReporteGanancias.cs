using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class ReporteGanancias : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();
        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();
        ModelosManager.CLS.ProductoSubcategorias _subcategorias = new ModelosManager.CLS.ProductoSubcategorias();
        int _periodo = 0;

        DataTable _dtcategeria = new DataTable();
        DataTable _dtsubcategoria = new DataTable();
        BindingSource _bssubcategoria = new BindingSource();

        public ReporteGanancias()
        {
            _periodo = _appcfg.PERIODO.TextoToEntero();
            InitializeComponent();

            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                dtpFechaInicial.Value = new DateTime(_periodo, 1, 1);

                _dtcategeria = _categorias.Todo();
                _dtsubcategoria = _subcategorias.Todo();
                _bssubcategoria.DataSource = _dtsubcategoria;

                cbbCategoria.DisplayMember = "NombreCategoria";
                cbbCategoria.ValueMember = "IDCategoria";
                cbbCategoria.DataSource = _dtcategeria;
                cbbCategoria.SelectedIndex = 0;

                cbbSubCategoria.DisplayMember = "NombreSubCategoria";
                cbbSubCategoria.ValueMember = "IDSubcategoria";
                cbbSubCategoria.DataSource = _bssubcategoria;
                cbbSubCategoria.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            string _psubcategoria = string.Empty;
            string _pcategoria = string.Empty;

            try
            {
                if (ckbActivarCategoria.Checked)
                {
                    _pcategoria = cbbCategoria.Text;
                    _psubcategoria = cbbSubCategoria.Text;
                }

                _tabla = ModelosManager.CLS.Consultas.ReporteGanancias(
                    dtpFechaInicial.Value.FechaParaMySQL(), 
                    dtpFechaFinal.Value.FechaParaMySQL(),
                    _pcategoria,
                    _psubcategoria
                );

                VistasManager.REPORTES.Ganancias _repo = new REPORTES.Ganancias();
                _repo.SetDataSource(_tabla);
                _repo.SetParameterValue("pFechaInicio", dtpFechaInicial.Value.FechaParaMySQL());
                _repo.SetParameterValue("pFechaFinal", dtpFechaFinal.Value.FechaParaMySQL());

                if (_pformato == "VP")
                {
                    VistaPrevia _vp = new VistaPrevia(_repo);
                    _vp.ShowDialog(this);
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

        private void ckbActivarCategoria_CheckedChanged(object sender, EventArgs e)
        {
            cbbCategoria.Enabled = ckbActivarCategoria.Checked;
            cbbCategoria.Focus();
            cbbSubCategoria.Enabled = ckbActivarCategoria.Checked;
        }

        private void cbbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _bssubcategoria.Filter = string.Format("NombreCategoria = '{0}'", cbbCategoria.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
