using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MiBancoSQL
    {
        private static SqlConnection sqlCon;

        private static void CadenaConexion()
        {
            string strConexion = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";
            sqlCon = new SqlConnection(strConexion);
        }

        public string EjecutarMantenimientoMiBanco(int opcion, string idUsuario, string numeroCuenta, string cvv)
        {
            try
            {
                CadenaConexion();
                using (sqlCon)
                {
                    sqlCon.Open();
                    using (SqlCommand command = new SqlCommand("[Proyecto].[MantenimientoMiBanco]", sqlCon))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Opcion", opcion);
                        command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        command.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta);
                        command.Parameters.AddWithValue("@CVV", cvv);
                        command.ExecuteNonQuery();
                    }
                }
               // return "Exito"; // Devuelve un mensaje de éxito
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message; // Devuelve un mensaje de error con detalles
            }

            return "Exito";
        }

        public string InsertarUsuarioMiBanco(string idUsuario, string numeroCuenta, string cvv)
        {
            return EjecutarMantenimientoMiBanco(1, idUsuario, numeroCuenta, cvv);
        }

        public string EliminarUsuarioMiBanco(string idUsuario, string numeroCuenta)
        {
            return EjecutarMantenimientoMiBanco(4, idUsuario, numeroCuenta, "");
        }
        public string EliminarUsuarioMiBanco2(string idUsuario, string numeroCuenta)
        {
            return EjecutarMantenimientoMiBanco(5, idUsuario, numeroCuenta, "");
        }

        public bool ExisteUsuarioMiBanco(string idUsuario)
        {
            CadenaConexion();
            using (sqlCon)
            {
                sqlCon.Open();
                using (SqlCommand command = new SqlCommand("[Proyecto].[MantenimientoMiBanco]", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Opcion", 3);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.Parameters.AddWithValue("@NumeroCuenta", "");
                    command.Parameters.AddWithValue("@CVV", "");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifica si el lector tiene alguna fila (es decir, si existe un usuario con el IdUsuario)
                        return reader.HasRows;
                    }
                }
            }
        }


    }
}
