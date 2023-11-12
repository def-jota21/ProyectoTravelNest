using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Negocios;

namespace ProyectoTravelNest.pages
{
    public partial class Favoritos : System.Web.UI.Page
    {
        Neg_Favoritos iFavoritos = new Neg_Favoritos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            iFavoritos.Instruccion = "Read";

            rptData.DataSource = iFavoritos.ObtenerFavoritosDeUsuario("2222222222");
            rptData.DataBind();
        }

        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void AgregarFavorito_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string idInmueble = button.CommandArgument;

            iFavoritos.Instruccion = "Insert";
            string idUsuario = Session["idUsuario"].ToString();

            iFavoritos.AgregarFavorito(idUsuario, idInmueble);
        }


        private void EliminarFavorito(string idInmueble)
        {
            try
            {
                string idUsuario = "2222222222";
                //string idUsuario = Session["idUsuario"].ToString();

                // Llamar a la función EliminarFavorito de la capa de negocios
                iFavoritos.Instruccion = "Delete";
                iFavoritos.EliminarFavorito(idInmueble, idUsuario);

                // Recuperar nuevos datos y recargar la página para reflejar los cambios
                CargarDatos();

                upd_Favoritos.Update();
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                throw new Exception(ex.Message);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton lnkButton = (LinkButton)sender;
            string idInmueble = lnkButton.CommandArgument;

            // Lógica para eliminar favorito usando el idInmueble
            EliminarFavorito(idInmueble);
            upd_Favoritos.Update();
        }
    }
}