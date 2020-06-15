using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        { }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Universitario pg = (Universitario)obj;
                return (legajo == pg.legajo && DNI == pg.DNI);
            }
        }

        /// <summary>
        /// Muestra los datos de la persona en formato string.
        /// </summary>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo.ToString()}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador ==.
        /// </summary>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.legajo == pg2.legajo && pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Sobrecarga del operador !=.
        /// </summary>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1 == pg2));
        }
        protected abstract string ParticiparEnClase();

    }
}
