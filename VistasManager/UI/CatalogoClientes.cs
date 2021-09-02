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
    public partial class CatalogoClientes : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.PersonasNombres _personas = new ModelosManager.CLS.PersonasNombres();

        DataTable _dtpersonas = new DataTable();
        BindingSource _bspersonas = new BindingSource();

        public CatalogoClientes()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtpersonas = _personas.TodosClientes();
                _bspersonas.DataSource = _dtpersonas;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bspersonas;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCatalogo.Notificar(BarraEstado);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _personas, Iniciar);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogoPersonasEditor _editor = new CatalogoPersonasEditor(0, CLS.Enumeraciones.TIPO_PERSONA.CLIENTES);
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                CatalogoPersonasEditor _editor = new CatalogoPersonasEditor(_row["IDPersona"].TextoToEntero(), CLS.Enumeraciones.TIPO_PERSONA.CLIENTES);
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Iniciar();
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

        private void btnPrecioCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                int _id = _row["IDPersona"].TextoToEntero();
                CatalogoClientesPrecios _precios = new CatalogoClientesPrecios(new ModelosManager.CLS.PersonasNombres(_id));
                _precios.doRefrescarFormularioExterno += Iniciar;
                _precios.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
