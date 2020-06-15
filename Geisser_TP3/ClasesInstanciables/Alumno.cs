using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return !(a != clase);
            }
            return false;
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            if (a.claseQueToma == clase)
            {
                return false;
            }

            return true;
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TOMA CLASE DE {this.claseQueToma.ToString()}");
           
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }



    }
}
