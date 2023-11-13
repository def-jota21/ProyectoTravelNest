using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Neg_Inmueble
    {
        public DataTable ObtenerServicios()
        {
            DataTable tablaServicios = new DataTable();
            Datos.ServiciosSQL serviciosSQL = new Datos.ServiciosSQL();
            tablaServicios = serviciosSQL.ObtenerTablaServicios();

            return tablaServicios;
        }
        public DataTable ObtenerCategorias()
        {
            DataTable tablaServicios = new DataTable();
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            tablaServicios = inmuebleSQL.ObtenerTablaCategoria();

            return tablaServicios;
        }

        public DataTable ObtenerAmenidades()
        {
            DataTable tablaServicios = new DataTable();
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            tablaServicios = inmuebleSQL.ObtenerTablaAmenidades();

            return tablaServicios;
        }

        public void InsertarInmueble(Entidades.Inmueble inmueble, string categoria, string rutas, List<string> servicios, List<string> amenidades) 
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            string idInmueble = inmuebleSQL.InsertarInmueble(inmueble, categoria, "");

            ServiciosSQL ServiciosSQL = new ServiciosSQL();
            foreach (string servicio in servicios)
            {
                string Id = ServiciosSQL.ObtenerIdServicioPorNombre(servicio);

                ServiciosSQL.EjecutarProcedureServicioxInmueble(idInmueble, Id);
            }
            
        }
    }
}
