using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
      
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
         
        /// <summary>
        /// priopiedad para acceder a la lista de alumnos.
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
        /// propiedad para acceder a la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// propiedad para acceder a la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// indexador de jornada.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                return this.jornada[index];
            }
            set
            {
                this.jornada[index] = value;
            }
        }
        
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Valida si un alumno pertenece a una universidad.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>TRUE si el alumno participa en la universidad, FALSE caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Valida si un alumno NO pertenece a una universidad.
        /// </summary>
        /// <returns>TRUE si el alumno NO participa en la universidad, FALSE caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// /// Valida si un profesor pertenece a una universidad.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns>TRUE si el profesor participa en la universidad, FALSE caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            bool retorno = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == p)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// /// Valida si un profesor NO pertenece a una universidad.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns>TRUE si el profesor NO participa en la universidad, FALSE caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase. Sino, lanza Excepción SinProfesorException
        /// </summary>
        /// <param name="g">univeridad</param>
        /// <param name="clase">clase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }


        /// <summary>
        /// Retorna el primer Profesor que NO es capaz de dar esa clase. Sino, lanza Excepción SinProfesorException
        /// </summary>
        /// <param name="g">univeridad</param>
        /// <param name="clase">clase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }


        /// <summary>
        /// Genera y agrega una nueva jornada al agregar una clase a una Universidad, indicacando un Profesor
        /// que pueda darla y la lista de alumnos que la toman.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor instructor = g == clase;
            Jornada jornada = new Jornada(clase, instructor);
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornada += item;
                }
            }
            g.Jornada.Add(jornada);
            return g;
        }


        /// <summary>
        /// Agrega un alumno a una universidad si el mismo no se encuentra en ella, caso contrario 
        /// lanza una exception AlumnoRepetidoException
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            g.alumnos.Add(a);
            return g;
        }


        /// <summary>
        /// Agrega un profesor a una universidad si el mismo no se encuentra en ella.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="p">profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            bool estaProfesor = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == p)
                {
                    estaProfesor = true;
                    break;
                }
            }
            if (!estaProfesor)
            {
                g.profesores.Add(p);
            }
            return g;
        }

        /// <summary>
        /// retorna la informacion de la universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>retorna la informacion de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// sobrecarga del metodo ToString.
        /// </summary>
        /// <returns>retorna la informacion de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        /// <summary>
        /// Serializa los datos de Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>TRUE si se pudo serealizar correctamente, FALSE caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            string path = String.Format("{0}\\Universidad.xml" , (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Xml<Universidad> xml = new Xml<Universidad>();
        
            retorno = xml.Guardar(path, uni);
            return retorno;
        }

        /// <summary>
        /// Lee un archivo xml de nombre Universidad, ubicado en el escritorio.
        /// </summary>
        /// <returns>retorna universidad</returns>
        public static Universidad Leer()
        {
            string path = String.Format("{0}\\Universidad.xml" , (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();

            xml.Leer(path, out uni);
            return uni;
        }
    }
}
