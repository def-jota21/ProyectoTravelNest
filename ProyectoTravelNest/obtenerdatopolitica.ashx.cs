using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoTravelNest
{
    /// <summary>
    /// Descripción breve de obtenerdatopolitica
    /// </summary>
    public class obtenerdatopolitica : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string idPolitica = context.Request.QueryString["idPolitica"];

            // Aquí, deberías llamar a tu lógica de negocios para obtener los datos del usuario
            // Reemplaza esto con tu propia lógica
            DataTable datosUsuario = ObtenerDatosPoliticaDesdeBD(int.Parse(idPolitica));

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

        private DataTable ObtenerDatosPoliticaDesdeBD(int idPolitica)
        {
            Negocios.Negocio_Inmuebles iNeUser = new Negocios.Negocio_Inmuebles();

            DataTable datosUsuario = iNeUser.ListarPolitica(idPolitica);

            return datosUsuario;
        }

    }
}