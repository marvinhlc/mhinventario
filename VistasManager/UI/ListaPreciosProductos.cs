using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using System.Collections;

namespace VistasManager.UI
{
    public partial class ListaPreciosProductos : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();

        public ListaPreciosProductos()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
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
                                                where Convert.ToBoolean(item.Cells["Editada"].Value) == true
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

        private void dgvCatalogo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridViewRow _row = dgvCatalogo.CurrentRow;
                //int _id = Convert.ToInt32(_row.Cells["IDProducto"].Value);

                //DataRow _resulta = _dtproductos.Select(string.Format("IDProducto = {0}", _id)).FirstOrDefault();

                //IEnumerable _resultado = from _item in _dtproductos.AsEnumerable()
                //                 where _item.Field<Int32>("IDProducto") == _id
                //                 select _item;
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
            //int _total = 0;
            //int _tasa = 0;

            try
            {
                if (MessageBox.Show("¿Desea procesar los cambios?", "GUARDAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                BarraProgreso.Visible = true;
                BarraProgreso.Value = 0;
                lblTasa.Visible = true;
                lblTasa.Text = "0%";

                //_total = _dtproductos.Rows.Count;
                
                EntityManager.Transaccion _transa = new EntityManager.Transaccion();
                _transa.doRefrescarFormularioExterno += MostrarProgreso;

                StringBuilder _sqls = new StringBuilder();
                string _sql = @"UPDATE producto_nombres
	                            SET	PrecioVenta     = {0},
			                            Precio1		= {1},
			                            Precio2		= {2},
			                            Precio3		= {3},
			                            Precio4		= {4}
	                            WHERE IDProducto    = {5};";

                var _cambios = _dtproductos.GetChanges();

                foreach (DataRow _row in _cambios.Rows)
                {
                    _sqls.AppendFormat(_sql, 
                                        _row["PrecioVenta"], 
                                        _row["Precio1"], 
                                        _row["Precio2"], 
                                        _row["Precio3"], 
                                        _row["Precio4"], 
                                        _row["IDProducto"]);
                    _transa.AnexarPreSql(_sqls.ToString());
                    _conteo++;

                    //_tasa = (_conteo * 100) / _total;
                }

                if (_transa.Procesar() > 0)
                {
                    MessageBox.Show("Cambios se han guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
