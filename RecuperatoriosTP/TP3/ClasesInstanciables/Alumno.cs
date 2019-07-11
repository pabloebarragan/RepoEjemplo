using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// constructor con parametros.
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">DNI  del alumno</param>
        /// <param name="nacionalidad">Nacionalidad  del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }

        /// <summary>
        /// constructor con parametros.
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        /// <param name="estadoCuenta">estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, 
                      Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna en que clase participa el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClases()
        {
            return String.Format("TOMA CLASE DE {0}\n", this.claseQueToma.ToString());   
        }

        /// <summary>
        /// retorna la informacion del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta.ToString());
            sb.AppendLine(this.ParticipaEnClases());
            return sb.ToString();
        }

        /// <summary>
        /// sobrecarga del metodo ToString.
        /// </summary>
        /// <returns>retorna la informacion del alumno</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Valida si un alumno participa en una clase y su estado no es Deudor.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>TRUE si cumple con dichas condiciones, FALSE caso contrario.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && !(a.estadoCuenta == EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Valida si un alumno NO participa de una clase.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>TRUE si el alumno no participa la clase, FALSE caso contrario.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
    }



}
