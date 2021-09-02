using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portable
{
    public sealed class Portador
    {
        private static volatile Portador instancia;
        private static Object syncRoot = new Object();
        private string _conexion = string.Empty;

        public string Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private Portador()
        {
            //nada
        }

        public static Portador Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                        {
                            instancia = new Portador();
                        }
                    }
                }
                return instancia;
            }
        }
    }
}
