using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public static class TypeManager
    {
        public enum Tipo
        {
            ENTERO= MySqlDbType.Int32,
            DOUBLE= MySqlDbType.Double,
            DECIMAL= MySqlDbType.Decimal,
            VARCHAR = MySqlDbType.VarChar,
            BOOL=MySqlDbType.UInt16,
            ENUM=MySqlDbType.Enum,
            CHAR=MySqlDbType.String,
            DATETIME= MySqlDbType.DateTime,
            DATE= MySqlDbType.Date,
            TEXT= MySqlDbType.Text,
            LONGTEXT= MySqlDbType.LongText,
            STRING= MySqlDbType.String,
            BLOB= MySqlDbType.Blob,
            TIMESTAMP = MySqlDbType.Timestamp,
            MEDIUMBLOB = MySqlDbType.MediumBlob,
            LONGBLOB = MySqlDbType.LongBlob
        }
        public enum Modificador
        {
            PRIMARIO = 0,
            NORMAL = 1,
            FORANEO = 2,
            PASSWORD_MD5 = 3,
            PASSWORD_SHA1 = 4,
            NO_UPDATABLE
        }
    }
}
