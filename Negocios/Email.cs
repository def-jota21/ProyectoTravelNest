using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Services.Description;

namespace Negocios
{
    public class Email
    {
        private string body;
        private MensajeriaBD DataMensajeria = new MensajeriaBD();

        private string GetReceiverEmail(string idReceptor)
        {
            return DataMensajeria.GetReceiverEmail(idReceptor);
        }

        private string GetDenuncianteID(string idDenuncia)
        {
            return DataMensajeria.GetDenuncianteID(idDenuncia);
        }

        public void EnviarEmail(string idReceptor, string asunto)
        {
            try
            {
                string correoDestino = GetReceiverEmail(idReceptor);

                // Ajustes de credenciales y envíos de email
                var fromAddress = new MailAddress(ConfigurationManager.AppSettings["fromEmail"], ConfigurationManager.AppSettings["DisplayName"]);
                var toAddress = new MailAddress(correoDestino, "TravelNest");

                string fromPassword = ConfigurationManager.AppSettings["fromEmailPass"];

                // Se agrega el título de la finalidad del correo
                string subject = asunto;

                // Obtener la ruta del proyecto para buscar la plantilla 
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;

                // Cargar la plantilla HTML y reemplazar las variables con los valores adecuados
                string templatePath = Path.Combine(rootPath, "Plantillas", "Plantilla_Chat.html");
                body = File.ReadAllText(templatePath);

                var smtp = new SmtpClient
                {
                    Host = "smtp.titan.email",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Esto permite que el cuerpo del correo se interprete como HTML
                })
                {
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el email" + ex.Message);
            }
        }

        public string getReservaHuesped()
        {
            string strNombreSP = "CRUDConfigCorreo";
            List<SqlParameter> lstParametros = new List<SqlParameter>
            {
                new SqlParameter("@Opcion", "getReservaHuesped")
            };
            return ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros).Rows[0][0].ToString();
        }
        public string getReservaAnfitrion()
        {
            string strNombreSP = "CRUDConfigCorreo";
            List<SqlParameter> lstParametros = new List<SqlParameter>
            {
                new SqlParameter("@Opcion", "getReservaAnfitrion")
            };
            return ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros).Rows[0][0].ToString();
        }
        public void setReservaHuesped(String mensaje)
        {
            try
            {
                string strNombreSP = "CRUDConfigCorreo";
                List<SqlParameter> lstParametros = new List<SqlParameter>
                {
                    new SqlParameter("@Opcion", "setReservaHuesped"),
                    new SqlParameter("@MensajeA_Huesped", mensaje)
                };
                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setReservaAnfitrion(String mensaje)
        {
            try
            {
                string strNombreSP = "CRUDConfigCorreo";
                List<SqlParameter> lstParametros = new List<SqlParameter>
                {
                    new SqlParameter("@Opcion", "setReservaAnfitrion"),
                    new SqlParameter("@MensajeA_Anfitrion", mensaje)
                };
                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarEmailDenuncia(string idReceptor, string asunto)
        {
            try
            {
                string correoDestino = GetDenuncianteID(idReceptor);

                // Ajustes de credenciales y envíos de email
                var fromAddress = new MailAddress(ConfigurationManager.AppSettings["fromEmail"], ConfigurationManager.AppSettings["DisplayName"]);
                var toAddress = new MailAddress(correoDestino, "TravelNest - Denuncias");

                string fromPassword = ConfigurationManager.AppSettings["fromEmailPass"];

                // Se agrega el título de la finalidad del correo
                string subject = asunto;

                // Obtener la ruta del proyecto para buscar la plantilla 
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;

                // Cargar la plantilla HTML y reemplazar las variables con los valores adecuados
                string templatePath = Path.Combine(rootPath, "Plantillas", "Plantilla_Notificacion.html");
                body = File.ReadAllText(templatePath);

                var smtp = new SmtpClient
                {
                    Host = "smtp.titan.email",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Esto permite que el cuerpo del correo se interprete como HTML
                })
                {
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el email" + ex.Message);
            }
        }



    }
}

