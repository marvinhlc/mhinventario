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
    public partial class CatalogoBodegasEditor : Estilos.FormEditores
    {
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        ModelosManager.CLS.BodegasNombres _bodega = new ModelosManager.CLS.BodegasNombres();
        ErrorProvider _errores = new ErrorProvider();
        
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        public CatalogoBodegasEditor(int _pid = 0)
        {
            _bodega = new ModelosManager.CLS.BodegasNombres(_pid);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                if (_bodega.Existe)
                {
                    grupoIdentificacion.Mapear(_bodega);
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

        private void Refrescar()
        {
            if (doRefrescarFormularioExterno != null)
            {
                doRefrescarFormularioExterno();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                grupoIdentificacion.Sincronizar(_bodega);

                if (Validaciones())
                {
                    if (CLS.ExtensionesLocales.GuardarRegistro(_bodega, Refrescar))
                    {
                        Close();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool Validaciones()
        {
            int _conteo = 0;

            try
            {
                if (NombreBodega.Text.EsNOE())
                {
                    _errores.SetError(NombreBodega, "No es valido");
                    _conteo++;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return (_conteo == 0);
        }

        private void NombreBodega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Guardar();
            }
        }
    }
}
