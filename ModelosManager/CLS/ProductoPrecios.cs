using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityManager;

namespace ModelosManager.CLS
{
    public class ProductoPrecios : EntityManager.Entidad
    {
        Descriptor _IDEscala = new Descriptor(DataManager.TypeManager.Tipo.ENTERO, DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDProducto = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _EscalaInicial = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _EscalaFinal = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Precio = new Descriptor(DataManager.TypeManager.Tipo.DOUBLE);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDEscala { get { return _IDEscala; } set { _IDEscala = value; } }
        public Descriptor IDProducto { get { return _IDProducto; } set { _IDProducto = value; } }
        public Descriptor EscalaInicial { get { return _EscalaInicial; } set { _EscalaInicial = value; } }
        public Descriptor EscalaFinal { get { return _EscalaFinal; } set { _EscalaFinal = value; } }
        public Descriptor Precio { get { return _Precio; } set { _Precio = value; } }
        public Descriptor FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        DataManager.Operacion _datos = new DataManager.Operacion();

        public ProductoPrecios()
            : base("producto_precios")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public ProductoPrecios(int _pid)
            : base("producto_precios")
        {
            this.Procesar(this);
            _IDEscala.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public ProductoPrecios(DataRow _prow)
            : base("producto_precios")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        //CARGAR DATOS POR ID DE PRODUCTO Y CANTIDAD
        public ProductoPrecios(int _pidproducto, double _pescala)
            : base("producto_precios")
        {
            this.Procesar(this);
            _IDProducto.Valor = _pidproducto;
            CargarPrecio(_pescala);
        }

        public void CargarPrecio(double _pescala)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDEscala,
	                            a.IDProducto,
	                            a.EscalaInicial,
	                            a.EscalaFinal,
	                            a.Precio,
	                            a.FechaCreacion
                            FROM producto_precios a
                            WHERE a.IDProducto = @pIDProducto
                            AND a.EscalaInicial <= @pEscala
                            AND a.EscalaFinal >= @pEscala
                            LIMIT 1";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pIDProducto", _IDProducto.Valor, DataManager.TypeManager.Tipo.ENTERO);
                _datos.AgregarParametro("pEscala", _pescala, DataManager.TypeManager.Tipo.DOUBLE);
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

        public bool Validar()
        {
            int _conteo = 0;
            if (Convert.ToInt32(_EscalaInicial.Valor) == 0)
                _conteo++;
            if (Convert.ToInt32(_EscalaInicial.Valor) == 0)
                _conteo++;
            if (Convert.ToDouble(_Precio.Valor) == 0)
                _conteo++;
            if (Convert.ToInt32(_IDProducto.Valor) == 0)
                _conteo++;

            return (_conteo == 0);
        }
    }
}
