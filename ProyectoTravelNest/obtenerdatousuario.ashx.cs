using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoTravelNest
{
    /// <summary>
    /// Descripción breve de obtenerdatousuario
    /// </summary>
    public class obtenerdatousuario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string idUsuario = context.Request.QueryString["idUsuario"];

            // Aquí, deberías llamar a tu lógica de negocios para obtener los datos del usuario
            // Reemplaza esto con tu propia lógica
            DataTable datosUsuario = ObtenerDatosUsuarioDesdeBD(idUsuario);

            string json = JsonConvert.SerializeObject(datosUsuario);

            context.Response.Write(json);
        }

        private DataTable ObtenerDatosUsuarioDesdeBD(string idUsuario)
        {
            Negocios.Neg_Usuarios iNeUser = new Negocios.Neg_Usuarios();

            DataTable datosUsuario = iNeUser.ListarUsuarioSeleccionado(4, idUsuario);

            return datosUsuario;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}