using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoTravelNest
{
    /// <summary>
    /// Descripción breve de ConsultarFechas
    /// </summary>
    public class ConsultarFechas : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            // Obtén el parámetro desde la solicitud (puedes ajustar esto según tu necesidad)
            string parametro = context.Request.QueryString["parametro"];

            // Llama a tu método para obtener las fechas ocupadas desde la base de datos
            List<DateTime> fechasOcupadas = ObtenerFechasOcupadasDesdeBD(parametro);

            // Convierte las fechas a formato JSON
            string fechasOcupadasJson = JsonConvert.SerializeObject(fechasOcupadas);

            // Envía las fechas ocupadas como respuesta
            context.Response.Write(fechasOcupadasJson);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private List<DateTime> ObtenerFechasOcupadasDesdeBD(string idInmueble)
        {
            List<DateTime> fechasOcupadas = new List<DateTime>();

            Negocios.Negocio_Inmuebles iInmueble = new Negocios.Negocio_Inmuebles();

            // Aquí debes obtener el DataTable desde tu base de datos
            DataTable dataTable = iInmueble.ListarFechasOcupadas(idInmueble); // Reemplaza con tu lógica para obtener el DataTable

            // Convierte las filas del DataTable a fechas y agrega a la lista
            foreach (DataRow row in dataTable.Rows)
            {
                if (DateTime.TryParse(row["Fecha"].ToString(), out DateTime fechaReserva))
                {
                    fechasOcupadas.Add(fechaReserva);
                }
            }

            return fechasOcupadas;
        }
    }
}