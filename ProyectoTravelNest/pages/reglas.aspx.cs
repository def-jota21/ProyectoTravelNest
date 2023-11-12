using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class reglas : System.Web.UI.Page
    {
        Negocios.Neg_Reglas regla = new Negocios.Neg_Reglas();
        Entidades.Reglas eRegla = new Entidades.Reglas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReglasRepeater.DataSource = regla.getReglas();
                ReglasRepeater.DataBind();
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
                actionButton("Guardar", txtRegla, txtExplicacion, divbtnModificar, divbtnGuardar, divbtnEliminar);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

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