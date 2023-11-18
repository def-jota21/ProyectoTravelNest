using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Dynamic;
using Entidades;

namespace Datos
{
    public class ConexionSQL

    {
        private static StringBuilder strConexion;
        private static SqlConnection sqlCon;
        public static void CadenaConexion()
        {
            strConexion = new StringBuilder();
            strConexion.Append("Data Source=");
            strConexion.Append("tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019");
            strConexion.Append(";Initial Catalog=");
            strConexion.Append("ProyectoG6");
            strConexion.Append(";User ID=");
            strConexion.Append("Proyecto");
            strConexion.Append(";Password=");
            strConexion.Append("Proyecto#12345"); 

            sqlCon = new SqlConnection(strConexion.ToString());

            try
            {
                sqlCon.Open();
            }catch (Exception ex)
            {
                String Mensaje = ex.Message;
            }
            sqlCon.Close();
        }//fin de cadena de conexion

        public SqlConnection sqlConn;

        //public ConexionSQL()
        //{
        //    sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString);
        //}

        string connection_string = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";

        public ConexionSQL()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString);
        }


        #region "Manejo de constultas SQL"
        public void QueryDB(string QuerySQL)
        {
            try
            {
                // Se indica la consulta que se desea realizar
                SqlCommand cmd = new SqlCommand(QuerySQL)
                {
                    Connection = this.sqlConn
                };
                // Se abre conexion con la base de datos
                sqlConn.Open();

                // Ejecuta la consulta de la base de datos
                cmd.ExecuteNonQuery();

                // Se cierra la conexion
                sqlConn.Close();
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Devuelve un datatable
        public DataTable QueryDBWithDT(string QuerySQL)
        {
            try
            {
                // Indica la consulta que se desea hacer
                SqlCommand cmd = new SqlCommand(QuerySQL);
                cmd.Connection = this.sqlConn;


                // Objeeto para ejecutar la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Objeto para almacenar la informacion
                DataTable dtDatos = new DataTable();

                // Ejecuta la consulta
                adapter.Fill(dtDatos);

                return dtDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region "Manejo de Procedimientos Almacenados"
        public int ExecuteSPWithScalar(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);

                sqlConn.Open();

                object result = cmd.ExecuteScalar();

                sqlConn.Close();

                return Convert.ToInt32(result);
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExecuteSP(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);


                sqlConn.Open();

                cmd.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ExecuteSPWithDS(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.sqlConn
                };
                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);

                // Objeeto para ejecutar la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                DataSet dsDatos = new DataSet();

                // Ejecuta la consulta
                adapter.Fill(dsDatos);

                return dsDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // METODOS DE JAIRO ------------------------------------------------------------------------
        public static void ExecuteQuery(String NombreProcedimiento, List<SqlParameter> ListaParametros)
        {
            try
            {
                //Inicializa la conexion
                CadenaConexion();

                //Crea el objeto SQL
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = NombreProcedimiento,
                    CommandType = CommandType.StoredProcedure,
                    Connection = sqlCon
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                {
                    cmd.Parameters.Add(sqlParam);
                }

                //Abre la Conexion
                sqlCon.Open();

                //Ejecuta la Consulta
                cmd.ExecuteNonQuery();

                //Cierra la conexion
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                if (sqlCon.State != ConnectionState.Closed)
                    sqlCon.Close();
                throw ex;
            }//fin del catch
        }//fin de ExecuteQuery

        public static DataTable ExecuteQueryTableGeneral(String NombreProcedimiento)
        {
            DataTable dtDatos = new DataTable();
            try

            {

                //Inicializa la conexion
                CadenaConexion();



                //Crea el objeto SQL
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = NombreProcedimiento,
                    CommandType = CommandType.StoredProcedure,
                    Connection = sqlCon
                };




                //Abre la Conexion
                sqlCon.Open();

                //Ejecuta la Consulta
                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dtDatos);


                //Cierra la conexion
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                if (sqlCon.State != ConnectionState.Closed)
                    sqlCon.Close();
                throw ex;
            }//fin del catch
            return dtDatos;
        }//fin de ExecuteQuery

        public static DataTable ExecuteQueryTable(String NombreProcedimiento, List<SqlParameter> ListaParametros)
        {
            DataTable dtDatos = new DataTable();
            try

            {

                //Inicializa la conexion
                CadenaConexion();



                //Crea el objeto SQL
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = NombreProcedimiento,
                    CommandType = CommandType.StoredProcedure,
                    Connection = sqlCon
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                {
                    cmd.Parameters.Add(sqlParam);
                }


                //Abre la Conexion
                sqlCon.Open();

                //Ejecuta la Consulta
                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dtDatos);

                //Cierra la conexion
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                if (sqlCon.State != ConnectionState.Closed)
                    sqlCon.Close();
                throw ex;
            }//fin del catch
            return dtDatos;
      }//fin de ExecuteQuery


     // METODOS DE JAIRO ------------------------------------------------------------------------
        public DataTable ExecuteSPWithDT(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = SPName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.sqlConn
                };

                if (ListaParametros != null && ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(ListaParametros.ToArray());

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                // Ejecuta la consulta
                adapter.Fill(dtDatos);

                return dtDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region "METODOS CHARLIE"

        public void EliminarFavorito(string idInmueble, string idUsuario, string instruccion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUDFavoritos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idInmueble", idInmueble);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@instruccion", instruccion);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar favorito: " + ex.Message);
            }
        }

        public void AgregarFavorito(string idUsuario, string idInmueble, string instruccion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUDFavoritos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@idInmueble", idInmueble);
                        cmd.Parameters.AddWithValue("@instruccion", instruccion);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar favoritos: " + ex.Message);
            }
        }

        public DataSet ObtenerFavoritosUsuario(string idUsuario, string instruccion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUDFavoritos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@instruccion", instruccion);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet dsFavoritos = new DataSet();
                            adapter.Fill(dsFavoritos);

                            return dsFavoritos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los favoritos del usuario : " + ex.Message);
            }
        }

        public void AjustarTiempoReservas(string IdInmueble, string Tiempo_EstadiaMinima, string Tiempo_EstadiaMaxima, string Tiempo_ReservaMinima, string Tiempo_ReservaMaxima)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("AjustarReservas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdInmueble", IdInmueble);
                        cmd.Parameters.AddWithValue("@Tiempo_EstadiaMinima", Tiempo_EstadiaMinima);
                        cmd.Parameters.AddWithValue("@Tiempo_EstadiaMaxima", Tiempo_EstadiaMaxima);
                        cmd.Parameters.AddWithValue("@Tiempo_ReservaMinima", Tiempo_ReservaMinima);
                        cmd.Parameters.AddWithValue("@Tiempo_ReservaMaxima", Tiempo_ReservaMaxima);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar ajustar las reservas" + ex.Message);
            }
        }


        public void AjustarDataInmueble(string idInmueble, decimal precioNoche)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("AjustarData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idInmueble", idInmueble);
                        cmd.Parameters.AddWithValue("@precioNoche", precioNoche);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ajustar los datos de tu calendario" + ex.Message);
            }
        }

        public string GetPrecio(string idInmueble)
        {
            string precio = "";
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("GetPrecioNoche", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idInmueble", idInmueble);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            precio = Convert.ToString(reader.GetDecimal(0));
                        }
                    }

                    return precio;
                }
            }
        }

        public List<Inmueble> GetInmueblesPorAnfitrion(string anfitrionId)
            {
                List<Inmueble> inmuebles = new List<Inmueble>();

                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("[Proyecto].[SP.InmueblesYPrecioPorAnfitrion]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AnfitrionId", anfitrionId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                inmuebles.Add(new Inmueble
                                {
                                    IdInmueble = reader.GetString(0),
                                    Nombre = reader.GetString(1),
                                    Precio = (float)reader.GetDecimal(0)

                        });
                            }
                        }
                    }
                }

                return inmuebles;
            }



        }

    #endregion
}
#endregion
