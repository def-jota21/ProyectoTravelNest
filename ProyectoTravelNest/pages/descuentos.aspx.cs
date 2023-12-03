using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class descuentos : System.Web.UI.Page
    {
        Negocios.Neg_Descuentos descuento = new Negocios.Neg_Descuentos();
        Entidades.Descuentos eDescuento = new Entidades.Descuentos();
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
                string IdUsuario = eUsuarios.IdUsuario;
                ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                DataTable dt = descuento.getDescuentos(Request.QueryString["IdInmueble"]);
                string porcentaje;
                if (dt.Rows.Count > 0)
                {
                    Repeater.DataSource = dt;
                    Repeater.DataBind();
                    addDescuento.Visible = false;
                    porcentaje = dt.Rows[0]["Porcentaje"].ToString() + "%";
                }
                else
                {
                    porcentaje = "0%";
                }
                List<Inmueble> ListaInmuebles = nInmueble.ListaInmuebleIndividual(IdUsuario, Request.QueryString["IdInmueble"]);
                Control div_Inmueble = mainContent.FindControl("cartaInmueble");
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
                    Session["inmueblemostrar_dr2"] = $@"
                            <div class='bg-white mb-2'>" +
                                                        imagen +
                                $@"<div style='clear: both;'>
                                    <h5 class='ms-1'>{inmueble.Nombre}</h5>
                                    <label class='text-muted'>{inmueble.Descripcion}</label>
                                    <div class='border-top mt-4 pt-4'>
                                        <div class='d-flex justify-content-around'>
                                            <h6 class='m-0'><i class='fa fa-star text-primary' style='color: #8cd56e !important'></i>{inmueble.Calificacion} <small></small>
                                            </h6>
                                            <h5 class='m-0'>${Math.Round(inmueble.Precio, 2)} <span style='color: #1fcd42; margin-left: 23px;'>{porcentaje}</span></h5>
                                            <p><b>por noche</b></p>
                                        </div>
                                    </div>
                                </div>
                            </div>";
                    htmlSnippet.Text = Session["inmueblemostrar_dr2"].ToString();
                    div_Inmueble.Controls.Add(htmlSnippet);
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            Control div_Inmueble = mainContent.FindControl("cartaInmueble");
            LiteralControl htmlSnippet = new LiteralControl();
            htmlSnippet.Text = Session["inmueblemostrar_dr2"].ToString();
            div_Inmueble.Controls.Add(htmlSnippet);

            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtNombre = (TextBox)item.FindControl("txtPorcentaje");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");

            if (txtNombre.ReadOnly)
            {
                actionButton("Modificar", txtNombre, divbtnModificar, divbtnGuardar, divbtnEliminar);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtPorcentaje = (TextBox)item.FindControl("txtPorcentaje");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");
            if (!txtPorcentaje.ReadOnly)
            {
                error.Visible = false;
                if (!int.TryParse(txtPorcentaje.Text, out int num))
                {
                    error.Visible = true;
                    lblEstado.Text = "Por favor, asegúrese de ingresar solamente números.";
                }
                else if (Int32.Parse(txtPorcentaje.Text) > 99 || Int32.Parse(txtPorcentaje.Text) < 1)
                {
                    error.Visible = true;
                    lblEstado.Text = "Por favor, ingrese un valor de descuento que esté en el rango del 1 al 99.";
                }
                else
                {
                    actionButton("Guardar", txtPorcentaje, divbtnModificar, divbtnGuardar, divbtnEliminar);
                    eDescuento.IdDescuento = btn.CommandArgument;
                    eDescuento.Porcentaje = float.Parse(txtPorcentaje.Text);
                    eDescuento.IdInmueble = Request.QueryString["IdInmueble"];
                    descuento.crud(eDescuento, "Modificar");
                    Response.Redirect(Request.RawUrl);
                }
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            eDescuento.IdDescuento = btn.CommandArgument;
            eDescuento.IdInmueble = Request.QueryString["IdInmueble"];
            descuento.crud(eDescuento, "Eliminar");
            actionButton("Eliminar");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            eDescuento.Porcentaje = 0.50F;
            eDescuento.IdDescuento = generateID();
            eDescuento.IdInmueble = Request.QueryString["IdInmueble"];

            descuento.crud(eDescuento, "Agregar");
            actionButton("Agregar");
        }

        private void actionButton(String accion, TextBox txt = null,
                                  HtmlGenericControl modificar = null, HtmlGenericControl guardar = null, HtmlGenericControl eliminar = null)
        {
            string style = "";
            if (txt != null)
            {
                style = txt.Attributes["style"];
            }
            if (accion.Equals("Modificar"))
            {
                txt.ReadOnly = false;
                style += " border-bottom: 1px solid #A0A0A0;";
                modificar.Visible = false;
                guardar.Visible = true;
                txt.Attributes["style"] = style;
            }
            else if (accion.Equals("Guardar"))
            {
                txt.ReadOnly = true;
                style = style.Replace("border-bottom: 1px solid #A0A0A0;", "");
                modificar.Visible = true;
                guardar.Visible = false;
                txt.Attributes["style"] = style;
            }
            else if (accion.Equals("Eliminar") || accion.Equals("Agregar"))
            {
                Response.Redirect(Request.RawUrl);
            }
        }
        private String generateID()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 13)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}