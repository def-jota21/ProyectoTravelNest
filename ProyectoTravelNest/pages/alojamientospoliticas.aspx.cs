﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class alojamientospoliticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocios.Negocio_Inmuebles iInmueble = new Negocios.Negocio_Inmuebles();

            //aca tambien se debe de obtener la variable session al inciciar sesion
            rptAlojamientos.DataSource = iInmueble.ListarInmueblesAnfitrion("2222222222");
            rptAlojamientos.DataBind();
        }

        protected void btnPoliticas_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "AdmPoliticas")
            {
                string[] args = e.CommandArgument.ToString().Split(',');

                if (args.Length == 2)
                {
                    string idUsuario = args[0].Trim();
                    string IdInmueble = args[1].Trim();

                    // Redirige a la página de destino con los parámetros
                    Response.Redirect($"gestionpoliticas.aspx?IdInmueble={IdInmueble}");
                }
            }
        }
    }
}