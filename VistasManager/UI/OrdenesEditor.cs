using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using ModelosManager;
using EntityManager;
using System.IO;

namespace VistasManager.UI
{
    public partial class OrdenesEditor : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.Ordenes _costura = new ModelosManager.CLS.Ordenes();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();
        DataBase _db = new DataBase();

        Sesion.CLS.ConfigApp _configapp = new Sesion.CLS.ConfigApp();

        CLS.ListaVentas _ventas = new CLS.ListaVentas();
        List<ModelosManager.CLS.OrdenesImagenes> _imagenes = new List<ModelosManager.CLS.OrdenesImagenes>();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        int _inicioMultiplicador = 1;

        public OrdenesEditor(int _pidorden = 0)
        {
            InitializeComponent();

            _bodega = new ModelosManager.CLS.BodegasNombres(_configapp.ID_BODEGA_SALIDA);
            _costura = new ModelosManager.CLS.Ordenes(_pidorden);
            if (_costura.Existe)
                CargarControles();
            else
                IniciarControles();
        }

        private void IniciarControles()
        {
            try
            {
                _ventas.Clear();
                _imagenes.Clear();

                txbIDOrden.Clear();
                txbNumeroOrden.Clear();
                txbNombreCliente.Clear();
                txbTipoPrenda.Clear();
                txbNombreInstitucion.Clear();
                txbTelefono.Clear();
                txbComentario.Clear();
                txbSuperiorHombro.Clear();
                txbSuperiorPecho.Clear();
                txbSuperiorCintura.Clear();
                txbSuperiorBase.Clear();
                txbSuperiorLargo.Clear();
                txbSuperiorLargoManga.Clear();
                txbSuperiorSiza.Clear();
                txbSuperiorPinsa.Clear();
                txbSuperiorEscote.Clear();
                txbSuperiorLargoAtras.Clear();
                txbSuperiorPeto.Clear();
                txbInferiorCintura.Clear();
                txbInferiorBase.Clear();
                txbInferiorLargo.Clear();
                txbInferiorPierna.Clear();
                txbInferiorRodilla.Clear();
                txbInferiorRuedo.Clear();
                txbInferiorTiro.Clear();
                dtpFechaInicio.Hoy();
                dtpFechaEntrega.Hoy();
                txbCostureraSastre.Clear();
                txbVendedor.Clear();
                txbTotal.ToMonto(0);
                txbTotalFinal.ToMonto(0);
                txbAbono.ToMonto(0);
                txbSaldo.ToMonto(0);
                ckbActivarMultiplicar.Checked = false;
                txbMultiplicador.Value = _inicioMultiplicador;
                txbMultiplicador.Enabled = false;
                lblEstado.Text = "PENDIENTE";

                if (doRefrescarFormularioExterno != null)
                    doRefrescarFormularioExterno();

                txbNombreCliente.Select();
                this.ActiveControl = txbNombreCliente;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            int _key = 0;
            int _conteo = 0;
            string _token = string.Empty;
            bool _ok = false;
            StringBuilder _presql = new StringBuilder();

            try
            {
                if (RecolectarDatos())
                {
                    //INICIAMOS LA TRANSACCION
                    EntityManager.Transaccion _transac = new EntityManager.Transaccion();

                    if (_costura.Existe)
                    {
                        _presql.AppendFormat(@"DELETE FROM ordenes WHERE IDOrden = {0};", _costura.IDOrden.Valor.TextoToEntero());
                        _transac.AnexarPreSql(_presql.ToString());
                    }
                    else
                    {
                        //OBTENEMOS EL TOKEN DE COSTURA
                        _costura.NumeroOrden.Valor = _configapp.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.COSTURA);
                    }

                    if (_transac.AnexarMaestro(_costura))
                    {
                        foreach (CLS.ItemVentas _item in _ventas)
                        {
                            ModelosManager.CLS.OrdenesDetalle _nuevo = new ModelosManager.CLS.OrdenesDetalle();
                            _nuevo.IDProducto.Valor = _item.IDProducto;
                            _nuevo.CodigoProducto.Valor = _item.CodigoProducto;
                            _nuevo.NombreProducto.Valor = _item.NombreProducto;
                            _nuevo.CantidadEntrada.Valor = 0;
                            _nuevo.PrecioEntrada.Valor = 0;
                            _nuevo.CantidadSalida.Valor = _item.Cantidad;
                            _nuevo.PrecioSalida.Valor = _item.Precio;
                            _nuevo.UltimoCosto.Valor = _item.Costo;
                            _nuevo.IDBodega.Valor = _item.IDBodega;
                            _nuevo.NombreBodega.Valor = _item.NombreBodega;
                            _nuevo.FormatoVenta.Valor = _item.FormatoVenta;
                            _nuevo.IvaRetenido.Valor = _item.IvaRetenido;
                            _nuevo.PagoCuenta.Valor = _item.PagoCuenta;
                            _nuevo.Descuento.Valor = _item.Descuento;
                            _nuevo.MontoIva.Valor = _item.MontoIva;
                            _nuevo.Gravado.Valor = _item.Total;
                            _nuevo.FechaEntrega.Valor = _item.FechaEntrega.ToString();

                            if (_transac.AnexarDetalle(_nuevo))
                                _conteo++;
                        }

                        if (_imagenes.Count > 0)
                        {
                            foreach (ModelosManager.CLS.OrdenesImagenes _img in _imagenes)
                            {
                                _transac.AnexarDetalle(_img);
                            }
                        }

                        if (_transac.Procesar("IDOrden") > 0)
                        {
                            _costura.IDOrden.Valor = _transac.UltimoID;

                            //INCREMENTAMOS EL CONTADOR DEL TOKEN
                            _configapp.AceptarToken(Sesion.CLS.ConfigApp.TIPO_TOKEN.COSTURA);
                            _ok = true;

                            //CREAMOS EL TICKET DE VENTA E IMPRIMIMOS EL TICKET
                            CrearTicketVenta();
                        }
                    }

                    if (_ok)
                    {
                        IniciarControles();
                        MessageBox.Show("Los datos se guardaron correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private Boolean RecolectarDatos()
        {
            Boolean _ok = false;

            try
            {
                _costura.IDOrden.Valor = txbIDOrden.Text.TextoToEntero();
                if (_cliente.Existe)
                    _costura.IDCliente.Valor = _cliente.IDPersona.Valor;

                _costura.NumeroOrden.Valor = txbNumeroOrden.Text;
                _costura.NombreCliente.Valor = txbNombreCliente.Text;
                _costura.TipoPrenda.Valor = txbTipoPrenda.Text;
                _costura.Institucion.Valor = txbNombreInstitucion.Text;
                _costura.TelefonoCliente.Valor = txbTelefono.Text;
                _costura.comentario.Valor = txbComentario.Text;
                _costura.superior_hombro.Valor = txbSuperiorHombro.Text;
                _costura.superior_pecho.Valor = txbSuperiorPecho.Text;
                _costura.superior_cintura.Valor = txbSuperiorCintura.Text;
                _costura.superior_base.Valor = txbSuperiorBase.Text;
                _costura.superior_largo.Valor = txbSuperiorLargo.Text;
                _costura.superior_largo_manga.Valor = txbSuperiorLargoManga.Text;
                _costura.superior_sisa.Valor = txbSuperiorSiza.Text;
                _costura.superior_pinsa.Valor = txbSuperiorPinsa.Text;
                _costura.superior_escote.Valor = txbSuperiorEscote.Text;
                _costura.superior_largo_atras.Valor = txbSuperiorLargoAtras.Text;
                _costura.superior_peto.Valor = txbSuperiorPeto.Text;
                _costura.inferior_cintura.Valor = txbInferiorCintura.Text;
                _costura.inferior_base.Valor = txbInferiorBase.Text;
                _costura.inferior_largo.Valor = txbInferiorLargo.Text;
                _costura.inferior_pierna.Valor = txbInferiorPierna.Text;
                _costura.inferior_rodillo.Valor = txbInferiorRodilla.Text;
                _costura.inferior_ruedo.Valor = txbInferiorRuedo.Text;
                _costura.inferior_tiro.Valor = txbInferiorTiro.Text;
                _costura.fecha_inicio.Valor = dtpFechaInicio.Value.FechaParaMySQL();
                _costura.fecha_entrega.Valor = dtpFechaEntrega.Value.FechaParaMySQL();
                _costura.costurera_sastre.Valor = txbCostureraSastre.Text;
                _costura.vendedor.Valor = txbVendedor.Text;
                _costura.total.Valor = txbTotalFinal.Text.TextoToDouble();
                _costura.abono.Valor = txbAbono.Text.TextoToDouble();
                _costura.saldo.Valor = txbSaldo.Text.TextoToDouble();
                _costura.estado.Valor = lblEstado.Text;
                _costura.descuento.Valor = txbDescuento.Text.ToDouble();
                _costura.multiplicador.Valor = txbMultiplicador.Value.ToEntero();

                _ok = _costura.Validar();

                if (_ok == false)
                    MessageBox.Show("Los datos no son validos. Complete la información correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogoBuscadorProductos();
        }

        private void DialogoBuscadorProductos()
        {
            try
            {
                BuscadorVarios _buscador = new BuscadorVarios(CLS.Enumeraciones.DIALOGO.TIPO_PRENDA);
                _buscador.ShowDialog(this);
                if (_buscador.Prendas != null)
                {
                    txbTipoPrenda.Text = _buscador.Prendas.NombrePrenda.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarIDOrden_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ModelosManager.CLS.Ordenes _buscada = new ModelosManager.CLS.Ordenes(txbBuscarIDOrden.Text);
                    if (_buscada.Existe)
                    {
                        _costura = _buscada;
                        txbBuscarIDOrden.Clear();
                        CargarControles();
                    }
                    else
                    {
                        MessageBox.Show("No existe en la base de datos la orden solicitada", "BUSCAR ORDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void CargarControles()
        {
            DataTable _dtdetalle = new DataTable();

            try
            {
                if (_costura.Existe)
                {
                    _ventas.Clear();
                    _dtdetalle = _costura.Detalle();
                    foreach (DataRow _row in _dtdetalle.Rows)
                    {
                        CLS.ItemVentas _nuevo = new CLS.ItemVentas(_row);
                        _ventas.Add(_nuevo);
                    }

                    dgvDetalle.AutoGenerateColumns = false;
                    dgvDetalle.DataSource = _ventas;
                }

                txbIDOrden.Text = _costura.IDOrden.Valor.ToString();
                txbNumeroOrden.Text = _costura.NumeroOrden.Valor.ToString();
                txbNombreCliente.Text = _costura.NombreCliente.Valor.ToString();
                txbTipoPrenda.Text = _costura.TipoPrenda.Valor.ToString();
                txbNombreInstitucion.Text = _costura.Institucion.Valor.ToString();
                txbTelefono.Text = _costura.TelefonoCliente.Valor.ToString();
                txbComentario.Text = _costura.comentario.Valor.ToString();
                txbSuperiorHombro.Text = _costura.superior_hombro.Valor.ToString();
                txbSuperiorPecho.Text = _costura.superior_pecho.Valor.ToString();
                txbSuperiorCintura.Text = _costura.superior_cintura.Valor.ToString();
                txbSuperiorBase.Text = _costura.superior_base.Valor.ToString();
                txbSuperiorLargo.Text = _costura.superior_largo.Valor.ToString();
                txbSuperiorLargoManga.Text = _costura.superior_largo_manga.Valor.ToString();
                txbSuperiorSiza.Text = _costura.superior_sisa.Valor.ToString();
                txbSuperiorPinsa.Text = _costura.superior_pinsa.Valor.ToString();
                txbSuperiorEscote.Text = _costura.superior_escote.Valor.ToString();
                txbSuperiorLargoAtras.Text = _costura.superior_largo.Valor.ToString();
                txbSuperiorPeto.Text = _costura.superior_peto.Valor.ToString();
                txbInferiorCintura.Text = _costura.inferior_cintura.Valor.ToString();
                txbInferiorBase.Text = _costura.inferior_base.Valor.ToString();
                txbInferiorLargo.Text = _costura.inferior_largo.Valor.ToString();
                txbInferiorPierna.Text = _costura.inferior_pierna.Valor.ToString();
                txbInferiorRodilla.Text = _costura.inferior_rodillo.Valor.ToString();
                txbInferiorRuedo.Text = _costura.inferior_ruedo.Valor.ToString();
                txbInferiorTiro.Text = _costura.inferior_tiro.Valor.ToString();
                dtpFechaInicio.Text = _costura.fecha_inicio.Valor.ToString();
                dtpFechaEntrega.Text = _costura.fecha_entrega.Valor.ToString();
                txbCostureraSastre.Text = _costura.costurera_sastre.Valor.ToString();
                txbVendedor.Text = _costura.vendedor.Valor.ToString();
                txbTotal.Text = _costura.total.Valor.ToString();
                if (_costura.multiplicador.Valor.ToEntero() > 0)
                    ckbActivarMultiplicar.Checked = true;
                else
                    ckbActivarMultiplicar.Checked = false;
                txbMultiplicador.Value = _costura.multiplicador.Valor.ToEntero();
                txbAbono.Text = _costura.abono.Valor.ToString();
                txbSaldo.Text = _costura.saldo.Valor.ToString();
                lblEstado.Text = _costura.estado.Valor.ToString();
                if (Convert.ToDouble(_costura.descuento.Valor) > 0)
                    ckbAplicarDescuento.Checked = true;
                else
                    ckbAplicarDescuento.Checked = false;
                txbDescuento.Text = _costura.descuento.Valor.ToString();
                txbTotalFinal.Text = _costura.total.Valor.ToString();

                this.ActiveControl = txbNombreCliente;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnDialogoClientes_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorPersonas _buscador = new BuscadorPersonas(BuscadorPersonas.RolPersona.CLIENTES);
                _buscador.ShowDialog(this);
                if (_buscador.Persona.Existe)
                {
                    txbNombreCliente.Text = _buscador.Persona.NombrePersona.Valor.ToString();
                    _cliente = _buscador.Persona;
                    _cliente.Existe = true;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnDialogoInstitucion_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorVarios _buscador = new BuscadorVarios(CLS.Enumeraciones.DIALOGO.INSTITUCION);
                _buscador.ShowDialog(this);
                if (_buscador.Institutos != null)
                {
                    txbNombreInstitucion.Text = _buscador.Institutos.NombreInstitucion.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnDialogoCostureraSastre_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorVarios _buscador = new BuscadorVarios(CLS.Enumeraciones.DIALOGO.COSTURERA_SASTRE);
                _buscador.ShowDialog(this);
                if (_buscador.Personas != null)
                {
                    txbCostureraSastre.Text = _buscador.Personas.NombrePersona.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnDialogoVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorVarios _buscador = new BuscadorVarios(CLS.Enumeraciones.DIALOGO.VENDEDOR);
                _buscador.ShowDialog(this);
                if (_buscador.Vendedores != null)
                {
                    txbVendedor.Text = _buscador.Vendedores.NombreVendedor.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorProductos _buscador = new BuscadorProductos();
                _buscador.ShowDialog(this);
                if (_buscador.Producto != null)
                {
                    _producto = _buscador.Producto;
                    if (_producto.EsServicio.Valor.Equals("SI"))
                    {
                        txbPrecio.Enabled = true;
                        txbPrecio.Text.CeroToTexto();
                        txbPrecio.Focus();
                    }
                    else
                    {
                        lblNombreProducto.Text = _producto.NombreProducto.Valor.ToString();

                        VentaListaPrecios _precios = new VentaListaPrecios(_producto);
                        _precios.ShowDialog(this);
                        if (_precios.Precio_actual > 0)
                            txbPrecio.Text = _precios.Precio_actual.ToString("N4");

                        txbCantidad.Focus();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_producto.Existe)
                {
                    CLS.ItemVentas _item = new CLS.ItemVentas();
                    _item.IDProducto = _producto.IDProducto.Valor.TextoToEntero();
                    _item.CodigoProducto = _producto.CodigoProducto.Valor.ToString();
                    _item.NombreProducto = _producto.NombreProducto.Valor.ToString();
                    _item.Precio = txbPrecio.Text.TextoToDouble();
                    _item.Costo = _producto.UltimoCosto.Valor.TextoToDouble();
                    _item.Cantidad = txbCantidad.Text.TextoToDouble();
                    _item.IDBodega = _bodega.IDBodega.Valor.TextoToEntero();
                    _item.NombreBodega = _bodega.NombreBodega.Valor.ToString();
                    _item.FormatoVenta = _producto.FormatoVenta.Valor.ToString();
                    _item.Calcular(_producto.TasaIVA.Valor.TextoToDouble(), _producto.PagoCuenta.Valor.TextoToDouble(), _producto.EsGravado.Valor.ToString());
                    _item.Producto_cache = _producto;

                    _ventas.Add(_item);
                }

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _ventas;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                lblNombreProducto.Text = "...";
                txbCantidad.Clear();
                txbPrecio.Clear();
                txbPrecio.Enabled = false;
            }
        }

        private void GridCalcularDatos()
        {
            double _total = 0;
            double _iva = 0;
            double _gravado = 0;
            double _subtotal = 0;
            double _saldo = 0;
            double _excento = 0;
            double _descuento = 0;
            int _multiplicador = 0;
            bool _aplicar_descuento = false;
            try
            {
                _aplicar_descuento = ckbAplicarDescuento.Checked;
                _multiplicador = _costura.multiplicador.Valor.ToEntero();
                foreach (DataGridViewRow _row in dgvDetalle.Rows)
                {
                    CLS.ItemVentas _item = _row.DataBoundItem as CLS.ItemVentas;
                    _item.Aplicar_descuento = _aplicar_descuento;
                    _item.Calcular();

                    _descuento = _descuento + _item.Descuento;
                    _total = _total + _item.Total;
                    _iva = _iva + _item.IvaRetenido;
                    _gravado = _gravado + (_item.Total - _item.IvaRetenido);
                    _excento = 0;
                    _subtotal = (_gravado + _iva);
                }

                _saldo = (((_total - _descuento) * _multiplicador) - txbAbono.Text.TextoToDouble());
                txbDescuento.Text = string.Format("{0:N2}", _descuento);
                txbTotal.Text = string.Format("{0:N2}", _total);
                txbTotalFinal.Text = string.Format("{0:N2}", _total - _descuento);
                txbSaldo.Text = string.Format("{0:N2}", _saldo);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridCalcularDatos();
        }

        private void txbCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAgregarItem.PerformClick();
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
                    if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_DETALLE_DOCUMENTO_VENTAS, false))
                    {
                        if (MessageBox.Show("¿Esta seguro de eliminar el item?", "ELIMINAR ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            DataGridViewRow _row = dgvDetalle.CurrentRow;
                            CLS.ItemVentas _item = _row.DataBoundItem as CLS.ItemVentas;
                            if (_ventas.Remove(_item))
                            {
                                MessageBox.Show("Item fué eliminado correctamente", "ELIMINAR ITEM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //this.ActiveControl = txbCodigoProducto;
                            }
                        }
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void lblEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Cambiar el estado?", "ESTADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_costura.estado.Valor.Equals("PENDIENTE"))
                        _costura.estado.Valor = "ENTREGADO";
                    else
                        _costura.estado.Valor = "PENDIENTE";
                    lblEstado.Text = _costura.estado.Valor.ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbCantidad.Focus();
        }

        private void CalcularTotalVenta()
        {
            try
            {
                //int _multiplicador = txbMultiplicador.Value.ToEntero();
                //double _saldo = ((txbTotal.Text.TextoToDouble() * _multiplicador) - txbAbono.Text.TextoToDouble());
                //txbSaldo.Text = string.Format("{0:N2}", _saldo);
                _costura.multiplicador.Valor = txbMultiplicador.Value.ToEntero();
                GridCalcularDatos();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }            
        }

        private void txbAbono_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalVenta();
        }

        private void txbMultiplicador_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotalVenta();
        }

        #region CREAR_TICKET
        private void CrearTicketVenta()
        {
            int _conteo = 0;
            double _total = 0;
            double _saldo = 0;
            double _abono = 0;
            string _token = string.Empty;
            StringBuilder _presql = new StringBuilder();
            bool _clienteOk = true;
            CLS.Enumeraciones.FORMA_PAGO _formaPago = CLS.Enumeraciones.FORMA_PAGO.CONTADO;

            try
            {
                EntityManager.Transaccion _transac = new Transaccion();
                _clienteOk = _cliente.Existe;
                if (_clienteOk && _ventas.Count > 0)
                {
                    _total = txbTotal.Text.TextoToDouble();
                    _abono = txbAbono.Text.TextoToDouble();
                    _saldo = txbSaldo.Text.TextoToDouble();

                    if (_saldo > 0)
                        _formaPago = CLS.Enumeraciones.FORMA_PAGO.CREDITO;

                    ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
                    _token = _configapp.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET);

                    _documento.NumeroDocumento.Valor = _token;
                    _documento.FechaDocumento.Valor = DateTime.Now.FechaParaMySQL();
                    _documento.FormaPago.Valor = _formaPago;
                    _documento.DiasPlazo.Valor = 0;
                    _documento.Operacion.Valor = "VENTA";
                    _documento.Documento.Valor = "TICKET";
                    _documento.IDPersona.Valor = _cliente.IDPersona.Valor;
                    _documento.NombreTitular.Valor = _cliente.NombrePersona.Valor;
                    _documento.Estado.Valor = "APLICADO";
                    _documento.Comentario.Valor = string.Format("Generado por COSTURA # {0}, ID {1}", _costura.NumeroOrden.Valor, _costura.IDOrden.Valor);

                    if (_transac.AnexarMaestro(_documento))
                    {
                        //ANEXAMOS UN DETALLE
                        ModelosManager.CLS.DocumentosLog _log = new ModelosManager.CLS.DocumentosLog();
                        _log.IDUsuario.Valor = _sesion.USUARIO.IDUsuario.Valor;
                        _log.Estacion.Valor = _configapp.ESTACION_ID.ToString();
                        _log.TotalVenta.Valor = _total;
                        _log.Efectivo.Valor = _abono;
                        _log.Cambio.Valor = 0;
                        _log.Saldo.Valor = _saldo;

                        if (_transac.AnexarDetalle(_log))
                        {
                            ModelosManager.CLS.DocumentosOrdenes _dorden = new ModelosManager.CLS.DocumentosOrdenes();
                            _dorden.IDDocumento.Valor = _documento.IDDocumento.Valor;
                            _dorden.IDOrden.Valor = _costura.IDOrden.Valor;

                            _transac.AnexarDetalle(_dorden);

                            foreach (CLS.ItemVentas _item in _ventas)
                            {
                                ModelosManager.CLS.DocumentosDetalle _nuevo = new ModelosManager.CLS.DocumentosDetalle();
                                _nuevo.IDDocumento.Valor = _documento.IDDocumento.Valor;
                                _nuevo.IDProducto.Valor = _item.IDProducto;
                                _nuevo.CodigoProducto.Valor = _item.CodigoProducto;
                                _nuevo.NombreProducto.Valor = _item.NombreProducto;
                                _nuevo.CantidadEntrada.Valor = 0;
                                _nuevo.PrecioEntrada.Valor = 0;
                                _nuevo.CantidadSalida.Valor = _item.Cantidad;
                                _nuevo.PrecioSalida.Valor = _item.Precio;
                                _nuevo.UltimoCosto.Valor = _item.Costo;
                                _nuevo.IDBodega.Valor = _item.IDBodega;
                                _nuevo.NombreBodega.Valor = _item.NombreBodega;
                                _nuevo.FormatoVenta.Valor = _item.FormatoVenta;
                                _nuevo.IvaRetenido.Valor = _item.IvaRetenido;
                                _nuevo.PagoCuenta.Valor = _item.PagoCuenta;
                                _nuevo.MontoIva.Valor = _item.MontoIva;
                                _nuevo.Gravado.Valor = _item.Total;
                                _nuevo.Descuento.Valor = _item.Descuento;
                                _nuevo.FechaEntrega.Valor = _item.FechaEntrega.ToString();

                                if (_transac.AnexarDetalle(_nuevo))
                                    _conteo++;
                            }
                        }

                        if (_conteo > 0)
                        {
                            if (_transac.Procesar("IDDocumento") > 0)
                            {
                                _documento.IDDocumento.Valor = _transac.UltimoID;
                                _documento.Existe = true;

                                ImprimirDocumento(
                                    _documento.IDDocumento.Valor.TextoToEntero(),
                                    _documento.Documento.Valor.ToString()
                                    );
                            }
                        }
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
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
        #endregion

        private void txbNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbTipoPrenda.Focus();
        }

        private void txbTipoPrenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbNombreInstitucion.Focus();
        }

        private void txbNombreInstitucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbTelefono.Focus();
        }

        private void txbTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbComentario.Focus();
        }

        private void txbComentario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorHombro.Focus();
        }

        private void txbSuperiorHombro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorPecho.Focus();
        }

        private void txbSuperiorPecho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorCintura.Focus();
        }

        private void txbSuperiorCintura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorBase.Focus();
        }

        private void txbSuperiorBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorLargo.Focus();
        }

        private void txbSuperiorLargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorLargoManga.Focus();
        }

        private void txbSuperiorLargoManga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorSiza.Focus();
        }

        private void txbSuperiorSiza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorPinsa.Focus();
        }

        private void txbSuperiorPinsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorEscote.Focus();
        }

        private void txbSuperiorEscote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorLargoAtras.Focus();
        }

        private void txbSuperiorLargoAtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbSuperiorPeto.Focus();
        }

        private void txbSuperiorPeto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorCintura.Focus();
        }

        private void txbInferiorCintura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorBase.Focus();
        }

        private void txbInferiorBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorLargo.Focus();
        }

        private void txbInferiorLargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorPierna.Focus();
        }

        private void txbInferiorPierna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorRodilla.Focus();
        }

        private void txbInferiorRodilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorRuedo.Focus();
        }

        private void txbInferiorRuedo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbInferiorTiro.Focus();
        }

        private void txbInferiorTiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpFechaInicio.Focus();
        }

        private void dtpFechaInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpFechaEntrega.Focus();
        }

        private void dtpFechaEntrega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbCostureraSastre.Focus();
        }

        private void txbCostureraSastre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbVendedor.Focus();
        }

        private void txbVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txbAbono.Focus();
        }

        private void ckbActivarMultiplicar_CheckedChanged(object sender, EventArgs e)
        {
            txbMultiplicador.Enabled = ckbActivarMultiplicar.Checked;
            txbMultiplicador.Focus();
        }

        private void txbTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalVenta();
        }

        private void ckbAplicarDescuento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridCalcularDatos();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
