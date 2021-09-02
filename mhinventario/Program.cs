using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHInventario
{
    static class Program
    {
        private enum Depurador
        {
            DEPURAR,
            PRODUCCION
        }

        [STAThread]
        static void Main()
        {
            //DEPURADOR
            Depurador _depu = Depurador.PRODUCCION;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (_depu == Depurador.PRODUCCION)
            {
                AppManager App = new AppManager();
                if (App.Continuar)
                {
                    Application.Run(App);
                }
            }
            else
            {
                Portable.Portador _portador = Portable.Portador.Instancia;
                _portador.Conexion = "Local";

                Sesion.CLS.OmniSesion sesion = Sesion.CLS.OmniSesion.Instancia;
                sesion.Validar("ADMIN", "123");
                sesion.CONFIGAPP.PERIODO = 2020;

                //Application.Run(new VistasManager.UI.ReporteCosturaProduccion());
                //Application.Run(new VistasManager.UI.GastosControl());
                //Application.Run(new VistasManager.UI.ReporteCostura());
                //Application.Run(new VistasManager.UI.OrdenesEditor());
                //Application.Run(new VistasManager.UI.Ordenes());
                //Application.Run(new VistasManager.UI.ReporteCaja());
                //Application.Run(new Migracion.Migrador());
                //Application.Run(new Backup.CadenasConexion());
                //Application.Run(new Sesion.GUI.Configuracion());
                //Application.Run(new VistasManager.UI.VentaTicketImagenes());
                //Application.Run(new VistasManager.UI.ReporteFechaEntrega());
                //Application.Run(new VistasManager.UI.ReporteVentasCredito());
                //Application.Run(new VistasManager.UI.DocumentosEntradas());
                //Application.Run(new VistasManager.UI.VentaServicios());
                //Application.Run(new VistasManager.UI.CuentasPorCobrar());
                //Application.Run(new VistasManager.UI.ReporteGanancias());
                //Application.Run(new Migracion.MigradorExcel());
                //Application.Run(new VistasManager.UI.DocumentosAnular());
                //Application.Run(new VistasManager.UI.DocumentosTraslados());
                //Application.Run(new VistasManager.UI.ReporteKardex());
                //Application.Run(new VistasManager.UI.ReporteInventarioGeneral());
                //Application.Run(new VistasManager.UI.ListaPreciosClientes());
                //Application.Run(new VistasManager.UI.ListaPreciosProductos());
                //Application.Run(new VistasManager.UI.CorteCajaAdmin());
                Application.Run(new VistasManager.UI.VentaTicket());
                //Application.Run(new VistasManager.UI.DocumentosCompras());
                //Application.Run(new VistasManager.UI.CatalogoSubcategorias());
                //Application.Run(new VistasManager.UI.CatalogoCategorias());
                //Application.Run(new VistasManager.UI.CatalogoBodegas());
                //Application.Run(new VistasManager.UI.CatalogoPersonas());
                //Application.Run(new VistasManager.UI.CatalogoProductos());
                //Application.Run(new VistasManager.UI.InventarioExistencias());
                //Application.Run(new VistasManager.UI.DocumentosInventario());
                //Application.Run(new VistasManager.UI.DocumentosSalidas());
                //Application.Run(new VistasManager.UI.PuntoVenta());
                //Application.Run(new VistasManager.UI.ReporteDocumentoEntradas());
                //Application.Run(new VistasManager.UI.ReporteDocumentoSalidas());
                //Application.Run(new VistasManager.UI.ReporteCatalogoProductos());
                //Application.Run(new VistasManager.UI.CorteCaja());
                //Application.Run(new VistasManager.UI.DocumentosVentas());
                //Application.Run(new MigracionManager.UI.MigrarRegistros());
                //Application.Run(new VistasManager.UI.CatalogoClientes());
                //Application.Run(new VistasManager.UI.CatalogoProveedores());
                //Application.Run(new VistasManager.UI.ReporteClientesProveedores());
            }
        }

        public static void Cerrar()
        {
            Application.Exit();
        }

        public static string VersionEnsamblado()
        {
            string _ensamblado = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(_ensamblado).FileVersion.ToString();
        }
    }
}
