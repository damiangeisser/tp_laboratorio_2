using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        ETipo tipo;

        /// <summary>
        /// Constructor de la clase Automovil. Por defecto, TIPO será Monovolumen. Invoca al constructor de la clase base Vehiculo.
        /// </summary>
        /// <param name="chasis">Código indentificador del chasis del auto</param>
        /// <param name="marca">Fabricante del auto</param>
        /// <param name="color">Color del auto</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Sobrecarga del Constructor de la clase Automovil que permite determinar el ETipo. Invoca al constructor de la clase base Vehiculo.
        /// </summary>
        /// <param name="chasis">Código indentificador del chasis del auto</param>
        /// <param name="marca">Fabricante del auto</param>
        /// <param name="color">Color del auto</param>
        /// <param name="tipo">Tipo del auto</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Implementación real del descriptor de acceso de sólo lectura Vehiculo.Tamanio.
        /// </summary>
        /// <returns>Retorna el tamaño del Automovil. Los automoviles son medianos.</returns>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Implementación específica del método virtual Vehiculo.Mostrar(). Publica todos los datos de la instancia de Automovil. 
        /// </summary>
        /// <returns>Retorna un string con los datos del automovil</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        public enum ETipo
        { 
            Monovolumen,
            Sedan
        }
    }
}
