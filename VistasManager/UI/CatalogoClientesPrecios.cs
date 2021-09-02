using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityManager;
using Herramientas;

namespace VistasManager.UI
{
    public partial class CatalogoClientesPrecios : Estilos.FormDialogos
    {
        EntityManager.DataBase _bd = new DataBase();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoClientesPrecios(ModelosManager.CLS.PersonasNombres _pcliente)
        {
            _cliente = _pcliente;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                cbbPrecios.ClasificacionPrecio();
                if (_cliente.Existe)
                    cbbPrecios.Text = _cliente.Precio.Valor.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GuardarCambios()
        {
            try
            {
                if (_cliente.Existe)
                {
                    _cliente.Precio.Valor = cbbPrecios.Text;
                    if (_bd.Actualizar(_cliente) > 0)
                    {
                        if (doRefrescarFormularioExterno != null)
                            doRefrescarFormularioExterno();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el registro.", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
