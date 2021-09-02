using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class PersonasPagos : EntityManager.Entidad
    {

        Descriptor _IDPago = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDPersona = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Numero = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Fecha = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _Valor = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _Tipo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDPago { get { return _IDPago; } set { _IDPago = value; } }
        public Descriptor IDPersona { get { return _IDPersona; } set { _IDPersona = value; } }
        public Descriptor IDDocumento { get { return _IDDocumento; } set { _IDDocumento = value; } }
        public Descriptor Numero { get { return _Numero; } set { _Numero = value; } }
        public Descriptor Fecha { get { return _Fecha; } set { _Fecha = value; } }
        public Descriptor Valor { get { return _Valor; } set { _Valor = value; } }
        public Descriptor Tipo { get { return _Tipo; } set { _Tipo = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public PersonasPagos()
            : base("personas_pagos")
        {
            this.Procesar(this);
        }

        public PersonasPagos(int _pid)
            : base("personas_pagos")
        {
            this.Procesar(this);
            _IDPago.Valor = _pid;
            CargarDatosPorID();
        }

        public PersonasPagos(DataRow _prow)
            : base("personas_pagos")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
