using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class UsuariosPermisos : EntityManager.Entidad
    {
        Descriptor _IDPermiso = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDRol = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDComando = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDPermiso { get { return _IDPermiso; } set { _IDPermiso = value; } }
        public Descriptor IDRol { get { return _IDRol; } set { _IDRol = value; } }
        public Descriptor IDComando { get { return _IDComando; } set { _IDComando = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public UsuariosPermisos()
            : base("usuarios_permisos")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public UsuariosPermisos(int _pid)
            : base("usuarios_permisos")
        {
            this.Procesar(this);
            _IDPermiso.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public UsuariosPermisos(DataRow _prow)
            : base("usuarios_permisos")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable PermisosDeRoles()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDPermiso,
	                            a.IDRol,
	                            a.IDComando,
	                            b.NombreComando,
	                            b.Descripcion
                            FROM usuarios_permisos a,
		                            usuarios_comandos b
                            WHERE a.IDComando = b.IDComando
                            ORDER BY a.IDPermiso;";

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

        public DataTable PermisosPorIDRol(int _pidrol)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDPermiso,
	                            a.IDRol,
	                            a.IDComando,
	                            b.NombreComando,
	                            b.Descripcion
                            FROM usuarios_permisos a,
		                            usuarios_comandos b
                            WHERE a.IDComando = b.IDComando
                            AND a.IDRol = @pIDRol
                            ORDER BY a.IDPermiso;";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pIDRol", _pidrol, DataManager.TypeManager.Tipo.ENTERO);
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
