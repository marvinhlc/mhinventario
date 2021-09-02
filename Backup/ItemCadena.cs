using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backup
{
    public class ItemCadena
    {
        private string _nombre = string.Empty;
        private string _cadena = string.Empty;

        public string Cadena
        {
            get { return _cadena; }
            set { _cadena = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
