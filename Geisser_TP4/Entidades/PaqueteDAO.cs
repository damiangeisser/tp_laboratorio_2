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
        static PaqueteDAO()
        {
            try
            {
                PaqueteDAO.conexion = new SqlConnection("Data Source = localhost; Database = correo-sp-2017; Trusted_Connection = true;");

                PaqueteDAO.comando = new SqlCommand();

                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.comando.CommandType = CommandType.Text;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }

        /// <summary>
        /// Gestiona los parámetros y la conexión a la base de datos
        /// para poder grabar los datos de un paquete.
        /// </summary>
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO.comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                PaqueteDAO.comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID));
                PaqueteDAO.comando.Parameters.Add(new SqlParameter("alumno", "Geisser Damian"));

                PaqueteDAO.comando.CommandText = "INSERT INTO Paquetes VALUES(@direccionEntrega, @trackingID, @alumno )";

                PaqueteDAO.conexion.Open();

                PaqueteDAO.comando.ExecuteNonQuery();

                PaqueteDAO.conexion.Close();

                PaqueteDAO.comando.Parameters.Clear();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
