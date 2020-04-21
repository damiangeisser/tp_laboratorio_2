using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor de la clase. Inicializa el atributo numero en 0.
        /// </summary>
        /// <param>No recibe parámetros.</param>
        /// <returns>No retorna valores.</returns>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase. Inicializa el atributo numero con el parámetro recibido.
        /// </summary>
        /// <param name="numero">double que se le asignará al atributo numero.</param>
        /// <returns>No retorna valores.</returns>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase. Inicializa el atributo numero con el parámetro recibido.
        /// </summary>
        /// <param name="strNumero">string que se le asignará al atributo numero.</param>
        /// <returns>No retorna valores.</returns>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad de solo escritura para el atributo numero.
        /// </summary>
        /// <param>No recibe parámetros.</param>
        /// <returns>No retorna valores.</returns>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el parámetro recibido pueda ser convertido a double.
        /// </summary>
        /// <param name="strNumero">string que intentará convertir.</param>
        /// <returns>El string convertido a double o 0 en caso de no poder convertirlo.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double operando;

            if (!double.TryParse(strNumero.Replace('.', ','), out operando))
            {
                operando = 0;
            }

            return operando;
        }

        /// <summary>
        /// Convierte el parámetro recibido a su equivalente en decimal.
        /// </summary>
        /// <param name="binario">string que intentará convertir.</param>
        /// <returns>El string convertido a decimal o un mensaje de error en caso de no poder convertirlo.</returns>
        public string BinarioDecimal(string binario)
        {
            double numeroDecimal = 0;
            bool convertible = true;
            char[] inputInverso = binario.ToCharArray();

            if (binario !=null && binario != "")
            {
                foreach (char c in inputInverso)
                {
                    if (c < '0' || c > '1')
                    {
                        convertible = false;
                    }
                }
            }
            else
            {
                convertible = false;
            }

            if (convertible)
            {
                Array.Reverse(inputInverso);

                for (int i = 0; i < inputInverso.Length; i++)
                {
                    if (inputInverso[i] != '0')
                    {
                        numeroDecimal += Math.Truncate(Math.Pow(2, i));
                    }
                }

                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte el parámetro recibido a su equivalente en binario.
        /// </summary>
        /// <param name="numero">double que intentará convertir utilizando su parte entera y con signo positivo.</param>
        /// <returns>El string con el equivalente binario del parámetro recibido.</returns>
        public string DecimalBinario(double numero)
        {
            StringBuilder cadenaBinaria = new StringBuilder();

            numero = Math.Truncate(Math.Abs(numero));

            do
            {
                if (numero % 2 == 0)
                {
                    cadenaBinaria.Append('0');
                }
                else
                {
                    cadenaBinaria.Append('1');
                }

                numero = Math.Truncate(numero / 2);

            } while (numero >= 1);

            return new string(cadenaBinaria.ToString().Reverse().ToArray());
        }

        /// <summary>
        /// Sobrecarga del método DecimalBinario.
        /// </summary>
        /// <param name="numero">string que intentará convertir invocando al método DecimalBinario(double numero).</param>
        /// <returns>El string con el equivalente binario del parámetro recibido o un mensaje de error en caso de no poder convertirlo.</returns>
        public string DecimalBinario(string numero)
        {
            double operando;

            if (numero != null && numero != "" && double.TryParse(numero.Replace('.', ','), out operando))
            {
                return DecimalBinario(operando);
            }

            return "Valor inválido";
        }

        /// <summary>
        /// Sobrecarga del operador +.
        /// </summary>
        /// <param name="n1">primer objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <param name="n2">segundo objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <returns>El double con el resultado de la operación entre los parámetros recibidos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -.
        /// </summary>
        /// <param name="n1">primer objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <param name="n2">segundo objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <returns>El double con el resultado de la operación entre los parámetros recibidos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *.
        /// </summary>
        /// <param name="n1">primer objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <param name="n2">segundo objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <returns>El double con el resultado de la operación entre los parámetros recibidos.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /.
        /// </summary>
        /// <param name="n1">primer objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <param name="n2">segundo objeto de la clase Numero cuyo atributo numero será uno de los operandos.</param>
        /// <returns>El double con el resultado de la operación entre los parámetros recibidos o double.MinValue en caso de que el divisor sea 0.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

    }
}
