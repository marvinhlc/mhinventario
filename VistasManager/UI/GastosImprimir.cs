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
    public partial class GastosImprimir : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();
        int _periodo = 0;

        ModelosManager.CLS.GastosClasificaciones _clasificaciones = new ModelosManager.CLS.GastosClasificaciones();
        DataTable _dtclasificaciones = new DataTable();
        BindingSource _bsclasificaciones = new BindingSource();

        public GastosImprimir()
        {
            _periodo = _appcfg.PERIODO.TextoToEntero();
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtclasificaciones = _clasificaciones.Todo();
                _bsclasificaciones.DataSource = _dtclasificaciones;
                cbbClasificaciones.DisplayMember = "Descripcion";
                cbbClasificaciones.ValueMember = "Descripcion";
                cbbClasificaciones.DataSource = _bsclasificaciones;
                cbbClasificaciones.SelectedIndex = 0;

                cbbReportes.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarEstado_CheckedChanged(object sender, EventArgs e)
        {
            cbbClasificaciones.Enabled = ckbActivarEstado.Checked;
            cbbClasificaciones.Focus();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            string _clasificaciones = string.Empty;
            CrystalDecisions.CrystalReports.Engine.ReportClass _repo = new CrystalDecisions.CrystalReports.Engine.ReportClass();

            try
            {
                if (ckbActivarEstado.Checked)
                {
                    _clasificaciones = cbbClasificaciones.Text;
                }

                if (cbbReportes.Text.Equals("RESUMEN DE GASTOS"))
                {
                    _repo = new REPORTES.GastosResumen();
                    _tabla = ModelosManager.CLS.Consultas.ReporteGastosResumen(
                                       dtpFechaInicial.Value.FechaParaMySQL(),
                                       dtpFechaFinal.Value.FechaParaMySQL(),
                                       _clasificaciones
                                   );
                }
                if (cbbReportes.Text.Equals("GASTOS DETALLADO"))
                {
                    _repo = new REPORTES.GastosDetallado();
                    _tabla = ModelosManager.CLS.Consultas.ReporteGastosDetallado(
                                       dtpFechaInicial.Value.FechaParaMySQL(),
                                       dtpFechaFinal.Value.FechaParaMySQL(),
                                       _clasificaciones
                                   );
                }

                if (_tabla != null && _tabla.Rows.Count >= 0)
                {
                    _repo.SetDataSource(_tabla);
                    _repo.SetParameterValue("pFechaInicio", dtpFechaInicial.Value.FechaParaMySQL());
                    _repo.SetParameterValue("pFechaFinal", dtpFechaFinal.Value.FechaParaMySQL());
                    _repo.SetParameterValue("pClasifiacion", _clasificaciones);

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
                else
                {
                    MessageBox.Show("No hay datos para mostrar en el reporte", "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
