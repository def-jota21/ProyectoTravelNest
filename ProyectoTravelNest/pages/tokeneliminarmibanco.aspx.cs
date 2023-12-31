﻿using Negocios;
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
    public partial class tokeneliminarmibanco : System.Web.UI.Page
    {
        static string numero_cuenta;
        static string token;
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
                //numero_cuenta = Request.QueryString["parametro1"];
                //token = Request.QueryString["parametro2"];
                string parametrosEncriptados = Request.QueryString["parametros"];
                string parametrosDesencriptados = DesencriptarParametros(parametrosEncriptados);

                string[] parametros = parametrosDesencriptados.Split('|');
                numero_cuenta = parametros[0];
                token = parametros[1];
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
            Negocios.Neg_MiBanco neg_MiBanco = new Neg_MiBanco();
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
                        string mensaje2 = neg_MiBanco.EliminarCuentaMiBanco2(eUsuarios.IdUsuario, numero_cuenta);


                        if (mensaje2 == "Exito")
                        {
                            string script = "Swal.fire('¡Éxito!', 'Se elimino correctamente.', 'success');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                            Response.Redirect("panelanfitrion.aspx");
                        }

                    }
                    if (eUsuarios.T_Rol == 'H')
                    {
                        token = "";
                        string mensaje2 = neg_MiBanco.EliminarCuentaMiBanco2(eUsuarios.IdUsuario, numero_cuenta);


                        if (mensaje2 == "Exito")
                        {
                            string script = "Swal.fire('¡Éxito!', 'Se elimino correctamente.', 'success');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                            Response.Redirect("paneladministracionhuesped.aspx");
                        }
                        

                    }
                }
            }

        }
    }
}