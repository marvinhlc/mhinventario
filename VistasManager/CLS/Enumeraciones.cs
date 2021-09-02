using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasManager.CLS
{
    public static class Enumeraciones
    {
        public enum TIPO_PERSONA
        {
            PROVEEDORES,
            CLIENTES
        }

        public enum OPERACION
        {
            ENTRADAS,
            SALIDAS
        }

        public enum EXPORTAR
        {
            RPT,
            EXCEL,
            PDF
        }

        public enum TIPO_DOCUMENTO
        {
            CONSUMIDOR_FINAL,
            CREDITO_FISCAL,
            TICKET,
            NA,
            NINGUNO,
            SERVICIOS
        }

        public enum FORMA_PAGO
        {
            CONTADO,
            CREDITO,
            NO_APLICA
        }

        public enum FILTRO_DOCUMENTO
        {
            VENTAS,
            COMPRAS,
            INVENTARIO,
            TIKET,
            CONSUMIDOR_FINAL,
            CREDITO_FISCAL,
            SERVICIOS
        }

        public enum FILTRO_PRODUCTOS_SERVICIOS
        {
            PRODUCTOS,
            SERVICIOS
        }

        public enum DIALOGO
        {
            NINGUNO,
            TIPO_PRENDA,
            INSTITUCION,
            COSTURERA_SASTRE,
            VENDEDOR,
        }
    }
}
