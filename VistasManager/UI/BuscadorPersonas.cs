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

namespace VistasManager.UI
{
    public partial class BuscadorPersonas : Estilos.FormDialogos
    {
        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();

        DataTable _dtpersonas = new DataTable();
        BindingSource _bspersonas = new BindingSource();

        public ModelosManager.CLS.PersonasNombres Persona
        {
            get { return _personas; }
            set { _personas = value; }
        }


        public enum RolPersona
        {
            CLIENTES,
            PROVEEDORES,
            TODO
        }

        private RolPersona _rolpersona = RolPersona.TODO;

        public BuscadorPersonas(RolPersona _prolpersona = RolPersona.TODO)
        {
            _rolpersona = _prolpersona;
            InitializeComponent();
            this.Text = string.Format("BUSCADOR DE {0}", _rolpersona.ToString());
            Datos();
            Inicio();
        }

        private void Datos()
        {
            try
            {
                if (_rolpersona == RolPersona.CLIENTES)
                    _dtpersonas = _personas.TodosClientes();
                if (_rolpersona == RolPersona.PROVEEDORES)
                    _dtpersonas = _personas.TodosProveedores();
                if (_rolpersona == RolPersona.TODO)
                    _dtpersonas = _personas.Todo();

                _bspersonas.DataSource = _dtpersonas;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Inicio()
        {
            try
            {
                dgvPersonas.AutoGenerateColumns = false;
                dgvPersonas.DataSource = _bspersonas;

                ActiveControl = txbBuscarTexto.Control;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Datos();
        }

        private void dgvPersonas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvPersonas.Notificar(BarraEstado);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bspersonas.Filter = string.Format("NombrePersona LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvPersonas.Focus();
            }
        }

        private void SeleccionarRegistro()
        {
            try
            {
                DataRow _row = dgvPersonas.CurrentRow.ToDataRow();
                _personas = new ModelosManager.CLS.PersonasNombres(_row["IDPersona"].TextoToEntero());
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvPersonas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void dgvPersonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistro();
        }

    }
}
