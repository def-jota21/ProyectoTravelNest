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
        }

    }

