using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class CambiarPeriodo : Estilos.FormDialogos
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = null;

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CambiarPeriodo()
        {
            InitializeComponent();
            _appcfg = _sesion.CONFIGAPP;
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                txbPeriodoActual.Text = _sesion.CONFIGAPP.PERIODO.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de guardar los cambios?", "GUARDAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _appcfg.GuardarConfiguracion("PERIODO", txbPeriodoActual.Text);
                _sesion.Reinstalar();
                
                if (doRefrescarFormularioExterno != null)
                    doRefrescarFormularioExterno();

                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
