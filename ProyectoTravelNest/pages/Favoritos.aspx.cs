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
using System.Web.Security;

namespace ProyectoTravelNest.pages
{
    public partial class Favoritos : System.Web.UI.Page
    {
        Neg_Favoritos iFavoritos = new Neg_Favoritos();
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
                CargarDatos(eUsuarios.IdUsuario.ToString());
            }
            
        }

        private void CargarDatos(string idUsuario)
        {
            iFavoritos.Instruccion = "Read";

            rptData.DataSource = iFavoritos.ObtenerFavoritosDeUsuario(idUsuario);
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
            string idUsuario = eUsuarios.IdUsuario.ToString();

            iFavoritos.AgregarFavorito(idUsuario, idInmueble);
        }


        private void EliminarFavorito(string idInmueble)
        {
            try
            {
                
                string idUsuario = eUsuarios.IdUsuario.ToString();

                // Llamar a la función EliminarFavorito de la capa de negocios
                iFavoritos.Instruccion = "Delete";
                iFavoritos.EliminarFavorito(idInmueble, idUsuario);

                // Recuperar nuevos datos y recargar la página para reflejar los cambios
                CargarDatos(eUsuarios.IdUsuario.ToString());

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
                    Response.Redirect($"~/pages/verinformacion.aspx?IdUsuario={IdUsuario}&IdInmueble={IdInmueble}");

                }
            }
        }
    }
}