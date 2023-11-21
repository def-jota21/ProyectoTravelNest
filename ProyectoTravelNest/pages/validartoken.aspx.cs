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
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class validartoken : System.Web.UI.Page
    {
        static string correo;
        static string contrasena;
        static string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            string parametrosEncriptados = Request.QueryString["parametros"];
            string parametrosDesencriptados = DesencriptarParametros(parametrosEncriptados);

            string[] parametros = parametrosDesencriptados.Split('|');
            correo = parametros[0];
            contrasena = parametros[1];
            token = parametros[2];

            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios != null)
            {
                Response.Redirect("Default.aspx");
            }

            //correo = Request.QueryString["parametro1"];
            //contrasena = Request.QueryString["parametro2"];
            //token = Request.QueryString["parametro3"];
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

            if(clave != null) { 
                
                if (clave == token) {
                    

                    // Instancia de la clase de negocios para verificar las credenciales
                    var negocioUsuarios = new Neg_Usuarios();
                    var usuario = negocioUsuarios.VerificarCredenciales(correo, contrasena);

                    if (usuario != null)
                    {
                        // Si el rol es A o H, inicia sesión
                        if (usuario.T_Rol == 'A' || usuario.T_Rol == 'H' || usuario.T_Rol == 'G')
                        {
                            token = "";
                            Session["IdUsuario"] = usuario;
                            FormsAuthentication.RedirectFromLoginPage(usuario.IdUsuario, false);
                            Response.Redirect("../Default.aspx"); // Redirige a la página de inicio

                        }
                        else
                        {
                            // Manejar roles no autorizados o mostrar mensaje
                        }
                    }
                }
            }
            
        }
    }
}