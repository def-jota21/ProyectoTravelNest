using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoTravelNest.pages
{
    public partial class cotizacion : System.Web.UI.Page
    {
        DataTable dtInformacionInmueble = new DataTable();
        static string parametro1 = "";
        static string parametro2 = "";
        static string parametro3 = "";
        static string parametro4 = "";
        static string parametro5 = "";
        static string parametro6 = "";
        static decimal totalTarifas;
        Entidades.Usuarios eUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            eUsuarios = Session["IdUsuario"] as Entidades.Usuarios;

            if (eUsuarios == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack & eUsuarios != null)
            {
                // Verifica si los parámetros se pasaron en la URL
                if (Request.QueryString["parametro1"] != null &&
                    Request.QueryString["parametro2"] != null &&
                    Request.QueryString["parametro3"] != null &&
                    Request.QueryString["parametro4"] != null &&
                    Request.QueryString["parametro5"] != null && 
                    Request.QueryString["parametro6"] != null)
                {
                    // Obtiene los valores de los parámetros desde la URL
                    parametro1 = Request.QueryString["parametro1"];
                    parametro2 = Request.QueryString["parametro2"];
                    parametro3 = Request.QueryString["parametro3"];
                    parametro4 = Request.QueryString["parametro4"];
                    parametro5 = Request.QueryString["parametro5"];
                    parametro6 = Request.QueryString["parametro6"];

                    Negocios.Negocio_Inmuebles iInmueble = new Negocio_Inmuebles();
                    RepeaterImagen.DataSource = iInmueble.ListarInformacionInmuebleImagenes(parametro6, parametro5);
                    RepeaterImagen.DataBind();
                    
                    

                    dtInformacionInmueble = iInmueble.ListarInformacionInmueble(parametro6, parametro5);

                    if (dtInformacionInmueble.Rows.Count > 0)
                    {
                        
                        lblCodigo.Text = dtInformacionInmueble.Rows[0][0].ToString();

                        
                        lblNombreInmueble.Text = dtInformacionInmueble.Rows[0][2].ToString();

                        txtf_inicio.Text = parametro1;
                        txtf_fin.Text = parametro2;
                        txthuesped.Text = parametro4;

                        // Supongamos que tienes las siguientes fechas y tarifas por noche
                        DateTime fechaInicio = DateTime.Parse(parametro1);
                        DateTime fechaFin = DateTime.Parse(parametro2);
                        decimal tarifaPorNoche = decimal.Parse(dtInformacionInmueble.Rows[0][7].ToString()); // Ajusta esto según tu estructura de datos

                        // Calcula el número de noches
                        int numeroDeNoches = (int)(fechaFin - fechaInicio).TotalDays;

                        // Porcentajes de las tarifas adicionales (en este caso, 10% para limpieza, 2% para servicio, 5% para impuestos)
                        decimal porcentajeLimpieza = 0.20m;
                        decimal porcentajeServicio = 0.15m;
                        decimal porcentajeImpuestos = 0.13m;

                        // Calcula las tarifas adicionales como porcentaje del costo por noche
                        decimal tarifaLimpieza = tarifaPorNoche * porcentajeLimpieza;
                        decimal tarifaServicio = tarifaPorNoche * porcentajeServicio;
                        decimal impuestos = tarifaPorNoche * porcentajeImpuestos;

                        // Calcula el total de la tarifa por noche
                        decimal totalPorNoche = tarifaPorNoche * numeroDeNoches;

                        // Calcula el total de todas las tarifas
                        totalTarifas = totalPorNoche + tarifaLimpieza + tarifaServicio + impuestos;

                        // Asigna los resultados a los controles
                        txtf_inicio.Text = fechaInicio.ToShortDateString();
                        txtf_fin.Text = fechaFin.ToShortDateString();
                        txthuesped.Text = numeroDeNoches.ToString();
                        lblNoches.Text = string.Format("${0:N2} x {1} noches", tarifaPorNoche, numeroDeNoches);
                        lblLimpieza.Text = string.Format("${0:N2}", tarifaLimpieza);
                        lblServicio.Text = string.Format("${0:N2}", tarifaServicio);
                        lblImpuestos.Text = string.Format("${0:N2}", impuestos);
                        lblTotal.Text = string.Format("${0:N2}", totalTarifas);

                    }


                }
            }
                    
                
        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Negocios.Neg_Reservaciones reservaciones = new Neg_Reservaciones();

            bool inserto = reservaciones.InsertarReservacion(parametro6, parametro5, parametro1, parametro2);

            if (inserto)
            {
                string script = "Swal.fire('¡Éxito!', 'Se reservo con Exito', 'success');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
                reservaciones.enviarCorreo(eUsuarios.IdUsuario, totalTarifas);
            }
            else
            {
                string script = "Swal.fire('¡Error!', 'Ocurrio un error', 'error');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlerta", script, true);
            }
        }
            protected void RepeaterImagen_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtenemos el índice del elemento actual
                int itemIndex = e.Item.ItemIndex;

                // Obtenemos el control Image dentro del ItemTemplate
                Image imgMueble = (Image)e.Item.FindControl("imgMueble");

                // Si el índice es 0 (el primer elemento), mantenemos la imagen visible
                // Para los demás elementos, la ocultamos
                imgMueble.Visible = (itemIndex == 0);
            }
        }
    }
}