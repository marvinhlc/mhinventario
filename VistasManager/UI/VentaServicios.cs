using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using EntityManager;

namespace VistasManager.UI
{
    public partial class VentaServicios : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Portable.Portador _portador = Portable.Portador.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.DocumentosEncabezados _documentos = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();
        ModelosManager.CLS.BodegasNombres _bodegasalida = new ModelosManager.CLS.BodegasNombres();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.ProductoPrecios _precios = new ModelosManager.CLS.ProductoPrecios();

        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        CLS.ListaVentas _ventas = new CLS.ListaVentas();
        BindingSource _bsventas = new BindingSource();

        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        DataTable _dtdocumentos = new DataTable();
        BindingSource _bsdocumentos = new BindingSource();
        DataTable _dtclientes = new DataTable();
        BindingSource _bsclientes = new BindingSource();

        ErrorProvider _errores = new ErrorProvider();

        private CLS.Enumeraciones.TIPO_DOCUMENTO _tipo_documento = CLS.Enumeraciones.TIPO_DOCUMENTO.SERVICIOS;
        private CLS.Enumeraciones.FORMA_PAGO _forma_pago = CLS.Enumeraciones.FORMA_PAGO.CONTADO;
        private CLS.Enumeraciones.FILTRO_DOCUMENTO _filtro_documento = CLS.Enumeraciones.FILTRO_DOCUMENTO.SERVICIOS;

        string _texto_tipo_documento = "TICKET";

        public VentaServicios()
        {
            _tipo_documento = CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET;
            InitializeComponent();
            CargarDatos();
            Iniciar();
        }

        public VentaServicios(CLS.Enumeraciones.TIPO_DOCUMENTO _tipo = CLS.Enumeraciones.TIPO_DOCUMENTO.SERVICIOS)
        {
            _tipo_documento = CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET;
            InitializeComponent();
            CargarDatos();
            Iniciar();
        }

