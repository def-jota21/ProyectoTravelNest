using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace ProyectoTravelNest.pages
{
    public partial class login : System.Web.UI.Page
    {
        private static string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios != null)
            {
                Response.Redirect("Default.aspx");
            }
        }


        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            string correo = txtCorreo.Text;
            string contrasena = txtcontrasena.Text;

            // Instancia de la clase de negocios para verificar las credenciales
            var negocioUsuarios = new Neg_Usuarios();
            var usuario = negocioUsuarios.VerificarCredenciales(correo, contrasena);

            if (usuario != null)
            {

                // Generar un token aleatorio de 6 dígitos
                token = negocioUsuarios.GenerarToken();

                // Correo electrónico del destinatario
                string destinatario = correo;

                // Enviar el correo electrónico con el token
                negocioUsuarios.EnviarCorreoElectronico(destinatario, token);

                //string parametrosEncriptados = EncriptarParametros(correo + "|" + contrasena + "|" + token);
                //string parametrosEncriptadosUrl = HttpUtility.UrlEncode(parametrosEncriptados);

                //Response.Redirect("validartoken.aspx?parametros=" + parametrosEncriptadosUrl);

                Response.Redirect("validartoken.aspx?parametro1=" + correo + "&parametro2=" + contrasena + "&parametro3=" + token + "");
            }
        }

        private string EncriptarParametros(string parametros)
        {
            string clave = "c0ntr4s3n14S3gUr4*";

            // Asegúrate de que la clave tenga un tamaño válido para AES (128, 192 o 256 bits)
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            Array.Resize(ref claveBytes, 32); // Ajusta la longitud a 256 bits (32 bytes)

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = claveBytes;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(parametros);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

    }
}