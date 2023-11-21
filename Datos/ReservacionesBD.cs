using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class ReservacionesBD
    {
        string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        public Reservaciones ObtenerReservacionRecientePorUsuario(string idUsuario)
        {
            Reservaciones reservacion = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("[Proyecto].[SP_ObtenerReservasiones]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            reservacion = new Reservaciones
                            {
                                // Asumiendo que tienes una clase Reservaciones que mapea a la tabla
                                IdReservacion = dr.GetInt32(dr.GetOrdinal("IdReservacion")),
                                IdInmueble = dr.GetString(dr.GetOrdinal("IdInmueble")),
                                // Usa el alias proporcionado en el procedimiento almacenado
                                NombreInmueble = dr.GetString(dr.GetOrdinal("NombreInmueble")),
                                NombreUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario")),
                                F_Inicio = dr.GetDateTime(dr.GetOrdinal("F_Inicio")),
                                F_Fin = dr.GetDateTime(dr.GetOrdinal("F_Fin")),
                                Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? null : dr.GetString(dr.GetOrdinal("Estado")),
                                // ... otras propiedades ...
                            };
                        }
                    }
                }
            }

            return reservacion;
        }

        public bool InsertarReservacion(string idInmueble, string idUsuario, DateTime fInicio, DateTime fFin)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CRUDReservaciones", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@opcion", 1);
                        cmd.Parameters.AddWithValue("@idInmueble", idInmueble);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@F_Inicio", fInicio);
                        cmd.Parameters.AddWithValue("@F_Fin", fFin);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        return rowsAffected < 0;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al insertar reservación: " + ex.Message);
                return false;
            }
        }

    }
}
    
