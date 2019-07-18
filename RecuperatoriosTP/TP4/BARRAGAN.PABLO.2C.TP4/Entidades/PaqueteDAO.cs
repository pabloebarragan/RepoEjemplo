using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Inicializa la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            string connectionStr = @"Server=CPX-ZJRAVV4MO3J; Initial Catalog = correo-sp-2017; Integrated Security = True";

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error en la conexion con la base de datos", e);
            }
        }

        /// <summary>
        /// Se guarda un paquete en la base de datos. Se guarda Direccion, trackingID y nombre del alumno.
        /// </summary>
        /// <param name="p">paquete que se va a guardar en la base</param>
        /// <returns>True si salio todo bien. Si hay un error lanza una exception</returns>
        public static bool Insertar(Paquete p)
        {
            bool respuesta = false;
            try
            {
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','{2}')",
                    p.DireccionEntrega, p.TrackingID, "Barragan Pablo");
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception e)
            {
                string message = String.Format("Se produjo un error al intentar guardar el paquete {0} en la base de datos",
                    p.ToString());
                throw new Exception(message, e);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return respuesta;
        }
    }
}
