using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class ProductoCategorias : EntityManager.Entidad
    {
        Descriptor _IDCategoria = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombreCategoria = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Descuento = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        public Descriptor IDCategoria { get { return _IDCategoria; } set { _IDCategoria = value; } }
        public Descriptor NombreCategoria { get { return _NombreCategoria; } set { _NombreCategoria = value; } }
        public Descriptor Descuento { get { return _Descuento; } set { _Descuento = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public ProductoCategorias()
            : base("producto_categorias")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public ProductoCategorias(int _pid)
            : base("producto_categorias")
        {
            this.Procesar(this);
            _IDCategoria.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public ProductoCategorias(DataRow _prow)
            : base("producto_categorias")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        //CARGAR DATOS POR DATAROW
        public ProductoCategorias(String _pcategoria)
            : base("producto_categorias")
        {
            this.Procesar(this);
            CargarPorNombreCategoria(_pcategoria);
        }

        private void CargarPorNombreCategoria(string _pcategoria)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDCategoria,
	                            a.NombreCategoria,
	                            a.Descuento
                            FROM producto_categorias a
                            WHERE a.NombreCategoria = @pCategoria
                            LIMIT 1;";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pCategoria", _pcategoria, DataManager.TypeManager.Tipo.VARCHAR);
                _tabla = _datos.Consultar(_sql);
                if (_tabla.Rows.Count > 0)
                {
                    DataRow _row = _tabla.Rows[0];
                    Rellenar(_row);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
