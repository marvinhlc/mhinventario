using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesPrendas : EntityManager.Entidad
    {
        Descriptor _IDPrenda = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombrePrenda = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDPrenda { get { return _IDPrenda; } set { _IDPrenda = value; } }
        public Descriptor NombrePrenda { get { return _NombrePrenda; } set { _NombrePrenda = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesPrendas()
            : base("ordenes_prendas")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesPrendas(int _pid)
            : base("ordenes_prendas")
        {
            this.Procesar(this);
            _IDPrenda.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesPrendas(DataRow _prow)
            : base("ordenes_prendas")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
