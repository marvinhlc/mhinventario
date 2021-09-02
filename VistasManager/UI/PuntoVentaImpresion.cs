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
    public partial class PuntoVentaImpresion : Estilos.FormDialogos
    {
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();
        string _token = string.Empty;
        string _tipo = string.Empty;
        bool _ok = false;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public PuntoVentaImpresion()
        {
            InitializeComponent();
        }

        private void btnConsumidorFinal_Click(object sender, EventArgs e)
        {
            SeleccionarTipoDocumento("CONSUMIDOR FINAL", _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CONSUMIDOR_FINAL));
        }

        private void btnCreditoFiscal_Click(object sender, EventArgs e)
        {
            SeleccionarTipoDocumento("CREDITO FISCAL", _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CREDITO_FISCAL));
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            SeleccionarTipoDocumento("TICKET", _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET));
        }

        private void btnFacturaSimplificada_Click(object sender, EventArgs e)
        {
            SeleccionarTipoDocumento("N/A");
        }

        private void PuntoVentaImpresion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                        _tipo = "CONSUMIDOR FINAL";
                        _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CONSUMIDOR_FINAL);
                        _ok = true;
                        break;
                    case Keys.F4:
                        _tipo = "CREDITO FISCAL";
                        _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.CREDITO_FISCAL);
                        _ok = true;
                        break;
                    case Keys.F5:
                        _tipo = "TICKET";
                        _token = _appcfg.Token(Sesion.CLS.ConfigApp.TIPO_TOKEN.TICKET);
                        _ok = true;
                        break;
                    case Keys.F6:
                        _tipo = "N/A";
                        _ok = false;
                        break;
                    case Keys.Escape:
                        _tipo = "N/A";
                        _ok = false;
                        break;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void SeleccionarTipoDocumento(string _ptipo, string _ptoken = "")
        {
            try
            {
                _tipo = _ptipo;
                _token = _ptoken;
                _ok = true;
            }
            catch (Exception _err)
            {
                _ok = false;
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                Close();
            }
        }
    }
}
