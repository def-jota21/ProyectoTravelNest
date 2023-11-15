using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocios
{
    public class Neg_MiBanco
    {
        public string InsertarCuentaMiBanco(string IdUsuario, string NumeroCuenta, string cvv)
        {
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();

            string mensaje = miBancoSQL.InsertarUsuarioMiBanco(IdUsuario, NumeroCuenta, cvv);
            return mensaje;
        }

        public string EliminarCuentaMiBanco(string IdUsuario)
        {
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();

            string mensaje = miBancoSQL.EliminarUsuarioMiBanco(IdUsuario);
            return mensaje;
        }

        public bool VerificarMiBanco(string IdUsuario)
        {
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();
            bool Usuario = miBancoSQL.ExisteUsuarioMiBanco(IdUsuario);
            return Usuario;
        }
    }
}
