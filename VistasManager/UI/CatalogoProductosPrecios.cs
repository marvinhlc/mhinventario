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
using EntityManager;

namespace VistasManager.UI
{
    public partial class CatalogoProductosPrecios : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _app = new Sesion.CLS.ConfigApp();
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtproductos = new DataTable();
        BindingSource _bsproductos = new BindingSource();
        DataTable _dtprecios = new DataTable();
        BindingSource _bsprecios = new BindingSource();

        ErrorProvider _errores = new ErrorProvider();

        ModelosManager.CLS.ProductoNombres _productos = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.ProductoPrecios _precios = new ModelosManager.CLS.ProductoPrecios();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoProductosPrecios()
        {
            InitializeComponent();
            Entorno();
            Iniciar();
        }

        public CatalogoProductosPrecios(int _pidproducto = 0)
        {
            _productos = new ModelosManager.CLS.ProductoNombres(_pidproducto);
            InitializeComponent();
            Entorno();
            Iniciar();
        }

        private void Entorno()
        {
            try
            {
                _dtproductos = _productos.Todo();
                _bsproductos.DataSource = _dtproductos;

                _dtprecios = _productos.EscalaPrecios();
                _bsprecios.DataSource = _dtprecios;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Iniciar()
        {
            try
            {
                txbEscalaInicial.ToZero();
                txbEscalaFinal.ToZero();
                txbPrecio.ToZeroDouble();

                if (_productos.Existe)
                {
                    txbCodigo.Text = _productos.CodigoProducto.Valor.ToString();
                    txbIDProducto.Text = _productos.IDProducto.Valor.ToString();
                    txbNombre.Text = _productos.NombreProducto.Valor.ToString();
                    txbPresentacion.Text = _productos.Presentacion.Valor.ToString();
                }

                dgvPrecios.AutoGenerateColumns = false;
                dgvPrecios.DataSource = _bsprecios;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }

        private void AgregarItem()
        {
            try
            {
                ModelosManager.CLS.ProductoPrecios _precio = new ModelosManager.CLS.ProductoPrecios();
                _precio.IDProducto.Valor = txbIDProducto.Text.TextoToEntero();
                _precio.EscalaInicial.Valor = txbEscalaInicial.Text.TextoToEntero();
                _precio.EscalaFinal.Valor = txbEscalaFinal.Text.TextoToEntero();
                _precio.Precio.Valor = txbPrecio.Text.TextoToDouble();

                if (_precio.Validar())
                {
                    if (_bd.Insertar(_precio) > 0)
                    {
                        Entorno();
                        txbEscalaInicial.ToZero();
                        txbEscalaFinal.ToZero();
                        txbPrecio.ToZeroDouble();
                        txbEscalaInicial.Focus();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvPrecios, _precios, Entorno);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbEscalaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbEscalaFinal.Focus();
            }
        }

        private void txbEscalaFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbPrecio.Focus();
            }
        }

        private void txbPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarItem();
            }
        }

        private void dgvPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataRow _row = dgvPrecios.CurrentRow.ToDataRow();
                    ModelosManager.CLS.ProductoPrecios _precio = new ModelosManager.CLS.ProductoPrecios(_row);
                    if (_bd.Actualizar(_precio) > 0)
                    {
                        MessageBox.Show("Registro fué modificado correctamente!", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbFiltrarIDProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            try
            {
                DataRow _row = (from _item in _dtproductos.AsEnumerable()
                                where _item.Field<string>("CodigoProducto") == txbFiltrarIDProducto.Text
                                select _item).FirstOrDefault<DataRow>();
                if (_row != null)
                {
                    _productos = new ModelosManager.CLS.ProductoNombres(_row);
                    if (_productos.Existe)
                    {
                        _dtprecios = _productos.EscalaPrecios();
                        _bsprecios.DataSource = _dtprecios;

                        Iniciar();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
