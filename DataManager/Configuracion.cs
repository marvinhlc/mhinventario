using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    class Configuracion
    {
        Bandera flag = Bandera.LOCAL;//<-------------------------------------------------------INTERRUMPTOR
        String _RUTA = AppDomain.CurrentDomain.BaseDirectory + @"\\Configuracion\\";
        String _ARCHIVO = @"Configuracion.xml";
        private Herramientas.Encriptador CRP = new Herramientas.Encriptador();
        private DataTable _Configuracion = new DataTable();
        private String _CADENACONEXION = "";

        public String CadenaConexion
        {
            get { return _CADENACONEXION; }
        }
        private enum Bandera
        {
            PRODUCCION,
            LOCAL,
            INTERNET,
            ARCHIVO,
            VPS,
        }

        public Configuracion()
        {
            _Configuracion = new DataTable();
            _Configuracion.TableName = "Configuracion";
            _Configuracion.Columns.Add("Servidor");
            _Configuracion.Columns.Add("Base");
            _Configuracion.Columns.Add("Usuario");
            _Configuracion.Columns.Add("Credencial");
            //_Configuracion.Rows.Add();

            try
            {
                if (LeerConfiguracion())
                {
                    StringBuilder _CadenaConexion = new StringBuilder();
                    try
                    {
                        //Formando la cadena de conexion
                        _CadenaConexion = new StringBuilder();
                        _CadenaConexion.Append("Database=");
                        _CadenaConexion.Append(CRP.Descifrar(_Configuracion.Rows[0]["Base"].ToString(), "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128));
                        _CadenaConexion.Append(" ;data source=");
                        _CadenaConexion.Append(CRP.Descifrar(_Configuracion.Rows[0]["Servidor"].ToString(), "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128));
                        _CadenaConexion.Append(" ;user id=");
                        _CadenaConexion.Append(CRP.Descifrar(_Configuracion.Rows[0]["Usuario"].ToString(), "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128));
                        _CadenaConexion.Append(" ;password=");
                        _CadenaConexion.Append(CRP.Descifrar(_Configuracion.Rows[0]["Credencial"].ToString(), "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128));
                        _CadenaConexion.Append(";Connection Timeout=10;AllowZeroDateTime=True;UseCompression=True;");
                        _CADENACONEXION = _CadenaConexion.ToString();
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private Boolean LeerConfiguracion()
        {
            Boolean resultado = true;
            try
            {
                DirectoryInfo Directorio = new DirectoryInfo(_RUTA);
                FileInfo Archivo = new FileInfo(_RUTA + _ARCHIVO);
                if (!Archivo.Exists)
                {
                    try
                    {
                        Directorio.Create();
                        if (EscribirConfiguracion())
                        {
                            //CARGO LA INFORMACION POR DEFECTO
                            _Configuracion.ReadXml(_RUTA + _ARCHIVO);
                        }
                        else
                        {
                            resultado = false;
                        }
                    }
                    catch
                    {
                        resultado = false;
                    }
                }
                else
                {
                    try
                    {
                        _Configuracion.ReadXml(_RUTA + _ARCHIVO);
                    }
                    catch
                    {
                        resultado = false;
                    }
                }
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }
        private Boolean EscribirConfiguracion()
        {
            Boolean resultado = true;
            try
            {               
                //AGREGANDO VALORES POR DEFAULT
                _Configuracion.Rows.Add();
                switch (flag)
                {

                    case Bandera.PRODUCCION:
                        _Configuracion.Rows[0]["Servidor"] = CRP.Cifrar("10.10.25.3", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Base"] = CRP.Cifrar("usobd", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Usuario"] = CRP.Cifrar("sinergia-admin", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Credencial"] = CRP.Cifrar("vertrigo", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        break;
                    case Bandera.LOCAL:
                        _Configuracion.Rows[0]["Servidor"] = CRP.Cifrar("localhost", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Base"] = CRP.Cifrar("astra", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Usuario"] = CRP.Cifrar("root", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Credencial"] = CRP.Cifrar("vertrigo", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        break;
                    case Bandera.INTERNET:
                        _Configuracion.Rows[0]["Servidor"] = CRP.Cifrar("168.243.34.217", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Base"] = CRP.Cifrar("usobd", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Usuario"] = CRP.Cifrar("sinergia-admin", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Credencial"] = CRP.Cifrar("vertrigo", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        break;
                    case Bandera.VPS:
                        _Configuracion.Rows[0]["Servidor"] = CRP.Cifrar("10.10.25.3", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Base"] = CRP.Cifrar("usobd", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Usuario"] = CRP.Cifrar("sinergia-admin", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        _Configuracion.Rows[0]["Credencial"] = CRP.Cifrar("vertrigo", "SINERGIA", "DATABASE", "SHA1", 22, "1234567891234567", 128);
                        break;
                }
                //ESCRIBIENDO EL ARCHIVO
                _Configuracion.WriteXml(_RUTA + _ARCHIVO);
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }
    }
}
