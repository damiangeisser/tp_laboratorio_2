using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor de la clase Moto. Invoca al constructor de la clase base Vehiculo.
        /// </summary>
        /// <param name="chasis">Código indentificador del chasis de la moto</param>
        /// <param name="marca">Fabricante de la moto</param>
        /// <param name="color">Color de la moto</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Implementación real del descriptor de acceso de sólo lectura Vehiculo.Tamanio.
        /// </summary>
        /// <returns>Retorna el tamaño de la moto. Las motos son chicas.</returns>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Implementación específica del método virtual Vehiculo.Mostrar(). Publica todos los datos de la instancia de Moto. 
        /// </summary>
        /// <returns>Retorna un string con los datos de la moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
