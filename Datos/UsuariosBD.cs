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



        public void ActualizarUsuario(string idUsuario, string nombre,string apellidos, string correo, int telefono)
        {
            try
            {
                string spName = "SP_ActualizarUsuario";

                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@IdUsuario", idUsuario));
                parametros.Add(new SqlParameter("@Nombre", nombre));
                parametros.Add(new SqlParameter("@Apellidos", apellidos));
                parametros.Add(new SqlParameter("@Correo", correo));
                parametros.Add(new SqlParameter("@Telefono", telefono));
                

                ConexionSQL conexion = new ConexionSQL();
                conexion.ExecuteSP(spName, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
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
        public void ActualizarContrasenaUsuario(string Contrasena)
        {
            try
            {
                string spName = "ActualizarContrasenaUsuario";

                var parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Contrasena", Contrasena));
                ConexionSQL conexion = new ConexionSQL();
                conexion.ExecuteSP(spName, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}





