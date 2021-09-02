using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using EntityManager;

namespace Sesion.CLS
{
    public class Usuario : EntityManager.Entidad
    {
        private string _SELECT_LOGIN_USER = @"SELECT 
	                                            a.IDUsuario,
	                                            a.NombreCompleto,
	                                            a.Estado,
	                                            a.IDRol,
	                                            a.Rol,
	                                            a.FechaCreacion
                                            FROM usuarios_nombres a
                                            WHERE a.IDUsuario = @pUsuario
                                            AND a.Password = SHA1(@pPassword);";

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

        private DataTable _permisos_user = new DataTable();

        public Usuario():base("usuarios_nombres")
        {
            this.Procesar(this);
        }

        public Usuario(string _pusuario, string _pcredencial):base("usuarios_nombres")
        {
            this.Procesar(this);
            _IDUsuario.Valor = _pusuario;
            _Password.Valor = _pcredencial;
        }

        public bool Loguear()
        {
            bool _ok = false;
            DataTable _tabla = new DataTable();
            Existe = false;

            try
            {
                DataManager.Operacion _db = new DataManager.Operacion();
                _db.AgregarParametro("pUsuario", _IDUsuario.Valor, DataManager.TypeManager.Tipo.STRING);
                _db.AgregarParametro("pPassword", _Password.Valor, DataManager.TypeManager.Tipo.STRING);
                _tabla = _db.Consultar(_SELECT_LOGIN_USER);

                if (_tabla.Rows.Count > 0)
                {
                    _ok = true;

                    DataRow _row = _tabla.Rows[0];
                    _NombreCompleto.Valor = _row["NombreCompleto"].ToString();
                    _Estado.Valor = _row["Estado"].ToString();
                    _IDRol.Valor = Convert.ToInt32(_row["IDRol"].ToString());
                    _Rol.Valor = _row["Rol"].ToString();
                    _FechaCreacion.Valor = Convert.ToDateTime(_row["FechaCreacion"].ToString());
                    Existe = true;

                    ModelosManager.CLS.UsuariosPermisos _permisos = new ModelosManager.CLS.UsuariosPermisos();
                    _permisos_user = _permisos_user = _permisos.PermisosPorIDRol(Convert.ToInt32(_IDRol.Valor));
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                _ok = false;
            }

            return _ok;
        }

        public bool Nuevo()
        {
            bool _ok = false;

            try
            {
                DataBase _db = new DataBase();

                if (_db.Insertar(this) > 0)
                {
                    _ok = true;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _ok;
        }

        public bool Kerveros(Comandos  _pidcomando, bool _advertir = false)
        {
            DataRow _row = null;

            try
            {
                _row = (from _myrow in _permisos_user.AsEnumerable()
                        where _myrow.Field<int>("IDComando") == Convert.ToInt32(_pidcomando)
                        select _myrow).FirstOrDefault();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                if (_row == null)
                {
                    MessageBox.Show("No tiene el permiso necesario para ejecutar ésta tarea.", "PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return (_row != null);
        }

        public bool RecargarPermisos()
        {
            bool _ok = false;
            try
            {
                ModelosManager.CLS.UsuariosPermisos _permisos = new ModelosManager.CLS.UsuariosPermisos();
                _permisos_user = _permisos_user = _permisos.PermisosPorIDRol(Convert.ToInt32(_IDRol.Valor));
                if (_permisos_user.Rows.Count > 0)
                    _ok = true;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }
    }
}
