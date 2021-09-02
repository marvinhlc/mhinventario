using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sesion.CLS
{
    public class Configuracion
    {
        private string _CicloInscripcion = string.Empty;
        private string _CicloColegiaturas = string.Empty;
        private int _PeriodoActual = 0;
        private int _PeriodoPreuniversitario = 0;

        public int PeriodoPreuniversitario
        {
            get { return _PeriodoPreuniversitario; }
            set { _PeriodoPreuniversitario = value; }
        }

        public int PeriodoActual
        {
            get { return _PeriodoActual; }
            set { _PeriodoActual = value; }
        }

        public string CicloColegiaturas
        {
            get { return _CicloColegiaturas; }
            set { _CicloColegiaturas = value; }
        }

        public string CicloInscripcion
        {
            get { return _CicloInscripcion; }
            set { _CicloInscripcion = value; }
        }

        private void CargarDatos()
        {
            DataTable _Tabla = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM sistema_configuracion;");

            try
            {
                _Tabla = ObtenerDatos(sql.ToString());

                CicloInscripcion = _Tabla.Rows[0]["CicloInscripcion"].ToString();
                CicloColegiaturas = _Tabla.Rows[0]["CicloColegiaturas"].ToString();
                PeriodoActual = Convert.ToInt32(_Tabla.Rows[0]["PeriodoActual"].ToString());
                PeriodoPreuniversitario = Convert.ToInt32(_Tabla.Rows[0]["PeriodoPreuniversitario"].ToString());
            }
            catch
            {
                CicloInscripcion = string.Empty;
                CicloColegiaturas = string.Empty;
                PeriodoActual = 0;
                PeriodoPreuniversitario = 0;
            }
        }

        protected DataTable ObtenerDatos(string sentenciaSQL)
        {
            DataTable tabla = new DataTable();
            
            //try
            //{
            //    tabla = data.Consultar(sentenciaSQL);
            //}
            //catch
            //{
            //    tabla = null;
            //}
            return tabla;
        }

        public Configuracion()
        {
            CargarDatos();
        }
    }
}
