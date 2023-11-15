using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Neg_Usuarios
    {
        public Entidades.Usuarios VerificarCredenciales(string Correo, string Contrasena)
        {
            string spName = "SP_VerificarCredenciales";
            var lstParametros = new List<SqlParameter>()
    {
        new SqlParameter("@Correo", Correo),
        new SqlParameter("@Contrasena", Contrasena) // Asegúrate de que estás haciendo hash y comparando el hash si es necesario
    };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            DataTable dtDatos = iConexion.ExecuteSPWithDT(spName, lstParametros);
            Entidades.Usuarios iUsuarios = null;
            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                iUsuarios = new Entidades.Usuarios()
                {
                    IdUsuario = Convert.ToInt32(dtDatos.Rows[0]["idUsuario"]),
                    T_Rol = Convert.ToChar(dtDatos.Rows[0]["T_Rol"]) // Añade esta línea para obtener el rol del usuario
                                                                     // Asegúrate de que el índice de la columna es correcto y que el campo existe en el DataTable
                };
            }
            return iUsuarios;
        }


        public void AgregarUsuario(Entidades.Usuarios Usuario, int Accion)
        {
            try
            {
                string strNombreSP = "CRUDUsuarios";
                SqlParameter parametroImagen = new SqlParameter("@FotoPerfil", SqlDbType.Image);
                parametroImagen.Value = Usuario.ImagenPerfil;
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", Accion));
                lstParametros.Add(new SqlParameter("@Identificacion", Usuario.IdUsuarioRegistro));
                lstParametros.Add(new SqlParameter("@Nombre", Usuario.Nombre));
                lstParametros.Add(new SqlParameter("@Apellidos", Usuario.Apellidos));
                lstParametros.Add(new SqlParameter("@Rol", Usuario.T_Rol));
                lstParametros.Add(new SqlParameter("@Telefono",Usuario.Telefono));
                lstParametros.Add(new SqlParameter("@CorreoElectronico", Usuario.Correo));
                lstParametros.Add(new SqlParameter("@Contrasena", Usuario.Contrasena));
                lstParametros.Add(parametroImagen);
                lstParametros.Add(new SqlParameter("@Estado", "Activo"));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//fin de agregar usuario

        public void EditarUsuario(Entidades.Usuarios Usuario, int Accion)
        {
            try
            {
                string strNombreSP = "CRUDUsuarios";
        
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", Accion));
                lstParametros.Add(new SqlParameter("@Identificacion", Usuario.IdUsuarioRegistro));
                lstParametros.Add(new SqlParameter("@Nombre", Usuario.Nombre));
                lstParametros.Add(new SqlParameter("@Apellidos", Usuario.Apellidos));
                lstParametros.Add(new SqlParameter("@Telefono", Usuario.Telefono));
                lstParametros.Add(new SqlParameter("@CorreoElectronico", Usuario.Correo));
                lstParametros.Add(new SqlParameter("@Estado", Usuario.Estado));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//fin de agregar usuario

        public static void VerificarConexion()
        {
            try
            {
                Datos.ConexionSQL.CadenaConexion();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }//fin de agregar usuario
        public DataTable ListarUsuarios(int Accion)
        {
            try
            {
                DataTable dt = new DataTable();
                
                string strNombreSP = "CRUDUsuarios";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", Accion));

                dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);


                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            

        }

        public DataTable ListarUsuarioSeleccionado(int Accion, string idUsuario)
        {
            try
            {
                DataTable dt = new DataTable();

                string strNombreSP = "CRUDUsuarios";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", Accion));
                lstParametros.Add(new SqlParameter("@Identificacion",idUsuario));

                dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);


                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }//fin de agregar usuario


        // ENVIO DE CORREO Y VALIDACION
        public string GenerarToken()
        {
            // Utilizar un generador de números aleatorios para crear un token de 6 dígitos
            Random random = new Random();
            int tokenValue = random.Next(100000, 999999);

            // Convertir el valor a cadena y devolverlo
            return tokenValue.ToString();
        }

        public void EnviarCorreoElectronico(string destinatario, string token)
        {
            // Configuración del cliente SMTP
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587; // Puerto SMTP
                smtpClient.Credentials = new NetworkCredential("josejulianrm8@gmail.com", "idmv fiaf tvgq lqqb"); // Autenticación del servidor SMTP
                smtpClient.EnableSsl = true; // Habilitar SSL si es necesario

                // Crear el mensaje de correo electrónico
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("josejulianrm8@gmail.com"); // Dirección de correo electrónico del remitente
                    mailMessage.To.Add(destinatario); // Dirección de correo electrónico del destinatario
                    mailMessage.Subject = "Código de verificación"; // Asunto del correo electrónico
                    mailMessage.Body = $"Tu código de verificación es: {token}"; // Cuerpo del correo electrónico

                    // Enviar el correo electrónico
                    smtpClient.Send(mailMessage);
                }
            }
        }
        //FIN ENVIO DE CORREO Y VALIDACION



        //Metodos obtener notificaciones
        public int ObtenerNotificaciones(string idUsuario)
        {
            Datos.NotificacionesSQL notificacionesSQL = new NotificacionesSQL();
            int mensajes = notificacionesSQL.ObtenerCantidadComentariosNotificacion(idUsuario);
            return mensajes;
        }

        //Fin metodos obtener notificaciones
    }
}