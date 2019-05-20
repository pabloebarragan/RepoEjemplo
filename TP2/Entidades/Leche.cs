using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Leche : Producto
    {
        private ETipo tipo;

        public enum ETipo
        {
            Entera, Descremada
        }
        
        /// <summary>
        /// Constructor de la subclase Leche. Por defecto, tipo será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="colorPrimarioEmpaque"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) 
            : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor de la subclase Leche
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="colorPrimarioEmpaque"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque, ETipo tipo)
            : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra los datos de Leche y su clase base
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
