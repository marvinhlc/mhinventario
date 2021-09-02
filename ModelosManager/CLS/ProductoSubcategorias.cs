using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class ProductoSubcategorias : EntityManager.Entidad
    {
        Descriptor _IDSubcategoria = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDCategoria = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _NombreSubCategoria = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _NombreCategoria = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        public Descriptor IDSubcategoria { get { return _IDSubcategoria; } set { _IDSubcategoria = value; } }
        public Descriptor IDCategoria { get { return _IDCategoria; } set { _IDCategoria = value; } }
        public Descriptor NombreSubCategoria { get { return _NombreSubCategoria; } set { _NombreSubCategoria = value; } }
        public Descriptor NombreCategoria { get { return _NombreCategoria; } set { _NombreCategoria = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public ProductoSubcategorias()
            : base("producto_subcategorias")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public ProductoSubcategorias(int _pid)
            : base("producto_subcategorias")
        {
            this.Procesar(this);
            _IDSubcategoria.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public ProductoSubcategorias(DataRow _prow)
            : base("producto_subcategorias")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable ObtenerPorIDCategoria(int _pidcategoria)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDSubcategoria,
	                            a.IDCategoria,
	                            a.NombreSubCategoria,
	                            a.NombreCategoria
                            FROM producto_subcategorias a
                            WHERE a.IDCategoria = @pIDCategoria
                            ORDER BY a.NombreSubCategoria;";
            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pIDCategoria", _pidcategoria, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
    }
}
