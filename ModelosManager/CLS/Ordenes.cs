using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class Ordenes : EntityManager.Entidad
    {
        Descriptor _IDOrden = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NumeroOrden = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IDCliente = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreCliente = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _TipoPrenda = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Institucion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _TelefonoCliente = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_hombro = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_pecho = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_cintura = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_base = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_largo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_largo_manga = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_sisa = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_pinsa = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_escote = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_largo_atras = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _superior_peto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_cintura = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_base = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_largo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_pierna = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_rodillo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_ruedo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _inferior_tiro = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _fecha_inicio = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _fecha_entrega = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _costurera_sastre = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _vendedor = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _multiplicador = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _total = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _abono = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _saldo = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _estado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _comentario = new Descriptor(DataManager.TypeManager.Tipo.TEXT);
        Descriptor _descuento = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        //Descriptor _FechaHora = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDOrden { get { return _IDOrden; } set { _IDOrden = value; } }
        public Descriptor NumeroOrden { get { return _NumeroOrden; } set { _NumeroOrden = value; } }
        public Descriptor IDCliente { get { return _IDCliente; } set { _IDCliente = value; } }
        public Descriptor NombreCliente { get { return _NombreCliente; } set { _NombreCliente = value; } }
        public Descriptor TipoPrenda { get { return _TipoPrenda; } set { _TipoPrenda = value; } }
        public Descriptor Institucion { get { return _Institucion; } set { _Institucion = value; } }
        public Descriptor TelefonoCliente { get { return _TelefonoCliente; } set { _TelefonoCliente = value; } }
        public Descriptor superior_hombro { get { return _superior_hombro; } set { _superior_hombro = value; } }
        public Descriptor superior_pecho { get { return _superior_pecho; } set { _superior_pecho = value; } }
        public Descriptor superior_cintura { get { return _superior_cintura; } set { _superior_cintura = value; } }
        public Descriptor superior_base { get { return _superior_base; } set { _superior_base = value; } }
        public Descriptor superior_largo { get { return _superior_largo; } set { _superior_largo = value; } }
        public Descriptor superior_largo_manga { get { return _superior_largo_manga; } set { _superior_largo_manga = value; } }
        public Descriptor superior_sisa { get { return _superior_sisa; } set { _superior_sisa = value; } }
        public Descriptor superior_pinsa { get { return _superior_pinsa; } set { _superior_pinsa = value; } }
        public Descriptor superior_escote { get { return _superior_escote; } set { _superior_escote = value; } }
        public Descriptor superior_largo_atras { get { return _superior_largo_atras; } set { _superior_largo_atras = value; } }
        public Descriptor superior_peto { get { return _superior_peto; } set { _superior_peto = value; } }
        public Descriptor inferior_cintura { get { return _inferior_cintura; } set { _inferior_cintura = value; } }
        public Descriptor inferior_base { get { return _inferior_base; } set { _inferior_base = value; } }
        public Descriptor inferior_largo { get { return _inferior_largo; } set { _inferior_largo = value; } }
        public Descriptor inferior_pierna { get { return _inferior_pierna; } set { _inferior_pierna = value; } }
        public Descriptor inferior_rodillo { get { return _inferior_rodillo; } set { _inferior_rodillo = value; } }
        public Descriptor inferior_ruedo { get { return _inferior_ruedo; } set { _inferior_ruedo = value; } }
        public Descriptor inferior_tiro { get { return _inferior_tiro; } set { _inferior_tiro = value; } }
        public Descriptor fecha_inicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
        public Descriptor fecha_entrega { get { return _fecha_entrega; } set { _fecha_entrega = value; } }
        public Descriptor costurera_sastre { get { return _costurera_sastre; } set { _costurera_sastre = value; } }
        public Descriptor vendedor { get { return _vendedor; } set { _vendedor = value; } }
        public Descriptor multiplicador { get { return _multiplicador; } set { _multiplicador = value; } }
        public Descriptor total { get { return _total; } set { _total = value; } }
        public Descriptor abono { get { return _abono; } set { _abono = value; } }
        public Descriptor saldo { get { return _saldo; } set { _saldo = value; } }
        public Descriptor estado { get { return _estado; } set { _estado = value; } }
        public Descriptor comentario { get { return _comentario; } set { _comentario = value; } }
        public Descriptor descuento { get { return _descuento; } set { _descuento = value; } }
        //public Descriptor FechaHora { get { return _FechaHora; } set { _FechaHora = value; } }


        DataManager.Operacion _bd = new DataManager.Operacion();

        public Ordenes()
            : base("ordenes")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public Ordenes(int _pid)
            : base("ordenes")
        {
            this.Procesar(this);
            _IDOrden.Valor = _pid;
            CargarDatosPorID();
            if (Existe == false && _multiplicador.Valor.ToEntero() == 0)
            {
                _multiplicador.Valor = 1;
            }
        }

        //CARGAR DATOS POR DATAROW
        public Ordenes(DataRow _prow)
            : base("ordenes")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        //CARGAR DATOS POR DATAROW
        public Ordenes(string _pnumero)
            : base("ordenes")
        {
            this.Procesar(this);
            DataRow _prow = CargarDatosPorNumero(_pnumero);
            Rellenar(_prow);
        }

        public DataTable Todo(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDOrden,
                                a.NumeroOrden,
	                            a.IDCliente,
	                            a.NombreCliente,
	                            a.TipoPrenda,
	                            a.Institucion,
	                            a.TelefonoCliente,
	                            a.superior_hombro,
	                            a.superior_pecho,
	                            a.superior_cintura,
	                            a.superior_base,
	                            a.superior_largo,
	                            a.superior_largo_manga,
	                            a.superior_sisa,
	                            a.superior_pinsa,
	                            a.superior_escote,
	                            a.superior_largo_atras,
                                a.superior_peto,
	                            a.inferior_cintura,
	                            a.inferior_base,
	                            a.inferior_largo,
	                            a.inferior_pierna,
	                            a.inferior_rodillo,
	                            a.inferior_ruedo,
	                            a.inferior_tiro,
	                            a.fecha_inicio,
	                            a.fecha_entrega,
	                            a.costurera_sastre,
	                            a.vendedor,
	                            a.abono,
	                            a.saldo,
	                            a.estado,
                                a.descuento,
                                a.comentario,
                                IFNULL((SELECT COUNT(d.IDDetalleOrden) FROM ordenes_detalle d 
								    WHERE d.IDOrden = a.IDOrden),0) AS Items,
                                IFNULL((SELECT SUM(d.CantidadSalida * d.PrecioSalida) 
								    FROM ordenes_detalle d WHERE d.IDOrden = a.IDOrden),0) AS Total
                            FROM ordenes a
                            WHERE YEAR(a.FechaHora) = @pPeriodo
                            ORDER BY a.IDOrden;";

            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        private DataRow CargarDatosPorNumero(string _pnumero)
        {
            DataTable _tabla = new DataTable();
            DataRow _row = null;

            string _sql = @"SELECT 
	                            a.IDOrden,
                                a.NumeroOrden,
	                            a.IDCliente,
	                            a.NombreCliente,
	                            a.TipoPrenda,
	                            a.Institucion,
	                            a.TelefonoCliente,
	                            a.superior_hombro,
	                            a.superior_pecho,
	                            a.superior_cintura,
	                            a.superior_base,
	                            a.superior_largo,
	                            a.superior_largo_manga,
	                            a.superior_sisa,
	                            a.superior_pinsa,
	                            a.superior_escote,
	                            a.superior_largo_atras,
                                a.superior_peto,
	                            a.inferior_cintura,
	                            a.inferior_base,
	                            a.inferior_largo,
	                            a.inferior_pierna,
	                            a.inferior_rodillo,
	                            a.inferior_ruedo,
	                            a.inferior_tiro,
	                            a.fecha_inicio,
	                            a.fecha_entrega,
	                            a.costurera_sastre,
	                            a.vendedor,
	                            a.abono,
	                            a.saldo,
	                            a.estado,
                                a.descuento,
                                a.comentario,
	                            IFNULL((SELECT SUM(b.CantidadSalida * b.PrecioSalida) 
										 	FROM ordenes_detalle b WHERE b.IDOrden = a.IDOrden),0) AS Total
                            FROM ordenes a
                            WHERE a.NumeroOrden = @pNumeroOrden
                            ORDER BY a.IDOrden;";

            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pNumeroOrden", _pnumero, DataManager.TypeManager.Tipo.STRING);
                _tabla = _bd.Consultar(_sql);
                _row = _tabla.Rows[0];
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                _row = null;
            }

            return _row;
        }

        public DataTable Detalle()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDDetalleOrden,
	                            a.IDOrden,
	                            a.IDProducto,
	                            a.CodigoProducto,
	                            a.NombreProducto,
	                            a.CantidadEntrada,
	                            a.PrecioEntrada,
	                            a.CantidadSalida,
	                            a.PrecioSalida,
	                            a.UltimoCosto,
	                            a.FormatoVenta,
	                            a.Excento,
	                            a.Gravado,
	                            a.MontoIva,
	                            a.IvaRetenido,
	                            a.PagoCuenta,
	                            a.FechaVencimiento,
	                            a.FechaEntrega,
	                            a.IDBodega,
	                            a.NombreBodega,
	                            a.IDBodegaOrigen,
	                            a.NombreBodegaOrigen,
	                            a.FechaCreacion
                            FROM ordenes_detalle a
                            WHERE a.IDOrden = @pIDOrden
                            ORDER BY a.CodigoProducto;";

            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDOrden", _IDOrden.Valor, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable Imagenes()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDImagen,
	                            a.IDOrden,
	                            a.Archivo,
	                            a.Imagen,
	                            a.FechaCreacion
                            FROM ordenes_imagenes a
                            WHERE a.IDOrden = @pIDOrden
                            ORDER BY a.IDImagen;";

            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pIDOrden", _IDOrden.Valor, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public bool Validar()
        {
            int _errores = 0;
            try
            {
                if (string.IsNullOrEmpty(_NombreCliente.Valor.ToString()))
                    _errores++;
                if (Convert.ToDouble(_total.Valor) == 0)
                    _errores++;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_errores == 0);
        }
    }
}
