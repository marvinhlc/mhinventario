using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Herramientas;

namespace Backup
{
    public partial class CadenasConexion : Form
    {
        ListaCadenas _lista = new ListaCadenas();
        const string _cadena = @"server={0};User Id={1};Password={2};database={3};ConvertZeroDateTime=True;UseCompression=True;";
        string _cadena_nueva = string.Empty;

        MySqlConnection _conn = new MySqlConnection();
        MySqlConnectionStringBuilder _builder = new MySqlConnectionStringBuilder();

        public CadenasConexion()
        {
            InitializeComponent();
            CargarConexiones();
        }

        private void CargarConexiones()
        {
            try
            {
                _lista.Clear();
                string[] _conexiones = new string[ConfigurationManager.ConnectionStrings.Count];
                foreach (ConnectionStringSettings _item in ConfigurationManager.ConnectionStrings)
                {
                    ItemCadena _nuevo = new ItemCadena();
                    _nuevo.Nombre = _item.Name.ToString();
                    _nuevo.Cadena = ConfigurationManager.ConnectionStrings[_item.Name].ToString();

                    _lista.Add(_nuevo);
                }

                dgvCadenas.AutoGenerateColumns = false;
                dgvCadenas.DataSource = _lista;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                _cadena_nueva = string.Format(_cadena, txbServidor.Text, txbUsuario.Text, txbPassword.Text, txbBaseDatos.Text);
                using (_conn = new MySqlConnection(_cadena_nueva))
                {
                    _conn.Open();
                    if (_conn.State == ConnectionState.Open)
                        MessageBox.Show("Prueba de conexión correcta", "PRUEBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _cadena_nueva = string.Format(_cadena, txbServidor.Text, txbUsuario.Text, txbPassword.Text, txbBaseDatos.Text);
                ItemCadena _nuevo = new ItemCadena();
                _nuevo.Nombre = txbNombre.Text;
                _nuevo.Cadena = _cadena_nueva;

                int _existe = 0;
                foreach (ItemCadena _item in _lista)
                {
                    if (_item.Nombre.Equals(_nuevo.Nombre))
                    {
                        _existe++;
                    }
                }

                if (_existe == 0)
                {
                    _lista.Add(_nuevo);
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(_nuevo.Nombre, _nuevo.Cadena));
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(_nuevo.Nombre);
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(_nuevo.Nombre, _nuevo.Cadena));
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                CargarConexiones();

                txbNombre.Clear();
                txbServidor.Clear();
                txbBaseDatos.Clear();
                txbUsuario.Clear();
                txbPassword.Clear();

                MessageBox.Show("Los cambios se guardaron correctamente.", "CADENAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarConexiones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguor de eliminar éste registro?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ItemCadena _item = dgvCadenas.CurrentRow.DataBoundItem as ItemCadena;
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings.Remove(_item.Nombre.ToString());
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");

                    CargarConexiones();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCadena _item = dgvCadenas.CurrentRow.DataBoundItem as ItemCadena;
                _builder.ConnectionString = _item.Cadena;

                txbNombre.Text = _item.Nombre;
                txbServidor.Text = _builder["Data Source"].ToString();
                txbBaseDatos.Text = _builder["Initial Catalog"].ToString();
                txbUsuario.Text = _builder["User ID"].ToString();
                txbPassword.Text = _builder["Password"].ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
