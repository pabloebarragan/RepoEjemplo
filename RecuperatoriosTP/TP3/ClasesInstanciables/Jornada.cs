using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// consttuctor por defecto
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">profesor de la jornada, para esa clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }

        /// <summary>
        /// propiedad para acceder al atributo alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// propiedad para acceder al atributo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// propiedad para acceder al atributo Instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Valida si un alumno se encuentra en una jornada.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>TRUE si el alumno se encuentra en una jornada, FALSE caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Valida si un alumno NO se encuentra en una jornada.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>TRUE si el alumno NO se encuentra en una jornada, FALSE caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una jornada.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno a agregar</param>
        /// <returns>retorna la jornada con el alumno agregado si corresponde, sino retorna la jornada inicial</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// sobrecarga del metodo ToString
        /// </summary>
        /// <returns>retorna la informacion de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CLASE DE {this.clase.ToString()} POR ");
            sb.Append(instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<----------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de una jornada en un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            string path = String.Format("{0}\\Jornada.txt", (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Texto txt = new Texto();

            retorno = txt.Guardar(path, jornada.ToString());
            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo de nombre Jornada.txt, ubicado en el escritorio.
        /// </summary>
        /// <returns>retorna la informacion de una jornada</returns>
        public static string Leer()
        {
            string retorno = "";
            string path = String.Format("{0}\\Jornada.txt" , (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Texto txt = new Texto();

            txt.Leer(path, out retorno);
            return retorno;
        }
    }
}