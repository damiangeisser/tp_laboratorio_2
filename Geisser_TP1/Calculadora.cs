using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el parámetro enviado sea un operador válido.
        /// </summary>
        /// <param name="operador">string cuya primera posición será evaluada.</param>
        /// <returns>Un string con el operador validado o "+" en caso de ser un caracter inválido.</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != null && operador !="")
            {
                switch (operador[0])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        return operador[0].ToString();
                    default:
                        return "+";
                }
            }
            return "+";
        }

        /// <summary>
        /// Realiza las operaciones entre objetos de la clase Numero, validando el operador previamente.
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>Un double con el resultado obtenido.</returns>
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            switch (ValidarOperador(operador))
            {
                case "-":
                    return n1-n2;
                case "*":
                    return n1 * n2;
                case "/":
                    return n1 / n2;
                default:
                    return n1 + n2; ;
            }

        }

    }
}
