﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class cuponeshuesped : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Entidades.Usuarios eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                Negocios.Negocio_Cupon negc = new Negocios.Negocio_Cupon();

                rptCupon.DataSource = negc.ListarCuponHuespedP(eUsuarios.IdUsuario);
                rptCupon.DataBind();
            }
        }
    }
}