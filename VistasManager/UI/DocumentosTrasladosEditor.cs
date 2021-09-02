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
using VistasManager.UI;

namespace VistasManager.UI
{
    public partial class DocumentosTrasladosEditor : Estilos.FormMantenimiento
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.BodegasNombres _bodegas = new ModelosManager.CLS.BodegasNombres();

        DataTable _dtpersonas = new DataTable();
        BindingSource _bspersonas = new BindingSource();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        DataTable _dtbodegas = new DataTable();
        BindingSource _bsbodegas = new BindingSource();
        DataTable _dtdestino = new DataTable();
        BindingSource _bsdestino = new BindingSource();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public DocumentosTrasladosEditor(int _iddocumento = 0)
        {
            _documento = new ModelosManager.CLS.DocumentosEncabezados(_iddocumento);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtpersonas = _personas.TodosClientes();
                _bspersonas.DataSource = _dtpersonas;

                _dtbodegas = _bodegas.Todo();
                _bsbodegas.DataSource = _dtbodegas;

                cbbBodegas.ComboBox.DataSource = _bsbodegas;
                cbbBodegas.ComboBox.DisplayMember = "NombreBodega";
                cbbBodegas.ComboBox.ValueMember = "IDBodega";
                cbbBodegas.ComboBox.SelectedIndex = 0;

                _dtdestino = _bodegas.Todo();
                _bsdestino.DataSource = _dtdestino;

                cbbBodegaDestino.ComboBox.DataSource = _bsdestino;
                cbbBodegaDestino.ComboBox.DisplayMember = "NombreBodega";
                cbbBodegaDestino.ComboBox.ValueMember = "IDBodega";
                cbbBodegaDestino.ComboBox.SelectedIndex = 0;

                CargarCatalogoProductos();
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
                //int _idpersona = 0;
                //_idpersona = cbbPersonas.ComboBox.SelectedValue.TextoToEntero();
                //_personas = new ModelosManager.CLS.PersonasNombres(_idpersona);

                //_dtproductos = ModelosManager.CLS.Consultas.HojaSalidaProductos(_idpersona);
                int _idbodega = cbbBodegas.ComboBox.SelectedValue.TextoToEntero();
                _dtproductos = ModelosManager.CLS.Consultas.HojaTrasladoProductos(_idbodega);
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
            //CargarCatalogoProductos();
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _total = 0;
            try
            {
                dgvCatalogo.Notificar(BarraEstado);

                foreach (DataGridViewRow _row in dgvCatalogo.Rows)
                {
                    if (_row.Cells["Cantidad"].Value.TextoToDouble() > 0)
                    {
                        _row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        _row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        _row.DefaultCellStyle.BackColor = Color.White;
                        _row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    _total += _row.Cells["Total"].Value.TextoToDouble();
                }

                //List<DataGridViewRow> _grows = (from item in dgvCatalogo.Rows.Cast<DataGridViewRow>()
                //                                where Convert.ToDouble(item.Cells["Cantidad"].Value) > 0
                //                                select item).ToList<DataGridViewRow>();
                //foreach (DataGridViewRow _row in _grows)
                //{
                //    _row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                //    _row.DefaultCellStyle.ForeColor = Color.Black;

                //    _total += _row.Cells["Total"].Value.TextoToDouble();
                //}
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
                ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres(_row.Cells["IDProducto"].Value.TextoToEntero());
                _cantidad = _row.Cells["Cantidad"].Value.TextoToDouble();
                _precio = _row.Cells["PrecioSalida"].Value.TextoToDouble();
                _total = (_cantidad * _precio);
                _row.Cells["Total"].Value = _total;
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
                    if (!cbbBodegas.ComboBox.Text.Equals(cbbBodegaDestino.ComboBox.Text))
                    {
                        if (_documento.Existe)
                        {
                            if (Guardar(_documento))
                            {
                                Close();
                            }
                            //_documento.IDPersona.Valor = cbbPersonas.ComboBox.SelectedValue.TextoToEntero();

                            //DocumentosTrasladosGuardar _guardar = new DocumentosTrasladosGuardar(_documento);
                            //_guardar.doRefrescarFormularioExterno += Guardar;
                            //_guardar.ShowDialog(this);
                            //if (_guardar.Ok)
                            //{
                            //    Close();
                            //}                        
                        }
                        else
                        {
                            //int _idpersona = cbbPersonas.ComboBox.SelectedValue.TextoToEntero();
                            int _idbodegaorigen = cbbBodegas.ComboBox.SelectedValue.TextoToEntero();
                            int _idbodegadestino = cbbBodegaDestino.ComboBox.SelectedValue.TextoToEntero();

                            DocumentosTrasladosGuardar _guardar = new DocumentosTrasladosGuardar(_idbodegaorigen, _idbodegadestino);
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
                        MessageBox.Show("La bodega destino no puede ser la misma que la bodega origen", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            EntityManager.Transaccion _transa = new EntityManager.Transaccion();

            try
            {
                BarraProgreso.Value = 0;
                BarraProgreso.Visible = true;
                BarraEstado.Items[0].Visible = false;

                if (_docu.Existe)
                {
                    //_ok = (_bd.Actualizar(_docu) > 0);
                    _ok = _transa.AnexarMaestro(_docu);
                }
                else
                {
                    //_ok = (_bd.Insertar(_docu) > 0);
                    _ok = _transa.AnexarMaestro(_docu);
                    //_docu.IDDocumento.Valor = _bd.UltimoID;
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
                        //CREAMOS CADA ITEM DE SALIDA DE BODEGA ORIGEN
                        ModelosManager.CLS.DocumentosDetalle _item = new ModelosManager.CLS.DocumentosDetalle();
                        _item.IDDocumento.Valor = _docu.IDDocumento.Valor;
                        _item.IDProducto.Valor = _row.Cells["IDProducto"].Value;
                        _item.CodigoProducto.Valor = _row.Cells["CodigoProducto"].Value;
                        _item.NombreProducto.Valor = _row.Cells["NombreProducto"].Value;
                        _item.CantidadEntrada.Valor = 0;
                        _item.PrecioEntrada.Valor = 0;
                        _item.CantidadSalida.Valor = _row.Cells["Cantidad"].Value;
                        _item.PrecioSalida.Valor = _row.Cells["PrecioSalida"].Value;
                        _item.UltimoCosto.Valor = _producto.UltimoCosto.Valor;
                        _item.IDBodega.Valor = cbbBodegas.ComboBox.SelectedValue.TextoToEntero();
                        _item.NombreBodega.Valor = cbbBodegas.ComboBox.Text;
                        _item.FormatoVenta.Valor = _producto.FormatoVenta.Valor.ToString();

                        //CREAMOS CADA ITEM DE ENTRADA DE BODEGA DESTINO
                        ModelosManager.CLS.DocumentosDetalle _item2 = new ModelosManager.CLS.DocumentosDetalle();
                        _item2.IDDocumento.Valor = _docu.IDDocumento.Valor;
                        _item2.IDProducto.Valor = _row.Cells["IDProducto"].Value;
                        _item2.CodigoProducto.Valor = _row.Cells["CodigoProducto"].Value;
                        _item2.NombreProducto.Valor = _row.Cells["NombreProducto"].Value;
                        _item2.CantidadSalida.Valor = 0;
                        _item2.PrecioSalida.Valor = 0;
                        _item2.CantidadEntrada.Valor = _row.Cells["Cantidad"].Value;
                        _item2.PrecioEntrada.Valor = _row.Cells["PrecioSalida"].Value;
                        _item2.UltimoCosto.Valor = _producto.UltimoCosto.Valor;
                        _item2.IDBodega.Valor = cbbBodegaDestino.ComboBox.SelectedValue.TextoToEntero();
                        _item2.NombreBodega.Valor = cbbBodegaDestino.ComboBox.Text;
                        _item2.IDBodegaOrigen.Valor = cbbBodegas.ComboBox.SelectedValue.TextoToEntero();
                        _item2.NombreBodegaOrigen.Valor = cbbBodegas.ComboBox.Text;
                        _item2.FormatoVenta.Valor = _producto.FormatoVenta.Valor.ToString();

                        if (_transa.AnexarDetalle(_item) && _transa.AnexarDetalle(_item2))
                            _exitos++;

                        //if (_bd.Insertar(_item) > 0 && _bd.Insertar(_item2) > 0)
                        //{
                        //    _exitos++;
                        //}

                        _conteo++;
                        _progreso = (_conteo * 100) / _grows.Count;

                        BarraProgreso.Value = _progreso;
                        this.Refresh();
                    }
                    //_ok = (_exitos > 0);

                    //APLICAMOS LA TRANSACCION
                    _ok = _transa.Procesar("IDDocumento") > 0;
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

                    //if (_docu.Existe)
                    //{
                    //    ImprimirDocumento(_docu.IDDocumento.Valor.TextoToEntero());
                    //}
                }
                if (_exitos != _conteo)
                {
                    MessageBox.Show(string.Format("ADVERTENCIA: algunos registros no pudieron ser guardados. Se guardaron {0} de {1}.", _exitos, _conteo), "ERRORES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return _ok;
        }

        private void ImprimirDocumento(int _piddocumento)
        {
            try
            {
                DataTable _dtrepo = ModelosManager.CLS.Consultas.HojaTraslados(_piddocumento);

                REPORTES.HojaTraslado _hoja = new REPORTES.HojaTraslado();
                _hoja.SetDataSource(_dtrepo);

                VistasManager.UI.VistaPrevia _vp = new UI.VistaPrevia(_hoja);
                _vp.Show();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnCargarProductos_Click(object sender, EventArgs e)
        {
            CargarCatalogoProductos();
        }

        private void dgvCatalogo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            e.Cancel = CLS.ExtensionesLocales.ValidarExistenciaEnCeldaGrid(dgvCatalogo, e, "Cantidad");
        }

        private void dgvCatalogo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCatalogo.IsCurrentCellDirty)
            {
                dgvCatalogo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cbbBodegas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCatalogoProductos();
        }
    }
}
