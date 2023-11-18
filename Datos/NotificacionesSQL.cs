using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class NotificacionesSQL
    {
        private static SqlConnection sqlCon;

        private static void CadenaConexion()
        {
            string strConexion = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";
            sqlCon = new SqlConnection(strConexion);
        }

        public int ObtenerCantidadComentariosNotificacion(string idUsuario)
        {
            CadenaConexion();
            using (sqlCon)
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("CantidadComentariosNotificacion", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro "@idUsuario" al comando
                    command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.NChar, 13));
                    command.Parameters["@idUsuario"].Value = idUsuario;

                    // Ejecutar el procedimiento almacenado y obtener el resultado
                    int contadorMensajes = (int)command.ExecuteScalar();

                    return contadorMensajes;
                }
            }
        }

        public int ObtenerMibanco(string idUsuario)
        {
            CadenaConexion();
            using (sqlCon)
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("CantidadComentariosNotificacion", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar el parámetro "@idUsuario" al comando
                    command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.NChar, 13));
                    command.Parameters["@idUsuario"].Value = idUsuario;

                    // Ejecutar el procedimiento almacenado y obtener el resultado
                    int contadorMensajes = (int)command.ExecuteScalar();

                    return contadorMensajes;
                }
            }
        }
    }
}
