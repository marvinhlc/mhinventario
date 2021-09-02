using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Sesion.CLS
{
    public class Wallpaper
    {
        //Leer la configuracion
        public static string LeerWallpaper(string pWallpaper)
        {
            string miConfigXml = "Wallpapers.xml";
            XmlDocument miXmlDoc = new XmlDocument();
            string miValor = string.Empty;

            try
            {
                miXmlDoc.Load(miConfigXml);

                //Leermos el nodo principal.
                XmlNode miNodoPrin = miXmlDoc.SelectSingleNode("Wallpaper");

                //Leemos el nodo del winform.
                XmlNode miNodoWinform = miNodoPrin.SelectSingleNode(pWallpaper);

                //Leemos el valor de la propiedad.
                XmlNode miNodoValor = miNodoWinform.SelectSingleNode("WallpaperFile");

                miValor = miNodoValor.LastChild.Value.ToString();

                //Cargamos la configuracion.
                //this.Location = miPoint;

                miXmlDoc = null;
            }
            catch
            {
                miXmlDoc = null;
            }

            return miValor;
        }
        public static void GuardarWallpaper(string pWallpaper, string pWallpaperFile)
        {
            string miConfigXml = "Wallpapers.xml";
            XmlNode miNodo;

            try
            {
                XmlDocument miXmlDoc = new XmlDocument();
                if (!File.Exists(miConfigXml))
                {
                    //Si no existe, se crea los comentarios y nodos iniciales.
                    miXmlDoc.AppendChild(miXmlDoc.CreateComment("Biblioteca de Wallpapers"));
                    miNodo = miXmlDoc.CreateNode(XmlNodeType.Element, "Wallpaper", null);
                    miXmlDoc.AppendChild(miNodo);
                }
                else
                {
                    //Si existe, se lee el fichero.
                    miXmlDoc.Load(miConfigXml);
                    miNodo = miXmlDoc.SelectSingleNode("Wallpaper");
                }

                //Ahora, leemos la configuración.
                XmlNode miNodoWinform = miNodo.SelectSingleNode(pWallpaper);
                if (miNodoWinform == null)
                {
                    //Si el nodo aún no existe, lo creamos.
                    miNodoWinform = miNodo.AppendChild(miXmlDoc.CreateNode(XmlNodeType.Element, pWallpaper, null));
                }

                //Ahora almacenamos los valores.
                XmlNode miNodoValor = miNodoWinform.SelectSingleNode("WallpaperFile");
                if (miNodoValor == null)
                {
                    miNodoValor = miNodoWinform.AppendChild(miXmlDoc.CreateNode(XmlNodeType.Element, "WallpaperFile", null));
                }

                miNodoValor.InnerText = pWallpaperFile;

                //Guardamos el xml.
                XmlTextWriter tw = new XmlTextWriter(miConfigXml, Encoding.UTF8);
                tw.Indentation = 4;
                tw.IndentChar = " "[0];
                tw.Formatting = Formatting.Indented;

                miXmlDoc.Save(tw);
                miXmlDoc = null;

                tw.Flush();
                tw.Close();

            }
            catch
            {
                //nada
            }
        }
    }
}
