using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VistasManager.UI
{
    public partial class VentaCambio : Estilos.FormDialogos
    {
        double _cambio = 0;

        public VentaCambio(double _pcambio)
        {
            _cambio = _pcambio;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                lblTextoCambio.Text = string.Format("${0:N2}", _cambio);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
