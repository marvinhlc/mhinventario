using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class UsuariosComandos : EntityManager.Entidad
    {
        Descriptor _IDComando = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombreComando = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Descripcion = new Descriptor(DataManager.TypeManager.Tipo.TEXT);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDComando { get { return _IDComando; } set { _IDComando = value; } }
        public Descriptor NombreComando { get { return _NombreComando; } set { _NombreComando = value; } }
        public Descriptor Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public UsuariosComandos()
            : base("usuarios_comandos")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public UsuariosComandos(int _pidcomando)
            : base("usuarios_comandos")
        {
            this.Procesar(this);
            _IDComando.Valor = _pidcomando;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public UsuariosComandos(DataRow _prow)
            : base("usuarios_comandos")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
