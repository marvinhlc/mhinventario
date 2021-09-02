using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class GastosClasificaciones : EntityManager.Entidad
    {
        Descriptor _IDClasificacion = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _Descripcion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        //Descriptor _FechaInsert = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        //Descriptor _FechaUpdate = new Descriptor(DataManager.TypeManager.Tipo.DATETIME);
        public Descriptor IDClasificacion { get { return _IDClasificacion; } set { _IDClasificacion = value; } }
        public Descriptor Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        //public Descriptor FechaInsert { get { return _FechaInsert; } set { _FechaInsert = value; } }
        //public Descriptor FechaUpdate { get { return _FechaUpdate; } set { _FechaUpdate = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public GastosClasificaciones()
            : base("gastos_clasificaciones")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public GastosClasificaciones(int _pid)
            : base("gastos_clasificaciones")
        {
            this.Procesar(this);
            _IDClasificacion.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public GastosClasificaciones(DataRow _prow)
            : base("gastos_clasificaciones")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
