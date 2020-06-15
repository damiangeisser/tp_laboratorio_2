using Archivos;
using ClasesAbstractas;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
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
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }

        }
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Guardar("Universidad.xml", uni);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public static Universidad Leer()
        {
            Universidad uni;

            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Leer("Universidad.xml", out uni);
                return uni;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in uni.Jornada)
            {
                sb.AppendLine($"{jornada.ToString()}");
            }

            return sb.ToString();

        }
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool auxiliar;

            Jornada nuevaJornada = new Jornada(clase, g == clase);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    auxiliar = nuevaJornada + alumno;

                    if (!auxiliar)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }

            g.Jornada.Add(nuevaJornada);

            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }

            u.Alumnos.Add(a);

            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool auxiliar = true;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == i)
                {
                    auxiliar = false;
                }
            }

            if (auxiliar)
            {
                u.Instructores.Add(i);
            }

            return u;
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

    }
}
