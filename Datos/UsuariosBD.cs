using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class UsuariosBD
    {
        //string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        //public Usuarios VerificarCredenciales(string correo, string contrasena)
        //{
        //    Usuarios usuario = null;

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SP_IniciarSesion", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@correo", correo));
        //            cmd.Parameters.Add(new SqlParameter("@contra", contrasena));
        //            con.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    usuario = new Usuarios()
        //                    {
        //                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),

        //                        T_Rol = dr["T_Rol"].ToString()[0]

        //                        // Asignar el resto de las propiedades
        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return usuario;
        //}
    }
}

