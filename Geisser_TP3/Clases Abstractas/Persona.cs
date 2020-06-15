using Excepciones;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de la clase con DNI como int. Reutiliza al constructor de la clase.
        /// </summary>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de la clase con DNI como string. Reutiliza al constructor de la clase.
        /// </summary>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Propiedad para el atributo apellido. Valida su composición.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;

            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Propiedad para el atributo DNI. Valida su composición.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Propiedad para el atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;

            }
            set
            {
                {
                    this.nacionalidad = value;
                }
            }
        }

        /// <summary>
        /// Propiedad para el atributo nombre. Valida su composición.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;

            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Propiedad para el atributo DNI cuando es recibido como string. Valida su composición.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                   this.DNI = ValidarDni(this.nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw e;
                }
                catch (NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Validador del DNI cuando se recibe como int.
        /// </summary>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            //Valido la cantidad de cifras del DNI
            if (Math.Floor(Math.Log10(dato) + 1) == 8)
            { 
                //Valido la nacionalidad del DNI
                if (dato > 0 && (dato < 90000000 && nacionalidad == ENacionalidad.Argentino || dato > 89000000 && nacionalidad == ENacionalidad.Extranjero))
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException("Cantidad de cifras del DNI inválida.");
            }
        }

        /// <summary>
        /// Validador del DNI cuando se recibe como string.
        /// </summary>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato.Replace(".", "");

            int numeroDni;

            if (Int32.TryParse(dato, out numeroDni))
            {
                return ValidarDni(nacionalidad, numeroDni);
            }
            else
            {
                throw new DniInvalidoException("El DNI contiene caracteres inválidos.");
            }
        }

        /// <summary>
        /// Muestra los datos de la persona en formato string.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad.ToString()}");

            return sb.ToString();
        }
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
