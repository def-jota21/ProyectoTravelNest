using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inmueble
    {
        public string IdInmueble { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Calificacion { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
