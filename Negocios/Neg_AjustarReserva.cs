using Datos;
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
        ConexionSQL conexionBD = new ConexionSQL();

        public void AjustarTimeReserva(string IdInmueble, string Tiempo_EstadiaMinima, string Tiempo_EstadiaMaxima, string Tiempo_ReservaMinima, string Tiempo_ReservaMaxima)
        {
            conexionBD.AjustarTiempoReservas(IdInmueble, Tiempo_EstadiaMinima, Tiempo_EstadiaMaxima, Tiempo_ReservaMinima, Tiempo_ReservaMaxima);
        }

        public void AjustarDataPrecio(string idInmueble, decimal precioNoche)
        {
            conexionBD.AjustarDataInmueble(idInmueble, precioNoche);
        }

        public string GetPrecioNoche(string idInmueble)
        {
            return conexionBD.GetPrecio(idInmueble);
        }

    }
}