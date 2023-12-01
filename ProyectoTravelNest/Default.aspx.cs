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
        Neg_filtrarcategorias negocio = new Neg_filtrarcategorias();

        private int CurrentPageIndex
        {
            get { return ViewState["CurrentPageIndex"] != null ? Convert.ToInt32(ViewState["CurrentPageIndex"]) : 0; }
            set { ViewState["CurrentPageIndex"] = value; }
        }

        private int PageSize => 15; // Tamaño de página fijo
        protected void Page_Load(object sender, EventArgs e)

        {


            if (!IsPostBack)
            {
                CargarCategorias();
                BindRepeater();

            }

            
        }

        protected void lvInmuebles_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            CurrentPageIndex = e.StartRowIndex / e.MaximumRows;
            BindRepeaterConFiltro((DataTable)Session["DatosFiltrados"]);
        }


        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DataPager1.Visible = DataPager1.PageSize < ((DataTable)Session["DatosFiltrados"]).Rows.Count;
            DataPager1.DataBind();
        }

        private void BindRepeater()
        {
            DataTable datos = CargarTarjetas();
            Session["DatosFiltrados"] = datos; // Guardar los datos en el estado de sesión
            BindRepeaterConFiltro(datos);
        }

        private void BindRepeaterConFiltro(DataTable datos)
        {
            lvInmuebles.DataSource = datos;
            lvInmuebles.DataBind();
        }


        private DataTable CargarTarjetas()
        {
            return iInmueble.ListarInmueblesPrincipal();
        }

        private void CargarCategorias()
        {
            DataTable dt = negocio.ObtenerTodasLasCategorias();
            ddlCategorias.Items.Clear();
            ddlCategorias.Items.Add(new ListItem("Tipo de Alojamiento", ""));

            foreach (DataRow row in dt.Rows)
            {
                string nombreCategoria = row["Nombre"].ToString();
                ddlCategorias.Items.Add(new ListItem(nombreCategoria, nombreCategoria));
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

            DataTable datosFiltrados = FiltrarDatos(categoriaSeleccionada, cantidadPersonasSeleccionada, calificacionSeleccionada);
            Session["DatosFiltrados"] = datosFiltrados; // Actualiza los datos filtrados en la sesión
            CurrentPageIndex = 0;
            BindRepeaterConFiltro(datosFiltrados);
        }

        private DataTable FiltrarDatos(string categoria, string cantidadPersonas, string calificacion)
        {
            DataTable dtInmuebles = iInmueble.ListarInmueblesPrincipal();
            var inmueblesFiltrados = dtInmuebles.AsEnumerable();

            if (!string.IsNullOrEmpty(categoria) && categoria != "0")
            {
                inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<string>("Categoria") == categoria);
            }

            if (!string.IsNullOrEmpty(cantidadPersonas) && cantidadPersonas != "0")
            {
                int cantidad = Convert.ToInt32(cantidadPersonas);
                inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<int>("Cantidad_Huesped") == cantidad);
            }

            if (!string.IsNullOrEmpty(calificacion) && calificacion != "0")
            {
                int calif = Convert.ToInt32(calificacion);
                inmueblesFiltrados = inmueblesFiltrados.Where(row => row.Field<int>("Calificacion") == calif);
            }

            return inmueblesFiltrados.Any() ? inmueblesFiltrados.CopyToDataTable() : new DataTable();
        }


        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                BindRepeaterConFiltro(Session["DatosFiltrados"] as DataTable);
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            DataTable datosFiltrados = Session["DatosFiltrados"] as DataTable;
            int maxPageIndex = (datosFiltrados.Rows.Count / PageSize) + (datosFiltrados.Rows.Count % PageSize > 0 ? 1 : 0) - 1;


            if (CurrentPageIndex < maxPageIndex)
            {
                CurrentPageIndex++;
                BindRepeaterConFiltro(datosFiltrados);
            }
        }
    }
}
