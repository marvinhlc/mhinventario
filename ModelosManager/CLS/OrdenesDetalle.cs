using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesDetalle : EntityManager.Entidad
    {
        Descriptor _IDDetalleOrden = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDOrden = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
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
        Descriptor _FechaVencimiento = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _FechaEntrega = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _IDBodega = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreBodega = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IDBodegaOrigen = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreBodegaOrigen = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP, DataManager.TypeManager.Modificador.NO_UPDATABLE);
        public Descriptor IDDetalleOrden { get { return _IDDetalleOrden; } set { _IDDetalleOrden = value; } }
        public Descriptor IDOrden { get { return _IDOrden; } set { _IDOrden = value; } }
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
        public Descriptor FechaVencimiento { get { return _FechaVencimiento; } set { _FechaVencimiento = value; } }
        public Descriptor FechaEntrega { get { return _FechaEntrega; } set { _FechaEntrega = value; } }
        public Descriptor IDBodega { get { return _IDBodega; } set { _IDBodega = value; } }
        public Descriptor NombreBodega { get { return _NombreBodega; } set { _NombreBodega = value; } }
        public Descriptor IDBodegaOrigen { get { return _IDBodegaOrigen; } set { _IDBodegaOrigen = value; } }
        public Descriptor NombreBodegaOrigen { get { return _NombreBodegaOrigen; } set { _NombreBodegaOrigen = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesDetalle()
            : base("ordenes_detalle")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesDetalle(int _pid)
            : base("ordenes_detalle")
        {
            this.Procesar(this);
            _IDDetalleOrden.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesDetalle(DataRow _prow)
            : base("ordenes_detalle")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
