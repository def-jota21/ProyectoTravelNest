using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MensajeriaBD
    {
        string connectionString = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        public DataSet GetDataReservas(string idUsuarioHuesped, string instruccion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("GetAnfitrionDeReserva", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetro de entrada
                        cmd.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NChar, 13)).Value = idUsuarioHuesped;
                        cmd.Parameters.AddWithValue("@instruccion", instruccion);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            return dataSet;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los anfitriones de las reservas activas del huesped solicitado" + ex.Message);
            }
        }

        public void InsertMessageToBD(string idEmisor, string idReceptor, string mensaje)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertMessage", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idEmisor", idEmisor);
                        cmd.Parameters.AddWithValue("@idReceptor", idReceptor);
                        cmd.Parameters.AddWithValue("@contenido", mensaje);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar los mensajes: " + ex.Message);
            }
        }

        public string GetReceiverEmail(string idUsuario)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetReceiverEmail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parametros de entrada
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        // Declarar una variable para almacenar el resultado
                        string userEmail = string.Empty;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener el valor del identificador del chat desde el resultado de la consulta
                                userEmail = reader["Correo"].ToString();
                            }

                        }

                        return userEmail;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el email del ID Receptor" + ex.Message);
            }
        }

        public DataSet GetMessagesFromBD(string idRecuperado, string idUsuario)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("GetMessagesFromId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Pasrametro de entrada
                        cmd.Parameters.AddWithValue("@idRecuperado", idRecuperado);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            return dataSet;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los mensajes del chat especifico" + ex.Message);
            }
        }

        public string GetDenuncianteID(string idDenuncia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetDenuncianteEmail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parametros de entrada
                        cmd.Parameters.AddWithValue("@idDenuncia", idDenuncia);

                        // Declarar una variable para almacenar el resultado
                        string userEmail = string.Empty;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener el valor del identificador del chat desde el resultado de la consulta
                                userEmail = reader["Correo"].ToString();
                            }

                        }

                        return userEmail;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el email del ID Receptor" + ex.Message);
            }
        }


    }
}
