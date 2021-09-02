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
    public partial class ReporteClientesProveedores : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        int _periodo = 0;

        public ReporteClientesProveedores()
        {
            InitializeComponent();
            cbbPersonas.SelectedIndex = 0;
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            string _tipo = "COMBINADO";

            try
            {
                ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();

                if (cbbPersonas.Text.Equals("COMBINADO"))
                {
                    _tabla = _personas.Todo();
                }
                if (cbbPersonas.Text.Equals("CLIENTES"))
                {
                    _tabla = _personas.TodosClientes();
                }
                if (cbbPersonas.Text.Equals("PROVEEDORES"))
                {
                    _tabla = _personas.TodosProveedores();
                }

                if (_tabla.Rows.Count > 0)
                {
                    VistasManager.REPORTES.ClientesProveedores _repo = new REPORTES.ClientesProveedores();
                    _repo.SetDataSource(_tabla);

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
