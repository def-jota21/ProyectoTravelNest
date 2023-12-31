﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class comentariocalificacion : System.Web.UI.Page
    {
        Negocios.Negocio_Comentarios comentarios = new Negocios.Negocio_Comentarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                DataTable dtDestinatario = comentarios.getInfoUsuario(Request.QueryString["IdUsuario"]);
                try
                {
                    int calificacionDestinatario = Convert.ToInt16(dtDestinatario.Rows[0]["Calificacion"]);
                    lblNombreDestinatario.Text = dtDestinatario.Rows[0]["NombreCompleto"].ToString();
                    LiteralControl lc = new LiteralControl();
                    for (int i = 0; i < calificacionDestinatario; i++)
                    {
                        lc.Text += $@"<label id='colorStar'>★</label>";
                    }
                    for (int i = 0; i < 5 - calificacionDestinatario; i++)
                    {
                        lc.Text += $@"<label>★</label>";
                    }
                    lc.Text += $@"<label style='color: rgb(255, 204, 65); font-size: 35px;'>({calificacionDestinatario})</label>";
                    divCalificacionDestinatario.Controls.Add(lc);

                    RepeaterComentarios.DataSource = comentarios.cargarComentarios(Request.QueryString["IdUsuario"]);
                    RepeaterComentarios.DataBind();
                    rptImagen.DataSource = dtDestinatario; rptImagen.DataBind();
                }
                catch (Exception ex)
                {
                    lblNombreDestinatario.Text = "/ No hay Comentarios"; 
                }
            }
        }
        protected string generarCalificacion(int calificacion)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < calificacion; i++)
            {
                sb.Append("<label id='colorStar'>★</label>");
            }
            for (int i = 0; i < 5 - calificacion; i++)
            {
                sb.Append("<label>★</label>");
            }
            return sb.ToString();
        }

    }
}