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
        /// Realiza la operacion entre 2 numeros.
        /// </summary>
        /// <param name="num1">numero 1 </param>
        /// <param name="num2">numero 2</param>
        /// <param name="operador"></param>
        /// <returns>retorna el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *.
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>Retorna operador si es valido. Caso contrario retorna +.</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
