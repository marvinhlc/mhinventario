using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class Ordenes : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtordenes = new DataTable();
        BindingSource _bsordenes = new BindingSource();

        ModelosManager.CLS.Ordenes _ordenes = new ModelosManager.CLS.Ordenes();
        ModelosManager.CLS.OrdenesDetalle _detalle = new ModelosManager.CLS.OrdenesDetalle();

        int _periodo = 0;

        public Ordenes()
        {
            _periodo = _sesion.CONFIGAPP.PERIODO;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtordenes = _ordenes.Todo(_periodo);
                _bsordenes.DataSource = _dtordenes;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsordenes;
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

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsordenes.Filter = string.Format("NombreCliente LIKE '%{0}%'", txbBuscarTexto.Text);
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
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_DETALLE_COSTURAS, true))
                {
                    ModelosManager.CLS.Ordenes _ordenes = new ModelosManager.CLS.Ordenes();
                    CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _ordenes, Iniciar);
                }
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
                VistasManager.UI.OrdenesEditor _editor = new OrdenesEditor(_row["IDOrden"].TextoToEntero());
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
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
                VistasManager.UI.OrdenesEditor _editor = new OrdenesEditor();
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                VistasManager.UI.OrdenesImagenes _imagenes = new OrdenesImagenes(_row["IDOrden"].TextoToEntero());
                _imagenes.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
