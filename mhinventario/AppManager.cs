using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHInventario
{
    class AppManager : ApplicationContext
    {
        Sesion.CLS.OmniSesion _SESION = Sesion.CLS.OmniSesion.Instancia;
        public Boolean Continuar = true;
        public Boolean Reiniciar = true;

        public AppManager()
        {
            if (SplashScreen())
            {
                if (Validacion())
                {
                    Main.mdiPrincipal frm = new Main.mdiPrincipal();
                    frm = new Main.mdiPrincipal();
                    frm.Closed += new EventHandler(CerrandoFormularioPrincipal);
                    frm.ShowDialog();
                    FinalizarApp();
                }
                else
                {
                    FinalizarApp();
                }
            }
            else
            {
                FinalizarApp();
            }

        }

        private void FinalizarApp()
        {
            Continuar = false;
            Program.Cerrar();
            //Environment.Exit(0);
        }

        private Boolean SplashScreen()
        {
            Boolean resultado = false;
            Sesion.GUI.Splash frm = new Sesion.GUI.Splash();
            frm.ShowDialog();
            if (frm.Continuar)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        private Boolean Validacion()
        {
            Boolean resultado = false;
            Sesion.GUI.frmLogin frm = new Sesion.GUI.frmLogin();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        private void CerrandoFormularioPrincipal(object sender, EventArgs e)
        {
            FinalizarApp();
            //FinalizarApp();
            //ExitThread();
            //Application.Exit();
            //if (Reiniciar)
            //{
            //    //_SESION.SesionAutorizada = false;
            //}
            //else
            //{
            //    Environment.Exit(0);
            //}

        }
    }
}
