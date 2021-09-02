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
    public partial class ReporteVentasCredito : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        int _periodo = 0;

        public ReporteVentasCredito()
        {
            _periodo = _appcfg.PERIODO.TextoToEntero();
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                cbbEstadoCredito.SelectedIndex = 0;

                dtpFechaInicial.Value = new DateTime(_periodo, 1, 1);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            string _operacion = cbbEstadoCredito.Text;

            try
            {
                _tabla = ModelosManager.CLS.Consultas.ReporteVentasCredito(dtpFechaInicial.Value.FechaParaMySQL(), dtpFechaFinal.Value.FechaParaMySQL(), _operacion);

                VistasManager.REPORTES.VentasCredito _repo = new REPORTES.VentasCredito();
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

        private void btnMostrarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

    }
}
