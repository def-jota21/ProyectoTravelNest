using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoTravelNest
{
    /// <summary>
    /// Descripción breve de politicasnoasociadas
    /// </summary>
    public class politicasnoasociadas : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string IdImueble = context.Request.QueryString["idInmueble"];

            // Aquí, deberías llamar a tu lógica de negocios para obtener los datos del usuario
            // Reemplaza esto con tu propia lógica
            DataTable datosUsuario = ObtenerDatosPoliticaDesdeBD(IdImueble);

            string json = JsonConvert.SerializeObject(datosUsuario);

            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private DataTable ObtenerDatosPoliticaDesdeBD(string IdImueble)
        {
            Negocios.Negocio_Inmuebles iNeUser = new Negocios.Negocio_Inmuebles();

            DataTable datosUsuario = iNeUser.ListarPoliticaNoAsociada(IdImueble);

            return datosUsuario;
        }
    }
}