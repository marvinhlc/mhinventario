using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EntityManager
{
    public class DataBase
    {
        StringBuilder _Sentencia = new StringBuilder();
        StringBuilder _Campos = new StringBuilder();
        StringBuilder _Valores = new StringBuilder();
        Descriptor _Key = new Descriptor();
        int _ultimoID = 0;

        public int UltimoID
        {
            get { return _ultimoID; }
            set { _ultimoID = value; }
        }

        public Int32  Insertar(Entidad pEntidad)
        {
            Int32 NumRegistrosAfectados = 0;
            Boolean Primero=true;
            DataManager.Operacion NuevaOperacion = new DataManager.Operacion();
            _Sentencia.Clear();
            _Campos.Clear();
            _Valores.Clear();
            _Key = new Descriptor();
            NuevaOperacion.LimpiarParametro();
            foreach(Descriptor item in pEntidad.Columnas)
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
                                _Valores.AppendFormat("MD5(@{0})", item.Campo);
                            }
                            else
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                {
                                    _Valores.AppendFormat("SHA1(@{0})", item.Campo);
                                }
                                else
                                {
                                    _Valores.AppendFormat("@{0}", item.Campo);
                                }
                            }
                            Primero = false;
                        }
                        else
                        {
                            _Campos.AppendFormat(",{0}", item.Campo);
                            if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                            {
                                _Valores.AppendFormat(",MD5(@{0})", item.Campo);
                            }
                            else
                            {
                                if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                {
                                    _Valores.AppendFormat(",SHA1(@{0})", item.Campo);
                                }
                                else
                                {
                                    _Valores.AppendFormat(",@{0}", item.Campo);
                                }
                            }
                        }
                        NuevaOperacion.AgregarParametro(item.Campo, item.Valor, item.Tipo);
                    }
                }
                catch
                {
                }

            }
            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            _Sentencia.Append("INSERT INTO " + pEntidad.Tabla + " (");
            _Sentencia.Append(_Campos.ToString ());
            _Sentencia.Append(") VALUES (");
            _Sentencia.Append(_Valores.ToString());
            _Sentencia.Append(");");

            NumRegistrosAfectados=NuevaOperacion.Insertar(_Sentencia.ToString());
            _ultimoID = NuevaOperacion.UltimoID();
            pEntidad.Existe = (_ultimoID > 0);
            _Key.Valor = _ultimoID;

            return NumRegistrosAfectados;
        }
        public Int32 Actualizar(Entidad pEntidad)
        {
            //Descriptor _Key = new Descriptor();
            Int32 NumRegistrosAfectados = 0;
            Boolean Primero = true;
            DataManager.Operacion NuevaOperacion = new DataManager.Operacion();
            _Sentencia.Clear();
            _Campos.Clear();
            _Valores.Clear();
            NuevaOperacion.LimpiarParametro();
            foreach (Descriptor item in pEntidad.Columnas)
            {
                try
                {
                    if (item.Modificador != DataManager.TypeManager.Modificador.NO_UPDATABLE)
                    {
                        if (!String.IsNullOrEmpty(item.Valor.ToString()) && item.Modificador != DataManager.TypeManager.Modificador.PRIMARIO)
                        {
                            if (Primero)
                            {
                                if (item.Tipo != DataManager.TypeManager.Tipo.TIMESTAMP)
                                {
                                    if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                                    {
                                        _Campos.Append(string.Format("{0}=MD5(@{1})", item.Campo, item.Campo));
                                    }
                                    else
                                    {
                                        if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                        {
                                            _Campos.Append(string.Format("{0}=SHA1(@{1})", item.Campo, item.Campo));
                                        }
                                        else
                                        {
                                            _Campos.Append(string.Format("{0}=@{1}", item.Campo, item.Campo));
                                        }
                                    }
                                }
                                Primero = false;
                            }
                            else
                            {
                                if (item.Tipo != DataManager.TypeManager.Tipo.TIMESTAMP)
                                {
                                    if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_MD5)
                                    {
                                        _Campos.Append(string.Format(",{0}=MD5(@{1})", item.Campo, item.Campo));
                                    }
                                    else
                                    {
                                        if (item.Modificador == DataManager.TypeManager.Modificador.PASSWORD_SHA1)
                                        {
                                            _Campos.Append(string.Format(",{0}=SHA1(@{1})", item.Campo, item.Campo));
                                        }
                                        else
                                        {
                                            _Campos.Append(string.Format(",{0}=@{1}", item.Campo, item.Campo));
                                        }
                                    }
                                }
                            }
                            if (item.Tipo != DataManager.TypeManager.Tipo.TIMESTAMP)
                            {
                                NuevaOperacion.AgregarParametro(item.Campo, item.Valor, item.Tipo);
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
                }
                catch
                {
                    //NADA
                }

            }
            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            if (_Key.Tipo == DataManager.TypeManager.Tipo.VARCHAR)
            {
                _Sentencia.Append(string.Format("UPDATE {0} SET {1} WHERE {2}='{3}';", pEntidad.Tabla, _Campos.ToString(), _Key.Campo, _Key.Valor));
            }
            else
            {
                _Sentencia.Append(string.Format("UPDATE {0} SET {1} WHERE {2}={3};", pEntidad.Tabla, _Campos.ToString(), _Key.Campo, _Key.Valor));
            }
            NumRegistrosAfectados = NuevaOperacion.Actualizar(_Sentencia.ToString());
            return NumRegistrosAfectados;
        }
        public Int32 Eliminar(Entidad pEntidad)
        {
            //Descriptor _Key = new Descriptor();
            Int32 NumRegistrosAfectados = 0;
            DataManager.Operacion NuevaOperacion = new DataManager.Operacion();
            _Sentencia.Clear();
            _Campos.Clear();
            _Valores.Clear();
            NuevaOperacion.LimpiarParametro();
            foreach (Descriptor item in pEntidad.Columnas)
            {
                try
                {
                    if (item.Modificador== DataManager.TypeManager.Modificador.PRIMARIO)
                    {
                        if (!String.IsNullOrEmpty(item.Valor.ToString()))
                        {
                            _Key = item;
                        }
                        NuevaOperacion.AgregarParametro(item.Campo, item.Valor, item.Tipo);
                    }
                }
                catch
                {
                }
            }
            //UNIENDO LAS SUBCADENAS PARA FORMAR LA CADENA DE INSERCION
            _Sentencia.Append(string.Format("DELETE FROM {0}  WHERE {1}=@{2};", pEntidad.Tabla, _Key.Campo, _Key.Campo));
            NumRegistrosAfectados = NuevaOperacion.Eliminar(_Sentencia.ToString());
            return NumRegistrosAfectados;
        }
    }
}
