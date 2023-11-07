using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class AjustarReserva
    {
        public int IdAjustarReserva { get; set; }
        public string Tiempo_EstadiaMinima { get; set; }
        public string Tiempo_EstadiaMaxima { get; set; }
        public string Tiempo_ReservaMinima { get; set; }
        public string Tiempo_ReservaMaxima { get; set; }
        public string IdInmueble { get; set; }
    }

}
