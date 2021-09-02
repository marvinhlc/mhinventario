using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace DataManager
{
    public class Operacion
    {
        //private Sesion.CLS.OmniSesion _SESION = Sesion.CLS.OmniSesion.Instancia;
        private Conexion ObjConexion = new Conexion();
        private Int16 _Espera = 0;
        private MySqlCommand Comando = new MySqlCommand();
        private MySqlDataAdapter adaptador = new MySqlDataAdapter();
        private string _MysqlError = string.Empty;

        public string MysqlError
        {
            get { return _MysqlError; }
            set { _MysqlError = value; }
        }
        public Operacion()
        {

        }
        public virtual MySqlCommand ComandoADO
        {
            get { return Comando; }
            set { Comando = value; }
        }

        public Int16 TiempoEspera
        {
            get { return _Espera; }
            set { _Espera = value; }
        }
        public virtual DataTable Consultar(String pConsulta)
        {
            DataTable tbl = new DataTable();
            try
            {
                tbl = EjecutarConsulta(pConsulta);
            }
            catch
            {
                tbl = null;
            }
            return tbl;
        }

        public virtual int Insertar(String pSentencia)
        {
            int result = 0;
            try
            {
                result = EjercutarSentencia(pSentencia);
            }
            catch
            {
                result = -1;
            }
            return result;
        }
        public virtual int Actualizar(String pSentencia)
        {
            int result = 0;
            try
            {
                result = EjercutarSentencia(pSentencia);
            }
            catch
            {
                result = -1;
            }
            return result;
        }
        public virtual int Eliminar(String pSentencia)
        {
            int result = 0;
            try
            {
                result = EjercutarSentencia(pSentencia);
            }
            catch
            {
                result = -1;
            }
            return result;
        }
        public DataTable Funcion(String pSentencia)
        {
            Comando.CommandType = CommandType.StoredProcedure;
            return this.EjecutarConsulta(pSentencia);
        }
        public Boolean Procedimiento(String pSentencia)
        {
            Comando.CommandType = CommandType.StoredProcedure;
            Boolean resultado = false;
            try
            {
                this.EjercutarSentencia(pSentencia);
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }
        protected virtual int EjercutarSentencia(String pSentencia)
        {
            int nr;
            ObjConexion.AbrirConexion();
            Comando.CommandTimeout=_Espera;
            try
            {
                using (ObjConexion._Conexion)
                {
                    Comando.CommandText = pSentencia;
                    Comando.Connection = ObjConexion._Conexion;
                    nr = Comando.ExecuteNonQuery();

                    DataManager.Interprete _interprete = new Interprete(Comando, ObjConexion._Conexion);
                }
            }
            catch (Exception myex)
            {
                _MysqlError = myex.Message.ToString();
                nr = 0;
                Herramientas.Log.Registrar(myex.ToString());
            }
            finally
            {
                ObjConexion.CerrarConexion();
            }
            return nr;
        }
        protected virtual DataTable EjecutarConsulta(String pConsulta)
        {
            DataTable resultado = new DataTable();

            ObjConexion.AbrirConexion();
            try
            {
                using (ObjConexion._Conexion)
                {
                    Comando.CommandText = pConsulta;
                    Comando.Connection = ObjConexion._Conexion;
                    adaptador.SelectCommand = Comando;
                    adaptador.Fill(resultado);

                    DataManager.Interprete _interprete = new Interprete(Comando, ObjConexion._Conexion);
                }
            }
            catch (MySqlException myex)
            {
                _MysqlError = myex.Message.ToString();
                resultado = null;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                resultado = null;
            }

            finally
            {
                ObjConexion.CerrarConexion();
            }
            return resultado;

        }

        public virtual bool AgregarParametro(string pNombre, object pValor, DataManager.TypeManager.Tipo pTipoValor)
        {
            bool miOk = false;

            try
            {
                this.Comando.Parameters.AddWithValue(pNombre, pValor);
                this.Comando.Parameters[pNombre].MySqlDbType =(MySqlDbType) pTipoValor;
                miOk = true;
            }
            catch
            {
                miOk = false;
            }

            return miOk;
        }
        public virtual bool LimpiarParametro()
        {
            bool miOk = false;
            try
            {
                this.Comando.Parameters.Clear();
                miOk = true;
            }
            catch
            {
                miOk = false;
            }
            return miOk;
        }

        public virtual int UltimoID()
        {
            try
            {
                return Convert.ToInt32(this.Comando.LastInsertedId);
            }
            catch
            {
                return 0;
            }
        }

        public string ProbarComunicacion()
        {
            StringBuilder mensaje = new StringBuilder();
            try
            {
                if (ObjConexion.AbrirConexion())
                {
                    mensaje.Append(ObjConexion._Conexion.DataSource.ToString());
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                mensaje.Append("000.000.000.000");
            }
            finally
            {
                ObjConexion.CerrarConexion();
            }
            return mensaje.ToString();
        }
    }
}
