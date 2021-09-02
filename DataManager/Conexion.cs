using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DataManager
{
    public class Conexion
    {
        private Portable.Portador _portador = Portable.Portador.Instancia;
        public MySqlConnection _Conexion = new MySqlConnection();
        private string _CADENA_CONEXION = string.Empty;

        public Conexion()
        {
            //nada
        }

        public Boolean AbrirConexion()
        {
            Boolean resultado = false;
            _CADENA_CONEXION = ConfigurationManager.ConnectionStrings[_portador.Conexion].ToString();
            _Conexion.ConnectionString = _CADENA_CONEXION;
            try
            {
                _Conexion.Open();
                resultado= true;
            }
            catch (MySqlException _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                resultado= false;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
                resultado = false;
            }
            return resultado;
        }

        public void CerrarConexion()
        {
            if (_Conexion.State == System.Data.ConnectionState.Open)
            {
                _Conexion.Close();
            }
        }

    }
}
