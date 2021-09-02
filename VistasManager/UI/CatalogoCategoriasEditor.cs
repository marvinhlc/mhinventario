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
    public partial class CatalogoCategoriasEditor : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.ProductoCategorias _categoria = new ModelosManager.CLS.ProductoCategorias();
        ErrorProvider _errores = new ErrorProvider();
        
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoCategoriasEditor(int _pid = 0)
        {
            _categoria = new ModelosManager.CLS.ProductoCategorias(_pid);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                if (_categoria.Existe)
                {
                    grupoIdentificacion.Mapear(_categoria);
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
                grupoIdentificacion.Sincronizar(_categoria);

                if (Validaciones())
                {
                    if (CLS.ExtensionesLocales.GuardarRegistro(_categoria, Refrescar))
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
                if (NombreCategoria.Text.EsNOE())
                {
                    _errores.SetError(NombreCategoria, "No es valido");
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

        private void Descuento_Validating(object sender, CancelEventArgs e)
        {
            double _descuento = 0;

            try
            {
                if (!Double.TryParse(Descuento.Text, out _descuento))
                {
                    e.Cancel = true;
                    MessageBox.Show("Aqui se requiere un numero", "DESCUENTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
