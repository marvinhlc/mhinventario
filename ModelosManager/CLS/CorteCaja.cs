using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class CorteCaja : EntityManager.Entidad
    {
        Descriptor _IDCorte = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDCaja = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDUsuario = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _MontoInicial = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _TotalVenta = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Estado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDCorte { get { return _IDCorte; } set { _IDCorte = value; } }
        public Descriptor IDCaja { get { return _IDCaja; } set { _IDCaja = value; } }
        public Descriptor IDUsuario { get { return _IDUsuario; } set { _IDUsuario = value; } }
        public Descriptor MontoInicial { get { return _MontoInicial; } set { _MontoInicial = value; } }
        public Descriptor TotalVenta { get { return _TotalVenta; } set { _TotalVenta = value; } }
        public Descriptor Estado { get { return _Estado; } set { _Estado = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public CorteCaja()
            : base("cortes_caja")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public CorteCaja(int _pid)
            : base("cortes_caja")
        {
            this.Procesar(this);
            _IDCorte.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public CorteCaja(DataRow _prow)
            : base("cortes_caja")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public int CompilarDocumentos()
        {
            int _registros = 0;
            string _sql = @"INSERT INTO documentos_cortes
	                            (IDDocumento,IDCorte)
                            SELECT a.IDDocumento,@pIDCorte
                            FROM documentos_encabezados a
                            WHERE a.Operacion = 'VENTA'
                            AND a.Estado = 'APLICADO'
                            AND a.IDDocumento NOT IN (SELECT b.IDdocumento FROM documentos_cortes b);";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDCorte", _IDCorte.Valor, DataManager.TypeManager.Tipo.ENTERO);
                _registros = _bd.Insertar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _registros;
        }

        public DataTable UltimoCorteCaja(int _pidcaja)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDCorte,
	                            a.IDCaja,
	                            a.IDUsuario,
	                            a.MontoInicial,
	                            a.TotalVenta,
	                            a.Estado,
	                            a.FechaCreacion,
	                            IFNULL((SELECT SUM(b.CantidadSalida * b.PrecioSalida)
		                            FROM documentos_detalle b, documentos_encabezados c 
		                            WHERE b.IDDocumento = c.IDDocumento
                                    AND c.Operacion = 'VENTA' 
                                    AND c.Estado = 'APLICADO'
		                            AND c.IDDocumento NOT IN (SELECT d.IDDocumento FROM documentos_cortes d)),0) AS SumaVenta
                            FROM cortes_caja a
                            WHERE a.IDCaja = @pIDCaja
                            AND a.Estado = 'ABIERTO'
                            ORDER BY a.IDCorte
                            LIMIT 1;";
            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDCaja", _pidcaja, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable ObtenerCorteCaja(string _pestacion, string _pfechainicio, string _pfechafinal)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.Descripcion,
	                            IFNULL((SELECT MIN(d.NumeroDocumento) 
			                            FROM documentos_encabezados d,
					                            documentos_detalle c,
					                            documentos_log e
			                            WHERE d.IDDocumento = c.IDDocumento
			                            AND d.Documento = a.Documento
			                            AND d.Estado = a.Estado
			                            AND d.IDDocumento = e.IDDocumento
			                            AND e.Estacion = @pEstacion
			                            AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),NULL) AS NumeroInicial,
	                            IFNULL((SELECT MAX(d.NumeroDocumento) 
			                            FROM documentos_encabezados d,
					                            documentos_detalle c,
					                            documentos_log e
			                            WHERE d.IDDocumento = c.IDDocumento
			                            AND d.Documento = a.Documento
			                            AND d.Estado = a.Estado
			                            AND d.IDDocumento = e.IDDocumento			
			                            AND e.Estacion = @pEstacion
			                            AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),NULL) AS NumeroFinal,
	                            IFNULL((SELECT SUM(c.CantidadSalida * c.PrecioSalida) 
			                            FROM documentos_encabezados d,
					                            documentos_detalle c,
					                            documentos_log e
			                            WHERE d.IDDocumento = c.IDDocumento
			                            AND d.Documento = a.Documento
			                            AND d.Estado = a.Estado
			                            AND d.IDDocumento = e.IDDocumento			
			                            AND e.Estacion = @pEstacion
			                            AND d.FechaDocumento BETWEEN @pFechaInicio AND @pFechaFinal),0) AS Monto				
                            FROM cortes_plantilla a
                            ORDER BY a.Descripcion;";
            try
            {
                if (_pestacion.EsNOE())
                    _sql = _sql.Replace("AND e.Estacion = @pEstacion", "");

                _bd.LimpiarParametro();
                _bd.AgregarParametro("pEstacion", _pestacion, DataManager.TypeManager.Tipo.STRING);
                _bd.AgregarParametro("pFechaInicio", _pfechainicio, DataManager.TypeManager.Tipo.STRING);
                _bd.AgregarParametro("pFechaFinal", _pfechafinal, DataManager.TypeManager.Tipo.STRING);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
    }
}
