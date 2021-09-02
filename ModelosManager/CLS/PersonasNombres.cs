using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class PersonasNombres : EntityManager.Entidad
    {
        Descriptor _IDPersona = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _NombrePersona = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Contacto = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Pais = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _NIT = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _IVA = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _DUI = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Giro = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Tipo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Rol = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Precio = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDPersona { get { return _IDPersona; } set { _IDPersona = value; } }
        public Descriptor NombrePersona { get { return _NombrePersona; } set { _NombrePersona = value; } }
        public Descriptor Contacto { get { return _Contacto; } set { _Contacto = value; } }
        public Descriptor Pais { get { return _Pais; } set { _Pais = value; } }
        public Descriptor NIT { get { return _NIT; } set { _NIT = value; } }
        public Descriptor IVA { get { return _IVA; } set { _IVA = value; } }
        public Descriptor DUI { get { return _DUI; } set { _DUI = value; } }
        public Descriptor Giro { get { return _Giro; } set { _Giro = value; } }
        public Descriptor Tipo { get { return _Tipo; } set { _Tipo = value; } }
        public Descriptor Rol { get { return _Rol; } set { _Rol = value; } }
        public Descriptor Precio { get { return _Precio; } set { _Precio = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public PersonasNombres()
            : base("personas_nombres")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public PersonasNombres(int _pid)
            : base("personas_nombres")
        {
            this.Procesar(this);
            _IDPersona.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public PersonasNombres(DataRow _prow)
            : base("personas_nombres")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable TodosProveedores()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDPersona,
	                            a.NombrePersona,
	                            a.Contacto,
	                            a.Tipo,
	                            a.Rol,
                                a.Precio,
	                            a.Pais,
	                            a.NIT,
	                            a.IVA,
	                            a.DUI,
	                            a.Giro,
	                            a.FechaCreacion,
	                            CONCAT(a.IDPersona,'-',IFNULL(a.NIT,''),'-',IFNULL(a.DUI,''),'-',IFNULL(a.IVA,'')) as FullBuscar
                            FROM personas_nombres a
                            WHERE a.Rol = 'PROVEEDOR'
                            ORDER BY a.NombrePersona;";
            try
            {
                _tabla = _datos.Consultar(_sql);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _tabla;
        }

        public DataTable TodosClientes()
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDPersona,
	                            a.NombrePersona,
	                            a.Contacto,
	                            a.Tipo,
	                            a.Rol,
                                a.Precio,
	                            a.Pais,
	                            a.NIT,
	                            a.IVA,
	                            a.DUI,
	                            a.Giro,
	                            a.FechaCreacion
                            FROM personas_nombres a
                            WHERE a.Rol = 'CLIENTE'
                            ORDER BY a.NombrePersona;";
            try
            {
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
