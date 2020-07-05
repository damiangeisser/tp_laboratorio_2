using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Crea un archivo de texto con la información enviada, o si ya existe agrega esa información al archivo.
        /// </summary>
        public static bool Guardar(this string texto, string archivo)
        {
            string ruta = Path.Combine($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\", $"{archivo}");

            try
            {
                if (Directory.Exists(Path.GetDirectoryName(ruta)))
                {
                    if (!File.Exists(ruta))
                    {
                        using (StreamWriter writer = new StreamWriter(ruta))
                        {
                            writer.WriteLine(texto);

                            return true;
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = File.AppendText(ruta))
                        {
                            writer.WriteLine(texto);

                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
