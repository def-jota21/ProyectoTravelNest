﻿using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class comentariosanfitrion : System.Web.UI.Page
    {
        private static string IdAnfitrion = "";
        private static string IdReservacion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idAnfitrion"] != null && Request.QueryString["IdReservacion"] != null)
                {
                    // Lee los valores de los parámetros
                    IdAnfitrion = Request.QueryString["idAnfitrion"];
                    IdReservacion = Request.QueryString["IdReservacion"];

                }

            }
        }

        protected void EnviarComentarioAnfitrion_Click(object sender, EventArgs e)
        {
            string Comentario = "";
            int comunicacion = 0;
            int calificacion = 0;

            Comentario = txtcomentarioPublico.Text;
            comunicacion = int.Parse(ddlComunicacion.SelectedValue.ToString());
            calificacion = int.Parse(ddlCalificacionAnfitrion.SelectedValue.ToString());

            //aca se debe de ontener el id huesped desde la variable session PENDIENTE
            Negocios.Negocio_Comentarios iNgcom = new Negocio_Comentarios();

            iNgcom.realizarComentarioaAnfitrion (IdAnfitrion, "2222222222", Comentario, comunicacion, calificacion, int.Parse(IdReservacion));
        }
    }
}