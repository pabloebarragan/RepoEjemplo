using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        /// <summary>
        /// constructor para el atributo estatico.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// contructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="id">Lejajo del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">Dni del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Asigna  de manera aleatoria una clase
        /// </summary>
        /// 
        private void _randomClases()
        {
            int valor = random.Next(0, 3);
            this.claseDelDia.Enqueue((Universidad.EClases)valor);
        }


        /// <summary>
        /// Informa las clases en las que participa el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClases()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            while (claseDelDia.Count > 0)
            {
                sb.AppendLine(this.claseDelDia.Dequeue().ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna la informacion del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticipaEnClases());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo  ToString
        /// </summary>
        /// <returns>retorna la informacion del profesor</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }


        /// <summary>
        /// Valida si un profedor participa de una clase.
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clases">clase</param>
        /// <returns>TRUE si el profesor participa de la clase, FALSE caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clases)
        {
            bool retorno = false;
            foreach (Universidad.EClases c in i.claseDelDia)
            {
                if (c == clases)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Valida si un profedor NO participa de una clase.
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clases">clase</param>
        /// <returns>TRUE si el profesor NO participa de la clase, FALSE caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clases)
        {
            return !(i == clases);
        }
    }
}
