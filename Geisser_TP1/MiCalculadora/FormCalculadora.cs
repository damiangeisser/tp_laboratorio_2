using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param>No recibe parámetros.</param>
        /// <returns>No retorna valores.</returns>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Desconzco el propósito de este método. Lo incluí porque figuraba en el diagrama de clase.
        /// </summary>
        /// <param>No recibe parámetros.</param>
        /// <returns>No retorna valores.</returns>
        public void LaCalculadora()
        {
        }

        /// <summary>
        /// Limpia los campos de la calculadora.
        /// </summary>
        /// <param name="sender">Referencia al control que disparó el evento.</param>
        /// <param name="e">Parámetro que contiene la inforamción del evento.</param>
        /// <returns>No retorna valores.</returns>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = "";
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">Referencia al control que disparó el evento.</param>
        /// <param name="e">Parámetro que contiene la inforamción del evento.</param>
        /// <returns>No retorna valores.</returns>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Invoca al método que realiza la operación matemática y muestra el resultado.
        /// </summary>
        /// <param name="sender">Referencia al control que disparó el evento.</param>
        /// <param name="e">Parámetro que contiene la inforamción del evento.</param>
        /// <returns>No retorna valores.</returns>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Realiza la operación matemática requerida por el usuario entre los valores ingresados.
        /// </summary>
        /// <param name="numero1">Primer operando.</param>
        /// <param name="numero2">Segundo operando.</param>
        /// <param name="operador">Operador a utilizar.</param>
        /// <returns>Retorna un double con el resultado de la operación.</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero operando1 = new Numero(numero1);
            Numero operando2 = new Numero(numero2);

            return Calculadora.Operar(operando1, operando2, operador);
        }

        /// <summary>
        /// Invoca al método encargado de convertir de decimal a binario y muestra el resultado devuelto.
        /// </summary>
        /// <param name="sender">Referencia al control que disparó el evento.</param>
        /// <param name="e">Parámetro que contiene la inforamción del evento.</param>
        /// <returns>No retorna valores.</returns>
        private void bntConvertirABinario_Click(object sender, EventArgs e)
        {
            //Al no ser DecimalBinario() un método de clase me veo obligado a instanciar Numero.
            Numero resultadoDecimal = new Numero();

            lblResultado.Text = resultadoDecimal.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Invoca al método encargado de convertir de binario a decimal y muestra el resultado devuelto.
        /// </summary>
        /// <param name="sender">Referencia al control que disparó el evento.</param>
        /// <param name="e">Parámetro que contiene la inforamción del evento.</param>
        /// <returns>No retorna valores.</returns>
        private void bntConvertirADecimal_Click(object sender, EventArgs e)
        {
            //Al no ser BinarioDecimal() un método de clase me veo obligado a instanciar Numero.
            Numero resultadoDecimal = new Numero();

            lblResultado.Text = resultadoDecimal.BinarioDecimal(lblResultado.Text);
        }
    }
}
