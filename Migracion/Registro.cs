using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;

namespace Migracion
{
    public class Registro
    {

        string _codigo_producto = string.Empty;

        public string Codigo_producto
        {
            get { return _codigo_producto; }
            set { _codigo_producto = value; }
        }
        string _nombre_producto = string.Empty;

        public string Nombre_producto
        {
            get { return _nombre_producto; }
            set { _nombre_producto = value; }
        }
        string _categoria = string.Empty;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        string _subcategoria = string.Empty;

        public string Subcategoria
        {
            get { return _subcategoria; }
            set { _subcategoria = value; }
        }

        string _precio1 = string.Empty;

        public string Precio1
        {
            get { return _precio1; }
            set { _precio1 = value; }
        }

        string _precio2 = string.Empty;

        public string Precio2
        {
            get { return _precio2; }
            set { _precio2 = value; }
        }

        string _precio3 = string.Empty;

        public string Precio3
        {
            get { return _precio3; }
            set { _precio3 = value; }
        }

        string _precio4 = string.Empty;

        public string Precio4
        {
            get { return _precio4; }
            set { _precio4 = value; }
        }
        string _precio5 = string.Empty;

        public string Precio5
        {
            get { return _precio5; }
            set { _precio5 = value; }
        }
        string _precio6 = string.Empty;

        public string Precio6
        {
            get { return _precio6; }
            set { _precio6 = value; }
        }
        string _precio7 = string.Empty;

        public string Precio7
        {
            get { return _precio7; }
            set { _precio7 = value; }
        }
        string _precio8 = string.Empty;

        public string Precio8
        {
            get { return _precio8; }
            set { _precio8 = value; }
        }
        string _precio9 = string.Empty;

        public string Precio9
        {
            get { return _precio9; }
            set { _precio9 = value; }
        }

        string _ultimo_costo = string.Empty;

        public string Ultimo_costo
        {
            get { return _ultimo_costo; }
            set { _ultimo_costo = value; }
        }

        public Registro()
        {
        }

        public Registro(string[] _campos)
        {
            _codigo_producto = _campos[0];
            _nombre_producto = _campos[1];
            _categoria = _campos[2];
            _subcategoria = _campos[3];
            _precio1 = ToCeroIfEmpty(_campos[4]);
            _precio2 = ToCeroIfEmpty(_campos[5]);
            _precio3 = ToCeroIfEmpty(_campos[6]);
            _precio4 = ToCeroIfEmpty(_campos[7]);
            _precio5 = ToCeroIfEmpty(_campos[8]);
            _precio6 = ToCeroIfEmpty(_campos[9]);
            _precio7 = ToCeroIfEmpty(_campos[10]);
            _precio8 = ToCeroIfEmpty(_campos[11]);
            _precio9 = ToCeroIfEmpty(_campos[12]);
            _ultimo_costo = ToCeroIfEmpty(_campos[13]);
        }

        private string ToCeroIfEmpty(string _dato)
        {
            string _retorno = _dato;
            if (string.IsNullOrEmpty(_dato))
                _retorno = "0";
            return _retorno;
        }

        public string SincronizarPrecios()
        {
            string _sql = string.Empty;
            _sql = string.Format(@"UPDATE producto_nombres
                                    SET 
	                                    Precio1 = IFNULL({0},0),
	                                    Precio2 = IFNULL({1},0),
	                                    Precio3 = IFNULL({2},0),
	                                    Precio4 = IFNULL({3},0),
	                                    Precio5 = IFNULL({4},0),
	                                    Precio6 = IFNULL({5},0),
	                                    Precio7 = IFNULL({6},0),
	                                    Precio8 = IFNULL({7},0),
	                                    Precio9 = IFNULL({8},0),
                                        UltimoCosto = IFNULL({9},0)
                                    WHERE CodigoProducto = '{10}';", 
                                    _precio1,
                                    _precio2,
                                    _precio3,
                                    _precio4,
                                    _precio5,
                                    _precio6,
                                    _precio7,
                                    _precio8,
                                    _precio9,
                                    _ultimo_costo,
                                    _codigo_producto
                    );
            return _sql;
        }

        public string CrearRegistros()
        {
            string _sql = string.Empty;
            _sql = string.Format(@"INSERT IGNORE INTO producto_nombres (
                                    CodigoProducto,
	                                NombreProducto,
	                                Categoria,
	                                SubCategoria,
	                                Precio1,
	                                Precio2,
	                                Precio3,
	                                Precio4,
	                                Precio5,
	                                Precio6,
	                                Precio7,
	                                Precio8,
	                                Precio9,
                                    UltimoCosto
                                ) VALUES (
                                    '{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}
                                );", 
                                   _codigo_producto, 
                                   _nombre_producto, 
                                   _categoria, 
                                   _subcategoria, 
                                   _precio1,
                                   _precio2,
                                   _precio3,
                                   _precio4,
                                   _precio5,
                                   _precio6,
                                   _precio7,
                                   _precio8,
                                   _precio9,
                                   _ultimo_costo
                               );
            return _sql;
        }

        public string SincronizarCategorias()
        {
            string _sql = string.Empty;
            _sql = string.Format(@"INSERT IGNORE INTO producto_categorias
	                                    (NombreCategoria)
                                    VALUES ('{0}');

                                    INSERT IGNORE INTO producto_subcategorias
	                                    (IDCategoria,NombreSubCategoria,NombreCategoria)
                                    VALUES
	                                    ((SELECT a.IDCategoria FROM producto_categorias a 
                                            WHERE a.NombreCategoria = '{0}' LIMIT 1),'{1}','{0}');", _categoria, _subcategoria);
            return _sql;
        }

        public string SincronizarCostos()
        {
            string _sql = string.Empty;
            _sql = string.Format(@"UPDATE producto_nombres
                                    SET 
                                        UltimoCosto = IFNULL({0},0)
                                    WHERE CodigoProducto = '{1}';",
                                    _ultimo_costo,
                                    _codigo_producto
                    );
            return _sql;
        }
    }
}
