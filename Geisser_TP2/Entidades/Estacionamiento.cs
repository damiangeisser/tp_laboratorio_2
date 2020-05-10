using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;

        #region "Constructores"

        /// <summary>
        /// Constructor de la clase Estacionamiento. Inicializa la lista de vehículos.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Estacionamiento. Permite establecer el espacio disponible 
        /// e invoca al constructor que inicializa la lista de vehículos.
        /// </summary>
        /// <param name="espacioDisponible">Cantidad máxima de espacios disponibles para vehículos.</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Implementación específica del método virtual Object.ToString(). Invoca al método estático Estacionamiento.Mostrar().
        /// Publica los datos del estacionamiento y todos los vehículos.
        /// </summary>
        /// <returns>Retorna un string con los datos del estacionamiento y sus vehículos.</returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Método estático que expone los datos de la instancia de Estacionamiento y su lista de Vehiculo (incluidas sus herencias)
        /// sólo del tipo requerido.
        /// </summary>
        /// <param name="c">La instancia de Estacionamiento a exponer</param>
        /// <param name="tipo">Tipos requerido de los ítems de la lista de Vehiculo a mostrar</param>
        /// <returns>Retorna un string con los datos del estacionamiento y los vehículos del tipo requerido.</returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            //Se incluyen los datos del estacionamiento al StringBuilder:
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");

            //Se recorre la lista de vehículos buscando aquellos del tipo especificado para incluirlos al StringBuilder:
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if(v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Sobrecarga del operador +. Agregará un vehículo a la lista si no existe ya en ella uno con
        /// el mismo código de chasis.
        /// </summary>
        /// <param name="c">Instancia de Estacionamiento donde se agregará el elemento</param>
        /// <param name="p">Instancia de Vehiculo a agregar</param>
        /// <returns>Retorna la instancia de Estacionamiento con la instancia de Vehiculo agregada si no lo estaba, o
        /// alternativamente la instancia de Estacionamiento sin modificar</returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            //Se recorre la lista de Vehiculo para determinar si ya existe, si es así, sale.
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                    return c;
            }

            //Se el vehículo a agregar no existe en la lista, si hay lugar disponible en el estacionamiento, se agrega a la lista.
            if (c.vehiculos.Count < c.espacioDisponible)
            {
                c.vehiculos.Add(p);
            }

            return c;
        }
        /// <summary>
        /// Sobrecarga del operador -. Eliminará al vehículo de la lista cuyo código de chasis coincida con el parametrizado.
        /// </summary>
        /// <param name="c">Instancia de Estacionamiento de donde se eliminará el elemento</param>
        /// <param name="p">Instancia de Vehiculo a eliminar</param>
        /// <returns>Retorna la instancia de Estacionamiento con la instancia de Vehiculo eliminada si existía, o
        /// alternativamente la instancia de Estacionamiento sin modificar</returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            //Se recorre la lista de Vehiculo para determinar si ya existe, si es así, lo elimina y sale.
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(v);
                    break;
                }
            }

            //Se el vehículo a eliminar no existe en la lista, se retorna la lista intacta.
            return c;
        }
        #endregion
        public enum ETipo
        {
            Moto,
            Automovil,
            Camioneta,
            Todos
        }
    }
}
