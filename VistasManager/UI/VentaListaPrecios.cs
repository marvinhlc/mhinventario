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
    public partial class VentaListaPrecios : Form
    {
        ModelosManager.CLS.ProductoNombres _producto;
        DataTable _dtprecios = new DataTable();
        private double _precio_actual = 0;

        public double Precio_actual
        {
            get { return _precio_actual; }
            set { _precio_actual = value; }
        }

        
        public VentaListaPrecios(ModelosManager.CLS.ProductoNombres _pproducto)
        {
            _producto = _pproducto;
            InitializeComponent();

            try 
	        {
                _dtprecios.Columns.Add("Descripcion");
                _dtprecios.Columns.Add("Precio");

                if (_producto.Precio1.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 1", _producto.Precio1.Valor.TextoToDouble());
                }
                if (_producto.Precio2.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 2", _producto.Precio2.Valor.TextoToDouble());
                }
                if (_producto.Precio3.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 3", _producto.Precio3.Valor.TextoToDouble());
                }
                if (_producto.Precio4.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 4", _producto.Precio4.Valor.TextoToDouble());
                }
                if (_producto.Precio5.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 5", _producto.Precio5.Valor.TextoToDouble());
                }
                if (_producto.Precio6.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 6", _producto.Precio6.Valor.TextoToDouble());
                }
                if (_producto.Precio6.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 7", _producto.Precio7.Valor.TextoToDouble());
                }
                if (_producto.Precio6.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 8", _producto.Precio8.Valor.TextoToDouble());
                }
                if (_producto.Precio6.Valor.TextoToDouble() > 0)
                {
                    InsertarRegistro("Precio 9", _producto.Precio9.Valor.TextoToDouble());
                }

                dgvPrecios.AutoGenerateColumns = false;
                dgvPrecios.DataSource = _dtprecios;
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
        }

        private void InsertarRegistro(string _pdescripcion, double _pvalor)
        {
            DataRow _row = _dtprecios.NewRow();
            _row["Descripcion"] = _pdescripcion;
            _row["Precio"] = _pvalor;
            _dtprecios.Rows.Add(_row);
        }

        private void dgvPrecios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvPrecios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
        }

        private void Seleccionar()
        {
            try
            {
                DataRow _row = dgvPrecios.CurrentRow.ToDataRow();
                _precio_actual = _row["Precio"].TextoToDouble();
                Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
