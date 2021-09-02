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
    public partial class ReporteDocumentoSalidas : Estilos.FormEditores
    {

        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();

        DataTable _dtproveedores = new DataTable();
        BindingSource _bsproveedores = new BindingSource();

        int _periodo = 0;

        public ReporteDocumentoSalidas()
        {
            _periodo = _appcfg.PERIODO.TextoToEntero();
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtproveedores = _personas.TodosClientes();
                _bsproveedores.DataSource = _dtproveedores;

                cbbProveedores.DataSource = _bsproveedores;
                cbbProveedores.DisplayMember = "NombrePersona";
                cbbProveedores.ValueMember = "IDPersona";
                cbbProveedores.SelectedIndex = 0;

                cbbTipoDocumento.TipoDocumento();
                cbbReporte.SelectedIndex = 0;

                dtpFechaInicial.Value = new DateTime(_periodo, 1, 1);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarProveedores_CheckedChanged(object sender, EventArgs e)
        {
            cbbProveedores.Enabled = ckbActivarProveedores.Checked;
            cbbProveedores.Focus();
        }

        private void ckbActivarTipo_CheckedChanged(object sender, EventArgs e)
        {
            cbbTipoDocumento.Enabled = ckbActivarTipo.Checked;
            cbbTipoDocumento.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte(string _pformato = "VP")
        {
            DataTable _tabla = new DataTable();
            int _idproveedor = 0;
            string _tipo = "TODO";
            string _operacion = cbbReporte.Text;

            try
            {
                if (ckbActivarProveedores.Checked)
                {
                    _idproveedor = cbbProveedores.SelectedValue.TextoToEntero();
                }
                if (ckbActivarTipo.Checked)
                {
                    _tipo = cbbTipoDocumento.Text;
                }

                _tabla = ModelosManager.CLS.Consultas.ReporteDocumentosEntradaSalida(dtpFechaInicial.Value.FechaParaMySQL(), dtpFechaFinal.Value.FechaParaMySQL(), _idproveedor, _tipo, _operacion);

                VistasManager.REPORTES.DocumentosSalidas _repo = new REPORTES.DocumentosSalidas();
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
    }
}
