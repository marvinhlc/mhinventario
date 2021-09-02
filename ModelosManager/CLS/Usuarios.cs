using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class Usuarios : EntityManager.Entidad
    {
        Descriptor _IDUsuario = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _Password = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR, DataManager.TypeManager.Modificador.PASSWORD_SHA1);
        Descriptor _NombreCompleto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Estado = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IDRol = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Rol = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDUsuario { get { return _IDUsuario; } set { _IDUsuario = value; } }
        public Descriptor Password { get { return _Password; } set { _Password = value; } }
        public Descriptor NombreCompleto { get { return _NombreCompleto; } set { _NombreCompleto = value; } }
        public Descriptor Estado { get { return _Estado; } set { _Estado = value; } }
        public Descriptor IDRol { get { return _IDRol; } set { _IDRol = value; } }
        public Descriptor Rol { get { return _Rol; } set { _Rol = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public Usuarios()
            : base("usuarios_nombres")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public Usuarios(int _pidusuario)
            : base("usuarios_nombres")
        {
            this.Procesar(this);
            _IDUsuario.Valor = _pidusuario;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public Usuarios(DataRow _prow)
            : base("usuarios_nombres")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable TodosLosUsuarios()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            IDUsuario,
	                            Password,
	                            NombreCompleto,
	                            Estado,
	                            IDRol,
	                            Rol,
	                            FechaCreacion 
                            FROM usuarios_nombres a 
                            ORDER BY IDUsuario;";

            try
            {
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
    }
}
