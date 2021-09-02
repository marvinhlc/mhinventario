using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class BuscadorProductos : Estilos.FormDialogos
    {
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();

        public ModelosManager.CLS.BodegasNombres Bodega
        {
            get { return _bodega; }
            set { _bodega = value; }
        }

        public ModelosManager.CLS.ProductoNombres Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();

        int _idproductoseleccionado = 0;
        bool _puntoventa = false;
        int _idbodegasalida = 0;
        int _idbodegaseleccionada = 0;

        CLS.Enumeraciones.FILTRO_PRODUCTOS_SERVICIOS _filtro = CLS.Enumeraciones.FILTRO_PRODUCTOS_SERVICIOS.PRODUCTOS;

        public int Idbodegaseleccionada
        {
            get { return _idbodegaseleccionada; }
            set { _idbodegaseleccionada = value; }
        }

        public int IDproductoSeleccionado
        {
            get { return _idproductoseleccionado; }
            set { _idproductoseleccionado = value; }
        }

        public BuscadorProductos(bool _ppuntoventa = false, int _pidbodegasalida = 0)
        {
            _puntoventa = _ppuntoventa;
            _idbodegasalida = _pidbodegasalida;
            InitializeComponent();
            Datos();
            Inicio();
        }

        public BuscadorProductos(CLS.Enumeraciones.FILTRO_PRODUCTOS_SERVICIOS _pfiltro)
        {
            _puntoventa = true;
            _idbodegasalida = 0;
            _filtro = _pfiltro;
            InitializeComponent();
            Datos();
            Inicio();
        }

        private void Datos()
        {
            try
            {
                if (_puntoventa)
                {
                    if (_filtro == CLS.Enumeraciones.FILTRO_PRODUCTOS_SERVICIOS.SERVICIOS)
                        _dtproductos = _producto.TodoServicios();
                    else
                    {
                        if (_idbodegasalida > 0)
                            _dtproductos = _producto.TodoPuntoVenta(_idbodegasalida);
                        else
                            _dtproductos = _producto.TodoPuntoVenta();
                    }
                }
                else
                {
                    _dtproductos = _producto.TodoFullBusqueda();
                }
                _bsproductos.DataSource = _dtproductos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Inicio()
        {
            try
            {
                if (_idbodegasalida == 0)
                {
                    dgvCatalogo.Columns["NombreBodega"].Visible = false;
                    dgvCatalogo.Columns["Existencia"].Visible = false;
                }
                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsproductos;

                ActiveControl = txbBuscarTexto.Control;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Datos();
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCatalogo.Notificar(BarraEstado);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsproductos.Filter = string.Format("FullBusqueda LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvCatalogo.Focus();
            }
        }

        private void SeleccionarRegistro()
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                _idproductoseleccionado = _row["IDProducto"].TextoToEntero();
                if (_idbodegasalida > 0)
                    _idbodegaseleccionada = _row["IDBodega"].TextoToEntero();

                _producto = new ModelosManager.CLS.ProductoNombres(_idproductoseleccionado);
                _bodega = new ModelosManager.CLS.BodegasNombres(_idbodegaseleccionada);
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void dgvCatalogo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
