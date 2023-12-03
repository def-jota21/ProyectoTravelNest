using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Entidades
{
    public class UsuariosBD
    {
        string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        public DataTable ObtenerDatosUsuario(string idUsuario)
        {
            DataTable dtUsuario = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Proyecto.ObtenerDatosUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtUsuario);
                }
            }

            return dtUsuario;
        }




        public void ActualizarUsuario(string idUsuario, string nombre, string apellidos, string correo, int telefono)

      
        {
            try
            {
                string spName = "SP_ActualizarUsuario";

                var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellidos", apellidos),
                new SqlParameter("@Correo", correo),
                new SqlParameter("@Telefono", telefono)
            };

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parametros.ToArray());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o volver a lanzarla según tus requisitos
                throw new Exception($"Ha ocurrido un error  al intentar actualizar los datos del usuario: {ex.Message}");
            }
        }
    



    public DataTable ObtenerContraseñaUsuario(string idUsuario)
        {
            DataTable dtUsuario = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerContrasenaUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtUsuario);
                }
            }

            return dtUsuario;
        }
        public void ActualizarContrasenaUsuario(string Contrasena,string IdUsuario)
        {
            try
            {
                string spName = "[Proyecto].[SP.ActualizarContrasenaUsuario]";


                var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdUsuario", IdUsuario),
                new SqlParameter("@Contrasena", Contrasena)
                
            };

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parametros.ToArray());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o volver a lanzarla según tus requisitos
                throw new Exception($"Ha ocurrido un error  al intentar actualizar los datos del usuario: {ex.Message}");
            }
        }

        public void DesactivarCuenta(string idUsuario)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[Proyecto].[SP.DesactivarCuenta]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepción
                throw new Exception("Error al desactivar la cuenta: " + ex.Message);
            }
        }
    }

}






