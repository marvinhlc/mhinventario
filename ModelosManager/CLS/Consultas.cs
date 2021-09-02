using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class Consultas
    {

        public static DataTable ReporteCosturaProduccion(string _pfechaini, string _pfechafin, string _pestado, string _pcosturerasastre)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pEstado", _pestado, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pPersona", _pcosturerasastre, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                         a.IDOrden,
	                         a.NumeroOrden,
	                         a.NombreCliente,
	                         a.TipoPrenda,
	                         a.Institucion,
	                         a.TelefonoCliente,
	                         a.fecha_inicio,
	                         a.fecha_entrega,
	                         a.costurera_sastre,
	                         a.vendedor,
	                         a.total,
	                         a.abono,
	                         a.saldo,
	                         a.estado,
	                         a.comentario,
                             a.multiplicador
                        FROM ordenes a
                        WHERE a.fecha_entrega BETWEEN @pFechaInicio AND @pFechaFinal
                        AND a.estado = @pEstado
                        AND a.costurera_sastre = @pPersona
                        ORDER BY a.costurera_sastre,a.fecha_entrega DESC;";

            try
            {
                if (string.IsNullOrEmpty(_pcosturerasastre))
                    _sql = _sql.Replace("AND a.costurera_sastre = @pPersona", "");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable ReporteGastosDetallado(string _pfechaini, string _pfechafin, string _pclasificacion)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pClasificacion", _pclasificacion, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                            a.IDGasto,
	                            a.Numero,
	                            a.Fecha,
	                            a.Clasificacion,
	                            a.Descripcion,
	                            a.Importe
                            FROM gastos a
                            WHERE a.fecha BETWEEN @pFechaInicio AND @pFechaFinal
                            AND a.Clasificacion = @pClasificacion
                            ORDER BY a.Clasificacion,a.Fecha";

            try
            {
                if (string.IsNullOrEmpty(_pclasificacion))
                    _sql = _sql.Replace("AND a.Clasificacion = @pClasificacion", "");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable ReporteGastosResumen(string _pfechaini, string _pfechafin, string _pclasificacion)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pClasificacion", _pclasificacion, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                            a.Clasificacion,
	                            MIN(a.Fecha) AS FechaMinima,
	                            MAX(a.Fecha) AS FechaMaxima,
	                            MIN(a.Numero) AS NumeroMinimo,
	                            MAX(a.Numero) AS NumeroMaximo,
	                            SUM(a.Importe) AS Sumas
                            FROM gastos a
                            WHERE a.fecha BETWEEN @pFechaInicio AND @pFechaFinal
                            AND a.Clasificacion = @pClasificacion
                            GROUP BY a.Clasificacion
                            ORDER BY a.Clasificacion;";

            try
            {
                if (string.IsNullOrEmpty(_pclasificacion))
                    _sql = _sql.Replace("AND a.Clasificacion = @pClasificacion", "");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable ReporteCostura(string _pfechaini, string _pfechafin, string _pestado)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pEstado", _pestado, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                            a.IDOrden,
	                            a.NumeroOrden,
	                            a.NombreCliente,
	                            a.TipoPrenda,
	                            a.Institucion,
	                            a.TelefonoCliente,
	                            a.fecha_inicio,
	                            a.fecha_entrega,
	                            a.costurera_sastre,
	                            a.vendedor,
	                            a.total,
	                            a.abono,
	                            a.saldo,
	                            a.estado,
	                            a.comentario
                            FROM ordenes a
                            WHERE a.fecha_entrega BETWEEN @pFechaInicio AND @pFechaFinal
                            AND a.estado = @pEstado
                            ORDER BY a.NumeroOrden;";

            try
            {
                if (string.IsNullOrEmpty(_pestado))
                    _sql = _sql.Replace("AND a.estado = @pEstado", "");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable ReporteCaja(string _pfechaini, string _pfechafin, string _pestacion)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pEstacion", _pestacion, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
                            a.IDDocumento,
                            c.Estacion,
                            a.NumeroDocumento,
                            a.FechaDocumento,
                            a.FormaPago,
                            a.Documento,
                            ROUND(SUM(b.CantidadSalida * b.PrecioSalida),2) AS Monto,
                            c.TotalVenta,
                            c.Efectivo,
                            c.Cambio,
                            c.Saldo,
                            IFNULL((SELECT SUM(p.Valor) FROM personas_pagos p WHERE p.IDDocumento = a.IDDocumento),0) AS Abonos
                            FROM documentos_encabezados a,
	                            documentos_detalle b,
		                            documentos_log c
                            WHERE a.IDDocumento = c.IDDocumento
                            AND a.IDDocumento = b.IDDocumento
                            AND c.Estacion = @pEstacion
                            AND a.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal
                            GROUP BY a.IDDocumento
                            ORDER BY a.FechaDocumento;";

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

        public static DataTable ReporteFechaEntrega(string _pfechaini, string _pfechafin)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.NombreTitular,
	                            a.Comentario,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            b.CantidadSalida,
	                            b.PrecioSalida,
	                            b.FechaEntrega,
	                            c.IDUsuario,
	                            c.Estacion,
	                            c.TotalVenta,
	                            c.Efectivo,
	                            c.Cambio,
	                            c.Saldo
                            FROM documentos_encabezados a,
		                            documentos_detalle b,
		                            documentos_log c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDDocumento = c.IDDocumento
                            AND a.Estado = 'APLICADO'
                            AND b.FechaEntrega BETWEEN @pFechaInicio AND @pFechaFinal
                            ORDER BY b.FechaVencimiento;";

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

        public static DataTable ReporteVentasCredito(string _pfechaini, string _pfechafin, string _pestado)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Estado,
	                            b.IDProducto,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            b.PrecioSalida,
	                            b.CantidadSalida,
	                            b.UltimoCosto,	   
								b.Gravado,
								b.Excento,
								SUM(ROUND(b.MontoIva,4)) AS MontoIva,
								SUM(b.IvaRetenido) AS IvaRetenido,                         
	                            SUM((b.PrecioSalida * b.CantidadSalida)) as TotalSalida,
	                            b.IDBodega,
	                            b.NombreBodega,
	                            (SELECT SUM(l.TotalVenta) FROM documentos_log l 
                                    WHERE l.IDDocumento = a.IDDocumento) AS TotalVenta,
	                            (SELECT SUM(l.Efectivo) FROM documentos_log l 
                                    WHERE l.IDDocumento = a.IDDocumento) AS Efectivo,
	                            (SELECT SUM(l.Saldo) FROM documentos_log l 
                                    WHERE l.IDDocumento = a.IDDocumento) AS Pagos,
	                            IFNULL((SELECT SUM(p.Valor) FROM personas_pagos p 
                                    WHERE p.IDDocumento = a.IDDocumento),0) AS AbonosExtra
                            FROM documentos_encabezados a,
		                            documentos_detalle b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.Operacion = 'VENTA'
                            AND a.Estado = 'APLICADO'
                            AND a.FormaPago = 'CREDITO'
                            AND a.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal
                            GROUP BY a.IDDocumento
                            HAVING TotalVenta > Pagos
                            ORDER BY a.IDDocumento,a.FechaDocumento;";

            try
            {
                if (_pestado == "PAGADO")
                    _sql = _sql.Replace("HAVING TotalVenta > Pagos", "HAVING TotalVenta = Pagos");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable ReporteGanancias(string _pfechaini, string _pfechafin, string _pcategoria, string _psubcategoria)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pCategoria", _pcategoria, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pSubcategoria", _psubcategoria, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();

            string _sql = @"SELECT 
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            IFNULL(SUM(v.CantidadSalida),0) AS Cantidad,
	                            a.UltimoCosto,
	                            IFNULL(v.PrecioSalida,0) AS PrecioSalida,
                                IFNULL(SUM(v.PrecioSalida * v.CantidadSalida),0) AS Venta
                            FROM producto_nombres a 
		                            LEFT JOIN documentos_detalle v 
				                            INNER JOIN documentos_encabezados d 
				                            ON d.IDDocumento = v.IDDocumento
				                            AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal
		                            ON v.IDProducto = a.IDProducto
		                    WHERE a.Categoria = @pCategoria
		                    AND a.SubCategoria = @pSubcategoria
                            GROUP BY a.IDProducto
                            ORDER BY a.NombreProducto;";

            try
            {
                if (_pcategoria.EsNOE())
                {
                    _sql = _sql.Replace("WHERE a.Categoria = @pCategoria", "");
                }
                if (_psubcategoria.EsNOE())
                {
                    _sql = _sql.Replace(" AND a.SubCategoria = @pSubcategoria", "");
                }

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable DocumentosParaMigrar()
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Operacion,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Comentario,
	                            a.Estado,
	                            a.FechaCreacion
                            FROM documentos_encabezados a
                            WHERE a.IDDocumento NOT IN (SELECT l.IDDocumento FROM migracion_log l)
                            ORDER BY a.FechaDocumento,a.NumeroDocumento;";

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

        public static DataTable CatalogoProductos(string _pcategoria = "TODO", string _psubcategoria = "TODO")
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pCategoria", _pcategoria, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pSubcategoria", _psubcategoria, TypeManager.Tipo.STRING);
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.PrecioVenta,
	                            a.EsGravado,
	                            a.FechaDescontinuado
                            FROM producto_nombres a
                            WHERE a.IDProducto > 0
                            AND a.Categoria = @pCategoria
                            AND a.SubCategoria = @pSubcategoria
                            ORDER BY a.Categoria,a.SubCategoria,a.NombreProducto;";

            try
            {
                if (_pcategoria == "TODO")
                {
                    _sql = _sql.Replace("AND a.Categoria = @pCategoria", "");
                }
                if (_psubcategoria == "TODO")
                {
                    _sql = _sql.Replace("AND a.SubCategoria = @pSubcategoria", "");
                }
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable HojaSalida(int _pid)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDDocumento", _pid, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Estado,
	                            b.IDProducto,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            c.PrecioVenta as PrecioSugerido,	                            
	                            b.PrecioSalida,
	                            SUM(b.CantidadSalida) AS CantidadSalida,
	                            b.UltimoCosto,	                            
	                            (b.PrecioEntrada * SUM(b.CantidadEntrada)) as TotalEntrada,
	                            (b.PrecioSalida * SUM(b.CantidadSalida)) as TotalSalida,
	                            (c.PrecioVenta * SUM(b.CantidadSalida)) as TotalSugerido,
	                            b.IDBodega,
	                            b.NombreBodega,	                            
                                c.Presentacion,
                                b.FormatoVenta
                            FROM documentos_encabezados a,
		                            documentos_detalle b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND b.IDProducto = c.IDProducto
                            AND a.IDDocumento = @pIDDocumento
                            GROUP BY b.IDProducto
                            ORDER BY a.FechaDocumento,a.IDDocumento,b.IDProducto;";
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

        public static DataTable ReporteDocumentosEntradaSalida(string _pfechaini, string _pfechafin, int _pidproveedor = 0, string _ptipo = "TODO", string _poperacion = "ENTRADA")
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.LimpiarParametro();
            _datos.AgregarParametro("pIDProveedor", _pidproveedor, TypeManager.Tipo.ENTERO);
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pTipo", _ptipo, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pOperacion", _poperacion, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Estado,
	                            b.IDProducto,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            b.PrecioEntrada,
	                            b.CantidadEntrada,
	                            b.PrecioSalida,
	                            b.CantidadSalida,
	                            b.UltimoCosto,	                            
	                            (b.PrecioEntrada * b.CantidadEntrada) as TotalEntrada,
	                            (b.Total) as TotalSalida,
	                            b.IDBodega,
	                            b.NombreBodega
                            FROM documentos_encabezados a,
		                            documentos_detalle b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.Operacion = @pOperacion
                            AND a.Estado = 'APLICADO'
                            AND a.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal
                            AND a.IDPersona = @pIDProveedor
                            AND a.Documento = @pTipo
                            ORDER BY a.FechaDocumento,a.IDDocumento;";

            try
            {
                if (_ptipo == "TODO")
                {
                    _sql = _sql.Replace("AND a.Documento = @pTipo", "");
                }
                if (_pidproveedor == 0)
                {
                    _sql = _sql.Replace("AND a.IDPersona = @pIDProveedor", "");
                }
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable DocumentoImprimir(int _pid)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDDocumento", _pid, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            DATE_FORMAT(a.FechaDocumento,'%m-%d-%Y') AS FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Comentario,
	                            b.IDDetalleDocumento,
	                            b.IDProducto,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            b.CantidadSalida,
	                            b.PrecioSalida,
	                            b.UltimoCosto,
	                            b.Excento,
	                            b.Gravado,
	                            b.IvaRetenido,
                                b.MontoIva,
	                            b.PagoCuenta,
                                b.Descuento,
                                b.Total,
	                            b.IDBodega,
	                            b.NombreBodega,
	                            (b.CantidadSalida * b.PrecioSalida) as Total,
                                (SELECT a.Ticket_encabezado FROM sistema_configuracion a WHERE a.IDConfiguracion = 1 LIMIT 1) AS TicketEncabezado
                            FROM documentos_encabezados a,
		                            documentos_detalle b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.IDDocumento = @pIDDocumento
                            ORDER BY b.IDDetalleDocumento;";

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

        public static DataTable ReporteExistencias(string _pfechaini, string _pfechafin)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                        IFNULL((SELECT SUM(c.CantidadEntrada) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Entradas,
	                        IFNULL((SELECT SUM(c.CantidadSalida) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Salidas,
	                        IFNULL((SELECT SUM(c.CantidadEntrada - c.CantidadSalida) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Existencias
                            FROM producto_nombres a,
		                            producto_proveedores b
                            WHERE a.IDProducto = b.IDProducto
                            ORDER BY a.Categoria,a.SubCategoria,a.NombreProducto;";

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

        public static DataTable ReporteExistencias(string _pfechaini, string _pfechafin, int _pidproveedor = 0, bool _pendientes = false)
        {
            DataManager.Operacion _datos = new Operacion();
            _datos.AgregarParametro("pIDProveedor", _pidproveedor, TypeManager.Tipo.ENTERO);
            _datos.AgregarParametro("pFechaInicio", _pfechaini, TypeManager.Tipo.STRING);
            _datos.AgregarParametro("pFechaFinal", _pfechafin, TypeManager.Tipo.STRING);
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda,
	                            a.Categoria,
	                            a.SubCategoria,
	                        IFNULL((SELECT SUM(c.CantidadEntrada) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Entradas,
	                        IFNULL((SELECT SUM(c.CantidadSalida) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Salidas,
	                        IFNULL((SELECT SUM(c.CantidadEntrada - c.CantidadSalida) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) as Existencias,
		                     a.UltimoCosto,
		                     IFNULL((SELECT SUM(c.CantidadEntrada - c.CantidadSalida) 
		                        FROM documentos_detalle c, documentos_encabezados d 
		                        WHERE c.IDDocumento = d.IDDocumento 
		                        AND c.IDProducto = a.IDProducto 
		                        AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal)*a.UltimoCosto,0) AS TotalInventario
                            FROM producto_nombres a
                            WHERE a.IDProducto IN (SELECT b.IDProducto FROM producto_proveedores b WHERE b.IDPersona = @pIDProveedor)
						    HAVING Existencias <= 0 AND (Entradas > 0 OR Salidas > 0)
                            ORDER BY a.NombreProducto;";
            try
            {
                if (_pidproveedor == 0)
                {
                    _sql = _sql.Replace("WHERE a.IDProducto IN (SELECT b.IDProducto FROM producto_proveedores b WHERE b.IDPersona = @pIDProveedor)", "");
                }
                if (_pendientes == false)
                {
                    _sql = _sql.Replace("HAVING Existencias <= 0 AND (Entradas > 0 OR Salidas > 0)", "");
                }
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable HojaEntradaProductos(int _pidpersona = 0)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDPersona", _pidpersona, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.Categoria,
	                            a.SubCategoria,
	                            a.Presentacion,
	                            a.PrecioVenta,
	                            a.UltimoCosto,
	                            0.00 as Cantidad,
	                            a.UltimoCosto as Precio,
	                            0.00 as Total,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda,
                               IFNULL((SELECT SUM(b.CantidadEntrada) - SUM(b.CantidadSalida) 
										  		FROM documentos_detalle b 
												WHERE b.IDProducto = a.IDProducto),0) as Existencia
                            FROM producto_nombres a
                            WHERE a.IDProducto IN (SELECT b.IDProducto FROM producto_proveedores b WHERE b.IDPersona = @pIDPersona)
                            ORDER BY a.NombreProducto;";
            try
            {
                if (_pidpersona == 0)
                {
                    //_sql = _sql.Replace("AND b.IDPersona = @pIDPersona", "");
                    _sql = _sql.Replace("WHERE a.IDProducto IN (SELECT b.IDProducto FROM producto_proveedores b WHERE b.IDPersona = @pIDPersona)", "");
                }
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public static DataTable HojaSalidaProductos(int _pidpersona)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDPersona", _pidpersona, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                             a.IDProducto,
	                             a.CodigoProducto,
	                             a.NombreProducto,
	                             a.Categoria,
	                             a.SubCategoria,
	                             a.Presentacion,
	                             a.PrecioVenta,
	                             (SELECT 
	 	                            CASE p.Precio
	 		                            WHEN 'PRECIO 1' THEN a.Precio1
	 		                            WHEN 'PRECIO 2' THEN a.Precio2
	 		                            WHEN 'PRECIO 3' THEN a.Precio3
	 	                            END
	 	                            FROM personas_nombres p WHERE p.Rol = 'CLIENTE' AND p.IDPersona = @pIDPersona) AS PrecioSalidaOld,	 	
	                             a.UltimoCosto,
	                             0.0000 AS Cantidad,
	                             a.UltimoCosto AS PrecioSalida,
	                             0.00 AS Total,
                                a.FormatoVenta,
                                CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda,
                                IFNULL((SELECT SUM(b.CantidadEntrada) - SUM(b.CantidadSalida) 
									FROM documentos_detalle b 
								    WHERE b.IDProducto = a.IDProducto),0) as Existencia
                            FROM producto_nombres a
                            ORDER BY a.NombreProducto;";
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

        public static DataTable ProveedoresRalacionadosConProductos(int _pid)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDProducto", _pid, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                            a.IDProveedor,
	                            a.IDProducto,
	                            a.IDPersona,
	                            b.NombrePersona
                            FROM producto_proveedores a,
		                            personas_nombres b
                            WHERE a.IDPersona = b.IDPersona
                            AND a.IDProducto = @pIDProducto
                            ORDER BY b.NombrePersona;";

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

        public static DataTable HojaTrasladoProductos(int _pidbodega = 0)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDBodega", _pidbodega, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                         a.IDProducto,
	                         a.CodigoProducto,
	                         a.NombreProducto,
	                         a.Categoria,
	                         a.SubCategoria,
	                         a.Presentacion,
	                         a.PrecioVenta,
                             a.Precio1 AS PrecioSalida,
	                         a.UltimoCosto,
	                         0.0000 AS Cantidad,
	                         a.UltimoCosto AS Precio,
	                         0.0000 AS Total, 
	                         CONCAT(a.CodigoProducto,a.NombreProducto) AS FullBusqueda, 
	                         IFNULL((SELECT SUM(b.CantidadEntrada) - SUM(b.CantidadSalida)
					                        FROM documentos_detalle b
					                        WHERE b.IDProducto = a.IDProducto AND b.IDBodega = @pIDBodega),0) AS Existencia
                        FROM producto_nombres a
                        HAVING Existencia > 0
                        ORDER BY a.NombreProducto;";
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

        public static DataTable HojaTraslados(int _pid)
        {
            DataManager.Operacion _datos = new Operacion();
            DataTable _tabla = new DataTable();
            _datos.AgregarParametro("pIDDocumento", _pid, TypeManager.Tipo.ENTERO);
            string _sql = @"SELECT 
	                            a.IDDocumento,
	                            a.NumeroDocumento,
	                            a.FechaDocumento,
	                            a.FormaPago,
	                            a.DiasPlazo,
	                            a.Documento,
	                            a.IDPersona,
	                            a.NombreTitular,
	                            a.Estado,
                                a.Comentario,
                                a.Operacion,
	                            b.IDProducto,
	                            b.CodigoProducto,
	                            b.NombreProducto,
	                            c.PrecioVenta as PrecioSugerido,	                            
	                            b.PrecioSalida,
	                            SUM(b.CantidadSalida) AS CantidadSalida,
	                            b.PrecioEntrada,
	                            SUM(b.CantidadEntrada) AS CantidadEntrada,
	                            b.UltimoCosto,	                            
	                            (b.PrecioEntrada * SUM(b.CantidadEntrada)) as TotalEntrada,
	                            (b.PrecioSalida * SUM(b.CantidadSalida)) as TotalSalida,
	                            (c.PrecioVenta * SUM(b.CantidadSalida)) as TotalSugerido,
	                            b.IDBodega,
	                            b.NombreBodega,	     
                                b.IDBodegaOrigen,
                                b.NombreBodegaOrigen,                       
                                c.Presentacion,
                                b.FormatoVenta
                            FROM documentos_encabezados a,
		                            documentos_detalle b,
		                            producto_nombres c
                            WHERE a.IDDocumento = b.IDDocumento
                            AND b.IDProducto = c.IDProducto
                            AND a.IDDocumento = @pIDDocumento
                            AND CantidadSalida = 0
                            GROUP BY b.IDProducto,b.NombreBodega
                            ORDER BY a.FechaDocumento,a.IDDocumento,b.IDProducto;";
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
