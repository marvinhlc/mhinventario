using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.CLS
{
    public static class ExtensionesLocales
    {
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public delegate void EjecutarMetodoExterno(int _id);
        public delegate void EjecutarMetodoExternoPersona(ModelosManager.CLS.PersonasNombres _ppersona);

        public static bool ValidarExistenciaEnCeldaGrid(DataGridView _grid, DataGridViewCellValidatingEventArgs e, string _nombrecolumna)
        {
            bool _ok = false;
            double _cantidad = 0;
            double _existencia = 0;

            try
            {
                if (_grid.Columns[e.ColumnIndex].Name == _nombrecolumna)
                {
                    _grid.Rows[e.RowIndex].ErrorText = string.Empty;

                    DataGridViewRow _row = _grid.CurrentRow;
                    ModelosManager.CLS.ProductoNombres _producto = new ModelosManager.CLS.ProductoNombres(_row.Cells["IDProducto"].Value.TextoToEntero());
                    _cantidad = _row.Cells[_nombrecolumna].Value.TextoToDouble();

                    if (_cantidad > 0)
                    {
                        _existencia = _producto.CalcularExistencia();
                        if (_existencia >= _cantidad)
                        {
                            _ok = false;
                        }
                        else
                        {
                            _ok = true;
                            _grid.Rows[e.RowIndex].ErrorText = "No hay existencias";
                            MessageBox.Show("Existencias insuficientes para realizar la salida de mercadería", "EXISTENCIAS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _ok;
        }

        public static double GuardarUltimoCosto(DataGridView _grid, DataGridViewRow _row)
        {
            EntityManager.DataBase _bd = new EntityManager.DataBase();
            double _nuevocosto = 0;
            try
            {
                DataRow _old = _grid.CurrentRow.ToDataRow();
                //_nuevocosto = (_old["Precio"].TextoToDouble() / _old["Cantidad"].TextoToDouble());
                _nuevocosto = _old["Precio"].TextoToDouble();

                if (_old["UltimoCosto"].TextoToDouble() != _nuevocosto)
                {
                    if (MessageBox.Show(string.Format("¿Desea actualizar el costo del producto? Ultimo costo: {0} -> Actual: {1}", _old["UltimoCosto"], _nuevocosto), "COSTOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ModelosManager.CLS.ProductoNombres _item = new ModelosManager.CLS.ProductoNombres(_old["IDProducto"].TextoToEntero());
                        if (_item.Existe)
                        {
                            _item.UltimoCosto.Valor = _nuevocosto;
                            if (_bd.Actualizar(_item) == 0)
                            {
                                MessageBox.Show("No se pudo actualizar el costo", "ACTUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        _nuevocosto = 0;
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _nuevocosto;
        }

        public static bool GuardarRegistro(EntityManager.Entidad _entidad, RefresarFormularioExterno _metodo = null)
        {
            bool _ok = false;
            EntityManager.DataBase _bd = new EntityManager.DataBase();
            try
            {
                if (_entidad.Existe)
                {
                    _ok = (_bd.Actualizar(_entidad) > 0);
                }
                else
                {
                    _ok = (_bd.Insertar(_entidad) > 0);
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
                    if (_metodo != null)
                    {
                        _metodo();
                    }
                    MessageBox.Show("Registro fué guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return _ok;
        }

        public static bool EliminarRegistro(DataGridView _gridview, EntityManager.Entidad _tabla, RefresarFormularioExterno _metodo = null)
        {
            EntityManager.DataBase _bd = new EntityManager.DataBase();
            bool _ok = false;
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar el registro?","ELIMINAR",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRow _row = _gridview.CurrentRow.ToDataRow();
                    _tabla.FromDataRow(_row);

                    if (_bd.Eliminar(_tabla) > 0)
                    {
                        if (_metodo != null)
                        {
                            _metodo();
                        }
                        _ok = true;

                        MessageBox.Show("Registro se eliminó correctamente", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        public static void CatalogoProductos(this Button _boton, Form _winform, EjecutarMetodoExterno _metodo = null)
        {
            VistasManager.UI.BuscadorProductos _buscador = new UI.BuscadorProductos();
            _buscador.ShowDialog(_winform);
            if (_buscador.IDproductoSeleccionado > 0)
            {
                if (_metodo != null)
                    _metodo(_buscador.IDproductoSeleccionado);
            }
        }

        public static void BuscadorProveedores(this Button _boton, Form _winform, EjecutarMetodoExternoPersona _metodo = null)
        {
            VistasManager.UI.BuscadorPersonas _buscador = new UI.BuscadorPersonas(UI.BuscadorPersonas.RolPersona.PROVEEDORES);
            _buscador.ShowDialog(_winform);
            if (_buscador.Persona.Existe)
            {
                if (_metodo != null)
                    _metodo(_buscador.Persona);
            }
        }

        public static void BuscadorClientes(this Button _boton, Form _winform, EjecutarMetodoExternoPersona _metodo = null)
        {
            VistasManager.UI.BuscadorPersonas _buscador = new UI.BuscadorPersonas(UI.BuscadorPersonas.RolPersona.CLIENTES);
            _buscador.ShowDialog(_winform);
            if (_buscador.Persona.Existe)
            {
                if (_metodo != null)
                    _metodo(_buscador.Persona);
            }
        }

    }
}
