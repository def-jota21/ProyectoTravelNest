using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class InmuebleSQL
    {
        private static SqlConnection sqlCon;

        private static void CadenaConexion()
        {
            string strConexion = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";
            sqlCon = new SqlConnection(strConexion);
        }

        public DataTable ObtenerTablaCategoria()
        {
            DataTable tablaServicios = new DataTable();

            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                string query = "SELECT * FROM Categorias";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaServicios);
                    }
                }
            }

            return tablaServicios;
        }

        public string ObtenerNombreCategoriaPorId(string idCategoria)
        {
            string nombreCategoria = string.Empty;
            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();
                string query = "SELECT Nombre FROM Categorias WHERE IdCategoria = @IdCategoria";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    // Ejecutar la consulta y obtener el nombre de la categoría
                    nombreCategoria = (string)command.ExecuteScalar();
                }
            }

            return nombreCategoria;
        }


        public DataTable ObtenerDatosInmueble(string idInmueble)
        {
            DataTable tablaInmueble = new DataTable();
            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();
                string query = "SELECT * FROM Inmueble WHERE IdInmueble = @IdInmueble";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    // Configurar el parámetro
                    command.Parameters.AddWithValue("@IdInmueble", idInmueble);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaInmueble);
                    }
                }
            }

            return tablaInmueble;
        }


        public DataTable ObtenerTablaPoliticas()
        {
            DataTable tablapoliticas = new DataTable();

            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                string query = "SELECT idPolitica, Nombre FROM Politicas";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablapoliticas);
                    }
                }
            }

            return tablapoliticas;
        }

        public DataTable ObtenerTablaAmenidades()
        {
            DataTable tablaServicios = new DataTable();

            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                string query = "SELECT * FROM Amenidades";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tablaServicios);
                    }
                }
            }

            return tablaServicios;
        }
        public string InsertarInmueble(Entidades.Inmueble inmueble,string IdCategoria,string rutas, string IdUsuario)
        {
            string nuevoIdInmueble = string.Empty;

            CadenaConexion();

            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand("ManteInmueble", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = "1";
                        cmd.Parameters.Add("@IdInmueble", SqlDbType.NVarChar).Value = "";
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = IdUsuario;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = inmueble.Nombre;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = inmueble.Direccion;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = inmueble.Descripcion;
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = inmueble.Estado;
                        cmd.Parameters.Add("@IdCategoria", SqlDbType.Decimal).Value = IdCategoria;
                        cmd.Parameters.Add("@Cant_Huesped", SqlDbType.VarChar).Value = inmueble.Cantidad_Huesped;
                        cmd.Parameters.Add("@Precio", SqlDbType.VarChar).Value = inmueble.Precio;
                        cmd.Parameters.Add("@Habitaciones", SqlDbType.Int).Value = inmueble.Habitaciones;
                        cmd.Parameters.Add("@Banhos", SqlDbType.Int).Value = inmueble.Banhos;

                        SqlParameter outputParam = new SqlParameter("@NuevoIdInmueble", SqlDbType.NChar, 13);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();

                        nuevoIdInmueble = outputParam.Value.ToString();
                    }

                }
                return nuevoIdInmueble;
            }
            catch (Exception ex)
            {
                // Manejo del error: puedes registrar el error, lanzar una excepción específica o realizar otras acciones según tus necesidades.
                throw new Exception($"Error: {ex.Message}", ex);
            }
        }

        public bool EditarInmueble(Entidades.Inmueble inmueble, string IdCategoria, string IdInmueble)
        {
            CadenaConexion();

            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand("ManteInmueble", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                        cmd.Parameters.Add("@IdInmueble", SqlDbType.NVarChar).Value = IdInmueble;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = "";
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = inmueble.Nombre;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = inmueble.Direccion;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = inmueble.Descripcion;
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = inmueble.Estado;
                        cmd.Parameters.Add("@IdCategoria", SqlDbType.Decimal).Value = IdCategoria;
                        cmd.Parameters.Add("@Cant_Huesped", SqlDbType.VarChar).Value = inmueble.Cantidad_Huesped;
                        cmd.Parameters.Add("@Precio", SqlDbType.VarChar).Value = inmueble.Precio;
                        cmd.Parameters.Add("@Habitaciones", SqlDbType.Int).Value = inmueble.Habitaciones;
                        cmd.Parameters.Add("@Banhos", SqlDbType.Int).Value = inmueble.Banhos;
                        

                        SqlParameter outputParam = new SqlParameter("@NuevoIdInmueble", SqlDbType.NChar, 13);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();

                        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public List<Tuple<string, string>> ObtenerAmenidadesDelInmueble(string idInmueble)
        {
            List<Tuple<string, string>> amenidadesInmueble = new List<Tuple<string, string>>();
            CadenaConexion();
            using (sqlCon)
            {
                using (SqlCommand command = new SqlCommand("ObtenerAmenidadesInmueble", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdInmueble", idInmueble);

                    sqlCon.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idAmenidades = reader["IdAmenidades"].ToString();
                            string nombreAmenidades = reader["Nombre"].ToString();

                            amenidadesInmueble.Add(new Tuple<string, string>(idAmenidades, nombreAmenidades));
                        }
                    }
                }
            }

            return amenidadesInmueble;
        }
        public void AsociarAmenidadAInmueble(string idInmueble, string idAmenidad)
        {
            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("AsociarAmenidadAInmueble", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros del procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@IdInmueble", SqlDbType.NChar)).Value = idInmueble;
                    command.Parameters.Add(new SqlParameter("@IdAmenidad", SqlDbType.NChar)).Value = idAmenidad;

                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAmenidadAInmueble(string idInmueble, string idAmenidad)
        {
            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                using (SqlCommand command = new SqlCommand("EliminarAmenidadAInmueble", sqlCon))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros del procedimiento almacenado
                    command.Parameters.Add(new SqlParameter("@IdInmueble", SqlDbType.NChar)).Value = idInmueble;
                    command.Parameters.Add(new SqlParameter("@IdAmenidad", SqlDbType.NChar)).Value = idAmenidad;

                    // Ejecuta el procedimiento almacenado
                    command.ExecuteNonQuery();
                }
            }
        }
        public string ObtenerIdAmenidadPorNombre(string nombreAmenidad)
        {
            string idAmenidad = "-1"; // Valor predeterminado en caso de que no se encuentre la amenidad
            CadenaConexion();

            using (sqlCon)
            {
                sqlCon.Open();

                string query = "SELECT IdAmenidades FROM Amenidades WHERE Nombre = @Nombre";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 255)).Value = nombreAmenidad;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idAmenidadInt;
                            if (int.TryParse(reader[0].ToString(), out idAmenidadInt))
                            {
                                idAmenidad = idAmenidadInt.ToString();
                            }
                        }
                    }
                }
            }

            return idAmenidad;
        }

        public bool InsertarImagenInmueble(string idInmueble, byte[] arregloByte)
        {
            try
            {
                CadenaConexion();
                using (sqlCon)
                {
                    sqlCon.Open();
                    // Crear el comando SQL para insertar la imagen
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [Proyecto].[ImagenesxInmueble] ([IdInmueble], [Imagen]) VALUES (@IdInmueble, @Imagen)", sqlCon))
                    {
                        // Asignar los parámetros
                        cmd.Parameters.AddWithValue("@IdInmueble", idInmueble);
                        cmd.Parameters.AddWithValue("@Imagen", arregloByte);

                        cmd.ExecuteNonQuery();

                        // Si la inserción fue exitosa, devolver true
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (puedes registrarla o mostrarla según sea necesario)
                // Devolver false en caso de error
                return false;
            }
        }

        public void InsertarPoliticas(string idInmueble, string idPolitica, string desPolitica)
        {
            CadenaConexion();
            using (sqlCon)
            {
                sqlCon.Open();
                // Crear el comando SQL para insertar la imagen
                using (SqlCommand cmd = new SqlCommand("INSERT INTO PoliticasxInmueble (IdInmueble, IdPolitica, Comentario) VALUES (@IdInmueble, @IdPolitica, @Comentario)", sqlCon))
                {
                    // Asignar los parámetros
                    cmd.Parameters.AddWithValue("@IdInmueble", idInmueble);
                    cmd.Parameters.AddWithValue("@IdPolitica", idPolitica);
                    cmd.Parameters.AddWithValue("@Comentario", desPolitica);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CambiarEstadoInactivo(string idInmueble)
        {
            try
            {
                CadenaConexion(); 
                using (sqlCon)
                {
                    sqlCon.Open();

                    string query = "UPDATE Inmueble SET Estado = 'Inactivo' WHERE IdInmueble = @IdInmueble";
                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        // Asignar los parámetros de forma segura
                        cmd.Parameters.AddWithValue("@IdInmueble", idInmueble);

                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
