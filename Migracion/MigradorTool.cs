using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using EntityManager;
using ModelosManager.CLS;
using Herramientas;

namespace Migracion
{
    public class MigradorTool
    {
        private string _nombreRango = "Catalogo";
        private string _cadenaConexion = string.Empty;
        private string _ficheroXls = string.Empty;
        StringBuilder _sbsql = new StringBuilder();
        DataSet _dsrango = new DataSet();
        DataBase _db = new DataBase();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno(int _ptotal, int _pconteo);
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public DataSet ObtenerRangoDesdeFicheroXls(string _pfichero)
        {
            _sbsql.Clear();
            _ficheroXls = _pfichero;
            if (!string.IsNullOrEmpty(_ficheroXls))
            {
                string _proveedor = @"Provider=Microsoft.Jet.OLEDB.4.0; 
                                        Data Source={0}; 
                                        Extended Properties='Excel 8.0; Xml; 
                                        HDR=NO;'";
                _cadenaConexion = string.Format(_proveedor, _ficheroXls);

                try
                {
                    _sbsql.AppendFormat("SELECT * FROM [{0}]", _nombreRango);
                    
                    OleDbConnection _oldbconexion = new OleDbConnection(_cadenaConexion);
                    OleDbCommand _oledbcommando = new OleDbCommand(_sbsql.ToString(), _oldbconexion);
                    OleDbDataAdapter _oledbadapter = new OleDbDataAdapter(_oledbcommando);

                    _oledbadapter.Fill(_dsrango, "tabla_catalogo");
                }
                catch (Exception)
                {
                    _dsrango = null;
                    throw;
                }
            }
            return _dsrango;
        }

        public bool ProcesarCatalogoProductos(DataTable _dtcatalogo)
        {
            bool _ok = false;
            int _conteo = 0;
            int _total = 0;
            ProductoNombres _producto = new ProductoNombres();
            
            try
            {
                _total = _dtcatalogo.Rows.Count;

                foreach (DataRow _row in _dtcatalogo.Rows)
                {
                    _producto = new ProductoNombres();
                    _producto.CodigoProducto.Valor = _row[0];
                    _producto.FormatoVenta.Valor = _row[1].ToString();
                    _producto.NombreProducto.Valor = _row[2].ToString();
                    _producto.Precio1.Valor = _row[3].ToDoubleIfNull();
                    _producto.Precio2.Valor = _row[4].ToDoubleIfNull();
                    _producto.Precio3.Valor = _row[5].ToDoubleIfNull();
                    _producto.Precio4.Valor = _row[6].ToDoubleIfNull();
                    _producto.Precio5.Valor = _row[7].ToDoubleIfNull();
                    _producto.Precio6.Valor = _row[8].ToDoubleIfNull();
                    _producto.Precio7.Valor = _row[9].ToDoubleIfNull();
                    _producto.Precio8.Valor = _row[10].ToDoubleIfNull();
                    _producto.Precio9.Valor = _row[11].ToDoubleIfNull();
                    _producto.UltimoCosto.Valor = _row[12].ToDoubleIfNull();
                    _producto.Categoria.Valor = "OTROS";
                    _producto.SubCategoria.Valor = "OTROS";
                    _producto.EsGravado.Valor = "SI";
                    _producto.PagoCuenta.Valor = 0.0175;
                    _producto.TasaIVA.Valor = 0.13;
                    _producto.Descontinuado.Valor = "NO";
                    _producto.PuntoVenta.Valor = "SI";

                    if (_db.Insertar(_producto) > 0)
                    {
                        _conteo++;
                        if (doRefrescarFormularioExterno != null)
                        {
                            doRefrescarFormularioExterno(_total, _conteo);
                        }
                    }
                }

                _ok = (_dtcatalogo.Rows.Count == _conteo);
            }
            catch (Exception _err)
            {
                //nada
            }
            return _ok;
        }

        public bool EliminarRegistros()
        {
            bool _ok = false;
            int _registros = 0;
            string _sql = @"DELETE FROM producto_nombres 
                            WHERE producto_nombres.IDProducto > 0;";
            DataManager.Operacion _datos = new DataManager.Operacion();
            try
            {
                _registros = _datos.Eliminar(_sql);
                if (_registros > 0 || _registros == 0)
                    _ok = true;
                else
                    _ok = false;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }
    }
}
