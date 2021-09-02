using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using EntityManager;

namespace VistasManager.UI
{
    public partial class VentaDevolucion : Estilos.FormDialogos
    {
        ErrorProvider _errores = new ErrorProvider();
        bool _ok = false;
        double _total_venta = 0;
        double _efectivo = 0;
        double _cambio = 0;
        double _saldo = 0;

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        
        public double Total_venta
        {
            get { return _total_venta; }
            set { _total_venta = value; }
        }

        public double Efectivo
        {
            get { return _efectivo; }
            set { _efectivo = value; }
        }

        public double Cambio
        {
            get { return _cambio; }
            set { _cambio = value; }
        }

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public VentaDevolucion(double _ptotal_venta)
        {
            _total_venta = _ptotal_venta;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                txbEfectivo.ToMonto(0);
                txbCambio.ToMonto(0);
                txbSaldo.ToMonto(0);
                txbTotalDocu.Text = _total_venta.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbEfectivo_Validating(object sender, CancelEventArgs e)
        {
            double _valor = 0;
            _cambio = 0;
            _efectivo = 0;
            _saldo = 0;

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
                    if (_valor >= 0)
                    {
                        _efectivo = _valor;
                        if (_efectivo >= 0)
                        {
                            _cambio = (_efectivo - _total_venta);
                        }
                        if (_cambio < 0)
                            _saldo = (_cambio * -1);

                        txbCambio.Text = string.Format("{0:N2}", _cambio);
                        txbSaldo.Text = string.Format("{0:N2}", _saldo);
                    }
                    else
                    {
                        _errores.SetIconAlignment(txbEfectivo, ErrorIconAlignment.MiddleLeft);
                        _errores.SetError(txbEfectivo, "Valor de efectivo no valido");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult _resuldo = System.Windows.Forms.DialogResult.Yes;
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Validate() & _resuldo == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_saldo > 0)
                        _resuldo = MessageBox.Show("Esta venta es al CREDITO. ¿Está seguro de continuar?", "VENTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (_resuldo == System.Windows.Forms.DialogResult.Yes)
                        btnAceptar.PerformClick();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_efectivo >= 0 || _saldo > 0)
            {
                VentaCambio _cambio = new VentaCambio(txbCambio.Text.TextoToDouble());
                _cambio.ShowDialog(this);
                //MessageBox.Show(string.Format("Su cambio es de {0:c}... presione ENTER para continuar.", txbCambio.Text.TextoToDouble()),
                //                    "FINALIZAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                _ok = true;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ok = false;
            Close();
        }
    }
}
