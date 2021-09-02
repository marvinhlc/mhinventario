using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace VistasManager.CLS
{
    public class ItemVentas
    {
        int _IDDocumento = 0;
        int _IDProducto = 0;
        string _NombreProducto = string.Empty;
        int _IDBodega = 0;
        string _NombreBodega = string.Empty;
        double _Cantidad = 0;
        double _Precio = 0;
        string _CodigoProducto = string.Empty;
        double _Costo = 0;
        double _IvaRetenido = 0;
        double _PagoCuenta = 0;
        double _MontoIva = 0;
        string _FormatoVenta = string.Empty;
        string _FechaEntrega = string.Empty;
        double _Descuento = 0;
        double _Total = 0;
        bool _Aplicar_descuento = false;

        ModelosManager.CLS.ProductoNombres _producto_cache;
        ModelosManager.CLS.ProductoCategorias _categoria_cache;

        public bool Aplicar_descuento
        {
            get { return _Aplicar_descuento; }
            set { _Aplicar_descuento = value; }
        }

        public double Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }

        public string FechaEntrega
        {
            get { return _FechaEntrega; }
            set { _FechaEntrega = value; }
        }

        public ModelosManager.CLS.ProductoNombres Producto_cache
        {
            get { return _producto_cache; }
            set { _producto_cache = value; }
        }

        public string FormatoVenta
        {
            get { return _FormatoVenta; }
            set { _FormatoVenta = value; }
        }

        public double MontoIva
        {
            get { return _MontoIva; }
            set { _MontoIva = value; }
        }

        public double PagoCuenta
        {
            get { return _PagoCuenta; }
            set { _PagoCuenta = value; }
        }

        public double IvaRetenido
        {
            get { return _IvaRetenido; }
            set { _IvaRetenido = value; }
        }

        public double Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        public string CodigoProducto
        {
            get { return _CodigoProducto; }
            set { _CodigoProducto = value; }
        }

        public double Total
        {
            //get { return (_Cantidad * _Precio); }
            get { return _Total; }
        }

        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public double Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public string NombreBodega
        {
            get { return _NombreBodega; }
            set { _NombreBodega = value; }
        }

        public int IDBodega
        {
            get { return _IDBodega; }
            set { _IDBodega = value; }
        }

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
        }

        public int IDProducto
        {
            get { return _IDProducto; }
            set { _IDProducto = value; }
        }

        public int IDDocumento
        {
            get { return _IDDocumento; }
            set { _IDDocumento = value; }
        }

        private void AplicarDescuento(double _total)
        {
            double _porcentaje_descuento = 0;

            try
            {
                if (_Aplicar_descuento)
                {
                    if (_producto_cache == null)
                    {
                        _producto_cache = new ModelosManager.CLS.ProductoNombres(_IDProducto);
                        _categoria_cache = new ModelosManager.CLS.ProductoCategorias(_producto_cache.Categoria.Valor.ToString());
                    }

                    if (_categoria_cache == null)
                        _categoria_cache = new ModelosManager.CLS.ProductoCategorias(_producto_cache.Categoria.Valor.ToString());

                    _porcentaje_descuento = (Convert.ToDouble(_categoria_cache.Descuento.Valor) / 100);

                    if (_porcentaje_descuento > 0)
                    {
                        _Descuento = (_total * _porcentaje_descuento);
                        _Total = (_Total - _Descuento);
                    }
                }
                else
                {
                    _Descuento = 0;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Calcular(double _piva, double _ppagocuenta, string _pgravado)
        {
            double _total = 0;

            try
            {
                _total = (_Cantidad * _Precio);
                _IvaRetenido = (_total * _piva);
                _MontoIva = (_total - _IvaRetenido);

                _Total = _total;

                AplicarDescuento(_total);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Calcular()
        {
            double _total = 0;
            ModelosManager.CLS.ProductoNombres _producto = null;

            try
            {
                if (_producto_cache == null)
                    _producto = new ModelosManager.CLS.ProductoNombres(_IDProducto);
                else
                    _producto = _producto_cache;

                _total = (_Cantidad * _Precio);
                _IvaRetenido = (_total * Convert.ToDouble(_producto.TasaIVA.Valor));
                _MontoIva = (_total - _IvaRetenido);

                _Total = _total;

                AplicarDescuento(_total);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public ItemVentas()
        {
            //nada
        }

        public ItemVentas(DataRow _prow)
        {
            try
            {
                IDProducto = Convert.ToInt32(_prow["IDProducto"]);
                CodigoProducto = _prow["CodigoProducto"].ToString();
                NombreProducto = _prow["NombreProducto"].ToString();
                Precio = Convert.ToDouble(_prow["PrecioSalida"]);
                Costo = Convert.ToDouble(_prow["UltimoCosto"]);
                Cantidad = Convert.ToDouble(_prow["CantidadSalida"]);
                IDBodega = Convert.ToInt32(_prow["IDBodega"]);
                NombreBodega = _prow["NombreBodega"].ToString();
                FormatoVenta = _prow["FormatoVenta"].ToString();
                FechaEntrega = _prow["FechaEntrega"].ToString();

                _producto_cache = new ModelosManager.CLS.ProductoNombres(_IDProducto);
                _categoria_cache = new ModelosManager.CLS.ProductoCategorias(_producto_cache.Categoria.Valor.ToString());

                Calcular(Convert.ToDouble(_producto_cache.TasaIVA.Valor), Convert.ToDouble(_producto_cache.PagoCuenta.Valor), _producto_cache.EsGravado.Valor.ToString());
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
