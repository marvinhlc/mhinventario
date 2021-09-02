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
    public partial class CatalogoPersonasEditor : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.PersonasNombres _persona = new ModelosManager.CLS.PersonasNombres();

        private CLS.Enumeraciones.TIPO_PERSONA _filtro = CLS.Enumeraciones.TIPO_PERSONA.PROVEEDORES;
        ErrorProvider _errores = new ErrorProvider();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoPersonasEditor(int _pid = 0, CLS.Enumeraciones.TIPO_PERSONA _pfiltro = CLS.Enumeraciones.TIPO_PERSONA.PROVEEDORES)
        {
            _filtro = _pfiltro;
            _persona = new ModelosManager.CLS.PersonasNombres(_pid);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                Rol.RolTitular();
                Rol.SelectedIndex = _filtro.TextoToEntero();

                Tipo.TipoTitular();
                if (_filtro == CLS.Enumeraciones.TIPO_PERSONA.CLIENTES)
                {
                    Tipo.Text = "CONSUMIDOR";
                }
                else
                {
                    Tipo.Text = "PEQUEÑO";
                }
                //Rol.Enabled = false;
                Pais.Paises();

                if (_persona.Existe)
                {
                    grupoIdentificacion.Mapear(_persona);
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
            bool _ok = false;

            try
            {
                grupoIdentificacion.Sincronizar(_persona);

                if (Validaciones())
                {
                    if (_persona.Existe)
                    {
                        _ok = (_bd.Actualizar(_persona) > 0);
                    }
                    else
                    {
                        _ok = (_bd.Insertar(_persona) > 0);
                    }
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
                    if (doRefrescarFormularioExterno != null)
                    {
                        doRefrescarFormularioExterno();
                    }
                    this.Notificar(Extensiones._NOTIFICADORES.REGISTRO_GUARDADO);
                    Close();
                }
            }
        }

        private bool Validaciones()
        {
            int _conteo = 0;

            try
            {
                if (NombrePersona.Text.EsNOE())
                {
                    _errores.SetError(NombrePersona, "No es valido");
                    _conteo++;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_conteo == 0);
        }
    }
}
