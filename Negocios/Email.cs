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

        public void EnviarEmail(string idReceptor, string asunto, string Emisor)
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
                body = body.Replace("{NombreEmisor}", Emisor);

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
