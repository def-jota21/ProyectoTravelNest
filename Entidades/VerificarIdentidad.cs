using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VerificarIdentidad
    {
        public string IdIdentidad { get; set; }
        public string IdUsuario { get; set; }
        public byte[] Documento { get; set; }
        public byte[] Rostro { get; set; }
        public string Estado { get; set; }
    }
}
