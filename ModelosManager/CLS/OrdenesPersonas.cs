using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesPersonas : EntityManager.Entidad
    {
        Descriptor _IDPersona = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombrePersona = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaHora = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDPersona { get { return _IDPersona; } set { _IDPersona = value; } }
        public Descriptor NombrePersona { get { return _NombrePersona; } set { _NombrePersona = value; } }
        public Descriptor FechaHora { get { return _FechaHora; } set { _FechaHora = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesPersonas()
            : base("ordenes_personas")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesPersonas(int _pid)
            : base("ordenes_personas")
        {
            this.Procesar(this);
            _IDPersona.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesPersonas(DataRow _prow)
            : base("ordenes_personas")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
