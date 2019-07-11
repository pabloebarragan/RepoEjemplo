using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {        
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad para acceder al atributo apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad para acceder al atributo dni.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad para acceder al atriburo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// propiedad para acceder al atributo nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad para setear un valor al dni. Verifica que sea un dato valido.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// constructor con parametros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }


        /// <summary>
        /// constructor con parametros.
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }

        /// <summary>
        /// constructor con parametros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni de la persona</param>
        /// <returns>retorna dni(dato) si es correcto, caso contrario lanza una exception</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if (this.nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 999999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
            }
        }

        /// <summary>
        /// valida que el DNI no sea un valor alfanumerico, solo contenga numeros.
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni de la persona</param>
        /// <returns>retorna dni(dato) si es correcto, caso contrario lanza una exception</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni) && dato.Length < 9)
            {
                return ValidarDni(nacionalidad, dni);
            }
            throw new DniInvalidException("DNI INVALIDA EXCEPTION");
        }

        /// <summary>
        /// Valida que el nombre/apellido sean cadenas con caracteres válidos para nombres.
        /// </summary>
        /// <param name="dato">nombre/apellido</param>
        /// <returns>retorna nombre o apellido(dato) si es correcto, caso contrario no carga.</returns> 
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            bool nombreValido = true;

            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    nombreValido = false;
                    break;
                }
            }
            if (nombreValido)
                retorno = dato;
     
            return retorno;
        }

        /// <summary>
        /// sobrecarga del metodo ToString
        /// </summary>
        /// <returns>retorna la informacion de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}.");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            return sb.ToString();
        }
    }
}
