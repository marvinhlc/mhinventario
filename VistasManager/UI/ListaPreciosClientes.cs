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
    public partial class ListaPreciosClientes : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();

        public ListaPreciosClientes()
        {
            InitializeComponent();
        }

        private void Iniciar()
        {
            try
            {
                if (_cliente.Existe)
                    _dtproductos = _productos.ProductosPorPrecioCliente(_cliente.Precio.Valor.ToString());
                else
                    _dtproductos = _productos.TodoFullBusqueda();

                _bsproductos.DataSource = _dtproductos;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsproductos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsproductos.Filter = string.Format("FullBusqueda LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCatalogo.Notificar(BarraEstado);

                List<DataGridViewRow> _grows = (from item in dgvCatalogo.Rows.Cast<DataGridViewRow>()
                                                where item.Cells["PrecioEditable"].Value.TextoToDouble() > 0
                                                select item).ToList<DataGridViewRow>();
                foreach (DataGridViewRow _row in _grows)
                {
                    _row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    _row.DefaultCellStyle.ForeColor = Color.Black;
                }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCatalogo.DataSource = null;
                BuscadorPersonas _buscador = new BuscadorPersonas(BuscadorPersonas.RolPersona.CLIENTES);
                _buscador.ShowDialog(this);
                if (_buscador.Persona.Existe)
                {
                    _cliente = _buscador.Persona;
                    txbNombreCliente.Text = _cliente.NombrePersona.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void dgvCatalogo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow _row = dgvCatalogo.CurrentRow;
                if (string.IsNullOrEmpty(_row.Cells["PrecioEditable"].Value.ToString()))
                {
                    _row.Cells["PrecioEditable"].Value = _row.Cells["PrecioActual"].Value;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            int _conteo = 0;
           
            try
            {
                if (MessageBox.Show("¿Desea procesar los cambios?", "GUARDAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                BarraProgreso.Visible = true;
                BarraProgreso.Value = 0;
                lblTasa.Visible = true;
                lblTasa.Text = "0%";

                EntityManager.Transaccion _transa = new EntityManager.Transaccion();
                _transa.doRefrescarFormularioExterno += MostrarProgreso;

                StringBuilder _sqls = new StringBuilder();
                string _sql = string.Empty;
                if (_cliente.Precio.Valor.ToString().Equals("PRECIO 1"))
                {
                    _sql = @"UPDATE producto_nombres
	                           SET	Precio1        = {0}
	                           WHERE IDProducto    = {1};";
                }
                else
                {
                    if (_cliente.Precio.Valor.ToString().Equals("PRECIO 2"))
                    {
                        _sql = @"UPDATE producto_nombres
	                               SET	Precio2        = {0}
	                               WHERE IDProducto    = {1};";
                    }
                    else
                    {
                        if (_cliente.Precio.Valor.ToString().Equals("PRECIO 3"))
                        {
                            _sql = @"UPDATE producto_nombres
	                                   SET	Precio3        = {0}
	                                   WHERE IDProducto    = {1};";
                        }
                        else
                        {
                            _sql = @"UPDATE producto_nombres
	                                   SET	Precio4        = {0}
	                                   WHERE IDProducto    = {1};";
                        }
                    }
                }

                DataTable _cambios = _dtproductos.GetChanges();

                if (_cambios != null)
                {
                    foreach (DataRow _row in _cambios.Rows)
                    {
                        _sqls.AppendFormat(_sql,
                                            _row["PrecioEditable"],
                                            _row["IDProducto"]);

                        _transa.AnexarPreSql(_sqls.ToString());
                        _conteo++;
                    }

                    if (_transa.Procesar() > 0)
                    {
                        MessageBox.Show("Cambios se han guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No hay cambios para guardar.", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                BarraProgreso.Visible = false;
                lblTasa.Visible = false;
            }
        }

        private void MostrarProgreso(int _tasa)
        {
            BarraProgreso.Value = _tasa;
            lblTasa.Text = string.Format("{0}%", _tasa);
            Refresh();
        }
    }
}
