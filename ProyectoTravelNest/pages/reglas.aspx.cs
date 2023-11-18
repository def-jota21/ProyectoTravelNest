using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class reglas : System.Web.UI.Page
    {
        Negocios.Neg_Reglas regla = new Negocios.Neg_Reglas();
        Entidades.Reglas eRegla = new Entidades.Reglas();
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
                String IdUsuario = Session["IdUsuario"].ToString();
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
                    ReglasRepeater.DataSource = regla.getReglas(Request.QueryString["IdInmueble"]);
                    ReglasRepeater.DataBind();
                }
            }

           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtRegla = (TextBox)item.FindControl("txtRegla");
            TextBox txtExplicacion = (TextBox)item.FindControl("txtExplicacion");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");

            if (txtRegla.ReadOnly)
            {
                actionButton("Modificar", txtRegla, txtExplicacion, divbtnModificar, divbtnGuardar, divbtnEliminar);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            TextBox txtRegla = (TextBox)item.FindControl("txtRegla");
            TextBox txtExplicacion = (TextBox)item.FindControl("txtExplicacion");
            HtmlGenericControl divbtnModificar = (HtmlGenericControl)item.FindControl("divbtnModificar");
            HtmlGenericControl divbtnGuardar = (HtmlGenericControl)item.FindControl("divbtnGuardar");
            HtmlGenericControl divbtnEliminar = (HtmlGenericControl)item.FindControl("divbtnEliminar");
            if (!txtRegla.ReadOnly)
            {
                if (txtRegla.Text.Equals("") || txtExplicacion.Text.Equals(""))
                {
                    error.Visible = true;
                    lblEstado.Text = "No debes dejar espacios en blanco.";
                }
                else
                {
                    error.Visible = false;
                    actionButton("Guardar", txtRegla, txtExplicacion, divbtnModificar, divbtnGuardar, divbtnEliminar);
                    eRegla.IdRegla = Convert.ToInt32(btn.CommandArgument);
                    eRegla.NombreRegla = txtRegla.Text;
                    eRegla.Explicacion = txtExplicacion.Text;
                    regla.crud(eRegla, "Modificar");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            eRegla.IdRegla = Convert.ToInt32(btn.CommandArgument);
            eRegla.IdInmueble = Request.QueryString["IdInmueble"];
            regla.crud(eRegla, "Eliminar");
            actionButton("Eliminar");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            eRegla.NombreRegla = "Nombre de la regla";
            eRegla.Explicacion = "Explicacion de la regla";
            eRegla.IdInmueble = Request.QueryString["IdInmueble"];

            regla.crud(eRegla, "Agregar");
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