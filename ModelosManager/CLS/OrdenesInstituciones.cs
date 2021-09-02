using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesInstituciones : EntityManager.Entidad
    {
        Descriptor _IDInstitucion = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombreInstitucion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDInstitucion { get { return _IDInstitucion; } set { _IDInstitucion = value; } }
        public Descriptor NombreInstitucion { get { return _NombreInstitucion; } set { _NombreInstitucion = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesInstituciones()
            : base("ordenes_instituciones")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesInstituciones(int _pid)
            : base("ordenes_instituciones")
        {
            this.Procesar(this);
            _IDInstitucion.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesInstituciones(DataRow _prow)
            : base("ordenes_instituciones")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
