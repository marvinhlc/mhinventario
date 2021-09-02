using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EntityManager;
using Herramientas;

namespace ModelosManager.CLS
{
    public class OrdenesImagenes : EntityManager.Entidad
    {
        Descriptor _IDImagen = new Descriptor(DataManager.TypeManager.Tipo.ENTERO,DataManager.TypeManager.Modificador.PRIMARIO);
        Descriptor _IDOrden = new Descriptor(DataManager.TypeManager.Tipo.ENTERO);
        Descriptor _Archivo = new Descriptor(DataManager.TypeManager.Tipo.TEXT);
        Descriptor _Imagen = new Descriptor(DataManager.TypeManager.Tipo.LONGBLOB);
        Descriptor _FechaCreacion = new Descriptor(DataManager.TypeManager.Tipo.TIMESTAMP, DataManager.TypeManager.Modificador.NO_UPDATABLE);
        public Descriptor IDImagen{get{return _IDImagen;}set{_IDImagen=value;}}
        public Descriptor IDOrden{get{return _IDOrden;}set{_IDOrden=value;}}
        public Descriptor Archivo{get{return _Archivo;}set{_Archivo=value;}}
        public Descriptor Imagen{get{return _Imagen;}set{_Imagen=value;}}
        public Descriptor FechaCreacion{get{return _FechaCreacion;}set{_FechaCreacion=value;}}

        private int _dato_idimagen = 0;

        public int Dato_idimagen
        {
            get { return _dato_idimagen; }
            set { _dato_idimagen = value; }
        }
        private int _dato_idorden = 0;

        public int Dato_idorden
        {
            get { return _dato_idorden; }
            set { _dato_idorden = value; }
        }
        private string _dato_archivo = string.Empty;

        public string Dato_archivo
        {
            get { return _dato_archivo; }
            set { _dato_archivo = value; }
        }
        private string _dato_imagen;

        public string Dato_imagen
        {
            get { return _dato_imagen; }
            set { _dato_imagen = value; }
        }

        DataManager.Operacion _bd = new DataManager.Operacion();

        public OrdenesImagenes()
            : base("ordenes_imagenes")
        {
            this.Procesar(this);
        }

        //CARGAR DATOS POR ID
        public OrdenesImagenes(int _pid)
            : base("ordenes_imagenes")
        {
            this.Procesar(this);
            _IDImagen.Valor = _pid;
            CargarDatosPorID();
        }

        //CARGAR DATOS POR DATAROW
        public OrdenesImagenes(DataRow _prow)
            : base("ordenes_imagenes")
        {
            this.Procesar(this);
            Rellenar(_prow);
        }
    }
}
