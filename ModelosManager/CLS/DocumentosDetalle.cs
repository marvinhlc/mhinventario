using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class DocumentosDetalle : Entidad
    {
        Descriptor _IDDetalleDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDProducto = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _CodigoProducto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _NombreProducto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _CantidadEntrada = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _PrecioEntrada = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _CantidadSalida = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _PrecioSalida = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _UltimoCosto = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _FormatoVenta = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Excento = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Gravado = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _MontoIva = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _IvaRetenido = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _PagoCuenta = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Descuento = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Total = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _FechaVencimiento = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _FechaEntrega = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _IDBodega = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreBodega = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IDBodegaOrigen = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreBodegaOrigen = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDDetalleDocumento { get { return _IDDetalleDocumento; } set { _IDDetalleDocumento = value; } }
        public Descriptor IDDocumento { get { return _IDDocumento; } set { _IDDocumento = value; } }
        public Descriptor IDProducto { get { return _IDProducto; } set { _IDProducto = value; } }
        public Descriptor CodigoProducto { get { return _CodigoProducto; } set { _CodigoProducto = value; } }
        public Descriptor NombreProducto { get { return _NombreProducto; } set { _NombreProducto = value; } }
        public Descriptor CantidadEntrada { get { return _CantidadEntrada; } set { _CantidadEntrada = value; } }
        public Descriptor PrecioEntrada { get { return _PrecioEntrada; } set { _PrecioEntrada = value; } }
        public Descriptor CantidadSalida { get { return _CantidadSalida; } set { _CantidadSalida = value; } }
        public Descriptor PrecioSalida { get { return _PrecioSalida; } set { _PrecioSalida = value; } }
        public Descriptor UltimoCosto { get { return _UltimoCosto; } set { _UltimoCosto = value; } }
        public Descriptor FormatoVenta { get { return _FormatoVenta; } set { _FormatoVenta = value; } }
        public Descriptor Excento { get { return _Excento; } set { _Excento = value; } }
        public Descriptor Gravado { get { return _Gravado; } set { _Gravado = value; } }
        public Descriptor MontoIva { get { return _MontoIva; } set { _MontoIva = value; } }
        public Descriptor IvaRetenido { get { return _IvaRetenido; } set { _IvaRetenido = value; } }
        public Descriptor PagoCuenta { get { return _PagoCuenta; } set { _PagoCuenta = value; } }
        public Descriptor Descuento { get { return _Descuento; } set { _Descuento = value; } }
        public Descriptor Total { get { return _Total; } set { _Total = value; } }
        public Descriptor FechaVencimiento { get { return _FechaVencimiento; } set { _FechaVencimiento = value; } }
        public Descriptor FechaEntrega { get { return _FechaEntrega; } set { _FechaEntrega = value; } }
        public Descriptor IDBodega { get { return _IDBodega; } set { _IDBodega = value; } }
        public Descriptor NombreBodega { get { return _NombreBodega; } set { _NombreBodega = value; } }
        public Descriptor IDBodegaOrigen { get { return _IDBodegaOrigen; } set { _IDBodegaOrigen = value; } }
        public Descriptor NombreBodegaOrigen { get { return _NombreBodegaOrigen; } set { _NombreBodegaOrigen = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public DocumentosDetalle()
            : base("documentos_detalle")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public DocumentosDetalle(int _pid)
            : base("documentos_detalle")
        {
            this.Procesar(this);
            _IDDetalleDocumento.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public DocumentosDetalle(DataRow _prow)
            : base("documentos_detalle")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public int LimpiarDetalle(int _pid)
        {
            int _regs = 0;
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pIDDocumento", _pid, DataManager.TypeManager.Tipo.ENTERO);
            string _sql = @"DELETE FROM documentos_detalle
                                WHERE IDDocumento = @pIDDocumento;";

            try
            {
                _regs = _datos.Eliminar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _regs;
        }

        public DataTable DetalleDocumentosCompras(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadEntrada,
	                            a.PrecioEntrada,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
	                            (a.CantidadEntrada * a.PrecioEntrada) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'COMPRA'
                            AND YEAR(b.FechaDocumento) = @pPeriodo
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosEntradas(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadEntrada,
	                            a.PrecioEntrada,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
	                            (a.CantidadEntrada * a.PrecioEntrada) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'ENTRADA'
                            AND YEAR(b.FechaDocumento) = @pPeriodo
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosInventario(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadEntrada,
	                            a.PrecioEntrada,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
	                            (a.CantidadEntrada * a.PrecioEntrada) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'INVENTARIO'
                            AND YEAR(b.FechaDocumento) = @pPeriodo
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosSalidas(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
                                a.FormatoVenta,
	                            (a.CantidadSalida * a.PrecioSalida) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'SALIDA'
                            AND YEAR(b.FechaDocumento) = @pPeriodo
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosVentas(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
	                            (a.CantidadSalida * a.PrecioSalida) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'VENTA'
                            AND YEAR(b.FechaDocumento) = @pPeriodo
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosPorIDDocumento(int _piddocumento)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
	                            c.Categoria,
	                            c.SubCategoria,
                                a.FormatoVenta,
	                            (a.CantidadSalida * a.PrecioSalida) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND a.IDDocumento = @pIDDocumento
                            ORDER BY a.IDDetalleDocumento;";

            try
            {
                _datos.AgregarParametro("pIDDocumento", _piddocumento, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DetalleDocumentosTraslado()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
                                a.CantidadEntrada,
	                            a.UltimoCosto,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.PagoCuenta,
                                a.Descuento,
                                a.Total,
	                            a.FechaVencimiento,
                                a.FechaEntrega,
	                            a.FechaCreacion,
                                a.IDBodega,
                                a.NombreBodega,
                                a.IDBodegaOrigen,
                                a.NombreBodegaOrigen,
	                            c.Categoria,
	                            c.SubCategoria,
                                a.FormatoVenta,
	                            (a.CantidadSalida * a.PrecioSalida) as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM documentos_detalle a,
		                            documentos_encabezados b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = c.IDProducto
                            AND b.Operacion = 'TRASLADO'
                            ORDER BY a.CantidadSalida DESC;";

            try
            {
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

    }
}
