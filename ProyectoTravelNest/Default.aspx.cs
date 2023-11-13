using Entidades;
using Negocios;
using ProyectoTravelNest.pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            if (!IsPostBack)
            {

                Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                DataTable dtInmbuebles = new DataTable();
                dtInmbuebles = iInmueble.ListarInmueblesPrincipal();

                rptInmuebles.DataSource = dtInmbuebles;
                rptInmuebles.DataBind();
                CargarCategorias();

            }
        }

        private void CargarCategorias()
        {
            // Crea una instancia de la clase de negocio
            Neg_filtrarcategorias negocio = new Neg_filtrarcategorias();

            // Obtén los datos de la base de datos
            DataTable dt = negocio.ObtenerTodasLasCategorias();

            ddlCategorias.Items.Clear();
            ddlCantidadPersonas.Items.Clear();
            ddlCalificacion.Items.Clear();

            // Agrega elementos predeterminados a los controles select
            ddlCategorias.Items.Add(new ListItem("Tipo de Alojamiento", ""));
            ddlCantidadPersonas.Items.Add(new ListItem("Cantidad de Personas", ""));
            ddlCalificacion.Items.Add(new ListItem("Calificación", ""));

            // Agrega los datos a los controles select
            foreach (DataRow row in dt.Rows)
            {
                // Obtén la información de la fila
                string nombreCategoria = row["Nombre"].ToString();
                string idCategoria = row["IdCategoria"].ToString();
                string cantidadHuesped = row["Cantidad_Huesped"].ToString();
                string calificacion = row["Calificacion"].ToString();

                // Agrega la información a los controles select
                ddlCategorias.Items.Add(new ListItem(nombreCategoria, idCategoria));
                ddlCantidadPersonas.Items.Add(new ListItem(cantidadHuesped, cantidadHuesped));
                ddlCalificacion.Items.Add(new ListItem(calificacion, calificacion));
            }
        }






        protected void AgregarFavorito_Click(object sender, EventArgs e)
        {

            // Obtener el idInmueble del botón "Favorito"
            LinkButton lnkFavorito = (LinkButton)sender;
            string idInmueble = lnkFavorito.Attributes["data-idinmueble"];

            // Asignar un valor fijo para idUsuario (esto debe ser reemplazado por autenticación)
            string IdUsuario = "2222222222";

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
        }//fin de iniciar sesion


        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            char tRol = 'a';
            String Nombre = txtNombre.Text;
            String Rol = ddlRol.SelectedValue.ToString();
            String Apellidos = txtApellidos.Text;
            String Telefono = txtTelefono.Text;
            String CorreoElectronico = txtCorreoElectronico.Text;
            String Identificacion = txtIdentificacion.Text;
            String Contrasena = txtcontrasenaCrear.Text;
            //int Tamanio = fileImagen.PostedFile.ContentLength;
            byte[] ImagenOriginal;
            ImagenOriginal = new byte[0];

            if (fileImagen.HasFile)
            {
                Stream fs = fileImagen.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                ImagenOriginal = br.ReadBytes((Int32)fs.Length);
            }

            Entidades.Usuarios iUsuario = new Entidades.Usuarios();

            iUsuario.Nombre = Nombre;
            if(Rol.Equals("Anfitrión"))
            {
                tRol = 'A';
            }
            if (Rol.Equals("Huésped"))
            {
               tRol = 'H';
            }

            iUsuario.T_Rol = tRol;
            iUsuario.Apellidos = Apellidos;
            iUsuario.Telefono = int.Parse(Telefono);
            iUsuario.Correo = CorreoElectronico;
            iUsuario.IdUsuarioRegistro = Identificacion;
            iUsuario.Contrasena = Contrasena;
            iUsuario.ImagenPerfil = ImagenOriginal;

            Negocios.Neg_Usuarios iUsuariosNeg = new Neg_Usuarios();

            iUsuariosNeg.AgregarUsuario(iUsuario, 1);
        }



        protected void btnVerInformacion_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "VerInformacion")
            {
                string[] args = e.CommandArgument.ToString().Split(',');

                if (args.Length == 2)
                {
                    string IdUsuario = args[0].Trim();
                    string IdInmueble = args[1].Trim();

                    // Redirige a la página de destino con los parámetros
                    Response.Redirect($"pages/verinformacion.aspx?IdUsuario={IdUsuario}&IdInmueble={IdInmueble}");
                }
            }
        }

    }

}  
