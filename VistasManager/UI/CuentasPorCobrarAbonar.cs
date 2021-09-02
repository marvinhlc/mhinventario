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
    public partial class CuentasPorCobrarAbonar : Estilos.FormDialogos
    {
        ModelosManager.CLS.DocumentosEncabezados _documento;
        ModelosManager.CLS.PersonasNombres _cliente;
        ModelosManager.CLS.PersonasPagos _pago;

        int _iddocumento = 0;
        double _saldo = 0;

        EntityManager.DataBase _db = new EntityManager.DataBase();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CuentasPorCobrarAbonar(int _piddocumento)
        {
            _iddocumento = _piddocumento;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _documento = new ModelosManager.CLS.DocumentosEncabezados(_iddocumento);
                if (_documento.Existe)
                {
                    _cliente = new ModelosManager.CLS.PersonasNombres(_documento.IDPersona.Valor.TextoToEntero());

                    txbIDDocumento.Text = _documento.IDDocumento.Valor.ToString();
                    txbIDCliente.Text = _cliente.IDPersona.Valor.ToString();
                    txbNombreCliente.Text = _cliente.NombrePersona.Valor.ToString();

                    _saldo = _documento.DocumentosCreditoSaldoActual();
                    lblMontoSugerido.Text = string.Format("Monto sugerido: $ {0:N2}", _saldo);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();   
        }

        private void Guardar()
        {
            double _monto = 0;

            try
            {
                if (double.TryParse(txbMonto.Text, out _monto))
                {
                    _pago = new ModelosManager.CLS.PersonasPagos();
                    _pago.IDDocumento.Valor = _documento.IDDocumento.Valor;
                    _pago.IDPersona.Valor = _documento.IDPersona.Valor;
                    _pago.Numero.Valor = txbNumero.Text;
                    _pago.Fecha.Valor = dtpFecha.Value.FechaParaMySQL();
                    _pago.Valor.Valor = _monto;

                    if (_db.Insertar(_pago) > 0)
                    {
                        ImprimirTicket(_pago);

                        if (doRefrescarFormularioExterno != null)
                            doRefrescarFormularioExterno();

                        MessageBox.Show("Abono fué realizado satisfactoriamente", "ABONO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ImprimirTicket(ModelosManager.CLS.PersonasPagos _pago)
        {
            DataTable _tabla = new DataTable();

            try
            {
                _tabla.Columns.Add("NombreProducto");
                _tabla.Columns.Add("CantidadSalida");
                _tabla.Columns.Add("PrecioSalida");
                _tabla.Columns.Add("Total");
                _tabla.Columns.Add("Excento");
                _tabla.Columns.Add("Gravado");
                _tabla.Columns.Add("IvaRetenido");
                _tabla.Columns.Add("FechaDocumento");
                _tabla.Columns.Add("NumeroDocumento");

                DataRow _row = _tabla.NewRow();
                _row["NombreProducto"] = "ABONO";
                _row["CantidadSalida"] = 1;
                _row["PrecioSalida"] = _pago.Valor.Valor;
                _row["Total"] = _row["CantidadSalida"].TextoToDouble() * _row["PrecioSalida"].TextoToDouble();
                _row["Excento"] = 0;
                _row["Gravado"] = _row["Total"];
                _row["IvaRetenido"] = 0;
                _row["NumeroDocumento"] = _pago.Numero.Valor.ToString();
                _row["FechaDocumento"] = _pago.Fecha.Valor.FechaParaMySQL();

                _tabla.Rows.Add(_row);

                CLS.Ticket _ticket = new CLS.Ticket(_tabla);
                _ticket.Imprimir();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbMonto_Validating(object sender, CancelEventArgs e)
        {
            double _salida = 0;
            try
            {
                if (double.TryParse(txbMonto.Text, out _salida))
                {
                    if (_salida > _saldo)
                    {
                        e.Cancel = true;
                        MessageBox.Show("El monto supera al saldo", "ABONO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }
    }
}
