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

            // Obtener el usuario actual de la sesión
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            // Comprobar si hay un usuario logueado
            if (eUsuarios != null)
            {
                // Obtener el idInmueble del botón "Favorito"
                LinkButton lnkFavorito = (LinkButton)sender;
                string idInmueble = lnkFavorito.Attributes["data-idinmueble"];

                // Obtener el ID del usuario desde la entidad eUsuarios
                string IdUsuario = eUsuarios.IdUsuario; // Asume que 'Id' es la propiedad que contiene el ID del usuario

                // Almacenar los valores en variables de sesión
                Session["IdInmueble"] = idInmueble;

                // Llamar a la función AgregarFavorito
                iFavoritos.Instruccion = "Insert";
                iFavoritos.AgregarFavorito(IdUsuario, idInmueble);

                // Actualizar el panel o realizar otras acciones según sea necesario
                //upd_Panel.Update();
            }
            else
            {
                // Manejar el caso cuando el usuario no está logueado
                // Por ejemplo, redirigir a la página de inicio de sesión
                Response.Redirect("/pages/login.aspx");
            }
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
                IEnumerable<DataRow> inmueblesFiltrados = todosLosInmuebles.AsEnumerable();

                if (!string.IsNullOrEmpty(categoriaSeleccionada))
                {
                    inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<string>("Categoria") == categoriaSeleccionada);
                }

                if (!string.IsNullOrEmpty(cantidadPersonasSeleccionada) && cantidadPersonasSeleccionada != "0")
                {
                    inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<int>("Cantidad_Huesped").ToString() == cantidadPersonasSeleccionada);
                }

                if (!string.IsNullOrEmpty(calificacionSeleccionada) && calificacionSeleccionada != "0")
                {
                    inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<int>("Calificacion").ToString() == calificacionSeleccionada);
                }

                DataTable dtFiltrados = inmueblesFiltrados.Any() ? inmueblesFiltrados.CopyToDataTable() : new DataTable();
                rptInmuebles.DataSource = dtFiltrados;
                rptInmuebles.DataBind();
                upd_Panel.Update();
            }
        }
    }
}
