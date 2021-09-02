using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EntityManager
{
    public sealed class Descriptor
    {
        public String Campo="";
        public Object Valor="";
        public DataManager.TypeManager.Tipo Tipo = DataManager.TypeManager.Tipo.STRING;
        public DataManager.TypeManager.Modificador Modificador=DataManager.TypeManager.Modificador.NORMAL;

        public Descriptor()
        {
            //compatibilidad
        }

        public Descriptor(DataManager.TypeManager.Tipo _ptipo, DataManager.TypeManager.Modificador _pModificador = DataManager.TypeManager.Modificador.NORMAL)
        {
            Tipo = _ptipo;
            Modificador = _pModificador;
        }
    }
}
