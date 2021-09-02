using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class DocumentosImagenes : EntityManager.Entidad
    {
        Descriptor _IDImagen = new Descriptor(DataManager.TypeManager.Tipo.ENTERO,DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDDocumento = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Archivo = new Descriptor(DataManager.TypeManager.Tipo.VARCHAR);
        Descriptor _Imagen = new Descriptor(DataManager.TypeManager.Tipo.LONGBLOB);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP);
        public Descriptor IDImagen{get{return _IDImagen;}set{_IDImagen=value;}}
        public Descriptor IDDocumento{get{return _IDDocumento;}set{_IDDocumento=value;}}
        public Descriptor Archivo{get{return _Archivo;}set{_Archivo=value;}}
        public Descriptor Imagen{get{return _Imagen;}set{_Imagen=value;}}
        public Descriptor FechaCreacion{get{return _FechaCreacion;}set{_FechaCreacion=value;}}

         DataManager.Operacion _datos = new DataManager.Operacion();

        public DocumentosImagenes()
            : base("documentos_imagenes")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public DocumentosImagenes(int _pid)
            : base("documentos_imagenes")
        {
            this.Procesar(this);
            _IDImagen.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public DocumentosImagenes(DataRow _prow)
            : base("cortes_caja")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }

        public DataTable ObtenerDatosPorIDDocumento(int _piddocumento)
        {
            DataTable _tabla = new DataTable();
            string _sql = @"SELECT 
	                            a.IDImagen,
	                            a.IDDocumento,
	                            a.Archivo,
	                            a.Imagen,
	                            a.FechaCreacion
                            FROM documentos_imagenes a
                            WHERE a.IDDocumento = @pIDDocumento
                            ORDER BY a.FechaCreacion;";

            try
            {
                _datos.LimpiarParametro();
                _datos.AgregarParametro("pIDDocumento", _piddocumento, DataManager.TypeManager.Tipo.ENTERO);
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
