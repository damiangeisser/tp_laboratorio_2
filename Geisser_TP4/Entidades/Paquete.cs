using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;

            this.TrackingID = trackingID;
        }
        
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        
        /// <summary>
        /// Getiona el ciclo de vida del paquete, cambiando su estado,
        /// informándolo y guardándolo en la base datos al pasar a entregado.
        /// </summary>
        public void mockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                this.InformaEstado.Invoke(this, null);

                Thread.Sleep(4000);

                if (this.Estado == EEstado.Ingresado)
                {
                    this.Estado = EEstado.EnViaje;
                }
                else
                {
                    this.Estado = EEstado.Entregado;
                }
            }

            this.InformaEstado.Invoke(this, null);

            PaqueteDAO.Insertar(this);
        }
        
        /// <summary>
        /// Genera un string con los datos del paquete.
        /// </summary>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del operador ==.
        /// </summary>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga del operador !=.
        /// </summary>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Sobrecarga del método ToString.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} para {1} ({2})", this.TrackingID, this.DireccionEntrega, this.Estado.ToString());
        }

        public event DelegadoEstado InformaEstado;

        public delegate void DelegadoEstado(object emisor, EventArgs e);

        /// <summary>
        /// enum anidado del estado del paquete.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
