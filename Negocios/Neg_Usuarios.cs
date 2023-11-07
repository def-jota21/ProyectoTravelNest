using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Neg_Usuarios
    {
        public Entidades.Usuarios VerificarCredenciales(string Correo, string Contrasena)
        {
            string spName = "ObtenerCredenciales";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@Correo", Correo),
                new SqlParameter("@Contrasena",Contrasena)
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            DataTable dtDatos = iConexion.ExecuteSPWithDT(spName, lstParametros);
            Entidades.Usuarios iUsuarios = null;
            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                iUsuarios = new Entidades.Usuarios()
                {
                    IdUsuario = Convert.ToInt32(dtDatos.Rows[0]["idUsuario"]),
                };
            }
            return iUsuarios;

        }

    }
}