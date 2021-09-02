using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class DocumentosLog : EntityManager.Entidad
    {
        Descriptor _IDLogDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDUsuario = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Estacion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _TotalVenta = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Efectivo = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Cambio = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Saldo = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDLogDocumento { get { return _IDLogDocumento; } set { _IDLogDocumento = value; } }
        public Descriptor IDDocumento { get { return _IDDocumento; } set { _IDDocumento = value; } }
        public Descriptor IDUsuario { get { return _IDUsuario; } set { _IDUsuario = value; } }
        public Descriptor Estacion { get { return _Estacion; } set { _Estacion = value; } }
        public Descriptor TotalVenta { get { return _TotalVenta; } set { _TotalVenta = value; } }
        public Descriptor Efectivo { get { return _Efectivo; } set { _Efectivo = value; } }
        public Descriptor Cambio { get { return _Cambio; } set { _Cambio = value; } }
        public Descriptor Saldo { get { return _Saldo; } set { _Saldo = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }


       DataManager.Operacion _bd = new DataManager.Operacion();

        public DocumentosLog()
            : base("documentos_log")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public DocumentosLog(int _pid)
            : base("documentos_log")
        {
            this.Procesar(this);
            _IDLogDocumento.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public DocumentosLog(DataRow _prow)
            : base("documentos_log")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
