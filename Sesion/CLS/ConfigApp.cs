using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace Sesion.CLS
{
    public class ConfigApp
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        CLS.CajaConfiguracion _cajaconfig = new CajaConfiguracion();
        int _token = 0;

        private int _ID_SUCURSAL = 0;
        private double _TASA_IVA = 0;
        private double _TASA_PC175 = 0;
        private double _TASA_PC003 = 0;
        private int _PERIODO = 0;
        private int _ID_BODEGA_SALIDA = 0;
        private int _TOKEN_TICKET = 0;
        private int _TOKEN_CREDITO_FISCAL = 0;
        private int _TOKEN_CONSUMIDOR_FINAL = 0;
        private int _CAJA_ID = 0;
        private double _CAJA_EFECTIVO = 0;
        private int _ID_CLIENTE_VARIOS = 0;
        private string _ESTACION_ID = string.Empty;
        private int _ID_CAJA_CONFIGURACION = 0;
        private string _MARCA_BLANCA = string.Empty;
        private string _RUTA_DESTINO_BACKUP = string.Empty;

        [CategoryAttribute("Backup"), 
        DescriptionAttribute("Nombre del archivo para la salida del backup.")]  
        public string RUTA_DESTINO_BACKUP
        {
            get { return _RUTA_DESTINO_BACKUP; }
            set { _RUTA_DESTINO_BACKUP = value; }
        }

        [CategoryAttribute("Marca"), 
        DescriptionAttribute("Nombre del cliente a quien se le concede la licencia de uso.")]  
        public string MARCA_BLANCA
        {
            get { return _MARCA_BLANCA; }
            set { _MARCA_BLANCA = value; }
        }

        [CategoryAttribute("Caja"), 
        DescriptionAttribute("Identificador de la caja en éste equipo.")]  
        public int ID_CAJA_CONFIGURACION
        {
            get { return _ID_CAJA_CONFIGURACION; }
            set { _ID_CAJA_CONFIGURACION = value; }
        }

        [CategoryAttribute("Caja"), 
        DescriptionAttribute("Nombre de la caja en éste equipo.")]  
        public string ESTACION_ID
        {
            get { return _ESTACION_ID; }
            set { _ESTACION_ID = value; }
        }

        [CategoryAttribute("Clientes"), 
        DescriptionAttribute("Identificador del cliente en el catálogo que funciona como 'Clientes varios'.")]  
        public int ID_CLIENTE_VARIOS
        {
            get { return _ID_CLIENTE_VARIOS; }
            set { _ID_CLIENTE_VARIOS = value; }
        }

        [CategoryAttribute("Caja"), 
        DescriptionAttribute("Identificador de la caja en éste equipo, es el mismo de ID_CONFIGURACION_CAJA.")]  
        public double CAJA_EFECTIVO
        {
            get { return _CAJA_EFECTIVO; }
            set { _CAJA_EFECTIVO = value; }
        }

        [CategoryAttribute("Caja"), 
        DescriptionAttribute("Identificador de la caja en éste equipo, es el mismo de ID_CONFIGURACION_CAJA.")]  
        public int CAJA_ID
        {
            get { return _CAJA_ID; }
            set { _CAJA_ID = value; }
        }

        [CategoryAttribute("Facturación"), 
        DescriptionAttribute("Número actual de facturación para Consumidor Final.")]  
        public int TOKEN_CONSUMIDOR_FINAL
        {
            get { return _TOKEN_CONSUMIDOR_FINAL; }
            set { _TOKEN_CONSUMIDOR_FINAL = value; }
        }

        [CategoryAttribute("Facturación"), 
        DescriptionAttribute("Número actual de facturación para Crédito Fiscal.")]  
        public int TOKEN_CREDITO_FISCAL
        {
            get { return _TOKEN_CREDITO_FISCAL; }
            set { _TOKEN_CREDITO_FISCAL = value; }
        }

        [CategoryAttribute("Facturación"), 
        DescriptionAttribute("Número actual de facturación para Ticket.")]  
        public int TOKEN_TICKET
        {
            get { return _TOKEN_TICKET; }
            set { _TOKEN_TICKET = value; }
        }

        [CategoryAttribute("Facturación"), 
        DescriptionAttribute("Identificador de la bodega de donde se tomarán las ventas.")]  
        public int ID_BODEGA_SALIDA
        {
            get { return _ID_BODEGA_SALIDA; }
            set { _ID_BODEGA_SALIDA = value; }
        }

        [CategoryAttribute("Periodo"), 
        DescriptionAttribute("El año en curso.")]  
        public int PERIODO
        {
            get { return _PERIODO; }
            set { _PERIODO = value; }
        }

        [CategoryAttribute("Impuestos"), 
        DescriptionAttribute("Tasa del 0.03%")]  
        public double TASA_PC003
        {
            get { return _TASA_PC003; }
            set { _TASA_PC003 = value; }
        }

        [CategoryAttribute("Impuestos"), 
        DescriptionAttribute("Tasa del 1.75")]  
        public double TASA_PC175
        {
            get { return _TASA_PC175; }
            set { _TASA_PC175 = value; }
        }

        [CategoryAttribute("Impuestos"), 
        DescriptionAttribute("Tasa del IVA 0.13%")]  
        public double TASA_IVA
        {
            get { return _TASA_IVA; }
            set { _TASA_IVA = value; }
        }

        [CategoryAttribute("Sucursal"), 
        DescriptionAttribute("Identificador de la sucursal en caso que la base de datos esté centralizada en un servidor remoto.")]  
        public int ID_SUCURSAL
        {
            get { return _ID_SUCURSAL; }
            set { _ID_SUCURSAL = value; }
        }

        public ConfigApp()
        {
            try
            {
                Recargar();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Recargar()
        {
            try
            {
                _ID_SUCURSAL = Convert.ToInt32(ConfigurationManager.AppSettings["ID_SUCURSAL"].ToString());
                _TASA_IVA = Convert.ToDouble(ConfigurationManager.AppSettings["TASA_IVA"].ToString());
                _TASA_PC003 = Convert.ToDouble(ConfigurationManager.AppSettings["TASA_PC003"].ToString());
                _TASA_PC175 = Convert.ToDouble(ConfigurationManager.AppSettings["TASA_PC175"].ToString());
                _PERIODO = Convert.ToInt32(ConfigurationManager.AppSettings["PERIODO"].ToString());
                _ID_BODEGA_SALIDA = Convert.ToInt32(ConfigurationManager.AppSettings["ID_BODEGA_SALIDA"]);
                _TOKEN_TICKET = Convert.ToInt32(ConfigurationManager.AppSettings["TOKEN_TICKET"]);
                _TOKEN_CREDITO_FISCAL = Convert.ToInt32(ConfigurationManager.AppSettings["TOKEN_CREDITO_FISCAL"]);
                _TOKEN_CONSUMIDOR_FINAL = Convert.ToInt32(ConfigurationManager.AppSettings["TOKEN_CONSUMIDOR_FINAL"]);
                _CAJA_ID = Convert.ToInt32(ConfigurationManager.AppSettings["CAJA_ID"]);
                _CAJA_EFECTIVO = Convert.ToDouble(ConfigurationManager.AppSettings["CAJA_EFECTIVO"]);
                _ID_CLIENTE_VARIOS = Convert.ToInt32(ConfigurationManager.AppSettings["ID_CLIENTE_VARIOS"]);
                _ESTACION_ID = ConfigurationManager.AppSettings["ESTACION_ID"].ToString();
                _ID_CAJA_CONFIGURACION = Convert.ToInt32(ConfigurationManager.AppSettings["ID_CAJA_CONFIGURACION"]);
                _MARCA_BLANCA = ConfigurationManager.AppSettings["MARCA_BLANCA"].ToString();
                _RUTA_DESTINO_BACKUP = ConfigurationManager.AppSettings["RUTA_DESTINO_BACKUP"];
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Descargar()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ID_SUCURSAL"].Value = _ID_SUCURSAL.ToString();
                config.AppSettings.Settings["TASA_IVA"].Value = _TASA_IVA.ToString();
                config.AppSettings.Settings["TASA_PC003"].Value = _TASA_PC003.ToString();
                config.AppSettings.Settings["TASA_PC175"].Value = _TASA_PC175.ToString();
                config.AppSettings.Settings["PERIODO"].Value = _PERIODO.ToString();
                config.AppSettings.Settings["ID_BODEGA_SALIDA"].Value = _ID_BODEGA_SALIDA.ToString();
                config.AppSettings.Settings["TOKEN_TICKET"].Value = _TOKEN_TICKET.ToString();
                config.AppSettings.Settings["TOKEN_CREDITO_FISCAL"].Value = _TOKEN_CREDITO_FISCAL.ToString();
                config.AppSettings.Settings["TOKEN_CONSUMIDOR_FINAL"].Value = _TOKEN_CONSUMIDOR_FINAL.ToString();
                config.AppSettings.Settings["CAJA_ID"].Value = _CAJA_ID.ToString();
                config.AppSettings.Settings["CAJA_EFECTIVO"].Value = _CAJA_EFECTIVO.ToString();
                config.AppSettings.Settings["ID_CLIENTE_VARIOS"].Value = _ID_CLIENTE_VARIOS.ToString();
                config.AppSettings.Settings["ESTACION_ID"].Value = _ESTACION_ID.ToString();
                config.AppSettings.Settings["ID_CAJA_CONFIGURACION"].Value = _ID_CAJA_CONFIGURACION.ToString();
                config.AppSettings.Settings["MARCA_BLANCA"].Value = _MARCA_BLANCA.ToString();
                config.AppSettings.Settings["RUTA_DESTINO_BACKUP"].Value = _RUTA_DESTINO_BACKUP.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public enum TIPO_TOKEN
        {
            TICKET,
            CREDITO_FISCAL,
            CONSUMIDOR_FINAL,
            COSTURA,
        }

        public string Token(TIPO_TOKEN _tipo)
        {
            _token = 0;
            string _key = string.Empty;
            try
            {
                _cajaconfig = new CajaConfiguracion(_ID_CAJA_CONFIGURACION);

                switch (_tipo)
                {
                    case TIPO_TOKEN.TICKET:
                        _token = Convert.ToInt32(_cajaconfig.TokenTickets.Valor);
                        _key = "TOKEN_TICKET";
                        break;
                    case TIPO_TOKEN.CREDITO_FISCAL:
                        _token = Convert.ToInt32(_cajaconfig.TokenCFiscal.Valor);
                        _key = "TOKEN_CREDITO_FISCAL";
                        break;
                    case TIPO_TOKEN.CONSUMIDOR_FINAL:
                        _token = Convert.ToInt32(_cajaconfig.TokenCFinal.Valor);
                        _key = "TOKEN_CONSUMIDOR_FINAL";
                        break;
                    case TIPO_TOKEN.COSTURA:
                        _token = Convert.ToInt32(_cajaconfig.TokenCostura.Valor);
                        break;
                }
                if (_token > 0)
                {
                    //GuardarConfiguracion(_key, _token.ToString());

                    //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //config.AppSettings.Settings[_key].Value = (Convert.ToInt32(_token) + 1).ToString();
                    //config.Save(ConfigurationSaveMode.Modified);
                    //ConfigurationManager.RefreshSection("appSettings");

                    //Recargar();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _token.ToString();
        }

        public bool AceptarToken(TIPO_TOKEN _tipo)
        {
            bool _ok = false;
            try
            {
                switch (_tipo)
                {
                    case TIPO_TOKEN.TICKET:
                        _cajaconfig.TokenTickets.Valor = _token + 1;
                        break;
                    case TIPO_TOKEN.CREDITO_FISCAL:
                        _cajaconfig.TokenCFiscal.Valor = _token + 1;
                        break;
                    case TIPO_TOKEN.CONSUMIDOR_FINAL:
                        _cajaconfig.TokenCFinal.Valor = _token + 1;
                        break;
                    case TIPO_TOKEN.COSTURA:
                        _cajaconfig.TokenCostura.Valor = _token + 1;
                        break;
                }
                _cajaconfig.FechaCreacion.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                _ok = _bd.Actualizar(_cajaconfig) > 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public void GuardarConfiguracion(string _pkey, string _pvalor)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[_pkey].Value = _pvalor;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                Recargar();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public bool GuardarCambios()
        {
            bool _ok = false;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["ID_SUCURSAL"].Value = _ID_SUCURSAL.ToString();
                config.AppSettings.Settings["TASA_IVA"].Value = _TASA_IVA.ToString();
                config.AppSettings.Settings["TASA_PC003"].Value = _TASA_PC003.ToString();
                config.AppSettings.Settings["TASA_PC175"].Value = _TASA_PC175.ToString();
                config.AppSettings.Settings["PERIODO"].Value = _PERIODO.ToString();
                config.AppSettings.Settings["ID_BODEGA_SALIDA"].Value = _ID_BODEGA_SALIDA.ToString();
                config.AppSettings.Settings["TOKEN_TICKET"].Value = _TOKEN_TICKET.ToString();
                config.AppSettings.Settings["TOKEN_CREDITO_FISCAL"].Value = _TOKEN_CREDITO_FISCAL.ToString();
                config.AppSettings.Settings["TOKEN_CONSUMIDOR_FINAL"].Value = _TOKEN_CONSUMIDOR_FINAL.ToString();
                config.AppSettings.Settings["CAJA_ID"].Value = _CAJA_ID.ToString();
                config.AppSettings.Settings["CAJA_EFECTIVO"].Value = _CAJA_EFECTIVO.ToString();
                config.AppSettings.Settings["ID_CLIENTE_VARIOS"].Value = _ID_CLIENTE_VARIOS.ToString();
                config.AppSettings.Settings["ESTACION_ID"].Value = _ESTACION_ID.ToString();
                config.AppSettings.Settings["ID_CAJA_CONFIGURACION"].Value = _ID_CAJA_CONFIGURACION.ToString();
                config.AppSettings.Settings["MARCA_BLANCA"].Value = _MARCA_BLANCA.ToString();
                config.AppSettings.Settings["RUTA_DESTINO_BACKUP"].Value = _RUTA_DESTINO_BACKUP.ToString();

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
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
