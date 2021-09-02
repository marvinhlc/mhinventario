using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class DocumentosEncabezados : Entidad
    {
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NumeroDocumento = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaDocumento = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _FormaPago = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _DiasPlazo = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Operacion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Documento = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IDPersona = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreTitular = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Comentario = new Descriptor(DataManager.TypeManager.Tipo.TEXT);
        Descriptor _Estado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDDocumento { get { return _IDDocumento; } set { _IDDocumento = value; } }
        public Descriptor NumeroDocumento { get { return _NumeroDocumento; } set { _NumeroDocumento = value; } }
        public Descriptor FechaDocumento { get { return _FechaDocumento; } set { _FechaDocumento = value; } }
        public Descriptor FormaPago { get { return _FormaPago; } set { _FormaPago = value; } }
        public Descriptor DiasPlazo { get { return _DiasPlazo; } set { _DiasPlazo = value; } }
        public Descriptor Operacion { get { return _Operacion; } set { _Operacion = value; } }
        public Descriptor Documento { get { return _Documento; } set { _Documento = value; } }
        public Descriptor IDPersona { get { return _IDPersona; } set { _IDPersona = value; } }
        public Descriptor NombreTitular { get { return _NombreTitular; } set { _NombreTitular = value; } }
        public Descriptor Comentario { get { return _Comentario; } set { _Comentario = value; } }
        public Descriptor Estado { get { return _Estado; } set { _Estado = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public DocumentosEncabezados()
            : base("documentos_encabezados")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public DocumentosEncabezados(int _pid)
            : base("documentos_encabezados")
        {
            this.Procesar(this);
            _IDDocumento.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public DocumentosEncabezados(DataRow _prow)
            : base("documentos_encabezados")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        //CARGAR DATOS POR NUMERO DE DOCUMENTO
        public DocumentosEncabezados(string _pnumero, int _pperiodo)
            : base("documentos_encabezados")
        {
            this.Procesar(this);
            _NumeroDocumento.Valor = _pnumero;
            CargarDatosPorNumeroDocumento(_pperiodo);
        }

        public double DocumentosCreditoSaldoActual()
        {
            DataTable _tabla = new DataTable();
            int _pidpersona = Convert.ToInt32( _IDPersona.Valor);
            int _piddocumento = Convert.ToInt32(_IDDocumento.Valor);
            double _saldoactual = 0;

            string _sql = @"SELECT 
	                            b.TotalVenta,
	                            b.Efectivo,
	                            b.Cambio,
	                            b.Saldo,
	                            IFNULL((SELECT SUM(p.Valor) 
		                            FROM personas_pagos p 
		                            WHERE p.IDDocumento = a.IDDocumento 
		                            GROUP BY p.IDDocumento),0) AS Abonos,
										(b.Saldo - IFNULL((SELECT SUM(p.Valor) 
		                            FROM personas_pagos p 
		                            WHERE p.IDDocumento = a.IDDocumento 
		                            GROUP BY p.IDDocumento),0)) AS SaldoActual
                            FROM documentos_encabezados a,
		                            documentos_log b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.Estado = 'APLICADO'
                            AND b.Saldo > 0
                            AND a.IDPersona = @pidpersona
                            AND a.IDDocumento = @piddocumento
                            HAVING b.Saldo > Abonos
                            ORDER BY a.FechaDocumento DESC, a.NumeroDocumento DESC;";
            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pidpersona", _pidpersona, DataManager.TypeManager.Tipo.ENTERO);
                _datos.AgregarParametro("piddocumento", _piddocumento, DataManager.TypeManager.Tipo.ENTERO);

                _tabla = _datos.Consultar(_sql);
                if (_tabla.Rows.Count > 0)
                    _saldoactual = Convert.ToDouble(_tabla.Rows[0]["SaldoActual"]);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _saldoactual;
        }

        public DataTable DocumentosCredito(int _pidpersona = 0)
        {
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
	                            a.Comentario,
	                            a.Estado,
	                            b.IDUsuario,
	                            b.Estacion,
	                            b.TotalVenta,
	                            b.Efectivo,
	                            b.Cambio,
	                            b.Saldo,
	                            IFNULL((SELECT SUM(p.Valor) 
		                            FROM personas_pagos p 
		                            WHERE p.IDDocumento = a.IDDocumento 
		                            GROUP BY p.IDDocumento),0) AS Abonos,
	                            b.FechaCreacion
                            FROM documentos_encabezados a,
		                            documentos_log b
                            WHERE a.IDDocumento = b.IDDocumento
                            AND a.Estado = 'APLICADO'
                            AND b.Saldo > 0
                            AND a.IDPersona = @pidpersona
                            HAVING b.Saldo > Abonos
                            ORDER BY a.FechaDocumento DESC, a.NumeroDocumento DESC;";
            try
            {
                _datos.LimpiarParametro();
                if (_pidpersona > 0)
                    _datos.AgregarParametro("pidpersona", _pidpersona, DataManager.TypeManager.Tipo.ENTERO);
                else
                    _sql = _sql.Replace("AND a.IDPersona = @pidpersona", "");

                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public void CargarDatosPorNumeroDocumento(int _pperiodo)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.NumeroDocumento = @pNumero
                            AND YEAR(a.FechaDocumento) = @pPeriodo;";

            try
            {
                _datos.AgregarParametro("pNumero", _NumeroDocumento.Valor.ToString(), DataManager.TypeManager.Tipo.STRING);
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
                if (_tabla.Rows.Count > 0)
                {
                    DataRow _row = _tabla.Rows[0];
                    Rellenar(_row);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public DataTable DocumentosCompras(int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.CantidadEntrada * d.PrecioEntrada) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'COMPRA'
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            ORDER BY a.FechaCreacion DESC;";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DocumentosEntradas(int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.CantidadEntrada * d.PrecioEntrada) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'ENTRADA'
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            ORDER BY a.FechaCreacion DESC;";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DocumentosSalidas(int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'SALIDA'
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            ORDER BY a.FechaCreacion DESC;";

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

        public DataTable DocumentosInventario(int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.CantidadEntrada * d.PrecioEntrada) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'INVENTARIO'
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            ORDER BY a.FechaCreacion DESC;";

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

        public DataTable DocumentosVentasTodos(int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'VENTA'
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            AND a.IDDocumento NOT IN (SELECT e.IDDocumento FROM documentos_cortes e)
                            ORDER BY a.FechaCreacion DESC;";
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

        public DataTable DocumentosVentas()
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'VENTA'
                            AND a.Estado = 'APLICADO'
                            AND a.IDDocumento NOT IN (SELECT e.IDDocumento FROM documentos_cortes e)
                            ORDER BY a.FechaCreacion DESC;";
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

        public DataTable DocumentosTicket(int _pperiodo)
        {
            return DocumentosVentas("TICKET", _pperiodo);
        }

        public DataTable DocumentosConsumidorFinal(int _pperiodo)
        {
            return DocumentosVentas("CONSUMIDOR FINAL", _pperiodo);
        }

        public DataTable DocumentosCreditoFiscal(int _pperiodo)
        {
            return DocumentosVentas("CREDITO FISCAL", _pperiodo);
        }

        private DataTable DocumentosVentas(string _ptipodocumento, int _pperiodo = 0)
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'VENTA'
                            AND a.Documento = @pTipoDocumento
                            AND YEAR(a.FechaDocumento) = @pPeriodo
                            ORDER BY a.FechaCreacion DESC;";
            try
            {
                _datos.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _datos.AgregarParametro("pTipoDocumento", _ptipodocumento, DataManager.TypeManager.Tipo.STRING);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable DocumentosTraslados()
        {
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
	                            a.FechaCreacion,
	                            (SELECT COUNT(d.IDDetalleDocumento) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento) AS Items,
	                            IFNULL((SELECT SUM(d.Total) 
		                            FROM documentos_detalle d 
		                            WHERE d.IDDocumento = a.IDDocumento),0) AS Total
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'TRASLADO'
                            ORDER BY a.FechaCreacion DESC;";

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

        public bool Anular()
        {
            bool _ok = false;
            try
            {
                string _sql = @"UPDATE documentos_encabezados
                                    SET Estado = 'ANULADO'
                                    WHERE IDDocumento = @pIDDocumento;";

                _datos.AgregarParametro("pIDDocumento", Convert.ToInt32(_IDDocumento.Valor), DataManager.TypeManager.Tipo.ENTERO);
                _ok = (_datos.Actualizar(_sql) > 0);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public bool Aplicar()
        {
            bool _ok = false;
            try
            {
                string _sql = @"UPDATE documentos_encabezados
                                    SET Estado = 'APLICADO'
                                    WHERE IDDocumento = @pIDDocumento;";

                _datos.AgregarParametro("pIDDocumento", Convert.ToInt32(_IDDocumento.Valor), DataManager.TypeManager.Tipo.ENTERO);
                _ok = (_datos.Actualizar(_sql) > 0);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }
    }
}
