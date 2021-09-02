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
    public partial class CuentasPorCobrarMantenimiento : Estilos.FormEditores
    {
        ModelosManager.CLS.PersonasPagos _pagos = new ModelosManager.CLS.PersonasPagos();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();
        DataTable _dtpagos = new DataTable();
        BindingSource _bspagos = new BindingSource();

        int _idpersona = 0;

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CuentasPorCobrarMantenimiento(int _pidpersona)
        {
            _idpersona = _pidpersona;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _cliente = new ModelosManager.CLS.PersonasNombres(_idpersona);
                _dtpagos = _pagos.Todo(string.Format("IDPersona = {0}", _idpersona), "IDPago");
                _bspagos.DataSource = _dtpagos;
                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bspagos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                lblBarraEstado.Text = string.Format("{0} registros", _bspagos.List.Count);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CLS.ExtensionesLocales.EliminarRegistro(dgvDetalle, _pagos, Iniciar))
                {
                    if (doRefrescarFormularioExterno != null)
                        doRefrescarFormularioExterno();
                }
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
                if (txbBuscarTexto.Text.EsNOE())
                    _bspagos.RemoveFilter();
                else
                    _bspagos.Filter = string.Format("Numero = {0}", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
