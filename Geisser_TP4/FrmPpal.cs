using Entidades;
using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.Paquete;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();

            correo = new Correo();
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes, iniciando su ciclo de vida.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

                paquete.InformaEstado += paq_InformaEstado;

                this.correo += paquete;

                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException t)
            {
                MessageBox.Show(t.Message);
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message);
            }
        }

        /// <summary>
        /// Muestra los datos de un paquete a través del menú contextual.
        /// </summary>
        private void mostrarToolMenuStripItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza los ListBox del formulario.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();

            this.lstEstadoEnViaje.Items.Clear();

            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Manejador encargado mostrar los datos de los paquetes.
        /// </summary>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra los datos del objeto enviado como parámetro y lo guarda en un archivo de texto.
        /// </summary>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
               this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Cierra todos los hilos activos al momento del cierre del formulario.
        /// </summary>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}
