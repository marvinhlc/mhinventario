using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityManager
{
    public class Transaccion
    {
        StringBuilder _Sentencia = new StringBuilder();
        StringBuilder _Campos = new StringBuilder();
        StringBuilder _Valores = new StringBuilder();
        Descriptor _Key = new Descriptor();
        int _ultimoID = 0;

        List<string> _presql = new List<string>();
        List<Entidad> _maestro = new List<Entidad>();
        List<Entidad> _detalle = new List<Entidad>();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno(int _progreso);
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public int UltimoID
        {
            get { return _ultimoID; }
            set { _ultimoID = value; }
        }

        public Transaccion()
        {
            _presql.Clear();
            _maestro.Clear();
            _detalle.Clear();
        }

        public bool AnexarPreSql(string _psql)
        {
            bool _ok = false;
            try
            {
                _presql.Add(_psql);
                _ok = true;
            }
            catch (Exception _err)
            {
                _ok = false;
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public bool AnexarMaestro(Entidad _entidad)
        {
            bool _ok = false;
            try
            {
                _maestro.Add(_entidad);
                _ok = true;
            }
            catch (Exception _err)
            {
                _ok = false;
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public bool AnexarDetalle(Entidad _entidad)
        {
            bool _ok = false;
            try
            {
                _detalle.Add(_entidad);
                _ok = true;
            }
            catch (Exception _err)
            {
                _ok = false;
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public int Procesar()
        {
            int _registros = 0;
            int _tasa = 0;
            DataManager.Conexion _conexion = new DataManager.Conexion();
            MySql.Data.MySqlClient.MySqlCommand _comandos = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlTransaction _transac = null;

            try
            {
                _conexion.AbrirConexion();
                _transac = _conexion._Conexion.BeginTransaction();
                _comandos.Connection = _conexion._Conexion;
                _comandos.Transaction = _transac;

                //PROCESAMOS LAS PRESQL
                if (_presql.Count > 0)
                {
                    foreach (string _sql in _presql)
                    {
                        _comandos.CommandText = _sql;
                        _comandos.ExecuteNonQuery();
                        _registros++;
                        _tasa = (_registros * 100) / _presql.Count;

                        if (doRefrescarFormularioExterno != null)
                            doRefrescarFormularioExterno(_tasa);
                    }
                }
                _transac.Commit();
            }
            catch (Exception _err)
            {
                _transac.Rollback();
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _registros;
        }

        public int Procesar(string _NombreCampoID)
        {
            DataManager.Conexion _conexion = new DataManager.Conexion();
            MySql.Data.MySqlClient.MySqlCommand _comandos = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlTransaction _transac = null;

            try
            {
                _conexion.AbrirConexion();
                _transac = _conexion._Conexion.BeginTransaction();
                _comandos.Connection = _conexion._Conexion;
                _comandos.Transaction = _transac;

                //PROCESAMOS LAS PRESQL PRIMERO
                if (_presql.Count > 0)
                {
                    foreach (string _sql in _presql)
                    {
                        _comandos.CommandText = _sql;
                        _comandos.ExecuteNonQuery();
                    }
                }

                foreach (Entidad _padre in _maestro)
                {
                    _comandos.CommandText = Insertar(_padre);
                    _comandos.ExecuteNonQuery();
                }

                _ultimoID = Convert.ToInt32(_comandos.LastInsertedId);

                if (_ultimoID > 0)
                {
                    //PROCESAMOS LOS HIJOS
                    foreach (Entidad _hijo in _detalle)
                    {
                        foreach (Descriptor _columna in _hijo.Columnas)
                        {
                            if (_columna.Campo == _NombreCampoID)
                            {
                                _columna.Valor = _ultimoID;
                            }
                        }
                        _comandos.CommandText = Insertar(_hijo);
                        _comandos.ExecuteNonQuery();
                    }

                    _transac.Commit();
                }
                else
                {
                    _transac.Rollback();
                }
            }
            catch (Exception _err)
            {
                _transac.Rollback();
                Herramientas.Log.Registrar(_err.ToString());
            }
            _conexion.CerrarConexion();

            return _ultimoID;
        }

        #region METODOS DE PROCESAMIENTO DE CADENAS SQL
        public string Insertar(Entidad pEntidad)
        {
            Int32 NumRegistrosAfectados = 0;
            Boolean Primero = true;
            _Sentencia.Clear();
            _Campos.Clear();
            _Valores.Clear();
            _Key = new Descriptor();
            foreach (Descriptor item in pEntidad.Columnas)
            {
                try
                {
                    if (!String.IsNullOrEmpty(item.Valor.ToString()))
                    {
                        if (item.Modificador == DataManager.TypeManager.Modificador.PRIMARIO)
                        {
                            _Key = item;
                        }

                        if (Primero)
                        {
                            _Campos.Append(item.Campo);
                            if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                            {
                                _Valores.AppendFormat("MD5('{0}')", item.Valor);
                            }
                            else
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                {
                                    _Valores.AppendFormat("SHA1('{0}')", item.Valor);
                                }
                                else
                                {
                                    if (item.Tipo == DataManager.TypeManager.Tipo.DATE)
                                        _Valores.AppendFormat("'{0}'", item.Valor.FechaParaMySQL());
                                    else
                                        _Valores.AppendFormat("'{0}'", item.Valor);
                                }
                            }
                            Primero = false;
                        }
                        else
                        {
                            _Campos.AppendFormat(",{0}", item.Campo);
                            if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                            {
                                _Valores.AppendFormat(",MD5('{0}')", item.Valor);
                            }
                            else
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                {
                                    _Valores.AppendFormat(",SHA1('{0}')", item.Valor);
                                }
                                else
                                {
                                    if (item.Tipo == DataManager.TypeManager.Tipo.DATE)
                                        _Valores.AppendFormat(",'{0}'", item.Valor.FechaParaMySQL());
                                    else
                                        _Valores.AppendFormat(",'{0}'", item.Valor);
                                }
                            }
                        }
                        //NuevaOperacion.AgregarParametro(item.Campo, item.Valor, item.Tipo);
                    }
                }
                catch
                {
                }

            }
            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            _Sentencia.Append("INSERT INTO " + pEntidad.Tabla + " (");
            _Sentencia.Append(_Campos.ToString());
            _Sentencia.Append(") VALUES (");
            _Sentencia.Append(_Valores.ToString());
            _Sentencia.Append(");");

            //NumRegistrosAfectados = NuevaOperacion.Insertar(_Sentencia.ToString());
            //_ultimoID = NuevaOperacion.UltimoID();
            //pEntidad.Existe = (_ultimoID > 0);
            //_Key.Valor = _ultimoID;

            return _Sentencia.ToString();
        }
        #endregion
    }
}
