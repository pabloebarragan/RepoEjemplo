using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }

        /// <summary>
        /// Inicializa la lista de hilos y la lista de paquetes
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            Paquetes = new List<Paquete>();
        }

        /// <summary>
        /// cerrará todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if (hilo.IsAlive)
                    hilo.Abort();
            }
        }

        /// <summary>
        /// Muestra la información del Correo.
        /// </summary>
        /// <param name="elementos">Correo a mostrar</param>
        /// <returns>String con la info del correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} ({1})", paquete.ToString(), paquete.Estado.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// En el operador +:
        /// a.Controlar si el paquete ya está en la lista.En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        /// b.De no estar repetido, agregar el paquete a la lista de paquetes.
        /// c.Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        /// d.Ejecutar el hilo.
        /// </summary>
        /// <param name="c">correo</param>
        /// <param name="p">paquete</param>
        /// <returns>Devuelve el Correo con los cambios</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                {
                    string message = String.Format("El tracking ID {0} ya figura en la lista de envios", p.TrackingID);
                    throw new TrackingIdRepetidoException(message);
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
    }
}
