using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityManager;
using System.Data;

namespace Sesion.CLS
{
    class CajaConfiguracion : EntityManager.Entidad
    {
        Descriptor _IDCajaConfiguracion = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _Estacion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _TokenTickets = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _TokenCFiscal = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _TokenCFinal = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _TokenCostura = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _FechaActualizacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.DATETIME);
        public Descriptor IDCajaConfiguracion { get { return _IDCajaConfiguracion; } set { _IDCajaConfiguracion = value; } }
        public Descriptor Estacion { get { return _Estacion; } set { _Estacion = value; } }
        public Descriptor TokenTickets { get { return _TokenTickets; } set { _TokenTickets = value; } }
        public Descriptor TokenCFiscal { get { return _TokenCFiscal; } set { _TokenCFiscal = value; } }
        public Descriptor TokenCFinal { get { return _TokenCFinal; } set { _TokenCFinal = value; } }
        public Descriptor TokenCostura { get { return _TokenCostura; } set { _TokenCostura = value; } }
        public Descriptor FechaActualizacion { get { return _FechaActualizacion; } set { _FechaActualizacion = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public CajaConfiguracion()
            : base("caja_configuracion")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public CajaConfiguracion(int _pid)
            : base("caja_configuracion")
        {
            this.Procesar(this);
            _IDCajaConfiguracion.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public CajaConfiguracion(DataRow _prow)
            : base("caja_configuracion")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
