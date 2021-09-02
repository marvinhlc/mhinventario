using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class mdiPrincipal : Form
    {
        Sesion.CLS.OmniSesion _SESION = Sesion.CLS.OmniSesion.Instancia;
        Portable.Portador _portable = Portable.Portador.Instancia;
        

        public mdiPrincipal()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                lblMarcaBlanca.Text = _SESION.CONFIGAPP.MARCA_BLANCA.ToString();
                btnlPeriodoGenral.Text = string.Format("{0}", _SESION.CONFIGAPP.PERIODO);
                if (_SESION.USUARIO.Existe)
                {
                    lblUsuario.Text = string.Format("{0}", _SESION.USUARIO.IDUsuario.Valor.ToString());
                }
                else
                {
                    lblUsuario.Text = "NO LOGUEADO";
                }
                Comunicacion();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Comunicacion()
        {
            try
            {
                DataManager.Operacion _cnn = new DataManager.Operacion();
                lblTipoConeccion.Text = string.Format("Conexión: {0}", _cnn.ProbarComunicacion());
                if (_portable.Conexion.ToUpper().Equals("LOCAL"))
                {
                    lblTipoConeccion.Image = Resource1.if_dns_64075;
                }
                if(_portable.Conexion.ToUpper().Equals("REMOTO"))
                {
                    lblTipoConeccion.Image = Resource1.if_network_cloud_93210;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void mdiPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea salir del sistema?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Close();
            }
        }

        private void mdiPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        //btnLocalizarCliente.PerformClick();
                        break;
                    case Keys.F2:
                        //puntoDeVentaToolStripMenuItem.PerformClick();
                        break;
                    case Keys.Escape:
                        salirToolStripMenuItem.PerformClick();
                        break;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.USUARIOS_SISTEMA, true))
            {
                VistasManager.UI.UsuariosManager _frmusers = new VistasManager.UI.UsuariosManager();
                _frmusers.MdiParent = this;
                _frmusers.Show();
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_CATALOGO_PRODUCTOS, true))
            {
                VistasManager.UI.CatalogoProductos _frm = new VistasManager.UI.CatalogoProductos();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_CATALOGO_PRODUCTOS, true))
            {
                VistasManager.UI.CatalogoProductos _frm = new VistasManager.UI.CatalogoProductos();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void proveedoresClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_PROVEEDORES_CLIENTES, true))
            {
                VistasManager.UI.CatalogoProveedores _frm = new VistasManager.UI.CatalogoProveedores();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_BODEGAS, true))
            {
                VistasManager.UI.CatalogoBodegas _frm = new VistasManager.UI.CatalogoBodegas();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_CATEGORIAS, true))
            {
                VistasManager.UI.CatalogoCategorias _frm = new VistasManager.UI.CatalogoCategorias();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void inicioInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_INVENTARIO, true))
            {
                VistasManager.UI.DocumentosInventario _frm = new VistasManager.UI.DocumentosInventario();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_ENTRADAS, true))
            {
                VistasManager.UI.DocumentosCompras _frm = new VistasManager.UI.DocumentosCompras();
                _frm.MdiParent = this;
                _frm.Show();
            }            
        }

        private void existenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.INVENTARIO_EXISTENCIAS, true))
            {
                VistasManager.UI.InventarioExistencias _frm = new VistasManager.UI.InventarioExistencias();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistasManager.UI.UsuariosPassword _frm = new VistasManager.UI.UsuariosPassword();
            _frm.MdiParent = this;
            _frm.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_SALIDAS, true))
            //{
            //    VistasManager.UI.DocumentosSalidas _frm = new VistasManager.UI.DocumentosSalidas();
            //    _frm.MdiParent = this;
            //    _frm.Show();
            //}     
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_INVENTARIO, true))
            {
                VistasManager.UI.DocumentosInventario _frm = new VistasManager.UI.DocumentosInventario();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_ENTRADAS, true))
            {
                VistasManager.UI.DocumentosCompras _frm = new VistasManager.UI.DocumentosCompras();
                _frm.MdiParent = this;
                _frm.Show();
            }       
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_SALIDAS, true))
            //{
            //    VistasManager.UI.DocumentosSalidas _frm = new VistasManager.UI.DocumentosSalidas();
            //    _frm.MdiParent = this;
            //    _frm.Show();
            //}     
        }

       
        private void documentosDeEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_DOCUMENTOS_ENTRADAS, true))
            {
                VistasManager.UI.ReporteDocumentoEntradas _frm = new VistasManager.UI.ReporteDocumentoEntradas();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void documentosDeSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_DOCUMENTOS_SALIDAS, true))
            {
                VistasManager.UI.ReporteDocumentoSalidas _frm = new VistasManager.UI.ReporteDocumentoSalidas();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void catalogoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_CATALOGO_PRODUCTOS, true))
            {
                VistasManager.UI.ReporteCatalogoProductos _frm = new VistasManager.UI.ReporteCatalogoProductos();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.CORTE_DE_CAJA, true))
            {
                //VistasManager.UI.CorteCaja _frm = new VistasManager.UI.CorteCaja();
                VistasManager.UI.CorteCajaAdmin _frm = new VistasManager.UI.CorteCajaAdmin();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_VENTAS, true))
            {
                VistasManager.UI.DocumentosVentas _frm = new VistasManager.UI.DocumentosVentas();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_VENTAS, true))
            {
                VistasManager.UI.DocumentosVentas _frm = new VistasManager.UI.DocumentosVentas();
                _frm.MdiParent = this;
                _frm.Show();
            }  
        }

        private void btnlPeriodoGenral_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.CAMBIAR_CONFIGURACION_PERIODO, true))
            {
                CambiarPeriodo _frm = new CambiarPeriodo();
                _frm.MdiParent = this;
                _frm.doRefrescarFormularioExterno += Iniciar;
                _frm.Show();
            }   
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_PROVEEDORES_CLIENTES, true))
            {
                VistasManager.UI.CatalogoClientes _frm = new VistasManager.UI.CatalogoClientes();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_PROVEEDORES_CLIENTES, true))
            {
                VistasManager.UI.CatalogoClientes _frm = new VistasManager.UI.CatalogoClientes();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void reporteDeClientesProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_CLIENTES_PROVEEDORES, true))
            {
                VistasManager.UI.ReporteClientesProveedores _frm = new VistasManager.UI.ReporteClientesProveedores();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.MANTENIMIENTO_PROVEEDORES_CLIENTES, true))
            {
                VistasManager.UI.CatalogoProveedores _frm = new VistasManager.UI.CatalogoProveedores();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void escalaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PRODUCTOS_ESCALA_PRECIOS, true))
            {
                VistasManager.UI.CatalogoProductosPrecios _frm = new VistasManager.UI.CatalogoProductosPrecios();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET);
                //_frm.MdiParent = this;
                _frm.ShowDialog(this);
            }
        }

        private void btnCFiscal_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.CREDITO_FISCAL);
                //_frm.MdiParent = this;
                _frm.ShowDialog(this);
            }
        }

        private void btnCFinal_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.CONSUMIDOR_FINAL);
                //_frm.MdiParent = this;
                _frm.ShowDialog(this);
            }
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.TICKET);
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void creditoFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.CREDITO_FISCAL);
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void consumidorFinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.PUNTO_DE_VENTA, true))
            {
                VistasManager.UI.VentaTicket _frm = new VistasManager.UI.VentaTicket(VistasManager.CLS.Enumeraciones.TIPO_DOCUMENTO.CONSUMIDOR_FINAL);
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void paraClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.LISTA_DE_PRECIOS_CLIENTES, true))
            {
                VistasManager.UI.ListaPreciosClientes _frm = new VistasManager.UI.ListaPreciosClientes();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.LISTA_DE_PRECIOS, true))
            {
                VistasManager.UI.ListaPreciosProductos _frm = new VistasManager.UI.ListaPreciosProductos();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void inventarioGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_INVENTARIO_GENERAL, true))
            {
                VistasManager.UI.ReporteInventarioGeneral _frm = new VistasManager.UI.ReporteInventarioGeneral();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_KARDEX, true))
            {
                VistasManager.UI.ReporteKardex _frm = new VistasManager.UI.ReporteKardex();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void anularDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_ANULAR, true))
            {
                VistasManager.UI.DocumentosAnular _frm = new VistasManager.UI.DocumentosAnular();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void gananciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_GANANCIAS, true))
            {
                VistasManager.UI.ReporteGanancias _frm = new VistasManager.UI.ReporteGanancias();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.CUENTAS_POR_COBRAR, true))
            {
                VistasManager.UI.CuentasPorCobrar _frm = new VistasManager.UI.CuentasPorCobrar();
                _frm.MdiParent = this;
                _frm.Show();
            }
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_SALIDAS, true))
            {
                VistasManager.UI.DocumentosSalidas _frm = new VistasManager.UI.DocumentosSalidas();
                _frm.MdiParent = this;
                _frm.Show();
            }     
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.FACTURAR_SERVICIOS, true))
            {
                VistasManager.UI.VentaServicios _frm = new VistasManager.UI.VentaServicios();
                _frm.ShowDialog(this);
            }     
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DOCUMENTOS_ENTRADAS, true))
            {
                VistasManager.UI.DocumentosEntradas _frm = new VistasManager.UI.DocumentosEntradas();
                _frm.ShowDialog(this);
            }   
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            if (MessageBox.Show("¿Realmente desea cerrar la sesión?", "CERRAR SESION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                Sesion.GUI.frmLogin _login = new Sesion.GUI.frmLogin();
                _login.ShowDialog();
                if (_login.Autorizado)
                {
                    Iniciar();
                    this.Visible = true;
                }
            }
        }

        private void cuentasPorCobrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_CUENTAS_POR_COBRAR, true))
            {
                VistasManager.UI.ReporteVentasCredito _frm = new VistasManager.UI.ReporteVentasCredito();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea salir del sistema?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Close();
            }
        }

        private void fechasDeEntregaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_FECHAS_ENTREGA, true))
            {
                VistasManager.UI.ReporteFechaEntrega _frm = new VistasManager.UI.ReporteFechaEntrega();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void galeriaDeImágenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.GALERIA_DE_IMAGENES, true))
            {
                VistasManager.UI.VentaTicketImagenes _frm = new VistasManager.UI.VentaTicketImagenes();
                _frm.MdiParent = this;
                _frm.Show();
            }   
        }

        private void lblMarcaBlanca_Click(object sender, EventArgs e)
        {
            try
            {
                Licencia _licencia = new Licencia();
                _licencia.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void hacerBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DB_BACKUP_HACER, true))
            {
                Backup.HacerBackup _frm = new Backup.HacerBackup();
                _frm.ShowDialog();
            }   
        }

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DB_BACKUP_RESTAURAR, true))
            {
                Backup.RestaurarBackup _frm = new Backup.RestaurarBackup();
                _frm.ShowDialog();
            }   
        }

        private void cadenasDeConexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.DB_CADENAS_CONEXION, true))
            {
                Backup.CadenasConexion _frm = new Backup.CadenasConexion();
                _frm.ShowDialog();
            }   
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.CONFIGURACION, true))
            {
                Sesion.GUI.Configuracion _frm = new Sesion.GUI.Configuracion();
                _frm.ShowDialog();
            }   
        }

        private void sincronizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.BD_MIGRADOR_CSV, true))
            {
                Migracion.Migrador _frm = new Migracion.Migrador();
                _frm.ShowDialog();
            }   
        }

        private void reporteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_DE_CAJA, true))
            {
                VistasManager.UI.ReporteCaja _frm = new VistasManager.UI.ReporteCaja();
                _frm.ShowDialog();
            }   
        }

        private void nuevaCosturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.COSTURA_NUEVA, true))
            {
                VistasManager.UI.OrdenesEditor _frm = new VistasManager.UI.OrdenesEditor();
                _frm.ShowDialog();
            }   
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.COSTURA_NUEVA, true))
            {
                VistasManager.UI.Ordenes _frm = new VistasManager.UI.Ordenes();
                _frm.ShowDialog();
            }   
        }


        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.REPORTE_COSTURA, true))
            {
                VistasManager.UI.ReporteCostura _frm = new VistasManager.UI.ReporteCostura();
                _frm.ShowDialog();
            }   
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.GASTOS_ADMIN, true))
            {
                VistasManager.UI.GastosControl _frm = new VistasManager.UI.GastosControl();
                _frm.ShowDialog();
            }   
        }

        private void reporteDeProducciónCosturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESION.USUARIO.Kerveros(Sesion.CLS.Comandos.GASTOS_ADMIN, true))
            {
                VistasManager.UI.ReporteCosturaProduccion _frm = new VistasManager.UI.ReporteCosturaProduccion();
                _frm.ShowDialog();
            }   
        }
    }
}
