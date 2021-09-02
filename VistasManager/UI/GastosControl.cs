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
    public partial class GastosControl : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtgastos = new DataTable();
        BindingSource _bsgastos = new BindingSource();

        ModelosManager.CLS.Gastos _gastos = new ModelosManager.CLS.Gastos();
        ModelosManager.CLS.GastosClasificaciones _clasificaciones = new ModelosManager.CLS.GastosClasificaciones();
        DataTable _dtclasificaciones = new DataTable();
        BindingSource _bsclasificaciones = new BindingSource();

        int _periodo = 0;

        public GastosControl()
        {
            InitializeComponent();
            _periodo = _sesion.CONFIGAPP.PERIODO;

            //DateTimePicker _dtpiker = new DateTimePicker();
            //_dtpiker.Format = DateTimePickerFormat.Short;
            //_dtpiker.Size = new Size(100, 29);
            //var _picker = new ToolStripControlHost(_dtpiker);
            //toolStrip1.Items.Add(_picker);

            _dtclasificaciones = _clasificaciones.Todo();
            _bsclasificaciones.DataSource = _dtclasificaciones;
            cbbClasificaciones.DisplayMember = "Descripcion";
            cbbClasificaciones.ValueMember = "Descripcion";
            cbbClasificaciones.DataSource = _bsclasificaciones;
            cbbClasificaciones.SelectedIndex = 0;

            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtgastos = _gastos.Todo(_periodo);
                _bsgastos.DataSource = _dtgastos;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsgastos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _sumas = 0;
            try
            {
                dgvCatalogo.Notificar(BarraEstado);
                foreach (DataGridViewRow _grow in dgvCatalogo.Rows)
                {
                    DataRow _row = _grow.ToDataRow();
                    _sumas = _sumas + (_row["Importe"].ToDouble());
                }
                lblSumas.Text = string.Format("Sumas: {0:C2}", _sumas);
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

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsgastos.Filter = string.Format(
                    "Descripcion LIKE '%{0}%' OR Numero LIKE '%{0}%' OR Clasificacion LIKE '%{0}%'", 
                    txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.GASTOS_ELIMINAR, true))
                {
                    ModelosManager.CLS.Gastos _gasto = new ModelosManager.CLS.Gastos();
                    CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _gastos, Iniciar);
                }
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
                VistasManager.UI.GastosControlEditor _editor = new GastosControlEditor(_row);
                _editor.doUpdateExterno += ActualizarRegistro;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ActualizarRegistro(ModelosManager.CLS.Gastos _registro)
        {
            try
            {
                if (_bd.Actualizar(_registro) > 0)
                {
                    Iniciar();
                    MessageBox.Show("Registro fué guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No se puedo guardar el registro", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                VistasManager.UI.GastosControlEditor _editor = new GastosControlEditor();
                _editor.doInsertExterno += AgregarRegistro;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void AgregarRegistro(ModelosManager.CLS.Gastos _nuevo)
        {
            try
            {
                if (_bd.Insertar(_nuevo) > 0)
                {
                    _nuevo.IDGasto.Valor = _bd.UltimoID;
                    Iniciar();
                    MessageBox.Show("Registro fué guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No se puedo guardar el registro", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarClasificaciones_CheckedChanged(object sender, EventArgs e)
        {
            cbbClasificaciones.Enabled = ckbActivarClasificaciones.Checked;
            cbbClasificaciones.Focus();
        }

        private void ckbActivarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaInicial.Enabled = ckbActivarFechas.Checked;
            dtpFechaFinal.Enabled = ckbActivarFechas.Checked;
            dtpFechaInicial.Focus();
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            StringBuilder _filtro = new StringBuilder();

            try
            {
                _filtro.Append("IDGasto > 0");
                if (ckbActivarFechas.Checked)
                {
                    _filtro.AppendFormat(" AND (Fecha >= '{0}' AND Fecha <= '{1}')", 
                        dtpFechaInicial.Value.FechaParaMySQL(),
                        dtpFechaFinal.Value.FechaParaMySQL());
                }
                if (ckbActivarClasificaciones.Checked)
                {
                    _filtro.AppendFormat(" AND Clasificacion = '{0}'", cbbClasificaciones.Text);
                }

                if (_filtro.ToString().EsNOE())
                    _bsgastos.RemoveFilter();
                else
                    _bsgastos.Filter = _filtro.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                GastosImprimir _repos = new GastosImprimir();
                _repos.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
