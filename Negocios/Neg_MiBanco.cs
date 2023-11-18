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
            string mensaje = "";
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();
            
            mibanconeg.mibanco iBanco = new mibanconeg.mibanco();

            if (iBanco.ValidarExistencia(NumeroCuenta, cvv))
            {
                mensaje = miBancoSQL.InsertarUsuarioMiBanco(IdUsuario, NumeroCuenta, cvv);
            }
            else
            {
                mensaje = "La cuenta digítada no existe, registrese en MiBanco";
            }

            
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
