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
    public partial class DocumentosEntradasPrecios : Form
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        int _cero = 0;
        ModelosManager.CLS.ProductoNombres _producto;

        public DocumentosEntradasPrecios(ModelosManager.CLS.ProductoNombres _pproducto = null)
        {
            _producto = _pproducto;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                if (_producto.Existe)
                {
                    txbPrecioVenta.Text = _producto.PrecioVenta.Valor.ToString();
                    txbPrecio1.Text = _producto.Precio1.Valor.ToString();
                    txbPrecio2.Text = _producto.Precio2.Valor.ToString();
                    txbPrecio3.Text = _producto.Precio3.Valor.ToString();
                    txbPrecioCosto.Text = _producto.UltimoCosto.Valor.ToString();
                    txbFormatoVenta.Text = _producto.FormatoVenta.Valor.ToString();
                }
                else
                {
                    txbPrecioVenta.Text = _cero.ToString();
                    txbPrecio1.Text = _cero.ToString();
                    txbPrecio2.Text = _cero.ToString();
                    txbPrecio3.Text = _cero.ToString();
                    txbPrecioCosto.Text = _cero.ToString();
                    txbFormatoVenta.Clear();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _producto.PrecioVenta.Valor = txbPrecioVenta.Text.TextoToDouble();
                _producto.Precio1.Valor = txbPrecio1.Text.TextoToDouble();
                _producto.Precio2.Valor = txbPrecio2.Text.TextoToDouble();
                _producto.Precio3.Valor = txbPrecio3.Text.TextoToDouble();
                _producto.FormatoVenta.Valor = txbFormatoVenta.Text;
                _producto.UltimoCosto.Valor = txbPrecioCosto.Text.TextoToDouble();

                if (_bd.Actualizar(_producto) == 0)
                {
                    MessageBox.Show("No se pudo actualizar el costo", "ACTUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
