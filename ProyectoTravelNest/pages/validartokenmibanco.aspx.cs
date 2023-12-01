using Negocios;
using System;
using System.Collections.Generic;
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
    public partial class validartokenmibanco : System.Web.UI.Page
    {
        static string numero_cuenta;
        static string cvv;
        static string token;
        Entidades.Usuarios eUsuarios = new Entidades.Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string parametrosEncriptados = Request.QueryString["parametros"];
            //string parametrosDesencriptados = DesencriptarParametros(parametrosEncriptados);

            //string[] parametros = parametrosDesencriptados.Split('|');
            //numero_cuenta = parametros[0];
            //cvv = parametros[1];
            //token = parametros[2];

            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack & eUsuarios != null)
            {
                numero_cuenta = Request.QueryString["parametro1"];
                cvv = Request.QueryString["parametro2"];
                token = Request.QueryString["parametro3"];
            }
        }
        private string DesencriptarParametros(string parametrosEncriptados)
        {
            string clave = "c0ntr4s3n14S3gUr4*";

            // Ajusta la longitud de la clave a 256 bits (32 bytes)
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            Array.Resize(ref claveBytes, 32);

            // Elimina caracteres no válidos de la cadena encriptada
            parametrosEncriptados = parametrosEncriptados.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = claveBytes;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                try
                {
                    // Verificar si la cadena encriptada tiene una longitud válida para Base64
                    if (parametrosEncriptados.Length % 4 == 0)
                    {
                        // Decodificar desde Base64
                        byte[] bytes = Convert.FromBase64String(parametrosEncriptados);

                        using (MemoryStream msDecrypt = new MemoryStream(bytes))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {
                                    return srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Longitud de cadena encriptada no válida para Base64");
                        return string.Empty; // o manejar de otra forma el error, dependiendo de tus necesidades
                    }
                }
                catch (FormatException ex)
                {
                    // Manejar la excepción (puedes imprimir información de depuración)
                    Console.WriteLine("Error al decodificar desde Base64: " + ex.Message);
                    return string.Empty; // o manejar de otra forma el error, dependiendo de tus necesidades
                }
            }
        }

        protected void btnValidarToken_Click(object sender, EventArgs e)
        {
            string clave = txtToken.Text;
            string mensaje = "";
            if (clave != null)
            {

                if (clave == token)
                {

                    // Si el rol es A o H
                    if (eUsuarios.T_Rol == 'A')
                    {
                        token = "";
                        Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
                        mensaje = neg_MiBanco.InsertarCuentaMiBanco(eUsuarios.IdUsuario, numero_cuenta, cvv, eUsuarios.T_Rol.ToString());
                        Response.Redirect("panelanfitrion.aspx");

                    }
                    if (eUsuarios.T_Rol == 'H')
                    {
                        token = "";
                        Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
                        mensaje = neg_MiBanco.InsertarCuentaMiBanco(eUsuarios.IdUsuario, numero_cuenta, cvv, eUsuarios.T_Rol.ToString());
                        Response.Redirect("paneladministracionhuesped.aspx");

                    }
                }
            }

        }
    }
}
