using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class AgregarMiBanco : System.Web.UI.Page
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

            }
        }

        protected void btnGuardarMiBanco_Click(object sender, EventArgs e)
        {

            string numeroCuenta = txtNumeroCuenta.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            // Validación: Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(numeroCuenta) || string.IsNullOrEmpty(cvv))
            {
                lblMensaje.Text = "Ambos campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si hay campos vacíos
            }

            // Validación: Verificar la longitud de número de cuenta y CVV
            if (numeroCuenta.Length != 16)
            {
                lblMensaje.Text = "El número de cuenta debe tener 16 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 13
            }

            if (cvv.Length != 3)
            {
                lblMensaje.Text = "El CVV debe tener 3 dígitos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return; // Sale del evento si la longitud no es 3
            }

            var negocioUsuarios = new Neg_Usuarios();
            var negocioMiBanco = new Neg_MiBanco();
            bool usuario = negocioMiBanco.VerificarMiBanco(numeroCuenta);

            if (usuario)
            {
                lblMensaje.Text = "La cuenta ya esta enlazada en otra cuenta.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return;
            }
            bool existe = negocioMiBanco.ValidarExistenciaEnMiBanco(eUsuarios.IdUsuario, numeroCuenta, cvv, "");
            if (existe)
            {

                // Generar un token aleatorio de 6 dígitos
                token = negocioUsuarios.GenerarToken();
                Neg_Inmueble neg_Inmueble = new Neg_Inmueble();
                // Correo electrónico del destinatario
                string destinatario = neg_Inmueble.ObtenerCorreo(eUsuarios.IdUsuario);

                // Enviar el correo electrónico con el token
                negocioUsuarios.EnviarCorreoElectronico(destinatario, token);

                //string parametrosEncriptados = EncriptarParametros(correo + "|" + contrasena + "|" + token);
                //string parametrosEncriptadosUrl = HttpUtility.UrlEncode(parametrosEncriptados);

                //Response.Redirect("validartoken.aspx?parametros=" + parametrosEncriptadosUrl);

                Response.Redirect("validartokenmibanco.aspx?parametro1="+numeroCuenta+"&parametro2="+cvv+"&parametro3="+token+"");
            }

            else
            {
                string script = "Swal.fire('¡Error!', 'Los datos no coinciden', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
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