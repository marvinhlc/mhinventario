using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class UsuariosRoles : EntityManager.Entidad
    {
        Descriptor _IDRol = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _DescripcionRol = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDRol { get { return _IDRol; } set { _IDRol = value; } }
        public Descriptor DescripcionRol { get { return _DescripcionRol; } set { _DescripcionRol = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public UsuariosRoles()
            : base("usuarios_roles")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public UsuariosRoles(int _pid)
            : base("usuarios_roles")
        {
            this.Procesar(this);
            _IDRol.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public UsuariosRoles(DataRow _prow)
            : base("usuarios_roles")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
