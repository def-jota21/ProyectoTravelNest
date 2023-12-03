using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoTravelNest.pages
{
    public partial class eliminarCuentaMiBanco : System.Web.UI.Page
    {
        private static string token;
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                mibanco.mibanco mibanco  = new mibanco.mibanco();
                string[] datos = mibanco.listarDatos(eUsuarios.IdUsuario);
                string numeroCompleto = datos[3];
                string numeroOculto = new string('X', numeroCompleto.Length - 4) + numeroCompleto.Substring(numeroCompleto.Length - 4);
                txtcuenta.Text = numeroOculto;

                txtnombre.Text = datos[4] + " " + datos[5];
                string[] saldo = datos[6].Split('.');
                txtsaldo.Text = "$" + saldo[0];
            }
        }

        protected void btnEliminarMiBanco_Click(object sender, EventArgs e)
        {
            string numeroCuenta = txtNumeroCuenta.Text.Trim();

            if (numeroCuenta.Length != 16)
            {
                lblMensaje.Text = "El número de cuenta debe tener 16 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 13
            }
            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();

            string mensaje = neg_MiBanco.EliminarCuentaMiBanco(eUsuarios.IdUsuario, numeroCuenta);

            if (mensaje == "Exito")
            {
                
                var negocioUsuarios = new Neg_Usuarios();
                var negocioMiBanco = new Neg_MiBanco();
                // Generar un token aleatorio de 6 dígitos
                token = negocioUsuarios.GenerarToken();
                Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
                // Correo electrónico del destinatario
                string destinatario = neg_Inmueble.ObtenerCorreo(eUsuarios.IdUsuario);

                // Enviar el correo electrónico con el token
                negocioUsuarios.EnviarCorreoElectronico(destinatario, token);

                //string parametrosEncriptados = EncriptarParametros(numeroCuenta + "|" + token);
                //string parametrosEncriptadosUrl = HttpUtility.UrlEncode(parametrosEncriptados);

                //Response.Redirect("validartokenmibanco.aspx?parametros=" + parametrosEncriptadosUrl);

                Response.Redirect("tokeneliminarmibanco.aspx?parametro1=" + numeroCuenta + "&parametro2=" + token + "");

            }
            else
            {
                lblMensaje.Text = "La cuenta no esta la enlazada.";
                lblMensaje.ForeColor = mensaje.Contains("éxito") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMensaje.Visible = true;
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