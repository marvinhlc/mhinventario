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
    public partial class CatalogoProductosEditor : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _app = new Sesion.CLS.ConfigApp();
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtcategorias = new DataTable();
        BindingSource _bscategorias = new BindingSource();
        DataTable _dtsubcategorias = new DataTable();
        BindingSource _bssubcategorias = new BindingSource();

        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();
        ModelosManager.CLS.ProductoSubcategorias _subcategorias = new ModelosManager.CLS.ProductoSubcategorias();
        ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres();
        ModelosManager.CLS.ProductoProveedores _relacion = new ModelosManager.CLS.ProductoProveedores();

        ErrorProvider _errores = new ErrorProvider();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoProductosEditor(int _idproducto = 0)
        {
            _producto = new ModelosManager.CLS.ProductoNombres(_idproducto);
            InitializeComponent();
            Iniciar();
        }

        public CatalogoProductosEditor(int _idproducto, int _pidproveedor)
        {
            _producto = new ModelosManager.CLS.ProductoNombres(_idproducto);
            _relacion = new ModelosManager.CLS.ProductoProveedores(_pidproveedor);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtcategorias = _categorias.Todo("NombreCategoria");
                _bscategorias.DataSource = _dtcategorias;
                _dtsubcategorias = _subcategorias.Todo("NombreSubcategoria");
                _bssubcategorias.DataSource = _dtsubcategorias;

                Categoria.DisplayMember = "NombreCategoria";
                Categoria.ValueMember = "NombreCategoria";
                Categoria.DataSource = _bscategorias;
                Categoria.SelectedIndex = 0;

                PrecioVenta.ToZeroDouble();
                UltimoCosto.ToZeroDouble();
                PagoCuenta.Text = _app.TASA_PC175.ToString();
                TasaIVA.Text = _app.TASA_IVA.ToString();

                Descontinuado.ReglaSiNo();
                EsGravado.ReglaSiNo();
                PuntoVenta.ReglaSiNo();
                EsServicio.ReglaSiNo();

                if (_producto.Existe)
                {
                    grupoIdentificacion.Mapear(_producto);
                    grupoCategoria.Mapear(_producto);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _bssubcategorias.Filter = string.Format("NombreCategoria = '{0}'", Categoria.SelectedValue);

                Subcategoria.DisplayMember = "NombreSubcategoria";
                Subcategoria.ValueMember = "NombreSubcategoria";
                Subcategoria.DataSource = _bssubcategorias;
                Subcategoria.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            bool _ok = false;
            try
            {
                grupoCategoria.Sincronizar(_producto);
                grupoIdentificacion.Sincronizar(_producto);

                if (Validaciones())
                {
                    if (_producto.Existe)
                    {
                        _ok = (_bd.Actualizar(_producto) > 0);
                    }
                    else
                    {
                        _ok = (_bd.Insertar(_producto) > 0);
                        _producto.IDProducto.Valor = _bd.UltimoID;
                    }
                }
                if (_relacion.IDPersona.Valor.TextoToEntero() > 0)
                {
                    if (MessageBox.Show("¿Desea relacionar éste producto con el proveedor actual?", "RELACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        _relacion.IDProducto.Valor = _producto.IDProducto.Valor;
                        _ok = (_bd.Insertar(_relacion) > 0);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                if (_ok)
                {
                    if (doRefrescarFormularioExterno != null)
                    {
                        doRefrescarFormularioExterno();
                    }
                    this.Notificar(Extensiones._NOTIFICADORES.REGISTRO_GUARDADO);
                    Close();
                }
            }
        }

        private bool Validaciones()
        {
            int _conteo = 0;

            try
            {
                if (CodigoProducto.Text.EsNOE())
                {
                    _errores.SetError(CodigoProducto, "No válido");
                    _conteo++;
                }
                if (NombreProducto.Text.EsNOE())
                {
                    _errores.SetError(NombreProducto, "No válido");
                    _conteo++;
                }
                if (new ModelosManager.CLS.ProductoNombres(CodigoProducto.Text).Existe)
                {
                    MessageBox.Show(string.Format("Ya existe un producto con el codigo {0}", CodigoProducto.Text), "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_conteo == 0);
        }
    }
}
