using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class ProductoNombres : EntityManager.Entidad
    {
        Descriptor _IDProducto = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _CodigoProducto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _NombreProducto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Categoria = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _SubCategoria = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Presentacion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FormatoVenta = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _PrecioVenta = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio1 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio2 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio3 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio4 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio5 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio6 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio7 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio8 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Precio9 = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _UltimoCosto = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Existencia = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _EsGravado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _PagoCuenta = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _TasaIVA = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Descontinuado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _PuntoVenta = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _EsServicio = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaDescontinuado = new Descriptor(DataManager.TypeManager.Tipo.DATETIME);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDProducto { get { return _IDProducto; } set { _IDProducto = value; } }
        public Descriptor CodigoProducto { get { return _CodigoProducto; } set { _CodigoProducto = value; } }
        public Descriptor NombreProducto { get { return _NombreProducto; } set { _NombreProducto = value; } }
        public Descriptor Categoria { get { return _Categoria; } set { _Categoria = value; } }
        public Descriptor SubCategoria { get { return _SubCategoria; } set { _SubCategoria = value; } }
        public Descriptor Presentacion { get { return _Presentacion; } set { _Presentacion = value; } }
        public Descriptor FormatoVenta { get { return _FormatoVenta; } set { _FormatoVenta = value; } }
        public Descriptor PrecioVenta { get { return _PrecioVenta; } set { _PrecioVenta = value; } }
        public Descriptor Precio1 { get { return _Precio1; } set { _Precio1 = value; } }
        public Descriptor Precio2 { get { return _Precio2; } set { _Precio2 = value; } }
        public Descriptor Precio3 { get { return _Precio3; } set { _Precio3 = value; } }
        public Descriptor Precio4 { get { return _Precio4; } set { _Precio4 = value; } }
        public Descriptor Precio5 { get { return _Precio5; } set { _Precio5 = value; } }
        public Descriptor Precio6 { get { return _Precio6; } set { _Precio6 = value; } }
        public Descriptor Precio7 { get { return _Precio7; } set { _Precio7 = value; } }
        public Descriptor Precio8 { get { return _Precio8; } set { _Precio8 = value; } }
        public Descriptor Precio9 { get { return _Precio9; } set { _Precio9 = value; } }
        public Descriptor UltimoCosto { get { return _UltimoCosto; } set { _UltimoCosto = value; } }
        public Descriptor Existencia { get { return _Existencia; } set { _Existencia = value; } }
        public Descriptor EsGravado { get { return _EsGravado; } set { _EsGravado = value; } }
        public Descriptor PagoCuenta { get { return _PagoCuenta; } set { _PagoCuenta = value; } }
        public Descriptor TasaIVA { get { return _TasaIVA; } set { _TasaIVA = value; } }
        public Descriptor Descontinuado { get { return _Descontinuado; } set { _Descontinuado = value; } }
        public Descriptor PuntoVenta { get { return _PuntoVenta; } set { _PuntoVenta = value; } }
        public Descriptor EsServicio { get { return _EsServicio; } set { _EsServicio = value; } }
        public Descriptor FechaDescontinuado { get { return _FechaDescontinuado; } set { _FechaDescontinuado = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public ProductoNombres()
            : base("producto_nombres")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public ProductoNombres(int _pid)
            : base("producto_nombres")
        {
            this.Procesar(this);
            _IDProducto.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public ProductoNombres(DataRow _prow)
            : base("producto_nombres")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        //CARGAR DATOS POR CODIGO
        public ProductoNombres(string _pcodigo)
            : base("producto_nombres")
        {
            this.Procesar(this);
            ProductoPorCodigo(_pcodigo);
        }

        public DataTable ProductoPorCodigo(string _pcodigo)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
                                a.Precio7,a.Precio8,a.Precio9,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.EsServicio,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM producto_nombres a
                            WHERE a.CodigoProducto = @pCodigo
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pCodigo", _pcodigo, DataManager.TypeManager.Tipo.STRING);
                _tabla = _bd.Consultar(_sql);
                if (_tabla.Rows.Count > 0)
                {
                    Rellenar(_tabla.Rows[0]);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable TodoServicios()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
                                a.Precio7,a.Precio8,a.Precio9,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM producto_nombres a
                            WHERE a.PuntoVenta = 'SI'
                            AND a.Categoria = 'SERVICIOS'
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable TodoFullBusqueda(bool _ppuntoventa = false)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM producto_nombres a
                            WHERE a.PuntoVenta = 'SI'
                            ORDER BY a.NombreProducto;";
            try
            {
                if (_ppuntoventa == false)
                {
                    _sql = _sql.Replace("WHERE a.PuntoVenta = 'SI'", "");
                }
                _bd.LimpiarParametro();
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable TodoPuntoVenta()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM producto_nombres a
                            WHERE a.PuntoVenta = 'SI'
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable TodoPuntoVenta(int _pidbodega)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                b.IDBodega,
	                            b.NombreBodega,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda,
                                SUM(b.CantidadEntrada)-SUM(b.CantidadSalida) AS ExistenciaActual
                            FROM producto_nombres a,
                            		documentos_detalle b
                            WHERE a.PuntoVenta = 'SI'
                            AND a.IDProducto = b.IDProducto
                            AND b.IDBodega = @pIDBodegaSalida
                            GROUP BY b.IDBodega,a.IDProducto
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDBodegaSalida", _pidbodega, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public double CalcularExistencia()
        {
            double _existencia = 0;
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                             a.IDProducto,
	                             a.CodigoProducto,
	                             a.NombreProducto,
	                             a.Categoria,
	                             a.SubCategoria, 
	                             IFNULL((SELECT SUM(c.CantidadEntrada - c.CantidadSalida)
					                            FROM documentos_detalle c, documentos_encabezados d
					                            WHERE c.IDDocumento = d.IDDocumento 
					                            AND c.IDProducto = a.IDProducto),0) AS Existencias
                            FROM producto_nombres a
                            WHERE a.IDProducto = @pIDProducto
                            ORDER BY a.Categoria,a.SubCategoria,a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDProducto", IDProducto.Valor, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
                _existencia = Convert.ToDouble(_tabla.Rows[0]["Existencias"]);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _existencia;
        }

        public DataTable EscalaPrecios()
        {
            ProductoPrecios _precios = new ProductoPrecios();
            return _precios.Todo(string.Format("IDProducto = {0}", _IDProducto.Valor), "IDEscala");
        }

        public double ObtenerPrecio(double _pescala)
        {
            double _el_precio = 0;
            ProductoPrecios _precios;
            _precios = new ModelosManager.CLS.ProductoPrecios(Convert.ToInt32(IDProducto.Valor), _pescala);
            if (_precios.Existe)
                _el_precio = Convert.ToDouble(_precios.Precio.Valor);
            else
                _el_precio = Convert.ToDouble(_PrecioVenta.Valor);

            return _el_precio;
        }

        public DataTable ProductosPorPrecioCliente(string _pprecio)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.PrecioVenta,
	                            a.Precio1,
	                            a.Precio2,
	                            a.Precio3,
                                a.Precio4,
                                a.Precio5,
                                a.Precio6,
                                (CASE @pPrecio
                               	    WHEN 'PRECIO 1' THEN a.Precio1
                               	    WHEN 'PRECIO 2' THEN a.Precio2
                               	    WHEN 'PRECIO 3' THEN a.Precio3
                               	    WHEN 'PRECIO 4' THEN a.Precio4
                                    WHEN 'PRECIO 5' THEN a.Precio5
                                    WHEN 'PRECIO 6' THEN a.Precio6
                               	    ELSE 0 END) AS PrecioActual,
                               (a.PrecioVenta * 0) AS PrecioEditable,
                               @pPrecio AS NombrePrecioEditable,
	                            a.UltimoCosto,
	                            a.Existencia,
	                            a.EsGravado,
	                            a.PagoCuenta,
	                            a.TasaIVA,
	                            a.Descontinuado,
	                            a.PuntoVenta,
	                            a.FechaDescontinuado,
	                            a.FechaCreacion,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda
                            FROM producto_nombres a
                            WHERE a.PuntoVenta = 'SI'
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pPrecio", _pprecio, DataManager.TypeManager.Tipo.STRING);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable InventarioGeneral(int _pidbodega, string _pfechainicio, string _pfechafinal)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.FormatoVenta,
	                            a.UltimoCosto,
                                b.IDBodega,
	                            b.NombreBodega,
	                            SUM(b.CantidadEntrada) AS Entradas,
	                            SUM(b.CantidadSalida) AS Salidas,
                                SUM(b.CantidadEntrada)-SUM(b.CantidadSalida) AS ExistenciaActual
                            FROM producto_nombres a,
                            		documentos_detalle b,
                            		documentos_encabezados c
                            WHERE a.IDProducto = b.IDProducto
                            AND b.IDDocumento = c.IDDocumento
                            AND b.IDBodega = @pIDBodega
                            AND c.FechaDocumento BETWEEN @pFechaInicial AND @pFechaFinal
                            GROUP BY b.IDBodega,a.IDProducto
                            ORDER BY a.NombreProducto;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDBodega", _pidbodega, DataManager.TypeManager.Tipo.ENTERO);
                _bd.AgregarParametro("pFechaInicial", _pfechainicio, DataManager.TypeManager.Tipo.DATE);
                _bd.AgregarParametro("pFechaFinal", _pfechafinal, DataManager.TypeManager.Tipo.DATE);

                //CONTROL DE FILTROS
                if (_pidbodega == 0)
                    _sql = _sql.Replace("AND b.IDBodega = @pIDBodega", "");
                if (string.IsNullOrEmpty(_pfechainicio) || string.IsNullOrEmpty(_pfechafinal))
                    _sql = _sql.Replace("AND c.FechaDocumento BETWEEN @pFechaInicial AND @pFechaFinal", "");

                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable Kardex(int _pidbodega, string _pfechainicio, string _pfechafinal, int _pidproducto)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            b.NumeroDocumento,
	                            b.FechaDocumento,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            IFNULL(SUM(a.CantidadEntrada),0) AS CantidadEntrada,
	                            a.PrecioEntrada,
	                            IFNULL(SUM(a.CantidadSalida),0) AS CantidadSalida,
	                            a.PrecioSalida,
	                            (1.0000*0) AS Existencias,
                                (1.0000*0) AS ValorExistencias,
	                            a.UltimoCosto,
	                            a.FormatoVenta,
	                            a.IDBodega,
	                            a.NombreBodega,
	                            'SALDO INICIAL' AS Descripcion
                            FROM documentos_detalle a,
		                            documentos_encabezados b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = @pIDProducto
                            AND a.IDBodega = @pIDBodega
                            AND b.FechaDocumento BETWEEN @pFechaInicial AND @pFechaFinal
                            AND b.Operacion = 'INVENTARIO'
                            GROUP BY a.IDProducto

                            UNION

                            SELECT 
	                            a.IDDetalleDocumento,
	                            a.IDDocumento,
	                            b.NumeroDocumento,
	                            b.FechaDocumento,	
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadEntrada,
	                            a.PrecioEntrada,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
	                            (1.0000*0) AS Existencias,
                                (1.0000*0) AS ValorExistencias,
	                            a.UltimoCosto,
	                            a.FormatoVenta,
	                            a.IDBodega,
	                            a.NombreBodega,	
	                            'MOVIMIENTOS' AS Descripcion	
                            FROM documentos_detalle a,
		                            documentos_encabezados b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDProducto = @pIDProducto
                            AND a.IDBodega = @pIDBodega
                            AND b.FechaDocumento BETWEEN @pFechaInicial AND @pFechaFinal
                            AND b.Operacion NOT IN ('INVENTARIO')
                            ORDER BY 4 ASC;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDBodega", _pidbodega, DataManager.TypeManager.Tipo.ENTERO);
                _bd.AgregarParametro("pFechaInicial", _pfechainicio, DataManager.TypeManager.Tipo.DATE);
                _bd.AgregarParametro("pFechaFinal", _pfechafinal, DataManager.TypeManager.Tipo.DATE);
                _bd.AgregarParametro("pIDProducto", _pidproducto, DataManager.TypeManager.Tipo.ENTERO);

                //CONTROL DE FILTROS
                if (_pidbodega == 0)
                    _sql = _sql.Replace("AND a.IDBodega = @pIDBodega", "");
                if (string.IsNullOrEmpty(_pfechainicio) || string.IsNullOrEmpty(_pfechafinal))
                    _sql = _sql.Replace("AND b.FechaDocumento BETWEEN @pFechaInicial AND @pFechaFinal", "");
                if(_pidproducto == 0)
                    _sql = _sql.Replace("AND a.IDProducto = @pIDProducto", "");

                _tabla = _bd.Consultar(_sql);

                //PROCESAR SALDOS
                if (_tabla.Rows.Count > 0)
                {
                    double _existencia_inicial = 0;
                    double _existencia_actual = 0;
                    double _costo = 0;
                    foreach (DataRow _row in _tabla.Rows)
                    {
                        if (_row["Descripcion"].ToString() == "SALDO INICIAL")
                        {
                            _existencia_inicial = (Convert.ToDouble(_row["CantidadEntrada"]) - Convert.ToDouble(_row["CantidadSalida"]));
                            _existencia_actual = _existencia_inicial;
                        }
                        else
                        {
                            _existencia_actual = _existencia_actual + (Convert.ToDouble(_row["CantidadEntrada"]) - Convert.ToDouble(_row["CantidadSalida"]));
                        }
                        _costo = (_existencia_actual * Convert.ToDouble(_row["UltimoCosto"]));
                        _row["Existencias"] = _existencia_actual;
                        _row["ValorExistencias"] = _costo;
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
    }
}
