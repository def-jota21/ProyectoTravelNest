using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Datos
{

    public class DenunciasBD
    {
        string connection_string = "Data Source=tiusr21pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Initial Catalog=ProyectoG6;User ID=Proyecto;Password=Proyecto#12345";


        public void CRUDDenunciasBD(string _idDenuncia = null, string _idDenunciante = null, string _idDenunciado = null, string _motivoDenuncia = null,
                                                                string _sancion = null, string _tipoUsuario = null, string _descripcionDenuncia = null,
                                                                string _estado = null, string _instruccion = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUD_Denuncias", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idDenuncia", _idDenuncia);
                        cmd.Parameters.AddWithValue("@idDenunciante", _idDenunciante);
                        cmd.Parameters.AddWithValue("@idDenunciado", _idDenunciado);
                        cmd.Parameters.AddWithValue("@MotivoDenuncia", _motivoDenuncia);
                        cmd.Parameters.AddWithValue("@Sancion", _sancion);
                        cmd.Parameters.AddWithValue("@TipoUsuario", _tipoUsuario);
                        cmd.Parameters.AddWithValue("@DescripcionDenuncia", _descripcionDenuncia);
                        cmd.Parameters.AddWithValue("@Estado", _estado);
                        cmd.Parameters.AddWithValue("@Instruccion", _instruccion);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la instrucción" + ex.Message);
            }
        }

        public DataSet ObtenerDataDenunciasGestorBD(string _instruccion)
        {
            try
            {
                DataSet dsDenuncias = new DataSet();
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUD_Denuncias", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Instruccion", _instruccion);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dsDenuncias);
                        }
                    }
                    return dsDenuncias;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los datos: " + ex.Message);
            }
        }

        public DataSet ObtenerDataDenunciasPorID(string _instruccion, string _idDenunciante = null)
        {
            try
            {
                DataSet dsDenuncias = new DataSet();
                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("CRUD_Denuncias", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idDenunciante", _idDenunciante);
                        cmd.Parameters.AddWithValue("@Instruccion", _instruccion);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dsDenuncias);
                        }
                    }
                    return dsDenuncias;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los datos: " + ex.Message);
            }
        }

        public DataSet GetInmuebles(string idUsuario, string rolUsuario)
        {
            try
            {
                DataSet dsInfo = new DataSet();

                using (SqlConnection con = new SqlConnection(connection_string))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("GetDataInmuebles", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@RolUsuario", rolUsuario);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dsInfo);
                        }
                    }
                    return dsInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los inmuebles" + ex.Message);
            }
        }
    }
}
