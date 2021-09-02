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
    public partial class CuentasPorCobrar : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.DocumentosEncabezados _documentos = new ModelosManager.CLS.DocumentosEncabezados();
        DataTable _dtdocumentos = new DataTable();
        BindingSource _bsdocumentos = new BindingSource();

        public CuentasPorCobrar()
        {
            InitializeComponent();
        }

        private void Entorno()
        {
            try
            {
                _dtdocumentos = _documentos.DocumentosCredito(_cliente.IDPersona.Valor.TextoToEntero());
                _bsdocumentos.DataSource = _dtdocumentos;
                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsdocumentos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                BuscadorPersonas _buscador = new BuscadorPersonas(BuscadorPersonas.RolPersona.CLIENTES);
                _buscador.ShowDialog(this);
                if (_buscador.Persona.Existe)
                {
                    CargadorPersona(_buscador.Persona);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void CargadorPersona(ModelosManager.CLS.PersonasNombres _elcliente)
        {
            try
            {
                if (_elcliente.Existe)
                {
                    _cliente = _elcliente;
                    txbIDTitular.Text = _elcliente.IDPersona.Valor.ToString();
                    txbNombreTitular.Text = _elcliente.NombrePersona.Valor.ToString();
                    txbNitTitular.Text = _elcliente.NIT.Valor.ToString();
                    txbIvaTitular.Text = _elcliente.IVA.Valor.ToString();
                    txbDuiTitular.Text = _elcliente.DUI.Valor.ToString();
                    txbGiroTitular.Text = _elcliente.Giro.Valor.ToString();

                    Entorno();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _abonos = 0;
            double _total = 0;
            double _efectivo = 0;

            try
            {
                foreach (DataGridViewRow _row in dgvDetalle.Rows)
                {
                    _total += _row.Cells["TotalVenta"].Value.TextoToDouble();
                    _abonos += _row.Cells["Abonos"].Value.TextoToDouble();
                    _efectivo += _row.Cells["Efectivo"].Value.TextoToDouble();
                }

                lblBarraEstado.Text = string.Format("{0} registros", _bsdocumentos.List.Count);
                lblTotalAbonos.Text = string.Format("Abonos: $ {0:N2}", _abonos);
                lblTotalSaldo.Text = string.Format("Total: $ {0:N2}", _total);
                lblDiferencia.Text = string.Format("a Pagar: $ {0:N2}", (_total - (_efectivo + _abonos)));
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAbonos_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvDetalle.CurrentRow.ToDataRow();
                CuentasPorCobrarAbonar _abonar = new CuentasPorCobrarAbonar(_row["IDDocumento"].TextoToEntero());
                _abonar.doRefrescarFormularioExterno += Entorno;
                _abonar.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnVerAbonos_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvDetalle.CurrentRow.ToDataRow();
                CuentasPorCobrarMantenimiento _manteni = new CuentasPorCobrarMantenimiento(_row["IDPersona"].TextoToEntero());
                _manteni.doRefrescarFormularioExterno += Entorno;
                _manteni.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbFiltroDetalle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txbFiltroDetalle.Text.EsNOE())
                    _bsdocumentos.RemoveFilter();
                else
                    _bsdocumentos.Filter = string.Format("NumeroDocumento = {0}", txbFiltroDetalle.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
