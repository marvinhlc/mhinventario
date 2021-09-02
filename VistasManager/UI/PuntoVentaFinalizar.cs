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
using EntityManager;

namespace VistasManager.UI
{
    public partial class PuntoVentaFinalizar : Estilos.FormDialogos
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.PersonasNombres _cliente = new ModelosManager.CLS.PersonasNombres();
        ModelosManager.CLS.PersonasNombres _nuevo = new ModelosManager.CLS.PersonasNombres();

        DataTable _dtclientes = new DataTable();

        string _forma_pago = string.Empty;
        int _dias_plazo = 0;
        string _fecha_documento = string.Empty;

        public string Fecha_documento
        {
            get { return _fecha_documento; }
            set { _fecha_documento = value; }
        }

        public int Dias_plazo
        {
            get { return _dias_plazo; }
            set { _dias_plazo = value; }
        }

        public string Forma_pago
        {
            get { return _forma_pago; }
            set { _forma_pago = value; }
        }

        public ModelosManager.CLS.PersonasNombres Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        double _total_venta = 0;
        int _idclientevarios = 465;

        ErrorProvider _errores = new ErrorProvider();

        bool _ok = false;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public PuntoVentaFinalizar(double _ptotal = 0)
        {
            _total_venta = _ptotal;
            InitializeComponent();
            Datos();
            Iniciar();
        }

        private void Datos()
        {
            try
            {
                _dtclientes = _cliente.Todo();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Iniciar()
        {
            try
            {
                txbTotalDocu.Text = _total_venta.ToString();
                _cliente = new ModelosManager.CLS.PersonasNombres(_idclientevarios);

                cbbFormaPagoDocu.SelectedIndex = 0;

                txbIDTitular.Text = _cliente.IDPersona.Valor.ToString();
                txbNombreTitular.Text = _cliente.NombrePersona.Valor.ToString();
                txbPaisTitular.Text = _cliente.Pais.Valor.ToString();
                txbNitTitular.Text = _cliente.NIT.Valor.ToString();
                txbIvaTitular.Text = _cliente.IVA.Valor.ToString();
                txbDuiTitular.Text = _cliente.DUI.Valor.ToString();
                txbGiroTitular.Text = _cliente.Giro.Valor.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void BuscarPersona(string _pfiltro = "")
        {
            DataRow _row = null;

            try
            {
                _row = (from _item in _dtclientes.AsEnumerable()
                        where (_item.Field<string>("NIT") != null && _item.Field<string>("NIT").Equals(_pfiltro))
                        || (_item.Field<string>("IVA") != null && _item.Field<string>("IVA").Equals(_pfiltro))
                        || (_item.Field<string>("DUI") != null && _item.Field<string>("DUI").Equals(_pfiltro))
                        select _item).FirstOrDefault<DataRow>();
                if (_row != null)
                {
                    txbIDTitular.Text = _row["IDPersona"].ToString();
                    txbNombreTitular.Text = _row["NombrePersona"].ToString();
                    txbNitTitular.Text = _row["NIT"].ToString();
                    txbIvaTitular.Text = _row["IVA"].ToString();
                    txbDuiTitular.Text = _row["DUI"].ToString();
                    txbGiroTitular.Text = _row["Giro"].ToString();
                    txbFiltroTitular.Clear();
                    txbEfectivo.Focus();
                }
                else
                {
                    txbIDTitular.Clear();
                    txbNombreTitular.Clear();
                    txbNitTitular.Clear();
                    txbIvaTitular.Clear();
                    txbDuiTitular.Clear();
                    txbGiroTitular.Clear();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbFiltroTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txbFiltroTitular.Text.NoNOE())
                {
                    BuscarPersona(txbFiltroTitular.Text);
                }
                else
                {
                    if (MessageBox.Show("¿Desea crear un nuevo registro de cliente?", "NUEVO CLIENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txbIDTitular.Clear();
                        txbNombreTitular.Clear();
                        txbNitTitular.Clear();
                        txbIvaTitular.Clear();
                        txbDuiTitular.Clear();
                        txbGiroTitular.Clear();
                        txbPaisTitular.Clear();

                        txbNombreTitular.Enabled = true;
                        txbPaisTitular.Enabled = true;
                        txbNitTitular.Enabled = true;
                        txbIvaTitular.Enabled = true;
                        txbDuiTitular.Enabled = true;
                        txbGiroTitular.Enabled = true;
                        txbPaisTitular.Enabled = true;
                        txbNombreTitular.Focus();
                    }
                    else
                    {
                        txbEfectivo.Focus();
                    }
                }
            }
        }

        private void txbEfectivo_Validating(object sender, CancelEventArgs e)
        {
            double _valor = 0;
            double _total = 0;
            double _efectivo = 0;
            try
            {
                _errores.Clear();
                if (!double.TryParse(txbEfectivo.Text, out _valor))
                {
                    _errores.SetIconAlignment(txbEfectivo, ErrorIconAlignment.MiddleLeft);
                    _errores.SetError(txbEfectivo, "Valor de efectivo no valido");
                    e.Cancel = true;
                }
                else
                {
                    _efectivo = Convert.ToDouble(txbEfectivo.Text);
                    _total = (_efectivo - Convert.ToDouble(_total_venta));
                    if (_total < 0)
                    {
                        _total = 0;
                        _errores.SetError(txbEfectivo, "Valor inferior");
                    }
                    txbCambio.Text = string.Format("{0:N2}", _total);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Validate())
                {
                    btnGuardar.PerformClick();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _ok = false;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //ACTUALIZAMOS EL CLIENTE NUEVO SI LO HAY
                if (_cliente.Existe)
                {
                    grupoCliente.Sincronizar(_cliente);
                    _bd.Actualizar(_cliente);
                }
                _fecha_documento = dtpFechaDocu.Value.FechaParaMySQL();
                _forma_pago = cbbFormaPagoDocu.Text;
                _dias_plazo = txbPlazoDocu.Value.TextoToEntero();
                _ok = true;
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbNombreTitular_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _nuevo = new ModelosManager.CLS.PersonasNombres();
                    _nuevo.Rol.Valor = "CLIENTE";
                    _nuevo.Tipo.Valor = "CONSUMIDOR";
                    _nuevo.Pais.Valor = "EL SALVADOR";
                    _nuevo.NombrePersona.Valor = txbNombreTitular.Text;
                    _nuevo.Contacto.Valor = txbNombreTitular.Text;
                    if (_bd.Insertar(_nuevo) > 0)
                    {
                        _nuevo.IDPersona.Valor = _bd.UltimoID;
                        txbIDTitular.Text = _nuevo.IDPersona.Valor.ToString();
                        txbPaisTitular.Text = _nuevo.Pais.Valor.ToString();
                        _cliente = _nuevo;
                    }
                    txbPaisTitular.Focus();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbPaisTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbNitTitular.Focus();
            }
        }

        private void txbNitTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbIvaTitular.Focus();
            }
        }

        private void txbIvaTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbDuiTitular.Focus();
            }
        }

        private void txbDuiTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbGiroTitular.Focus();
            }
        }

        private void txbGiroTitular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbEfectivo.Focus();
            }
        }

        private void txbEfectivo_TextChanged(object sender, EventArgs e)
        {
            this.Validate();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {

        }
    }
}
