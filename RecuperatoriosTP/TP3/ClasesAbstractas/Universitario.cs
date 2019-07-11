using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="legajo">legajo de la persona</param>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Universitario (int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }


        /// <summary>
        /// metodo abstracto implementado en las clases hijas.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticipaEnClases();
        
        /// <summary>
        /// muestra los datos del universitario
        /// </summary>
        /// <returns>retorna la informacion del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($"LEGAJO: {this.legajo}");
            return sb.ToString();
        }


        /// <summary>
        /// Valida si dos Universitarios son iguales, verificando si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">universitario 1</param>
        /// <param name="pg2">universitario 2</param>
        /// <returns>TRUE si son iguales, FALSE caso contrario.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1 is Universitario && pg2 is Universitario) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Valida si dos Universitarios son distintos.
        /// </summary>
        /// <returns>TRUE si son distintos, FALSE caso contrario.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// sobrecarga del metodo Equals.
        /// </summary>
        /// <returns>TRUE si son iguales, FALSE caso contrario.</returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }
    }
}
