using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Main
{
    public partial class Licencia : Form
    {
        const string _file_eula  = "CLUF.rtf";
        string _root_file = string.Empty;

        public Licencia()
        {
            InitializeComponent();
            CargarContratoLicencia();
        }

        private void CargarContratoLicencia()
        {
            try
            {
                _root_file = string.Format("{0}/{1}", Application.StartupPath, _file_eula);
                if (File.Exists(_root_file))
                    richTextBox1.LoadFile(_root_file, RichTextBoxStreamType.RichText);
                else
                    MessageBox.Show("La licencia de uso ha sido removida", "LICENCIA DE USO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://mhsistemas.com");
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
