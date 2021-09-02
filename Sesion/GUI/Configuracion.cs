using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sesion.GUI
{
    public partial class Configuracion : Form
    {
        CLS.ConfigApp _config = new CLS.ConfigApp();

        public Configuracion()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = _config;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_config.GuardarCambios())
                MessageBox.Show("Se han guardado los cambios en la configuración del sistema.", "CONFIGURACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
