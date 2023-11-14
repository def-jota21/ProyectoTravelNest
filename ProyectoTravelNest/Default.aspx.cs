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
        Neg_Favoritos iFavoritos = new Neg_Favoritos();
        Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                rptInmuebles.DataSource = CargarTarjetas();
                rptInmuebles.DataBind();
                CargarCategorias();


            }
        }

        private DataTable CargarTarjetas()
        {
            DataTable dtInmbuebles = iInmueble.ListarInmueblesPrincipal();
            return dtInmbuebles;
        }

        private void CargarCategorias()
        {
            // Crea una instancia de la clase de negocio
            Neg_filtrarcategorias negocio = new Neg_filtrarcategorias();

            // Obtén los datos de la base de datos
            DataTable dt = negocio.ObtenerTodasLasCategorias();

            ddlCategorias.Items.Clear();
            //ddlCantidadPersonas.Items.Clear();
            //ddlCalificacion.Items.Clear();

            // Agrega elementos predeterminados a los controles select
            ddlCategorias.Items.Add(new ListItem("Tipo de Alojamiento", ""));
            //ddlCantidadPersonas.Items.Add(new ListItem("Cantidad de Personas", ""));
            //ddlCalificacion.Items.Add(new ListItem("Calificación", ""));

            // Agrega los datos a los controles select
            foreach (DataRow row in dt.Rows)
            {
                // Obtén la información de la fila
                string nombreCategoria = row["Nombre"].ToString();
               // string cantidadHuesped = row["Cantidad_Huesped"].ToString();
                //string calificacion = row["Calificacion"].ToString();

                // Agrega la información a los controles select
                ddlCategorias.Items.Add(new ListItem(nombreCategoria, nombreCategoria));
                //ddlCantidadPersonas.Items.Add(new ListItem(cantidadHuesped, cantidadHuesped));
                //ddlCalificacion.Items.Add(new ListItem(calificacion, calificacion));
            }
            upd_Panel.Update();
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
            iFavoritos.Instruccion = "Insert";
            iFavoritos.AgregarFavorito(IdUsuario, idInmueble);

            // Puedes redirigir al usuario a la página de resultados u otra página
            upd_Panel.Update();
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
                // Si el rol es A o H, inicia sesión
                if (usuario.T_Rol == 'A' || usuario.T_Rol == 'H')
                {
                    Session["IdUsuario"] = usuario;
                    Response.Redirect("Default.aspx"); // Redirige a la página de inicio
                }
                else
                {
                    // Manejar roles no autorizados o mostrar mensaje
                }

            }
        }

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


        protected void FiltrarIn(object sender, EventArgs e)
        {
            string categoriaSeleccionada = ddlCategorias.Value;
            string cantidadPersonasSeleccionada = ddlCantidadPersonas.Text;
            string calificacionSeleccionada = ddlCalificacion.Text;

            DataTable todosLosInmuebles = CargarTarjetas();

            if (todosLosInmuebles != null)
            {
                var inmueblesFiltrados = todosLosInmuebles.AsEnumerable()
                    .Where(row => (categoriaSeleccionada == "" || row.Field<string>("Categoria") == categoriaSeleccionada)
                               && (cantidadPersonasSeleccionada == "" || row.Field<int>("Cantidad_Huesped").ToString() == cantidadPersonasSeleccionada)
                               && (calificacionSeleccionada == "" || row.Field<int>("Calificacion").ToString() == calificacionSeleccionada))
                    .ToList();

                if (inmueblesFiltrados.Any())
                {
                    DataTable dtFiltrados = inmueblesFiltrados.CopyToDataTable();
                    rptInmuebles.DataSource = dtFiltrados;
                    rptInmuebles.DataBind();
                    upd_Panel.Update();
                }
                else
                {
                    rptInmuebles.DataSource = null;
                    rptInmuebles.DataBind();
                    upd_Panel.Update();
                }
            }
        }
    }
}