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

        public void AgregarUsuario(Entidades.Usuarios Usuario, int Accion)
        {
            try
            {
                string strNombreSP = "CRUDUsuarios";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", Accion));
                lstParametros.Add(new SqlParameter("@Identificacion", Usuario.IdUsuarioRegistro));
                lstParametros.Add(new SqlParameter("@Nombre", Usuario.Nombre));
                lstParametros.Add(new SqlParameter("@Apellidos", Usuario.Apellidos));
                lstParametros.Add(new SqlParameter("@Rol", Usuario.T_Rol));
                lstParametros.Add(new SqlParameter("@Telefono",Usuario.TelefonoRegistro));
                lstParametros.Add(new SqlParameter("@CorreoElectronico", Usuario.Correo));
                lstParametros.Add(new SqlParameter("@Contrasena", Usuario.Contrasena));
                lstParametros.Add(new SqlParameter("@FotoPerfil", Usuario.ÏmagenPerfil));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//fin de agregar usuario
    }
}