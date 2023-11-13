using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class promociones : System.Web.UI.Page
    {
        Negocios.Neg_Promocion promocion = new Negocios.Neg_Promocion();
        Entidades.Promocion ePromocion = new Entidades.Promocion();
        Negocios.Negocio_Inmuebles nInmueble = new Negocios.Negocio_Inmuebles();
        protected void Page_Load(object sender, EventArgs e)
        {
            String IdUsuario = "2222222222   ";
            ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            Control div_Inmueble = mainContent.FindControl("cartaInmueble");

            List<Inmueble> ListaInmuebles = nInmueble.ListaInmuebleIndividual(IdUsuario, Request.QueryString["IdInmueble"]);

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
                                    <div class='bg-white mb-2'>" +
                                                            imagen +
                                    $@"<div style='clear: both;'>
                                            <h5 class='ms-1'>{inmueble.Nombre}</h5>
                                            <label class='text-muted'>{inmueble.Descripcion}</label>
                                            <div class='border-top mt-4 pt-4'>
                                                <div class='d-flex justify-content-around'>
                                                    <h6 class='m-0'><i class='fa fa-star text-primary'></i>4.5 <small>({inmueble.Calificacion})</small>
                                                    </h6>
                                                    <h5 class='m-0'>${Math.Round(inmueble.Precio, 2)}</h5>
                                                    <p><b>por noche</b></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>";
                div_Inmueble.Controls.Add(htmlSnippet);
            }
            if (!IsPostBack)
            {
                Repeater.DataSource = promocion.getPromociones(Request.QueryString["IdInmueble"]);
                Repeater.DataBind();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtNombre = (TextBox)item.FindControl("txtNombre");
            TextBox txtDetalle = (TextBox)item.FindControl("txtDetalle");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");

            if (txtNombre.ReadOnly)
            {
                actionButton("Modificar", txtNombre, txtDetalle, divbtnModificar, divbtnGuardar, divbtnEliminar);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtNombre = (TextBox)item.FindControl("txtNombre");
            TextBox txtDetalle = (TextBox)item.FindControl("txtDetalle");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");
            if (!txtNombre.ReadOnly)
            {
                actionButton("Guardar", txtNombre, txtDetalle, divbtnModificar, divbtnGuardar, divbtnEliminar);
                ePromocion.IdPromocion = Convert.ToInt32(btn.CommandArgument);
                ePromocion.Nombre = txtNombre.Text;
                ePromocion.Detalle = txtDetalle.Text;
                promocion.crud(ePromocion, "Modificar");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            ePromocion.IdPromocion = Convert.ToInt32(btn.CommandArgument);
            ePromocion.IdInmueble = Request.QueryString["IdInmueble"];
            promocion.crud(ePromocion, "Eliminar");
            actionButton("Eliminar");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ePromocion.Nombre = "Nombre de la promoción";
            ePromocion.Detalle = "Detalle de la promoción";
            ePromocion.IdInmueble = Request.QueryString["IdInmueble"];

            promocion.crud(ePromocion, "Agregar");
            actionButton("Agregar");
        }


        private void actionButton(String accion, TextBox txt = null, TextBox txt2 = null,
                                  HtmlGenericControl modificar = null, HtmlGenericControl guardar = null, HtmlGenericControl eliminar = null)
        {
            string style = ""; string style2 = "";
            if (txt != null)
            {
                style = txt.Attributes["style"];
                style2 = txt2.Attributes["style"];
            }
            if (accion.Equals("Modificar"))
            {
                txt.ReadOnly = false;
                txt2.ReadOnly = false;
                style += " border-bottom: 1px solid #A0A0A0;";
                style2 += " background-color: white;";
                modificar.Visible = false;
                guardar.Visible = true;
                txt.Attributes["style"] = style;
                txt2.Attributes["style"] = style2;
            }
            else if (accion.Equals("Guardar"))
            {
                txt.ReadOnly = true;
                txt2.ReadOnly = true;
                style = style.Replace("border-bottom: 1px solid #A0A0A0;", "");
                style2 = style2.Replace("background-color: white;", "");
                modificar.Visible = true;
                guardar.Visible = false;
                txt.Attributes["style"] = style;
                txt2.Attributes["style"] = style2;
            }
            else if (accion.Equals("Eliminar") || accion.Equals("Agregar"))
            {
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}