using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class elegirinmueble : System.Web.UI.Page
    {
        Negocios.Negocio_Inmuebles nInmueble = new Negocios.Negocio_Inmuebles();
        protected void Page_Load(object sender, EventArgs e)
        {

            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                if (Session["pagina"].Equals("reglas"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una regla";
                }
                else if (Session["pagina"].Equals("promociones"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar una promoción";
                }
                else if (Session["pagina"].Equals("descuentos"))
                {
                    h1_titulo.InnerText = "Agregar, modificar o eliminar un descuento";
                }
                else if (Session["pagina"].Equals("modificarcalendarioreserva"))
                {
                    h1_titulo.InnerText = "Seleccione el alojamiento que desee cambiar fecha disponible";
                }
                else
                {
                    h1_titulo.InnerText = " - Error -";
                    return;
                }
                ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                Control div_row = mainContent.FindControl("row");

                List<Inmueble> ListaInmuebles = nInmueble.ListaInmueblesPagina(1, Session["IdUsuario"].ToString(), null);

                foreach (Inmueble inmueble in ListaInmuebles)
                {
                    string imagen = inmueble.Imagen != null ? Convert.ToBase64String(inmueble.Imagen) : null;
                    LiteralControl htmlSnippet = new LiteralControl();
                    if (imagen == null)
                    {
                        imagen = $@"<img class='img-fluid' src='/img/noimage.jpg' style='border-radius: 7px;'>";
                    }
                    else
                    {
                        imagen = $@"<img class='img-fluid' src='data:image/jpeg;base64,{imagen}' style='border-radius: 7px;'>";
                    }
                    htmlSnippet.Text = $@"
                                    <div class='col-lg-3 col-md-5 p-0 mb-5 me-4 bg-white rounded'>
                                        <a href='/pages/{Session["pagina"]}.aspx?IdInmueble={inmueble.IdInmueble}' class='text-decoration-none' style='color: initial;'>
                                            <div class='package-item bg-white mb-2'>" +
                                                imagen +
                                                $@"<div style='clear: both;'>
                                                    <h5 class='ms-1'>{inmueble.Nombre}</h5>
                                                    <label class='text-muted'>{inmueble.Descripcion}</label>
                                                    <div class='border-top mt-4 pt-4'>
                                                        <div class='d-flex justify-content-around'>
                                                            <h6 class='m-0'><i class='fa fa-star text-primary'></i>4.5
                                                                <small>({inmueble.Calificacion})</small></h6>
                                                            <h5 class='m-0'>${Math.Round(inmueble.Precio, 2)}</h5>
                                                            <p><b>por noche</b></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </div>";
                    div_row.Controls.Add(htmlSnippet);
                }
            }
            Session["IdUsuario"] = Session["IdUsuario"].ToString();
        }
    }
}