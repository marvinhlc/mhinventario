using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntityManager
{
    public abstract class Entidad
    {
        DataManager.Operacion _datos = new DataManager.Operacion();
        String _Tabla;
        public List<Descriptor> Columnas = new List<Descriptor>();
        bool _existe = false;

        public bool Existe
        {
            get { return _existe; }
            set { _existe = value; }
        }

        public String Tabla
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }

        public Entidad(String pTabla)
        {
            this._Tabla = pTabla;
        }

        public void FromDataRow(DataRow _row)
        {
            Rellenar(_row);
        }

        protected void Procesar(Entidad objeto)
        {
            try
            {
                foreach (PropertyInfo propiedad in this.GetType().GetProperties())
                {
                    Descriptor Nuevo = new Descriptor();
                    Nuevo = propiedad.GetValue(this, null) as Descriptor;
                    Nuevo.Campo = propiedad.Name;
                    Columnas.Add(Nuevo);
                }
            }
            catch (Exception _err)
            {
                //Herramientas.Log.Registrar(_err.ToString());
            }
        }

        //LLENA LAS PROPIEDADES CON LOS DATOS DEL REGISTRO
        protected void Rellenar(DataRow _prow)
        {
            try
            {
                foreach (Descriptor _item in Columnas)
                {
                    try
                    {
                        if (_item.Tipo == DataManager.TypeManager.Tipo.BLOB || _item.Tipo == DataManager.TypeManager.Tipo.MEDIUMBLOB)
                        {
                            _item.Valor = (byte[])_prow[_item.Campo];
                        }
                        else
                        {
                            if (_item.Tipo == DataManager.TypeManager.Tipo.DATE)
                            {
                                _item.Valor = _prow[_item.Campo].FechaParaMySQL();
                            }
                            else
                            {
                                _item.Valor = _prow[_item.Campo].ToString();
                            }
                        }
                    }
                    catch (Exception _err)
                    {
                        Herramientas.Log.Registrar(_err.ToString());
                    }
                }

                Existe = (_prow != null);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        #region METODOS PARA CARGAR REGISTROS BASICOS
        public void CargarDatosPorID()
        {
            DataTable _registro = new DataTable();

            try
            {
                _registro = _datos.Consultar(this.SelectSQL());
                Existe = (_registro.Rows.Count > 0);

                this.Rellenar(_registro.Rows[0]);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public DataTable Todo(string _pcampoordenar = "")
        {
            DataTable _tabla = new DataTable();

            try
            {
                _tabla = _datos.Consultar(this.SelectTodoSQL("", _pcampoordenar));
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable Todo(string _pfiltro, string _pcampoordenar = "")
        {
            DataTable _tabla = new DataTable();

            try
            {
                _tabla = _datos.Consultar(this.SelectTodoSQL(_pfiltro, _pcampoordenar));
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
        #endregion

        #region SENTENCIAS CRUD (EXPERIMIENTAL)
        public string SelectTodoSQL(string _where, string _orderby)
        {
            StringBuilder _sql = new StringBuilder();
            StringBuilder _Campos = new StringBuilder();
            StringBuilder _Valores = new StringBuilder();
            Boolean Primero = true;
            Descriptor _Key = new Descriptor();

            try
            {
                foreach (Descriptor item in Columnas)
                {
                    try
                    {
                        if (Primero)
                        {
                            if (item.Modificador == DataManager.TypeManager.Modificador.PRIMARIO)
                            {
                                _Campos.Append(item.Campo);
                                _Key = item;
                            }
                            else
                            {
                                _Campos.Append(item.Campo);
                            }
                            Primero = false;
                        }
                        else
                        {
                            _Campos.AppendFormat(",{0}", item.Campo);
                        }
                    }
                    catch
                    {
                        //Se ignora por tratarse de campo no establecido
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE CONSULTA
            if (string.IsNullOrEmpty(_where))
            {
                _where = string.Format("{0} > 0", _Key.Campo);
            }
            if (string.IsNullOrEmpty(_orderby))
            {
                _orderby = _Key.Campo;
            }
            _sql.Append(string.Format("SELECT {0} FROM {1} a WHERE {2} ORDER BY {3};", _Campos.ToString(), _Tabla, _where, _orderby));
            return _sql.ToString();
        }

        public string SelectSQL()
        {
            StringBuilder _sql = new StringBuilder();
            StringBuilder _Campos = new StringBuilder();
            StringBuilder _Valores = new StringBuilder();
            Boolean Primero = true;
            Descriptor _Key = new Descriptor();

            try
            {
                foreach (Descriptor item in Columnas)
                {
                    try
                    {
                        if (Primero)
                        {
                            if (item.Modificador == DataManager.TypeManager.Modificador.PRIMARIO)
                            {
                                _Campos.Append(item.Campo);                                
                                _Key = item;
                            }
                            else
                            {
                                _Campos.Append(item.Campo);
                            }
                            Primero = false;
                        }
                        else
                        {
                            _Campos.AppendFormat(",{0}", item.Campo);
                        }
                    }
                    catch
                    {
                        //Se ignora por tratarse de campo no establecido
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE CONSULTA
            _sql.Append(string.Format("SELECT {0} FROM {1} a WHERE {2}='{3}';", _Campos.ToString(), _Tabla, _Key.Campo, _Key.Valor));
            return _sql.ToString();
        }

        public string InsertSQL()
        {
            StringBuilder _sql = new StringBuilder();
            StringBuilder _Campos = new StringBuilder();
            StringBuilder _Valores = new StringBuilder();
            Boolean Primero = true;

            try
            {
                foreach (Descriptor item in Columnas)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(item.Valor.ToString()))
                        {
                            if (Primero)
                            {
                                _Campos.Append(item.Campo);
                               
                                switch (item.Modificador)
                                {
                                    case DataManager.TypeManager.Modificador.PASSWORD_MD5:
                                        _Valores.AppendFormat("MD5('{0}')", item.Valor);
                                        break;
                                    case DataManager.TypeManager.Modificador.PASSWORD_SHA1:
                                        _Valores.AppendFormat("SHA1('{0}')", item.Valor);
                                        break;
                                    default:
                                        if (item.Tipo == DataManager.TypeManager.Tipo.DATETIME || item.Tipo == DataManager.TypeManager.Tipo.TIMESTAMP)
                                        {
                                            _Valores.AppendFormat("'{0}'", item.Valor.FechaParaMySQL());
                                        }
                                        else
                                        {
                                            _Valores.AppendFormat("'{0}'", item.Valor);
                                        }
                                        break;
                                }
                               
                                Primero = false;
                            }
                            else
                            {
                                _Campos.AppendFormat(",{0}", item.Campo);

                                switch (item.Modificador)
                                {
                                    case DataManager.TypeManager.Modificador.PASSWORD_MD5:
                                        _Valores.AppendFormat(",MD5('{0}')", item.Valor);
                                        break;
                                    case DataManager.TypeManager.Modificador.PASSWORD_SHA1:
                                        _Valores.AppendFormat(",SHA1('{0}')", item.Valor);
                                        break;
                                    default:
                                        if (item.Tipo == DataManager.TypeManager.Tipo.DATETIME || item.Tipo == DataManager.TypeManager.Tipo.TIMESTAMP)
                                        {
                                            _Valores.AppendFormat(",'{0}'", item.Valor.FechaParaMySQL());
                                        }
                                        else
                                        {
                                            _Valores.AppendFormat(",'{0}'", item.Valor);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    catch 
                    {
                        //Se ignora por tratarse de campo no establecido
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            _sql.Append("INSERT INTO " + _Tabla + " (");
            _sql.Append(_Campos.ToString());
            _sql.Append(") VALUES (");
            _sql.Append(_Valores.ToString());
            _sql.Append(");");

            return _sql.ToString();
        }

        public string UpdateSQL()
        {
            StringBuilder _sql = new StringBuilder();
            StringBuilder _Campos = new StringBuilder();
            StringBuilder _Valores = new StringBuilder();
            Boolean Primero = true;
            Descriptor _Key = new Descriptor();

            try
            {
                foreach (Descriptor item in Columnas)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(item.Valor.ToString()) && item.Modificador != DataManager.TypeManager.Modificador.PRIMARIO)
                        {
                            if (Primero)
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                                {
                                    _Campos.Append(string.Format("{0}=MD5('{1}')", item.Campo, item.Valor));
                                }
                                else
                                {
                                    if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                    {
                                        _Campos.Append(string.Format("{0}=SHA1('{1}')", item.Campo, item.Valor));
                                    }
                                    else
                                    {
                                        _Campos.Append(string.Format("{0}='{1}'", item.Campo, item.Valor));
                                    }
                                }
                                Primero = false;
                            }
                            else
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                                {
                                    _Campos.Append(string.Format(",{0}=MD5('{1}')", item.Campo, item.Valor));
                                }
                                else
                                {
                                    if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                    {
                                        _Campos.Append(string.Format(",{0}=SHA1('{1}')", item.Campo, item.Valor));
                                    }
                                    else
                                    {
                                        _Campos.Append(string.Format(",{0}='{1}'", item.Campo, item.Valor));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(item.Valor.ToString()))
                            {
                                _Key = item;
                            }
                        }
                    }
                    catch
                    {
                        //Se ignora por tratarse de campo no establecido
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            _sql.Append(string.Format("UPDATE {0} SET {1} WHERE {2}='{3}';", _Tabla, _Campos.ToString(), _Key.Campo, _Key.Valor));

            return _sql.ToString();
        }

        public string DeleteSQL()
        {
            StringBuilder _sql = new StringBuilder();
            StringBuilder _Campos = new StringBuilder();
            StringBuilder _Valores = new StringBuilder();
            Descriptor _Key = new Descriptor();

            try
            {
                foreach (Descriptor item in Columnas)
                {
                    try
                    {
                        if (item.Modificador == DataManager.TypeManager.Modificador.PRIMARIO)
                        {
                            if (!String.IsNullOrEmpty(item.Valor.ToString()))
                            {
                                _Key = item;
                            }
                        }
                    }
                    catch
                    {
                        //Se ignora por tratarse de campo no establecido
                    }
                }
                //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
                _sql.Append(string.Format("DELETE FROM {0}  WHERE {1}='{2}';", _Tabla, _Key.Campo, _Key.Valor));
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _sql.ToString();
        }
        #endregion
    }
}
