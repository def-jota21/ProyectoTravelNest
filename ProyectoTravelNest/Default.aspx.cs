using Entidades;
using Negocios;
using ProyectoTravelNest.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProyectoTravelNest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void AgregarFavorito_Click(object sender, EventArgs e)
        {

            // Obtener el idInmueble del botón "Favorito"
            LinkButton lnkFavorito = (LinkButton)sender;
            string idInmueble = lnkFavorito.Attributes["data-idinmueble"];

            // Asignar un valor fijo para idUsuario (esto debe ser reemplazado por autenticación)
            string IdUsuario = "1";

            // Obtener los valores de los controles en tu página

            // Almacenar los valores en variables de sesión
            Session["IdInmueble"] = idInmueble;


            // Llamar a la función AgregarFavorito
            Neg_Favoritos.AgregarFavorito(IdUsuario, idInmueble);


            // Puedes redirigir al usuario a la página de resultados u otra página
            Response.Redirect("Default.aspx");

        }
    

        
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {
                string Correo = txtCorreo.Text;
                string Contrasena = txtcontrasena.Text;
                var warningss = new List<string>();
                bool entrar = false;
                string regexEmail = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
                Regex regex = new Regex(regexEmail);

                if (string.IsNullOrWhiteSpace(Correo))
                {
                    warningss.Add("El correo es requerido");
                    entrar = true;
                }

                if (!regex.IsMatch(Correo))
                {
                    warningss.Add("El email no es válido");
                    entrar = true;
                }

                if (string.IsNullOrWhiteSpace(Contrasena))
                {
                    warningss.Add("La contraseña es necesaria");
                    entrar = true;
                }

                if (entrar)
                {
                    // Muestra los mensajes de error en un control de la página o utiliza Toastr.
                    script = "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                             "toastr.error('" + string.Join("<br>", warningss) + "');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {
                    if (Page.IsValid)
                    {
                        // Llama a la capa de negocios para verificar las credenciales
                        Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();
                        Entidades.Usuarios iCredenciales = iUsuarios.VerificarCredenciales(Correo, Contrasena);

                        if (iCredenciales != null)
                        {
                            Session["Credenciales"] = iCredenciales;

                            //Variable session para el manejo de permisos de invitado
                            //if (iCredenciales.Rol == "Invitado")
                            //{
                            //    Session["IsDropDownEventExecuted"] = true;
                            //}

                            // Aquí puedes enviar el token de verificación por correo si es necesario.

                            // Redireccionar a la página de validación de token o a donde sea necesario.
                            Response.Redirect("pages/SegundoFactorAuten.aspx");
                            //Response.Redirect("pages/ControlPanel.aspx");
                        }
                        else
                        {
                            script = @"Swal.fire({
                        title: '¡Error!',
                        text: 'Correo/Contraseña incorrectos',
                        icon: 'error'
                    });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                            txtCorreo.Text = "";
                            txtcontrasena.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                script = "toastr.warning('Ha ocurrido un error, inténtelo más tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
    }
}  
