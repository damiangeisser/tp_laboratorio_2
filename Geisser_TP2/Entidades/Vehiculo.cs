using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Constructor de la clase Vehiculo.
        /// </summary>
        /// <param name="chasis">Código indentificador del chasis</param>
        /// <param name="marca">Fabricante del vehículo</param>
        /// <param name="color">Color del vehículo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda
        }
        public enum ETamanio
        {
            Chico, 
            Mediano,
            Grande
        }

        /// <summary>
        /// Descriptor de acceso de sólo lectura abstracto del tamaño del Vehiculo.
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }

        /// <summary>
        /// Método virtual. Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retorna un string con los datos del vehículo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Operador de conversión a string, generado uno con los datos del vehículo.
        /// </summary>
        /// <param name="p">Instancia de Vehiculo del cual obtener los datos</param>>
        /// <returns>Retorna un string con la marca, chasis y color del vehículo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca.ToString()}");
            sb.AppendLine($"COLOR : {p.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador ==. Determina que dos vehiculos son iguales si comparten el mismo chasis.
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar</param>
        /// <param name="v2">Segundo vehículo a comparar</param>
        /// <returns>Retorna true si son iguales o false si son distintos.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Sobrecarga del operador!=. Determina que dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar</param>
        /// <param name="v2">Segundo vehículo a comparar</param>
        /// <returns>Retorna false si son iguales o true si son distintos.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}
