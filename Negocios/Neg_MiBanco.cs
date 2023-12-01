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
        public string InsertarCuentaMiBanco(string IdUsuario, string NumeroCuenta, string cvv, string t_rol)
        {
            string mensaje = "";
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();
            
            mibanconeg.mibanco iBanco = new mibanconeg.mibanco();

            if (iBanco.ValidarExistencia(NumeroCuenta, cvv, t_rol))
            {
                mensaje = miBancoSQL.InsertarUsuarioMiBanco(IdUsuario, NumeroCuenta, cvv);
            }
            else
            {
                mensaje = "La cuenta digítada no existe, registrese en MiBanco";
            }


            return mensaje;
        }
        public bool ValidarExistenciaEnMiBanco(string IdUsuario, string NumeroCuenta, string cvv, string t_rol)
        {
            bool mensaje = false;
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();

            mibanconeg.mibanco iBanco = new mibanconeg.mibanco();

            if (iBanco.ValidarExistencia(NumeroCuenta, cvv, IdUsuario))
            {
                mensaje = true;
            }
            return mensaje;
        }
        public string EliminarCuentaMiBanco(string IdUsuario, string idCuenta)
        {
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();

            string mensaje = miBancoSQL.EliminarUsuarioMiBanco(IdUsuario, idCuenta);
            return mensaje;
        }

        public string EliminarCuentaMiBanco2(string IdUsuario, string idCuenta)
        {
            Datos.MiBancoSQL miBancoSQL = new MiBancoSQL();

            string mensaje = miBancoSQL.EliminarUsuarioMiBanco2(IdUsuario, idCuenta);
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
