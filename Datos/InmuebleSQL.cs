using System;
using System.Collections.Generic;
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
        public string InsertarInmueble(Entidades.Inmueble inmueble,string IdCategoria,string rutas)
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
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = "2222222222";
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
    }
}
