using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class DocumentosOrdenes : EntityManager.Entidad
    {
        Descriptor _IDRelacion = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDOrden = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _FechaHora = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDRelacion { get { return _IDRelacion; } set { _IDRelacion = value; } }
        public Descriptor IDDocumento { get { return _IDDocumento; } set { _IDDocumento = value; } }
        public Descriptor IDOrden { get { return _IDOrden; } set { _IDOrden = value; } }
        public Descriptor FechaHora { get { return _FechaHora; } set { _FechaHora = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public DocumentosOrdenes()
            : base("documentos_ordenes")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public DocumentosOrdenes(int _pid)
            : base("documentos_ordenes")
        {
            this.Procesar(this);
            _IDOrden.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public DocumentosOrdenes(DataRow _prow)
            : base("documentos_ordenes")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
