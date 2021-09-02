using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class BodegasNombres : EntityManager.Entidad
    {
        Descriptor _IDBodega = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombreBodega = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        public Descriptor IDBodega { get { return _IDBodega; } set { _IDBodega = value; } }
        public Descriptor NombreBodega { get { return _NombreBodega; } set { _NombreBodega = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public BodegasNombres()
            : base("bodegas_nombres")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public BodegasNombres(int _pid)
            : base("bodegas_nombres")
        {
            this.Procesar(this);
            _IDBodega.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public BodegasNombres(DataRow _prow)
            : base("bodegas_nombres")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
