using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace DataManager
{
    sealed class Interprete
    {
        DbCommand _dbcomando;
        DbConnection _dbconexion;
        DbParameterCollection _dbparametros;
        string _sql = string.Empty;

        string _SQL = @"INSERT INTO migracion_log
                            (SentenciaSQL)
                        VALUES (?{0}?);";

        public Interprete(DbCommand _pdbcomando, DbConnection _pdbconexion)
        {
            _dbcomando = _pdbcomando;
            _dbconexion = _pdbconexion;
            _sql = _dbcomando.CommandText;
            _dbparametros = _dbcomando.Parameters;
            Construir();
        }

        private void Construir()
        {
            string _sqlmix = _sql;
            string _nombreparametro = string.Empty;
            int _regs = 0;
            try
            {
                foreach (DbParameter _param in _dbparametros)
                {
                    _nombreparametro = string.Format("@{0}", _param.ParameterName);
                    _sqlmix = _sqlmix.Replace(_nombreparametro, string.Format("'{0}'", _param.Value.ToString()));
                }
                if (_dbconexion.State == ConnectionState.Open)
                {
                    _SQL = string.Format(_SQL, _sqlmix).Replace('?', '"');
                    using (MySql.Data.MySqlClient.MySqlCommand _comando = new MySql.Data.MySqlClient.MySqlCommand(_SQL, _dbconexion as MySql.Data.MySqlClient.MySqlConnection))
                    {
                        _regs = _comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception _err)
            {
                Exception _otroerr = _err;
            }
        }
    }
}
