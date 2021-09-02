using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class Gastos : EntityManager.Entidad
    {
        Descriptor _IDGasto = new Descriptor(DataManager.TypeManager.Tipo.ENTERO,DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _Numero = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Fecha = new Descriptor(DataManager.TypeManager.Tipo.DATE);
        Descriptor _Clasificacion = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Descripcion = new Descriptor(DataManager.TypeManager.Tipo.TEXT);
        Descriptor _Importe = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        //Descriptor _FechaInsert = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP, DataManager.TypeManager.Modificador.NO_UPDATABLE);
        //Descriptor _FechaUpdate = new Descriptor(DataManager.TypeManager.Tipo.DATETIME, DataManager.TypeManager.Modificador.NO_UPDATABLE);
        public Descriptor IDGasto{get{return _IDGasto;}set{_IDGasto=value;}}
        public Descriptor Numero{get{return _Numero;}set{_Numero=value;}}
        public Descriptor Fecha{get{return _Fecha;}set{_Fecha=value;}}
        public Descriptor Clasificacion{get{return _Clasificacion;}set{_Clasificacion=value;}}
        public Descriptor Descripcion{get{return _Descripcion;}set{_Descripcion=value;}}
        public Descriptor Importe{get{return _Importe;}set{_Importe=value;}}
        //public Descriptor FechaInsert{get{return _FechaInsert;}set{_FechaInsert=value;}}
        //public Descriptor FechaUpdate{get{return _FechaUpdate;}set{_FechaUpdate=value;}}

        DataManager.Operacion _bd = new DataManager.Operacion();

        public Gastos()
            : base("gastos")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public Gastos(int _pid)
            : base("gastos")
        {
            this.Procesar(this);
            _IDGasto.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public Gastos(DataRow _prow)
            : base("gastos")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable Todo(int _pperiodo = 0)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT
	                            a.IDGasto,
	                            a.Numero,
	                            a.Fecha,
	                            a.Clasificacion,
	                            a.Descripcion,
	                            a.Importe
                            FROM gastos a
                            WHERE YEAR(a.Fecha) = @pPeriodo
                            ORDER BY a.Fecha,a.Numero;";

            try
            {
                _bd.LimpiarParametro();
                _bd.AgregarParametro("pPeriodo", _pperiodo, DataManager.TypeManager.Tipo.ENTERO);
                _tabla = _bd.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }
    }
}
