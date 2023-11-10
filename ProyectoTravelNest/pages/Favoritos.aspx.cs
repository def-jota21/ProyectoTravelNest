using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ProyectoTravelNest.pages
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargar los cards en la pantalla

            Negocios.Neg_Favoritos iFavoritos = new Negocios.Neg_Favoritos();

                


            DataTable dtEtapas = iFavoritos.ObtenerFavoritosDeUsuario("1");

            System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();



            foreach (DataRow drEtapas in dtEtapas.Rows)
            {


                ////Convertir la imagen para que se muestre
                byte[] imageBytes = (byte[])drEtapas["Imagen"];
                string base64Image = Convert.ToBase64String(imageBytes);

                // Comienza a construir un elemento de tarjeta
                strListaProductos.Append("<div class=\"col-lg-4 col-md-6 mb-4\">");
                strListaProductos.Append("<div class=\"package-item bg-white mb-2\">");

                // Agrega la imagen del producto (debes proporcionar la base64Image)
                strListaProductos.Append("<img class=\"img-fluid\" src=\"data:image/jpg;base64,").Append(base64Image).Append("\" /></div>");

                strListaProductos.Append("<div class=\"p-4\">");
                strListaProductos.Append("<div class=\"d-flex justify-content-between mb-3\">");

                // Agrega la ubicación
                strListaProductos.Append("<small class=\"m-0\"><i class=\"fa fa-map-marker-alt text-primary mr-2\"></i>" + drEtapas["Direccion"] + "</small>");

                // Agrega el botón "Favorito"
                strListaProductos.Append("<a class=\"m-0\" href=\"#\" onclick=\"EliminarFavorito('" + drEtapas["IdInmueble"] + "')\"><i class=\"fa fa-heart text-danger\"></i>Favorito</a>");


                // Agrega el número de personas
                strListaProductos.Append("<small class=\"m-0\"><i class=\"fa fa-user text-primary mr-2\"></i>" + drEtapas["Cantidad_Huesped"] + "</small>");

                strListaProductos.Append("</div>");

                // Agrega el enlace al detalle del producto
                strListaProductos.Append("<a class=\"h5 text-decoration-none\" href=\"#\">" + drEtapas["Nombre"] + "</a>");

                // Agrega la sección de calificación y precio
                strListaProductos.Append("<div class=\"border-top mt-4 pt-4\">");
                strListaProductos.Append("<div class=\"d-flex justify-content-between\">");
                strListaProductos.Append("<h6 class=\"m-0\"><i class=\"fa fa-star text-primary mr-2\"></i>" + drEtapas["Calificacion"] + "</h6>");
                strListaProductos.Append("<h5 class=\"m-0\">" + drEtapas["Precio"] + "</h5>");
                strListaProductos.Append("<p><b>por noche</b></p>");
                strListaProductos.Append("</div>");
                strListaProductos.Append("</div>");

                // Cierra el elemento de tarjeta
                strListaProductos.Append("</div>");
                strListaProductos.Append("</div>");
                strListaProductos.Append("</div>");
            }

            //Agrega el código HTML a la página web para mostrar las cartas
            this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();

        }
        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void AgregarFavorito_Click(object sender, EventArgs e)
        {

        }

        protected void EliminarFavorito(string idInmueble, string idUsuario)
        {
            try
            {
                // Llamar a la función EliminarFavorito de la capa de negocios
                Negocios.Neg_Favoritos.EliminarFavorito(idInmueble,idUsuario);

                // Recargar la página para reflejar los cambios
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                throw new Exception(ex.Message);
            }
        }
    }
}