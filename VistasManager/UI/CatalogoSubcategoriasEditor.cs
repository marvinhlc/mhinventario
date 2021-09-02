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
    public partial class CatalogoSubcategoriasEditor : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.ProductoSubcategorias _subcategoria = new ModelosManager.CLS.ProductoSubcategorias();
        ModelosManager.CLS.ProductoCategorias _categorias = new ModelosManager.CLS.ProductoCategorias();
        ErrorProvider _errores = new ErrorProvider();

        DataTable _dtcategorias = new DataTable();
        BindingSource _bscategorias = new BindingSource();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoSubcategoriasEditor(int _pidcategoria, int _pidsubcategoria = 0)
        {
            _categorias = new ModelosManager.CLS.ProductoCategorias(_pidcategoria);
            _subcategoria = new ModelosManager.CLS.ProductoSubcategorias(_pidsubcategoria);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtcategorias = _categorias.Todo("NombreCategoria");
                _bscategorias.DataSource = _dtcategorias;

                NombreCategoria.DisplayMember = "NombreCategoria";
                NombreCategoria.ValueMember = "NombreCategoria";
                NombreCategoria.DataSource = _bscategorias;
                NombreCategoria.Text = _categorias.NombreCategoria.Valor.ToString();
                NombreCategoria.Enabled = false;

                if (_subcategoria.Existe)
                {
                    grupoIdentificacion.Mapear(_subcategoria);
                }
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

        private void Refrescar()
        {
            if (doRefrescarFormularioExterno != null)
            {
                doRefrescarFormularioExterno();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                grupoIdentificacion.Sincronizar(_subcategoria);
                _subcategoria.IDCategoria.Valor = _categorias.IDCategoria.Valor;

                if (Validaciones())
                {
                    if (CLS.ExtensionesLocales.GuardarRegistro(_subcategoria, Refrescar))
                    {
                        Close();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool Validaciones()
        {
            int _conteo = 0;

            try
            {
                if (NombreSubcategoria.Text.EsNOE())
                {
                    _errores.SetError(NombreSubcategoria, "No es valido");
                    _conteo++;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_conteo == 0);
        }

        private void NombreBodega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Guardar();
            }
        }
    }
}
