using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto, sin parametros.
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="numero">numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        public Numero(string strNumero)
        {
            this.SetNumero(strNumero);
        }

        /// <summary>
        /// Setea el numero pasado por parametro, previa validacion.
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        private void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        /// <summary>
        /// Valida que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero">numero en formato string</param>
        /// <returns>De ser valido retorna en numero en formato double. Caso contrario, retorna 0</returns>
        private static double ValidarNumero(string strNumero)
        {
            return double.TryParse(strNumero, out double ret) ? ret : 0;
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">numero binario</param>
        /// <returns>valor decimal en caso de ser posible la conversion. Caso contrario, "valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            bool valido = true;
            double sum = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1')
                {
                    sum = sum + Math.Pow(2, (binario.Length - (i + 1)));
                }
                else if (binario[i] != '0')
                {
                    valido = false;
                    break;
                }
            }
            return valido ? sum.ToString() : "Valor invalido";
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">numero en formato string</param>
        /// <returns>valor binario en caso de ser posible la conversion. Caso contrario, "valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = string.Empty;
            if (double.TryParse(numero, out double valor))
            {
                retorno = this.DecimalBinario(valor);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">numero decmal en formato double</param>
        /// <returns>valor binario en caso de ser posible la conversion. Caso contrario, "valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = string.Empty;
            int enteroAbs = Math.Abs((int)numero);
            while (enteroAbs > 0)
            {
                retorno = (enteroAbs % 2).ToString() + retorno;
                enteroAbs = enteroAbs / 2;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga operador +. Suma atributos "numero"
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Retorna la suma entre ambos numeros</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador -. Resta atributos "numero"
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Retorna la resta entre ambos numeros</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador *. Multiplica atributos "numero"
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Retorna la multiplicacion entre ambos numeros</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador /. Divide atributos "numero"
        /// </summary>
        /// <param name="n1">numero 1</param>
        /// <param name="n2">numero 2</param>
        /// <returns>Retorna la division entre ambos numeros</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
    }
}
