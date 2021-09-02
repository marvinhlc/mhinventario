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
    public partial class InventarioExistencias : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();

        DataTable _dtexistencia = new DataTable();
        BindingSource _bsexistencia = new BindingSource();
        DataTable _dtproveedores = new DataTable();
        BindingSource _bsproveedores = new BindingSource();

        int _periodo = 0;

        public InventarioExistencias()
        {
            _periodo = _appcfg.PERIODO.TextoToEntero();
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtproveedores = _personas.TodosProveedores();
                _bsproveedores.DataSource = _dtproveedores;

                cbbProveedores.ComboBox.DataSource = _bsproveedores;
                cbbProveedores.ComboBox.DisplayMember = "NombrePersona";
                cbbProveedores.ComboBox.ValueMember = "IDPersona";
                cbbProveedores.ComboBox.SelectedIndex = 0;

                dtpFechaInicial.Value = new DateTime(_periodo, 1, 1);

                FiltrarPorProveedor();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void FiltrarPorProveedor(int _pidproveedor = 0)
        {
            try
            {
                bool _pendientes = ckbPendientes.Checked;
                _dtexistencia = ModelosManager.CLS.Consultas.ReporteExistencias(dtpFechaInicial.Value.FechaParaMySQL(), dtpFechaFinal.Value.FechaParaMySQL(), _pidproveedor, _pendientes);
                _bsexistencia.DataSource = _dtexistencia;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsexistencia;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            FiltrarPorProveedor();
        }

        private void cbbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPorProveedor(cbbProveedores.ComboBox.SelectedValue.TextoToEntero());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _total = 0;
            try
            {
                List<DataGridViewRow> _grows = (from item in dgvCatalogo.Rows.Cast<DataGridViewRow>()
                                                where Convert.ToDouble(item.Cells["Entradas"].Value) > 0 || Convert.ToDouble(item.Cells["Salidas"].Value) > 0
                                                select item).ToList<DataGridViewRow>();
                foreach (DataGridViewRow _row in _grows)
                {
                    //_row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    //_row.DefaultCellStyle.ForeColor = Color.Black;

                    _total += _row.Cells["TotalInventario"].Value.TextoToDouble();
                }

                dgvCatalogo.Notificar(BarraEstado);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                BarraEstado.Items["lblTotalDocumento"].Text = string.Format("Total ${0:N2}", _total);
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsexistencia.Filter = string.Format("FullBusqueda LIKE '%{0}%'", txbBuscarTexto.Text);
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
                GenerarReporte(CLS.Enumeraciones.EXPORTAR.RPT);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void GenerarReporte(CLS.Enumeraciones.EXPORTAR _exportar)
        {
            try
            {
                string _rangofecha = string.Format("{0} Y {1}", dtpFechaInicial.Value.FechaParaMySQL(), dtpFechaFinal.Value.FechaParaMySQL());
                _dtexistencia.TableName = "tabla";
                REPORTES.Existencias _repo = new REPORTES.Existencias();
                _repo.SetDataSource(_dtexistencia);
                _repo.SetParameterValue("pPeriodo", _rangofecha);

                if (_exportar == CLS.Enumeraciones.EXPORTAR.RPT)
                {
                    UI.VistaPrevia _vp = new VistaPrevia(_repo);
                    _vp.Show();
                }
                else
                {
                    if (_exportar == CLS.Enumeraciones.EXPORTAR.EXCEL)
                    {
                        _repo.ToExcel(this);
                    }
                    if (_exportar == CLS.Enumeraciones.EXPORTAR.PDF)
                    {
                        _repo.ToPDF(this);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarPorProveedor();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FiltrarPorProveedor();
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            GenerarReporte(CLS.Enumeraciones.EXPORTAR.EXCEL);
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            GenerarReporte(CLS.Enumeraciones.EXPORTAR.PDF);
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            FiltrarPorProveedor(cbbProveedores.ComboBox.SelectedValue.TextoToEntero());
        }
    }
}
