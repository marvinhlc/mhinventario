using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesVendedores : EntityManager.Entidad
    {
        Descriptor _IDVendedor = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombreVendedor = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaHora = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDVendedor { get { return _IDVendedor; } set { _IDVendedor = value; } }
        public Descriptor NombreVendedor { get { return _NombreVendedor; } set { _NombreVendedor = value; } }
        public Descriptor FechaHora { get { return _FechaHora; } set { _FechaHora = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesVendedores()
            : base("ordenes_vendedores")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesVendedores(int _pid)
            : base("ordenes_vendedores")
        {
            this.Procesar(this);
            _IDVendedor.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesVendedores(DataRow _prow)
            : base("ordenes_vendedores")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
