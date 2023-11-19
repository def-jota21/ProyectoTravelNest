using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
    public class Neg_Reservaciones
    {
       
        Datos.ReservacionesBD datosReservaciones = new Datos.ReservacionesBD();

        public Reservaciones ObtenerReservacionRecientePorUsuario(string IdUsuario)
        {
            return datosReservaciones.ObtenerReservacionRecientePorUsuario(IdUsuario);
        }


        public List<Reservaciones> ObtenerTodasLasReservacionesPorUsuario(string IdUsuario)
        {
            return datosReservaciones.ObtenerTodasLasReservacionesPorUsuario(IdUsuario);
        }

        private void enviarCorreo(string IdUsuario)
        {
            DataTable dt = new DataTable();
            DataTable dtReserva = new DataTable();
            String destinatario = "";
            try
            {
                string strNombreSP = "CRUDUsuarios";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", 4));
                lstParametros.Add(new SqlParameter("@Identificacion", IdUsuario));
                dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
                destinatario = dt.Rows[0]["Correo"].ToString();

                lstParametros.Clear();
                strNombreSP = "CRUDUsuarios";
                lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
                dtReserva = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
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
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = $"Reserva realizada: {dtReserva.Rows[0]["Nombre"].ToString()}"; // Asunto del correo electrónico
                    mailMessage.Body = $@"
                                        <html>
                                        <body>
                                            <div style='text-align:center'>
                                                <img src='cid:imagen' style='width:200px;height:auto'/> <!-- Reemplaza 'cid:imagen' con el ContentId de la imagen -->
                                                <h1 style='font-family:Poppins;font-weight:bold'>¡Gracias por su compra!</h1>
                                                <p style='font-family:Poppins'>
                                                    Estimado/a {dt.Rows[0]["Nombre"].ToString() + ' ' + dt.Rows[0]["Apellidos"].ToString()},

                                                    Le agradecemos por elegir nuestro servicio TravelNest para su reserva. Estamos encantados de confirmar que su reserva, {dtReserva.Rows[0]["Nombre"].ToString()}, está programada desde el {dtReserva.Rows[0]["FechaInicio"].ToString()} hasta el {dtReserva.Rows[0]["FechaFin"].ToString()}.

                                                    El monto total a pagar por su reserva es {dtReserva.Rows[0]["Precio"].ToString()}. Nuestra meta es brindarle la mejor experiencia durante su alojamiento.

                                                    Si requiere más información o asistencia adicional, puede contactar al anfitrión al siguiente número: {dtReserva.Rows[0]["Telefono"].ToString()}.

                                                    Atentamente,
                                                    {dtReserva.Rows[0]["Anfitrion"].ToString()}
                                                </p>
                                            </div>
                                        </body>
                                        </html>";
                    // Agregar la imagen como un recurso vinculado
                    LinkedResource linkedResource = new LinkedResource("/pages/logo2.png", "image/jpeg");
                    linkedResource.ContentId = "imagen";
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMessage.Body, null, "text/html");
                    htmlView.LinkedResources.Add(linkedResource);
                    mailMessage.AlternateViews.Add(htmlView);

                    // Enviar el correo electrónico
                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}
         

        public bool InsertarReservacion(string idInmueble, string idUsuario, string finicio, string ffin)
        {
            Datos.ReservacionesBD reservaciones = new Datos.ReservacionesBD();

            try
            {
                DateTime fechaInicio = Convert.ToDateTime(finicio);
                DateTime fechaFin = Convert.ToDateTime(ffin);

                bool inserto = reservaciones.InsertarReservacion(idInmueble, idUsuario, fechaInicio, fechaFin);

                return inserto;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

    }

}

