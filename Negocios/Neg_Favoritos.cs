using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
    public class Neg_Favoritos
    {
        public static void AgregarFavorito(string idUsuario, string idInmueble)
        {
            try
            {
                        string insertQuery = "INSERT INTO Favoritos (IdUsuario, IdInmueble) " +
                            $"VALUES ('{idUsuario}', '{idInmueble}')";

                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.QueryDB(insertQuery); ;
                    }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                throw new Exception(ex.Message);
            }
        }



        public static void EliminarFavorito(string idInmueble, string idUsuario)
        {
            try
            {
                string deleteQuery = "DELETE FROM Favoritos (IdUsuario, IdInmueble) " +
                            $"VALUES ('{idUsuario}', '{idInmueble}')";


                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.QueryDB(deleteQuery);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                throw new Exception(ex.Message);
            }
        }


        public DataTable ObtenerFavoritosDeUsuario(string IdUsuario)
        {
            string spName = "ListarInmueblesPrincipal";
            var lstParametros = new List<SqlParameter>();
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);
        }
    }
}