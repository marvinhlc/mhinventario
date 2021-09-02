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
    public partial class CorteCajaAdmin :  Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _configapp = new Sesion.CLS.ConfigApp();
        ModelosManager.CLS.CorteCaja _corte = new ModelosManager.CLS.CorteCaja();
        DataTable _tabla = new DataTable();

        public CorteCajaAdmin()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            txbEstacionCaja.Text = _configapp.ESTACION_ID.ToString();
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinal.Value = dtpFechaInicial.UltimoDiaMes();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            try
            {
                _tabla = _corte.ObtenerCorteCaja(txbEstacionCaja.Text, dtpFechaInicial.Value.FechaParaMySQL(), dtpFechaFinal.Value.FechaParaMySQL());
                REPORTES.CorteCaja _repo = new REPORTES.CorteCaja();
                _repo.SetDataSource(_tabla);

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
                if (_pformato == "VP")
                {
                    VistaPrevia _vp = new VistaPrevia(_repo);
                    _vp.ShowDialog(this);
                }
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
