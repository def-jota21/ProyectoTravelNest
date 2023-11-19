using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ServiciosSQL
    {
        private string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        public DataTable ObtenerTablaServicios()
        {
            DataTable tablaServicios = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Servicios";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaServicios);
                    }
                }
            }

            return tablaServicios;
        }

        public List<Tuple<string, string>> ObtenerServiciosDelInmueble(string idInmueble)
        {
            List<Tuple<string, string>> serviciosInmueble = new List<Tuple<string, string>>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ObtenerServiciosInmueble", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdInmueble", idInmueble);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idServicio = reader["IdServicio"].ToString();
                            string nombreServicio = reader["Nombre"].ToString();

                            serviciosInmueble.Add(new Tuple<string, string>(idServicio, nombreServicio));
                        }
                    }
                }
            }

            return serviciosInmueble;
        }

        public void EjecutarProcedureServicioxInmueble(string IdInmueble, string IdServicio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ProcedureServicioxInmueble", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros del procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@IdInmueble", SqlDbType.NChar)).Value = IdInmueble;
                    command.Parameters.Add(new SqlParameter("@IdServicio", SqlDbType.NChar)).Value = IdServicio;

                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EjecutarEliminarServicioxInmueble(string IdInmueble, string IdServicio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("EliminarServicioxInmueble", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros del procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@IdInmueble", SqlDbType.NChar)).Value = IdInmueble;
                    command.Parameters.Add(new SqlParameter("@IdServicio", SqlDbType.NChar)).Value = IdServicio;

                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public string ObtenerIdServicioPorNombre(string nombreServicio)
        {
            string idServicio = "-1"; // Valor predeterminado en caso de que no se encuentre el servicio
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdServicio FROM Servicios WHERE TRIM(REPLACE(Nombre,' ', '')) = @Nombre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 255)).Value = nombreServicio;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idServicioInt;
                            if (int.TryParse(reader[0].ToString(), out idServicioInt))
                            {
                                idServicio = idServicioInt.ToString();
                            }
                        }
                    }
                }
            }

            return idServicio;
        }

        public DataTable ObtenerServiciosPorInmueble(string idInmueble)
        {
            DataTable tablaServicios = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT S.Nombre FROM ServicioxInmueble SI JOIN Servicios S ON SI.IdServicio = S.IdServicio WHERE SI.IdInmueble = @IdInmueble";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdInmueble", idInmueble);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaServicios);
                    }
                }
            }

            return tablaServicios;
        }

    }
}
