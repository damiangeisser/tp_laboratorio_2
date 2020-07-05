using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Cierra los hilos del ciclo de vida de los paquetes.
        /// </summary>
        public void FinEntregas()
        {
            if (this.Paquetes.Count == 0)
            {
                foreach (Thread hilo in this.mockPaquetes)
                {
                    if (hilo.IsAlive)
                    {
                        hilo.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Muestra los datos de los paquetes.
        /// </summary>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder datosPaquetes = new StringBuilder();

            foreach (Paquete paquete in this.Paquetes)
            {
                datosPaquetes.AppendLine(paquete.ToString());
            }

            return datosPaquetes.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador +, aqgregando paquetes a la lista del correo,
        /// validando que no se ingresen dos paquetes con el mismo Tracking ID.
        /// </summary>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p.TrackingID == paquete.TrackingID)
                {
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra ingresado en el sistema.");
                }
            }

            c.Paquetes.Add(p);

            Thread hiloPaquete = new Thread(p.mockCicloDeVida);

            c.mockPaquetes.Add(hiloPaquete);

            hiloPaquete.Start();

            return c;
        }



    }
}
