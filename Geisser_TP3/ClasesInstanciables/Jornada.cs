using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        public static bool Guardar(Jornada jornada)
        {
            bool resultado;

            try
            {
                Texto archivo = new Texto();
                resultado = archivo.Guardar("Jornada.txt", jornada.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return resultado;
        }
        public static string Leer()
        {
            try
            {
                string contenido;
                Texto archivo = new Texto();
                archivo.Leer("Jornada.txt", out contenido);
                return contenido;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j.clase)
            {
                return true;
            }

            return false;
        }
        public static bool operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return false;
                }
            }

            j.Alumnos.Add(a);

            return true;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine($"CLASE DE {this.Clase.ToString()} POR: {this.Instructor.ToString()}");
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine($"{alumno.ToString()}");
            }

            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

    }
}