        private void CargarDatos()
        {
            try
            {
                _ventas.Clear();

                _dtproductos = _productos.TodoServicios();
                _bsproductos.DataSource = _dtproductos;

                _bsventas.DataSource = _ventas;

                _dtdocumentos = _documentos.DocumentosVentas();
                //_bsdocumentos.DataSource = _dtdocumentos;

                _dtclientes = _cliente.TodosClientes();
                _bsclientes.DataSource = _dtclientes;
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
                switch (_tipo_documento)
                {
                    case CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET:
                        lblTipoDocumento.Text = "SERVICIOS";
                        _filtro_documento = CLS.Enumeraciones.FILTRO_DOCUMENTO.TIKET;
                        break;
                    case CLS.Enumeraciones.TIPO_DOCUMENTO.CREDITO_FISCAL:
                        //lblTipoDocumento.Text = "CREDITO FISCAL";
                        _filtro_documento = CLS.Enumeraciones.FILTRO_DOCUMENTO.CREDITO_FISCAL;
                        break;
                    case CLS.Enumeraciones.TIPO_DOCUMENTO.CONSUMIDOR_FINAL:
                        //lblTipoDocumento.Text = "CONSUMIDOR FINAL";
                        _filtro_documento = CLS.Enumeraciones.FILTRO_DOCUMENTO.CONSUMIDOR_FINAL;
                        break;
                    case CLS.Enumeraciones.TIPO_DOCUMENTO.SERVICIOS:
                        lblTipoDocumento.Text = "SERVICIOS";
                        _filtro_documento = CLS.Enumeraciones.FILTRO_DOCUMENTO.SERVICIOS;
                        break;
                }

                _bodega = new ModelosManager.CLS.BodegasNombres(_appcfg.ID_BODEGA_SALIDA);

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsventas;

                LimpiarControles();

                lblEstacion.Text = string.Format("ESTACION: {0}", _appcfg.ESTACION_ID);
                lblUsuario.Text = string.Format("USUARIO: {0}", _sesion.USUARIO.IDUsuario.Valor.ToString());
                lblConexion.Text = string.Format("CONEXION: {0}", _portador.Conexion.ToUpper());
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void LimpiarControles(bool _reiniciarcliente = true)
        {
            try
            {
                _forma_pago = CLS.Enumeraciones.FORMA_PAGO.CONTADO;
                txbCantidad.Clear();
                txbNombreProducto.Clear();
                txbCodigoProducto.Clear();
                txbPrecio.Clear();
                txbPrecio.CeroToTexto();
                txbFormatoVenta.Clear();
                txbBodega.Clear();

                txbPrecio.Enabled = false;
                txbCantidad.Enabled = false;

                //BODEGA DE SALIDA POR DEFAULT
                _bodega = new ModelosManager.CLS.BodegasNombres(_appcfg.ID_BODEGA_SALIDA);
                //CLIENTE VARIOS
                if (_reiniciarcliente)
                    _cliente = new ModelosManager.CLS.PersonasNombres(_appcfg.ID_CLIENTE_VARIOS);
                if (_cliente.Existe)
                {
                    try
                    {
                        txbIDTitular.Text = _cliente.IDPersona.Valor.ToString();
                        txbNombreTitular.Text = _cliente.NombrePersona.Valor.ToString();
                        txbPaisTitular.Text = _cliente.Pais.Valor.ToString();
                        txbNitTitular.Text = _cliente.NIT.Valor.ToString();
                        txbIvaTitular.Text = _cliente.IVA.Valor.ToString();
                        txbDuiTitular.Text = _cliente.DUI.Valor.ToString();
                        txbGiroTitular.Text = _cliente.Giro.Valor.ToString();
                    }
                    catch (Exception _err)
                    {
                        Herramientas.Log.Registrar(_err.ToString());
                    }
                }

                this.ActiveControl = txbCodigoProducto;
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

        private void BuscarProducto(int _idproducto = 0, int _idbodega = 0)
        {
            try
            {
                DataRow _row = null;
                double _elprecio = 0;

                if (_idproducto > 0)
                {
                    _producto = new ModelosManager.CLS.ProductoNombres(_idproducto);
                }
                else
                {
                    try
                    {
                        _row = (from _item in _dtproductos.AsEnumerable()
                                where _item.Field<string>("CodigoProducto").Equals(txbCodigoProducto.Text.Trim())
                                select _item).FirstOrDefault<DataRow>();
                    }
                    catch (Exception)
                    {
                        _row = null;
                    }
                    _producto = new ModelosManager.CLS.ProductoNombres(_row);
                }

                if (_idbodega > 0)
                    _bodegasalida = new ModelosManager.CLS.BodegasNombres(_idbodega);
                else
                    _bodegasalida = new ModelosManager.CLS.BodegasNombres();

                if (_producto.Existe)
                {
                    double _escala = 1.0;
                    //_elprecio = _producto.ObtenerPrecio(_escala);
                    
                    txbCodigoProducto.Text = _producto.CodigoProducto.Valor.ToString();
                    txbNombreProducto.Text = _producto.NombreProducto.Valor.ToString();
                    //txbPrecioVenta.Text = _elprecio.ToString();
                    txbFormatoVenta.Text = _producto.FormatoVenta.Valor.ToString();
                    txbPrecio.Enabled = true;
                    txbPrecio.Text.CeroToTexto();
                    txbCantidad.Enabled = true;
                    txbCantidad.Focus();
                }
                else
                {
                    txbNombreProducto.Clear();
                    txbPrecio.Clear();
                    txbCantidad.Clear();
                    txbFormatoVenta.Clear();
                    txbBodega.Clear();
                    txbCodigoProducto.Focus();
                    MessageBox.Show("Producto no existe.", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (_bodegasalida.Existe)
                {
                    txbBodega.Text = _bodegasalida.NombreBodega.Valor.ToString();
                }
                else
                {
                    txbBodega.Text = _bodega.NombreBodega.Valor.ToString();
                }

                //DIALOGO LISTA DE PRECIOS
                if (_producto.Existe)
                {
                    txbPrecio.Focus();
                    //VentaListaPrecios _precios = new VentaListaPrecios(_producto);
                    //_precios.ShowDialog(this);
                    //if (_precios.Precio_actual > 0)
                    //    txbPrecio.Text = _precios.Precio_actual.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void DialogoBuscadorProductos()
        {
            try
            {
                BuscadorProductos _buscador = new BuscadorProductos(CLS.Enumeraciones.FILTRO_PRODUCTOS_SERVICIOS.SERVICIOS);
                _buscador.ShowDialog(this);
                if (_buscador.IDproductoSeleccionado > 0)
                {
                    BuscarProducto(_buscador.IDproductoSeleccionado, _buscador.Idbodegaseleccionada);
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

        private void AgregarItem()
        {
            try
            {
                Validador _validar = new Validador(_errores);
                _validar.AgregarControl(txbCantidad);
                _validar.AgregarControl(txbCodigoProducto);
                _validar.AgregarControl(txbPrecio);

                if (_validar.Comprobar())
                {
                    double _escala = txbCantidad.Text.TextoToDouble();

                    if (_bodegasalida.Existe)
                        _bodega = _bodegasalida;

                    CLS.ItemVentas _item = new CLS.ItemVentas();
                    _item.IDProducto = _producto.IDProducto.Valor.TextoToEntero();
                    _item.CodigoProducto = _producto.CodigoProducto.Valor.ToString();
                    _item.NombreProducto = _producto.NombreProducto.Valor.ToString();
                    //_item.Precio = _producto.ObtenerPrecio(_escala);
                    //_item.Precio = cbbPreciosVenta.Text.TextoToDouble();
                    _item.Precio = txbPrecio.Text.TextoToDouble();
                    _item.Costo = _producto.UltimoCosto.Valor.TextoToDouble();
                    _item.Cantidad = txbCantidad.Text.TextoToDouble();
                    _item.IDBodega = _bodega.IDBodega.Valor.TextoToEntero();
                    _item.NombreBodega = _bodega.NombreBodega.Valor.ToString();
                    _item.FormatoVenta = _producto.FormatoVenta.Valor.ToString();
                    _item.Calcular(_producto.TasaIVA.Valor.TextoToDouble(), _producto.PagoCuenta.Valor.TextoToDouble(), _producto.EsGravado.Valor.ToString());
                    _item.Producto_cache = _producto;

                    _ventas.Add(_item);

                    LimpiarControles(false);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
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
                    _item.Calcular();

                    _total = _total + _item.Total;
                    _iva = _iva + _item.IvaRetenido;
                    _gravado = _gravado + (_item.Total - _item.IvaRetenido);
                    _excento = 0;
                    _subtotal = (_gravado + _iva);
                }

                lblItemsVendidos.Text = string.Format("ITEMS: {0}", _ventas.Count);
                lblTotalVenta.Text = string.Format("{0:N2}", _total);
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            DialogoBuscadorProductos();
        }

        private void FinalizarVenta()
        {
            int _conteo = 0;
            double _total = 0;
            double _saldo = 0;
            double _abono = 0;
            string _token = string.Empty;
            StringBuilder _presql = new StringBuilder();
            Sesion.CLS.ConfigApp.TIPO_TOKEN _ttoken = Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET;

            try
            {
                if (dgvDetalle.ExistenFilas() > 0)
                {
                    _total = Convert.ToDouble(lblTotalVenta.Text);

                    //PEDIR EFECTIVO Y MOSTRAR CAMBIO DE $$
                    UI.VentaDevolucion _devolucion = new VentaDevolucion(_total);
                    _devolucion.ShowDialog(this);
                    if (_devolucion.Ok == false)
                        return;
                    else{
                        _abono = _devolucion.Efectivo;
                        _saldo = _devolucion.Saldo;
                        if (_saldo > 0)
                            _forma_pago = CLS.Enumeraciones.FORMA_PAGO.CREDITO;
                    }

                    //OBTENEMOS EL TOKEN DE LA CONFIGURACION DE LA CAJA
                    if (_documentos.Existe == false)
                    {
                        if (_tipo_documento == CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET)
                        {
                            _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET);
                            _ttoken = Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET;
                        }
                        if (_tipo_documento == CLS.Enumeraciones.TIPO_DOCUMENTO.CREDITO_FISCAL)
                        {
                            _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CREDITO_FISCAL);
                            _ttoken = Sesion.CLS.ConfigApp.TIPO_TOKEN.CREDITO_FISCAL;
                        }
                        if (_tipo_documento == CLS.Enumeraciones.TIPO_DOCUMENTO.CONSUMIDOR_FINAL)
                        {
                            _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CONSUMIDOR_FINAL);
                            _ttoken = Sesion.CLS.ConfigApp.TIPO_TOKEN.CONSUMIDOR_FINAL;
                        }
                    }

                    ModelosManager.CLS.DocumentosLog _log = new ModelosManager.CLS.DocumentosLog();
                    ModelosManager.CLS.DocumentosEncabezados _nuevodoc = new ModelosManager.CLS.DocumentosEncabezados();
                    ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();

                    //INICIAMOS LA TRANSACCION
                    EntityManager.Transaccion _transac = new EntityManager.Transaccion();

                    //PROCESAMOS SI SE ESTA EDITANDO EL DOCUMENTO
                    //SI NO CREAMOS UNO NUEVO
                    if (_documentos.Existe)
                    {
                        _presql.Append(@"DELETE FROM documentos_encabezados 
                                            WHERE IDDocumento = {0};");
                        _transac.AnexarPreSql(string.Format(_presql.ToString(), _documentos.IDDocumento.Valor.TextoToEntero()));
                        _nuevodoc = _documentos;
                        _nuevodoc.IDPersona.Valor = _cliente.IDPersona.Valor;
                        _nuevodoc.NombreTitular.Valor = _cliente.NombrePersona.Valor;
                        _nuevodoc.FechaCreacion.Valor = null;
                    }
                    else
                    {
                        _nuevodoc.NumeroDocumento.Valor = _token;
                        _nuevodoc.FechaDocumento.Valor = DateTime.Now.FechaParaMySQL();
                        _nuevodoc.FormaPago.Valor = _forma_pago;
                        _nuevodoc.DiasPlazo.Valor = 0;
                        _nuevodoc.Operacion.Valor = "VENTA";
                        _nuevodoc.Documento.Valor = _texto_tipo_documento;
                        _nuevodoc.IDPersona.Valor = _cliente.IDPersona.Valor;
                        _nuevodoc.NombreTitular.Valor = _cliente.NombrePersona.Valor;
                        _nuevodoc.Estado.Valor = "APLICADO";
                        _nuevodoc.Comentario.Valor = "VENTA DE SERVICIOS";
                    }

                    //ANEXAMOS EL MAESTRO
                    if (_transac.AnexarMaestro(_nuevodoc))
                    {
                        //ANEXAMOS UN DETALLE
                        _log.IDUsuario.Valor = _sesion.USUARIO.IDUsuario.Valor;
                        _log.Estacion.Valor = _appcfg.ESTACION_ID.ToString();
                        _log.TotalVenta.Valor = _total;
                        _log.Efectivo.Valor = _devolucion.Efectivo;
                        _log.Cambio.Valor = _devolucion.Cambio;
                        _log.Saldo.Valor = _devolucion.Saldo;

                        if (_transac.AnexarDetalle(_log))
                        {
                            //ANEXAMOS OTRO DETALLE
                            //PROCESAMOS TODOS LOS ITEMS
                            foreach (CLS.ItemVentas _item in _ventas)
                            {
                                _detalle = new ModelosManager.CLS.DocumentosDetalle();
                                _detalle.IDDocumento.Valor = _nuevodoc.IDDocumento.Valor;
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

                                if (_transac.AnexarDetalle(_detalle))
                                    _conteo++;
                            }

                            //PROCESAMOS LA TRANSACCION
                            if (_transac.Procesar("IDDocumento") > 0)
                            {
                                _nuevodoc.IDDocumento.Valor = _transac.UltimoID;
                                _documentos = _nuevodoc;
                                _documentos.Existe = true;

                                //IMPRIMIR EL DOCUMENTO
                                if (_documentos.Existe)
                                {
                                    ImprimirDocumento(_documentos.IDDocumento.Valor.TextoToEntero(), _documentos.Documento.Valor.ToString());
                                    //NUEVO DOCUMENTO
                                    _documentos = new ModelosManager.CLS.DocumentosEncabezados();
                                }

                                //INCREMENTAMOS EL CONTADOR DEL TOKEN
                                _appcfg.AceptarToken(_ttoken);

                                CargarDatos();
                                LimpiarControles();
                            }
                            else
                            {
                                MessageBox.Show(@"Transacción falló. No se pudo guardar el documento, intente de nuevo. 
                                                    Si el problema persiste llame al soporte técnico.",
                                                    "FINALIZAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            FinalizarVenta();
        }

        private void BuscarPersona(string _pfiltro = "")
        {
            DataRow _row = null;

            try
            {
                _row = (from _item in _dtclientes.AsEnumerable()
                        where (_item.Field<string>("NIT") != null && _item.Field<string>("NIT").Equals(_pfiltro))
                        || (_item.Field<string>("IVA") != null && _item.Field<string>("IVA").Equals(_pfiltro))
                        || (_item.Field<string>("DUI") != null && _item.Field<string>("DUI").Equals(_pfiltro))
                        select _item).FirstOrDefault<DataRow>();
                if (_row != null)
                {
                    txbIDTitular.Text = _row["IDPersona"].ToString();
                    txbNombreTitular.Text = _row["NombrePersona"].ToString();
                    txbNitTitular.Text = _row["NIT"].ToString();
                    txbIvaTitular.Text = _row["IVA"].ToString();
                    txbDuiTitular.Text = _row["DUI"].ToString();
                    txbGiroTitular.Text = _row["Giro"].ToString();
                    txbFiltroTitular.Clear();
                }
                else
                {
                    txbIDTitular.Clear();
                    txbNombreTitular.Clear();
                    txbNitTitular.Clear();
                    txbIvaTitular.Clear();
                    txbDuiTitular.Clear();
                    txbGiroTitular.Clear();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbFiltroTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbFiltroTitular.Text.NoNOE())
                {
                    BuscarPersona(txbFiltroTitular.Text);
                }
                else
                {
                    if (MessageBox.Show("¿Desea crear un nuevo registro de cliente?", "NUEVO CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txbIDTitular.Clear();
                        txbNombreTitular.Clear();
                        txbNitTitular.Clear();
                        txbIvaTitular.Clear();
                        txbDuiTitular.Clear();
                        txbGiroTitular.Clear();
                        txbPaisTitular.Clear();

                        txbNombreTitular.Enabled = true;
                        txbPaisTitular.Enabled = true;
                        txbNitTitular.Enabled = true;
                        txbIvaTitular.Enabled = true;
                        txbDuiTitular.Enabled = true;
                        txbGiroTitular.Enabled = true;
                        txbPaisTitular.Enabled = true;
                        txbNombreTitular.Focus();
                    }
                    else
                    {
                        //txbEfectivo.Focus();
                    }
                }
            }
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorPersonas _buscador = new BuscadorPersonas(BuscadorPersonas.RolPersona.CLIENTES);
                _buscador.ShowDialog(this);
                if (_buscador.Persona.Existe)
                {
                    CargadorPersona(_buscador.Persona);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void CargadorPersona(ModelosManager.CLS.PersonasNombres _elcliente)
        {
            try
            {
                if (_elcliente.Existe)
                {
                    _cliente = _elcliente;
                    txbIDTitular.Text = _elcliente.IDPersona.Valor.ToString();
                    txbNombreTitular.Text = _elcliente.NombrePersona.Valor.ToString();
                    txbNitTitular.Text = _elcliente.NIT.Valor.ToString();
                    txbIvaTitular.Text = _elcliente.IVA.Valor.ToString();
                    txbDuiTitular.Text = _elcliente.DUI.Valor.ToString();
                    txbGiroTitular.Text = _elcliente.Giro.Valor.ToString();
                    txbFiltroTitular.Clear();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                btnNuevo.Text = "Guardar";
                btnNuevo.Image = VistasManager.Properties.Resources.disk;
                EditarPersona(true);
            }
            else
            {
                btnNuevo.Text = "Nuevo";
                btnNuevo.Image = VistasManager.Properties.Resources.add;
                EditarPersona(false);
            }
        }

        private void EditarPersona(bool _pactivar = true)
        {
            if (_pactivar == false)
            {
                if (txbNombreTitular.Text.NoNOE())
                {
                    ModelosManager.CLS.PersonasNombres _nuevo = new ModelosManager.CLS.PersonasNombres();
                    _nuevo.NombrePersona.Valor = txbNombreTitular.Text;
                    _nuevo.NIT.Valor = txbNitTitular.Text;
                    _nuevo.IVA.Valor = txbIvaTitular.Text;
                    _nuevo.DUI.Valor = txbDuiTitular.Text;
                    _nuevo.Giro.Valor = txbGiroTitular.Text;
                    _nuevo.Pais.Valor = txbPaisTitular.Text;
                    if (_bd.Insertar(_nuevo) > 0)
                    {
                        txbIDTitular.Text = _bd.UltimoID.ToString();
                        _cliente = _nuevo;
                    }
                }
            }
            else
            {
                txbIDTitular.Clear();
                txbNombreTitular.Clear();
                txbNitTitular.Clear();
                txbIvaTitular.Clear();
                txbDuiTitular.Clear();
                txbGiroTitular.Clear();
                txbPaisTitular.Text = "EL SALVADOR";
            }

            txbNombreTitular.Enabled = _pactivar;
            txbPaisTitular.Enabled = _pactivar;
            txbNitTitular.Enabled = _pactivar;
            txbIvaTitular.Enabled = _pactivar;
            txbDuiTitular.Enabled = _pactivar;
            txbGiroTitular.Enabled = _pactivar;
            txbPaisTitular.Enabled = _pactivar;

            txbFiltroTitular.Enabled = !_pactivar;
            btnBuscarPersona.Enabled = !_pactivar;
            splitContainer1.Panel1.Enabled = !_pactivar;
            splitContainer1.Panel2.Enabled = !_pactivar;

            txbCodigoProducto.Focus();
        }

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataRow _row = null;
                    if (txbBuscarTexto.Text.NoNOE())
                    {
                        _row = (from _item in _dtdocumentos.AsEnumerable()
                                where (_item.Field<string>("NumeroDocumento") != null && _item.Field<string>("NumeroDocumento").Equals(txbBuscarTexto.Text))
                                select _item).FirstOrDefault<DataRow>();

                        if (_row != null)
                        {
                            _documentos = new ModelosManager.CLS.DocumentosEncabezados(_row);
                            CargadorDetalle(_documentos);
                        }
                        else
                        {
                            MessageBox.Show("Documento no existe en la base de datos", "BUSCAR DOCUMENTO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        LanzarBuscadorDocumentos();
                    }
                }
                catch (Exception _err)
                {
                    Herramientas.Log.Registrar(_err.ToString());
                }
                finally
                {
                    txbBuscarTexto.Clear();
                }
            }
        }

        private void CargadorDetalle(ModelosManager.CLS.DocumentosEncabezados _encabezado)
        {
            DataTable _tabla = new DataTable();

            try
            {
                if (_encabezado.Existe)
                {
                    _detalle = new ModelosManager.CLS.DocumentosDetalle();
                    _tabla = _detalle.DetalleDocumentosPorIDDocumento(_encabezado.IDDocumento.Valor.TextoToEntero());
                    if (_tabla.Rows.Count > 0)
                    {
                        _ventas.Clear();
                        CLS.ItemVentas _item = null;
                        foreach (DataRow _row in _tabla.Rows)
                        {
                            _item = new CLS.ItemVentas(_row);
                            _ventas.Add(_item);
                        }
                    }

                    ModelosManager.CLS.PersonasNombres _elcliente = new ModelosManager.CLS.PersonasNombres(_documentos.IDPersona.Valor.TextoToEntero());
                    CargadorPersona(_elcliente);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LanzarBuscadorDocumentos();
        }

        private void LanzarBuscadorDocumentos()
        {
            try
            {
                BuscadorDocumentos _buscador = new BuscadorDocumentos(_filtro_documento);
                _buscador.ShowDialog(this);
                if (_buscador.Documento.Existe)
                {
                    _documentos = _buscador.Documento;
                    CargadorDetalle(_documentos);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void VentaTicket_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    FinalizarVenta();
                    break;
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void ImprimirDocumento(int _piddocumento = 0, string _ptipo = "", bool _pvista_previa = false)
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
                        _repo = new REPORTES.ConsumidorFinal();
                        break;
                    case "CREDITO FISCAL":
                        _repo = new REPORTES.CreditoFiscal();
                        break;
                }
                //CONFIGURAMOS EL REPORTE
                try
                {
                    _repo.SetDataSource(_tabla);
                    if (_pvista_previa == false)
                    {
                        //_repo.PrintToPrinter(1, false, 0, 0);

                        CLS.Ticket _ticket = new CLS.Ticket("ticket.txt", _tabla);
                        _ticket.Imprimir();
                    }
                    else
                    {
                        VistaPrevia _vp = new VistaPrevia(_repo);
                        _vp.ShowDialog(this);
                    }
                }
                catch (Exception _err)
                {
                    Herramientas.Log.Registrar(_err.ToString());
                }
                finally
                {
                    if (_repo != null)
                    {
                        _repo.Close();
                    }
                }
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
                if (_documentos.Existe)
                    ImprimirDocumento(_documentos.IDDocumento.Valor.TextoToEntero(), _documentos.Documento.Valor.ToString(), false);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                if (_documentos.Existe)
                    ImprimirDocumento(_documentos.IDDocumento.Valor.TextoToEntero(), _documentos.Documento.Valor.ToString(), true);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalle.ExistenFilas() > 0)
                {
                    if (MessageBox.Show("Existen items en este documento, se perderán si continúa. ¿Esta seguro de crear un nuevo documento?", "NUEVO DOCUMENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        CargarDatos();
                        LimpiarControles();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void cbbPreciosVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbCantidad.Focus();
            }
        }

        private void cbbPreciosVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbCantidad.Focus();
        }

        private void txbPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbCantidad.Focus();
            }
        }

        private void txbPrecio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double _precio = 0;
                if (!double.TryParse(txbPrecio.Text, out _precio))
                    e.Cancel = true;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
