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


        

        public void enviarCorreo(string IdUsuario, decimal PrecioTotal)
        {
            DataTable dt = new DataTable();
            DataTable dtReserva = new DataTable();
            string destinatario;
            try
            {
                string strNombreSP = "CRUDUsuarios";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Opcion", 4));
                lstParametros.Add(new SqlParameter("@Identificacion", IdUsuario));
                dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
                destinatario = dt.Rows[0]["Correo"].ToString();

                lstParametros.Clear();
                strNombreSP = "GetInfoReserva";
                lstParametros.Add(new SqlParameter("@IdUsuario", IdUsuario));
                dtReserva = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            Negocios.Email email = new Negocios.Email();
            String correoHuesped = cambioParametros(email.getReservaHuesped(), PrecioTotal, dt, dtReserva);
            String correoAnfitrion = cambioParametros(email.getReservaAnfitrion(), PrecioTotal, dt, dtReserva);

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
                    mailMessage.Body = @"
                                        <html>
                                            <head>
                                                <style>
                                                    @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');
                                                    .poppins-text {
                                                        font - family: 'Poppins', sans-serif;
                                                        color: black;
                                                    }
                                                    .im{
                                                        color: black;
                                                    }
                                                </style>
                                            </head>
                                            <body>
                                                <div style='text-align:center'>
                                                    <img src='cid:imagen' style='width:200px;height:auto'/>
                                                    <h1 class='poppins-text' style='font-weight:bold'>¡Gracias por su compra!</h1>
                                                    <p class='poppins-text'>" + correoHuesped +
                                                    @"</p>
                                                </div>
                                            </body>
                                            </html>";
                    smtpClient.Send(mailMessage);
                    // Correo para el anfitrión
                    mailMessage.From = new MailAddress("josejulianrm8@gmail.com");
                    mailMessage.To.Add(dtReserva.Rows[0]["AnfitrionCorreo"].ToString());
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = $"Han realizado una reservación en {dtReserva.Rows[0]["Nombre"].ToString()}";
                    mailMessage.Body = @"
                                        <html>
                                            <head>
                                                <style>
                                                    @import url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');
                                                    .poppins-text {
                                                        font - family: 'Poppins', sans-serif;
                                                        color: black;
                                                    }
                                                    .im{
                                                        color: black;
                                                    }
                                                </style>
                                            </head>
                                            <body>
                                                <div style='text-align:center'>
                                                    <img src='cid:imagen' style='width:200px;height:auto'/>
                                                    <h1 class='poppins-text' style='font-weight:bold'>¡Un huésped ha realizado una reservación!</h1>
                                                    <p class='poppins-text'>" + correoAnfitrion +
                                                    @"</p>
                                                </div>
                                            </body>
                                            </html>";
                    smtpClient.Send(mailMessage);
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

        private String cambioParametros(String mensaje, Decimal PrecioTotal, DataTable dt, DataTable dtReserva)
        {
            mensaje = mensaje.Replace("{HuespedNombre}", dt.Rows[0]["Nombre"].ToString())
                             .Replace("{HuespedApellidos}", dt.Rows[0]["Apellidos"].ToString())
                             .Replace("{HuespedCorreo}", dt.Rows[0]["Correo"].ToString())
                             .Replace("{HuespedTelefono}", dt.Rows[0]["Telefono"].ToString())
                             .Replace("{AnfitrionNombre}", dtReserva.Rows[0]["AnfitrionNombre"].ToString())
                             .Replace("{AnfitrionApellidos}", dtReserva.Rows[0]["AnfitrionApellidos"].ToString())
                             .Replace("{AnfitrionTelefono}", dtReserva.Rows[0]["Telefono"].ToString())
                             .Replace("{AnfitrionCorreo}", dtReserva.Rows[0]["AnfitrionCorreo"].ToString())
                             .Replace("{NombreReservacion}", dtReserva.Rows[0]["Nombre"].ToString())
                             .Replace("{ReservaPrecioTotal}", PrecioTotal.ToString("N2"))
                             .Replace("{ReservaInicio}", dtReserva.Rows[0]["FechaInicio"].ToString())
                             .Replace("{ReservaFin}", dtReserva.Rows[0]["FechaFin"].ToString())
                             .Replace("\n", "<br/>");
            return mensaje;
        }
    }
}
         
