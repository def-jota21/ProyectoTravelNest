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
    public class Neg_Reservaciones
    {
       
            Datos.ReservacionesBD datosReservaciones = new Datos.ReservacionesBD();

            public Reservaciones ObtenerReservacionRecientePorUsuario(string idUsuario)
            {
                return datosReservaciones.ObtenerReservacionRecientePorUsuario(idUsuario);
            }
        public bool InsertarReservacion(string idInmueble, string idUsuario, string finicio, string ffin)
        {
            Datos.ReservacionesBD reservaciones = new Datos.ReservacionesBD();

            try
            {
                DateTime fechaInicio = Convert.ToDateTime(finicio);
                DateTime fechaFin = Convert.ToDateTime(ffin);

                bool inserto = reservaciones.InsertarReservacion(idInmueble, idUsuario, fechaInicio, fechaFin);

                return inserto;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

    }

}

