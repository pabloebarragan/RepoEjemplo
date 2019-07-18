using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSQLException(Exception e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoSQLException InformaSQLException;

        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return trackingID;
            }
            set
            {
                trackingID = value;
            }
        }

        /// <summary>
        /// Crea un nuevo paquete. Asigna direccion, trackingID y estado (ingresado).
        /// </summary>
        /// <param name="direccionEntrega">direccion</param>
        /// <param name="trackingID">trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            Estado = EEstado.Ingresado;
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }

        /// <summary>
        /// MockCicloDeVida hará que el paquete cambie de estado de la siguiente forma:
        /// a.Colocar una demora de 4 segundos.
        /// b.Pasar al siguiente estado.
        /// c.Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        /// d.Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        /// e.Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                Estado += 1;
                InformaEstado(this, null);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                InformaSQLException(e);
            }
        }

        /// <summary>
        /// Muestra la información del paquete.
        /// </summary>
        /// <param name="elemento">Paquete a mostrar</param>
        /// <returns>String con la info del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Muestra la información del paquete.
        /// </summary>
        /// <returns>String con la info del paquete</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">paquete Uno a comparar</param>
        /// <param name="p2">paquete Dos a comparar</param>
        /// <returns>True si son iguales. False si son distintos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID.Equals(p2.TrackingID);
        }

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">paquete Uno a comparar</param>
        /// <param name="p2">paquete Dos a comparar</param>
        /// <returns>True si son distintos. False si son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
