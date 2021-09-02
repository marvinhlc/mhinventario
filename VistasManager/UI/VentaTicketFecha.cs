using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class VentaTicketFecha : Estilos.FormDialogos
    {
        string _fecha = string.Empty;

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public VentaTicketFecha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fecha = string.Empty;
            Close();
        }

        private void SeleccionarFecha()
        {
            try
            {
                _fecha = monthCalendar1.SelectionStart.FechaParaMySQL();
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeleccionarFecha();
        }

        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarFecha();
            }
        }
    }
}
