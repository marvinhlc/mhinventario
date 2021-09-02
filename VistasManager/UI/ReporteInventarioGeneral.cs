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
    public partial class ReporteInventarioGeneral : Estilos.FormDialogos
    {
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        DataTable _dtbodega = new DataTable();

        public ReporteInventarioGeneral()
        {
            InitializeComponent();
            Datos();
            Iniciar();
        }

        private void Datos()
        {
            try
            {
                _dtbodega = _bodega.Todo();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Iniciar()
        {
            try
            {
                cbbBodegas.DataSource = _dtbodega;
                cbbBodegas.DisplayMember = "NombreBodega";
                cbbBodegas.ValueMember = "IDBodega";
                cbbBodegas.SelectedIndex = 0;

                cbbBodegas.Enabled = false;
                dtpFechaInicial.Enabled = false;
                dtpFechaFinal.Enabled = false;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarBodegas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbbBodegas.Enabled = ckbActivarBodegas.Checked;
                cbbBodegas.Focus();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarFechas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFechaInicial.Enabled = ckbActivarFechas.Checked;
                dtpFechaFinal.Enabled = ckbActivarFechas.Checked;
                dtpFechaInicial.Focus();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinal.Value = dtpFechaInicial.UltimoDiaMes();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            int _idbodega = 0;
            string _fechaini = string.Empty;
            string _fechafin = string.Empty;

            try
            {
                if (ckbActivarBodegas.Checked)
                    _idbodega = cbbBodegas.SelectedValue.TextoToEntero();

                if (ckbActivarFechas.Checked)
                {
                    _fechaini = dtpFechaInicial.Value.FechaParaMySQL();
                    _fechafin = dtpFechaFinal.Value.FechaParaMySQL();
                }
                else
                {
                    dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, 1, 1);
                    dtpFechaFinal.Value = DateTime.Now;
                    _fechaini = dtpFechaInicial.Value.FechaParaMySQL();
                    _fechafin = dtpFechaFinal.Value.FechaParaMySQL();
                }

                _tabla = _productos.InventarioGeneral(_idbodega, _fechaini, _fechafin);

                if (_tabla.Rows.Count > 0)
                {
                    VistasManager.REPORTES.InventarioGeneral _repo = new REPORTES.InventarioGeneral();
                    _repo.SetDataSource(_tabla);
                    _repo.SetParameterValue("pFechaInicio", dtpFechaInicial.FechaFormatoLocal());
                    _repo.SetParameterValue("pFechaFinal", dtpFechaFinal.FechaFormatoLocal());

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
