using System;

namespace Entidades
{
    public class Reservaciones
    {
       
            public int IdReservacion { get; set; }
            public string IdInmueble { get; set; }
            public string IdUsuario { get; set; }
            public DateTime F_Inicio { get; set; }
            public DateTime F_Fin { get; set; }
            public string Estado { get; set; }
        }
    }

