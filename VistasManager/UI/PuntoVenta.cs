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
    public partial class PuntoVenta : Estilos.FormMantenimiento
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.DocumentosEncabezados _documentos = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();

        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        CLS.ListaVentas _ventas = new CLS.ListaVentas();
        BindingSource _bsventas = new BindingSource();

        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        DataTable _dtdocumentos = new DataTable();
        BindingSource _bsdocumentos = new BindingSource();

        ErrorProvider _errores = new ErrorProvider();
        //int _idclientevarios = 465;

        public PuntoVenta()
        {
            InitializeComponent();
            CargarDatos();
            Iniciar();
        }

        private void CargarDatos()
        {
            try
            {
                _ventas.Clear();

                _dtproductos = _productos.TodoPuntoVenta();
                _bsproductos.DataSource = _dtproductos;

                _bsventas.DataSource = _ventas;

                _dtdocumentos = _documentos.DocumentosVentas();
                _bsdocumentos.DataSource = _dtdocumentos;
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
                _bodega = new ModelosManager.CLS.BodegasNombres(_appcfg.ID_BODEGA_SALIDA);

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsventas;

                dgvDocumentos.AutoGenerateColumns = false;
                dgvDocumentos.DataSource = _bsdocumentos;

                LimpiarControles();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbCodigoProducto.Text.EsNOE())
                {
                    DialogoBuscadorProductos();
                }
                else
                {
                    BuscarProducto();
                }
            }
        }

        private void BuscarProducto(int _idproducto = 0)
        {
            try
            {
                DataRow _row = null;

                if (_idproducto > 0)
                {
                    _producto = new ModelosManager.CLS.ProductoNombres(_idproducto);
                }
                else
                {
                    _row = (from _item in _dtproductos.AsEnumerable()
                            where _item.Field<string>("CodigoProducto").Equals(txbCodigoProducto.Text)
                            select _item).FirstOrDefault<DataRow>();
                    _producto = new ModelosManager.CLS.ProductoNombres(_row);
                }
                if (_producto.Existe)
                {
                    
                    txbCodigoProducto.Text = _producto.CodigoProducto.Valor.ToString();
                    txbNombreProducto.Text = _producto.NombreProducto.Valor.ToString();
                    txbCantidad.Enabled = true;
                    txbCantidad.Focus();
                }
                else
                {
                    txbNombreProducto.Clear();
                    txbCantidad.Clear();
                    txbCodigoProducto.Focus();
                }

            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void LimpiarControles()
        {
            try
            {
                txbCantidad.Clear();
                txbNombreProducto.Clear();
                txbCodigoProducto.Clear();
                this.ActiveControl = txbCodigoProducto;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void AgregarItem()
        {
            try
            {
                Validador _validar = new Validador(_errores);
                _validar.AgregarControl(txbCantidad);
                _validar.AgregarControl(txbCodigoProducto);

                if (_validar.Comprobar())
                {
                    CLS.ItemVentas _item = new CLS.ItemVentas();
                    _item.IDProducto = _producto.IDProducto.Valor.TextoToEntero();
                    _item.CodigoProducto = _producto.CodigoProducto.Valor.ToString();
                    _item.NombreProducto = _producto.NombreProducto.Valor.ToString();
                    _item.Precio = _producto.Precio3.Valor.TextoToDouble();
                    _item.Costo = _producto.UltimoCosto.Valor.TextoToDouble();
                    _item.Cantidad = txbCantidad.Text.TextoToEntero();
                    _item.IDBodega = _bodega.IDBodega.Valor.TextoToEntero();
                    _item.NombreBodega = _bodega.NombreBodega.Valor.ToString();
                    _item.FormatoVenta = _producto.FormatoVenta.Valor.ToString();
                    _item.Calcular(_producto.TasaIVA.Valor.TextoToDouble(), _producto.PagoCuenta.Valor.TextoToDouble(), _producto.EsGravado.Valor.ToString());

                    _ventas.Add(_item);

                    LimpiarControles();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarItem();
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalle.ExistenFilas() > 0)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el item?", "ELIMINAR ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataGridViewRow _row = dgvDetalle.CurrentRow;
                        CLS.ItemVentas _item = _row.DataBoundItem as CLS.ItemVentas;
                        if (_ventas.Remove(_item))
                        {
                            MessageBox.Show("Item fué eliminado correctamente", "ELIMINAR ITEM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.ActiveControl = txbCodigoProducto;
                        }
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            FinalizarVenta();
        }

        private void FinalizarVenta()
        {
            int _conteo = 0;
            double _total = 0;

            try
            {
                if (dgvDetalle.ExistenFilas() > 0)
                {
                    _total = lblTotalVenta.Text.TextoToDouble();
                    PuntoVentaFinalizar _finalizar = new PuntoVentaFinalizar(_total);
                    _finalizar.ShowDialog(this);

                    if (_finalizar.Ok)
                    {
                        PuntoVentaImpresion _imp = new PuntoVentaImpresion();
                        _imp.ShowDialog(this);
                        if (_imp.Ok)
                        {
                            ModelosManager.CLS.PersonasNombres _cliente = _finalizar.Cliente;
                            ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();

                            _documento.NumeroDocumento.Valor = _imp.Token;
                            _documento.FechaDocumento.Valor = _finalizar.Fecha_documento;
                            _documento.FormaPago.Valor = _finalizar.Forma_pago;
                            _documento.DiasPlazo.Valor = _finalizar.Dias_plazo;
                            _documento.Operacion.Valor = "VENTA";
                            _documento.Documento.Valor = _imp.Tipo;
                            _documento.IDPersona.Valor = _cliente.IDPersona.Valor;
                            _documento.NombreTitular.Valor = _cliente.NombrePersona.Valor;
                            _documento.Estado.Valor = "APLICADO";
                            _documento.Comentario.Valor = string.Empty;

                            if (_bd.Insertar(_documento) > 0)
                            {
                                _documento.IDDocumento.Valor = _bd.UltimoID;

                                foreach (CLS.ItemVentas _item in _ventas)
                                {
                                    ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();
                                    _detalle.IDDocumento.Valor = _documento.IDDocumento.Valor;
                                    _detalle.IDProducto.Valor = _item.IDProducto;
                                    _detalle.CodigoProducto.Valor = _item.CodigoProducto;
                                    _detalle.NombreProducto.Valor = _item.NombreProducto;
                                    _detalle.CantidadEntrada.Valor = 0;
                                    _detalle.PrecioEntrada.Valor = 0;
                                    _detalle.CantidadSalida.Valor = _item.Cantidad;
                                    _detalle.PrecioSalida.Valor = _item.Precio;
                                    _detalle.UltimoCosto.Valor = _item.Costo;
                                    _detalle.IDBodega.Valor = _item.IDBodega;
                                    _detalle.NombreBodega.Valor = _item.NombreBodega;
                                    _detalle.FormatoVenta.Valor = _item.FormatoVenta;
                                    _detalle.IvaRetenido.Valor = _item.IvaRetenido;
                                    _detalle.PagoCuenta.Valor = _item.PagoCuenta;
                                    _detalle.MontoIva.Valor = _item.MontoIva;
                                    _detalle.Gravado.Valor = _item.Total;

                                    if (_bd.Insertar(_detalle) > 0)
                                    {
                                        _conteo++;
                                    }
                                }

                                if (_conteo > 0)
                                {
                                    CargarDatos();
                                    LimpiarControles();
                                    ImprimirDocumento(_documento.IDDocumento.Valor.TextoToEntero(), _documento.Documento.Valor.ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay items en ésta venta", "VENTA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsdocumentos.Filter = string.Format("NumeroDocumento LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDocumentos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvDocumentos.Notificar(BarraEstatusDocumentos);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            DialogoBuscadorProductos();
        }

        private void DialogoBuscadorProductos()
        {
            try
            {
                BuscadorProductos _buscador = new BuscadorProductos(true);
                _buscador.ShowDialog(this);
                if (_buscador.IDproductoSeleccionado > 0)
                {
                    BuscarProducto(_buscador.IDproductoSeleccionado);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _total = 0;
            double _iva = 0;
            double _gravado = 0;
            double _excento = 0;
            double _descuento = 0;
            double _subtotal = 0;

            try
            {
                foreach (DataGridViewRow _row in dgvDetalle.Rows)
                {
                    CLS.ItemVentas _item = _row.DataBoundItem as CLS.ItemVentas;
                    _total = _total + _item.MontoIva;
                    _iva = _iva + _item.IvaRetenido;
                    _gravado = _gravado + _item.Total;
                    _excento = 0;
                    _subtotal = (_gravado + _iva);
                }

                lblTotalVenta.Text = string.Format("{0:N2}", _total);
                lblItemsVendidos.Text = string.Format("Items vendidos: {0}", _ventas.Count);
                txbTotalIVA.Text = string.Format("{0:N2}", _iva);
                txbTotalGravado.Text = string.Format("{0:N2}", _gravado);
                txbTotalExcento.Text = string.Format("{0:N2}", _excento);
                txbTotalDescuento.Text = string.Format("{0:N2}", _descuento);
                txbSubTotal.Text = string.Format("{0:N2}", _subtotal);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ImprimirDocumento(int _piddocumento = 0, string _ptipo = "")
        {
            try
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass _repo = null;
                DataTable _tabla = ModelosManager.CLS.Consultas.DocumentoImprimir(_piddocumento);
                switch (_ptipo)
                {
                    case "TICKET":
                        _repo = new REPORTES.Ticket();
                        break;
                    case "CONSUMIDOR FINAL":
                        break;
                    case "CREDITO FISCAL":
                        break;
                }
                _repo.SetDataSource(_tabla);

                VistaPrevia _vp = new VistaPrevia(_repo);
                _vp.ShowDialog(this);
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
                DataRow _row = dgvDocumentos.CurrentRow.ToDataRow();
                ImprimirDocumento(_row["IDDocumento"].TextoToEntero(), _row["Documento"].ToString());
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void PuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        btnFinalizarVenta.PerformClick();
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
