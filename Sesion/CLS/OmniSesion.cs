using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sesion.CLS
{
    public sealed class OmniSesion
    {

        private static volatile OmniSesion instancia;
        private static Object syncRoot = new Object();
        private static Usuario _USUARIO;
        private static Configuracion _config;
        private static ConfigApp _configapp;
        private Boolean _Autorizado = false;

        #region Propiedades
        public ConfigApp CONFIGAPP
        {
            get { return OmniSesion._configapp; }
        }        
        public Boolean Autorizado
        {
            get { return _Autorizado; }
        }
        public Usuario USUARIO
        {
            get
            {
                return OmniSesion._USUARIO;
            }
        }
        #endregion

        private OmniSesion()
        {
            _config = new Configuracion();
            _configapp = new ConfigApp();
        }

        public static OmniSesion Instancia
        {
            get 
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                        {
                            instancia = new OmniSesion();
                            _USUARIO = new Usuario();
                        }
                    }
                }
                return instancia;
            }
        }

        #region Metodos
        public Boolean Validar(String pUsuario, String pCredencial)
        {
            Boolean validado = false;
            try
            {
                _USUARIO = new Usuario(pUsuario, pCredencial);
                _Autorizado = _USUARIO.Loguear();
                validado = Autorizado;
            }
            catch
            {
                _Autorizado = false;
                validado = Autorizado;
            }
            return validado;
        }

        public Boolean Reinstalar()
        {
            _config = new Configuracion();
            _configapp = new ConfigApp();
            return true;
        }

        #endregion
    }


}
