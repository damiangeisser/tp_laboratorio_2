using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Constructor de la clase Camioneta. Invoca al constructor de la clase base Vehiculo.
        /// </summary>
        /// <param name="chasis">Código indentificador del chasis de la camioneta</param>
        /// <param name="marca">Fabricante de la camioneta</param>
        /// <param name="color">Color de la camioneta</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Implementación real del descriptor de acceso de sólo lectura Vehiculo.Tamanio.
        /// </summary>
        /// <returns>Retorna el tamaño de la camioneta. Las camionetas son grandes.</returns>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Implementación específica del método virtual Vehiculo.Mostrar(). Publica todos los datos de la instancia de Camioneta. 
        /// </summary>
        /// <returns>Retorna un string con los datos de la camioneta</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
