using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class ProductoProveedores : EntityManager.Entidad
    {
        Descriptor _IDProveedor = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDProducto = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDPersona = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDProveedor { get { return _IDProveedor; } set { _IDProveedor = value; } }
        public Descriptor IDProducto { get { return _IDProducto; } set { _IDProducto = value; } }
        public Descriptor IDPersona { get { return _IDPersona; } set { _IDPersona = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public ProductoProveedores()
            : base("producto_proveedores")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public ProductoProveedores(int _pid)
            : base("producto_proveedores")
        {
            this.Procesar(this);
            _IDPersona.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public ProductoProveedores(DataRow _prow)
            : base("producto_proveedores")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
