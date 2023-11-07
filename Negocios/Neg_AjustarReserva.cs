using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
    public class Neg_AjustarReserva
    {
        public static void InsertarAjustarReserva(int IdInmueble, string Tiempo_EstadiaMinima, string Tiempo_EstadiaMaxima, string Tiempo_ReservaMinima, string Tiempo_ReservaMaxima)
        {
            try
            {
                string insertQuery = "INSERT INTO AjustarReserva (Tiempo_EstadiaMinima, Tiempo_EstadiaMaxima, Tiempo_ReservaMinima, Tiempo_ReservaMaxima, IdInmueble) " +
                                    $"VALUES ('{Tiempo_EstadiaMinima}', '{Tiempo_EstadiaMaxima}', '{Tiempo_ReservaMinima}', '{Tiempo_ReservaMaxima}', {IdInmueble})";

                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.QueryDB(insertQuery);
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                throw new Exception(ex.Message);
            }
        }

    }
}