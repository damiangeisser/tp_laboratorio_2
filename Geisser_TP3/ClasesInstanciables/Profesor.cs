using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();

            for (int i = 0; i <= 1; i++)
            {
                clasesDelDia.Enqueue((EClases)random.Next(4));
            }
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
             : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();

            for (int i = 0; i <= 1; i++)
            {
                clasesDelDia.Enqueue((EClases)random.Next(4));
            }
        }
        private static void randomClases()
        { }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        public static bool operator ==(Profesor i, EClases clase)
        {
            foreach (EClases curso in i.clasesDelDia)
            {
                if (curso == clase)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CLASES DEL DÍA");

            foreach (EClases clase in this.clasesDelDia)
            {
                sb.AppendLine($"{clase.ToString()}");
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
