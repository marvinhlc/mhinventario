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
    public partial class CorteCaja : Estilos.FormEditores
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        Sesion.CLS.ConfigApp _appcfg = new Sesion.CLS.ConfigApp();

        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.CorteCaja _corte = new ModelosManager.CLS.CorteCaja();

        DataTable _dtcorte = new DataTable();

        public CorteCaja()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                txbIDCaja.Text = _appcfg.CAJA_ID.ToString();
                txbEfectivoInicial.Text = _appcfg.CAJA_EFECTIVO.ToString();

                _dtcorte = _corte.UltimoCorteCaja(_appcfg.CAJA_ID.TextoToEntero());
                if (_dtcorte != null && _dtcorte.Rows.Count > 0)
                {
                    DataRow _row = _dtcorte.Rows[0];
                    txbTotalVentas.Text = _row["SumaVenta"].ToString();
                    txbIDCorte.Text = _row["IDCorte"].ToString();
                    txbEfectivoInicial.Text = _row["MontoInicial"].ToString();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbEfectivoInicial_TextChanged(object sender, EventArgs e)
        {
            double _total = 0;
            try
            {
                _total = (txbEfectivoInicial.Text.TextoToDouble() + txbTotalVentas.Text.TextoToDouble());
                txbTotalCaja.Text = _total.ToString();
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
            bool _ok = false;
            double _efectivo = 0;

            try
            {
                if (txbIDCorte.Text.NoNOE())
                {
                    _corte = new ModelosManager.CLS.CorteCaja(txbIDCorte.Text.TextoToEntero());
                }
                if (_corte.Existe)
                {
                    _corte.TotalVenta.Valor = txbTotalVentas.Text.TextoToDouble();
                    _corte.Estado.Valor = "CERRADO";

                    _ok = (_bd.Actualizar(_corte) > 0);
                    if (_ok)
                    {
                        _corte.CompilarDocumentos();
                    }

                    _efectivo = 0;
                }
                else
                {
                    _corte.IDCaja.Valor = txbIDCaja.Text.TextoToEntero();
                    _corte.IDUsuario.Valor = _sesion.USUARIO.IDUsuario.Valor.ToString();
                    _corte.Estado.Valor = "ABIERTO";
                    _corte.MontoInicial.Valor = txbEfectivoInicial.Text.TextoToDouble();

                    _ok = (_bd.Insertar(_corte) > 0);

                    _efectivo = txbEfectivoInicial.Text.TextoToDouble();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                if (_ok)
                {
                    _appcfg.GuardarConfiguracion("CAJA_EFECTIVO", _efectivo.ToString());
                    MessageBox.Show("Datos guardados correctamente", "CORTE DE CAJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
