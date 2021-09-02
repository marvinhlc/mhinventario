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
    public partial class DocumentosInventarioEditor : Estilos.FormMantenimiento
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.BodegasNombres _bodegas = new ModelosManager.CLS.BodegasNombres();

        DataTable _dtproveedores = new DataTable();
        BindingSource _bsproveedores = new BindingSource();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        DataTable _dtbodegas = new DataTable();
        BindingSource _bsbodegas = new BindingSource();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public DocumentosInventarioEditor(int _iddocumento = 0)
        {
            _documento = new ModelosManager.CLS.DocumentosEncabezados(_iddocumento);
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

                _dtbodegas = _bodegas.Todo();
                _bsbodegas.DataSource = _dtbodegas;

                cbbBodegas.ComboBox.DataSource = _bsbodegas;
                cbbBodegas.ComboBox.DisplayMember = "NombreBodega";
                cbbBodegas.ComboBox.ValueMember = "IDBodega";
                cbbBodegas.ComboBox.SelectedIndex = 0;

                CargarCatalogoProductos();

                if (_documento.Existe)
                {
                    //cbbProveedores.ComboBox.SelectedValue = _documento.IDPersona.Valor.TextoToEntero();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void CargarCatalogoProductos()
        {
            try
            {
                int _idpersona = 0;
                //_idpersona = cbbProveedores.ComboBox.SelectedValue.TextoToEntero();
                _dtproductos = ModelosManager.CLS.Consultas.HojaEntradaProductos(_idpersona);
                _bsproductos.DataSource = _dtproductos;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsproductos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void cbbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCatalogoProductos();
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _total = 0;
            try
            {
                dgvCatalogo.Notificar(BarraEstado);

                List<DataGridViewRow> _grows = (from item in dgvCatalogo.Rows.Cast<DataGridViewRow>()
                                                where Convert.ToDouble(item.Cells["Cantidad"].Value) > 0
                                                select item).ToList<DataGridViewRow>();
                foreach (DataGridViewRow _row in _grows)
                {
                    _row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    _row.DefaultCellStyle.ForeColor = Color.Black;

                    _total += _row.Cells["Total"].Value.TextoToDouble();
                }
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
                _bsproductos.Filter = string.Format("FullBusqueda LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double _cantidad = 0;
            double _precio = 0;
            double _total = 0;
            try
            {
                DataGridViewRow _row = dgvCatalogo.CurrentRow;
                _cantidad = _row.Cells["Cantidad"].Value.TextoToDouble();
                _precio = _row.Cells["Precio"].Value.TextoToDouble();
                _total = (_cantidad * _precio);
                _row.Cells["Total"].Value = _total;

                if (dgvCatalogo.Columns[e.ColumnIndex].Name == "Precio")
                {
                    CLS.ExtensionesLocales.GuardarUltimoCosto(dgvCatalogo, _row);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txbBuscarTexto.Clear();
                if (dgvCatalogo.ExistenFilasEditadas("Cantidad") > 0)
                {
                    if (_documento.Existe)
                    {
                        DocumentosInventarioGuardar _guardar = new DocumentosInventarioGuardar(_documento);
                        _guardar.doRefrescarFormularioExterno += Guardar;
                        _guardar.ShowDialog(this);
                        if (_guardar.Ok)
                        {
                            Close();
                        }                        
                    }
                    else
                    {
                        DocumentosInventarioGuardar _guardar = new DocumentosInventarioGuardar();
                        _guardar.doRefrescarFormularioExterno += Guardar;
                        _guardar.ShowDialog(this);
                        if (_guardar.Ok)
                        {
                            Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay filas editadas para éste documento.", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool Guardar(ModelosManager.CLS.DocumentosEncabezados _pdocu)
        {
            bool _ok = false;
            int _progreso = 0;
            int _conteo = 0;
            int _exitos = 0;
            ModelosManager.CLS.DocumentosEncabezados _docu = _pdocu;

            try
            {
                BarraProgreso.Value = 0;
                BarraProgreso.Visible = true;
                BarraEstado.Items[0].Visible = false;

                if (_docu.Existe)
                {
                    _ok = (_bd.Actualizar(_docu) > 0);
                }
                else
                {
                    _ok = (_bd.Insertar(_docu) > 0);
                    _docu.IDDocumento.Valor = _bd.UltimoID;
                }

                if (_ok == true)
                {
                    List<DataGridViewRow> _grows = (from item in dgvCatalogo.Rows.Cast<DataGridViewRow>()
                                                    where Convert.ToDouble(item.Cells["Cantidad"].Value) > 0
                                                    select item).ToList<DataGridViewRow>();
                    foreach (DataGridViewRow _row in _grows)
                    {
                        //CARGAMOS EL PRODUCTO
                        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres(_row.Cells["IDProducto"].Value.TextoToEntero());
                        //CREAMOS CADA ITEM
                        ModelosManager.CLS.DocumentosDetalle _item = new ModelosManager.CLS.DocumentosDetalle();
                        _item.IDDocumento.Valor = _docu.IDDocumento.Valor;
                        _item.IDProducto.Valor = _row.Cells["IDProducto"].Value;
                        _item.CodigoProducto.Valor = _row.Cells["CodigoProducto"].Value;
                        _item.NombreProducto.Valor = _row.Cells["NombreProducto"].Value;
                        _item.CantidadEntrada.Valor = _row.Cells["Cantidad"].Value;
                        _item.PrecioEntrada.Valor = _row.Cells["Precio"].Value;
                        _item.CantidadSalida.Valor = 0;
                        _item.PrecioSalida.Valor = 0;
                        _item.UltimoCosto.Valor = _producto.UltimoCosto.Valor;
                        _item.IDBodega.Valor = cbbBodegas.ComboBox.SelectedValue.TextoToEntero();
                        _item.NombreBodega.Valor = cbbBodegas.ComboBox.Text;

                        if (_bd.Insertar(_item) > 0)
                        {
                            _exitos++;
                        }

                        _conteo++;
                        _progreso = (_conteo * 100) / _grows.Count;

                        BarraProgreso.Value = _progreso;
                        this.Refresh();
                    }
                    _ok = (_exitos > 0);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                BarraProgreso.Visible = false;
                BarraEstado.Items[0].Visible = true;

                if (doRefrescarFormularioExterno != null)
                {
                    doRefrescarFormularioExterno();
                }
                if (_exitos != _conteo)
                {
                    MessageBox.Show(string.Format("ADVERTENCIA: algunos registros no pudieron ser guardados. Se guardaron {0} de {1}.", _exitos, _conteo), "ERRORES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return _ok;
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int _pidproveedor = 0;
                _pidproveedor = cbbProveedores.ComboBox.SelectedValue.TextoToEntero();
                CatalogoProductosEditor _editor = new CatalogoProductosEditor(0, _pidproveedor);
                _editor.doRefrescarFormularioExterno += CargarCatalogoProductos;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
