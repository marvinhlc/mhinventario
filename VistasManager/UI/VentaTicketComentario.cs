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
    public partial class VentaTicketComentario : Estilos.FormDialogos
    {
        string _comentario = string.Empty;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        public VentaTicketComentario()
        {
            InitializeComponent();
        }

        public VentaTicketComentario(string _pcomentario)
        {
            _comentario = _pcomentario;
            InitializeComponent();
            txbComentario.Text = _comentario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _comentario = string.Empty;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _comentario = txbComentario.Text;
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
