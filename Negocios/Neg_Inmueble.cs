using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

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

        public DataTable ObtenerPoliticas()
        {
            DataTable tablaPoliticas = new DataTable();
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            tablaPoliticas = inmuebleSQL.ObtenerTablaPoliticas();

            return tablaPoliticas;
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
        public DataTable ObtenerServicioxInmueble(string idInmueble)
        {
            DataTable tablaServicios = new DataTable();
            Datos.ServiciosSQL serviciosSQL = new Datos.ServiciosSQL();
            tablaServicios = serviciosSQL.ObtenerServiciosPorInmueble(idInmueble);

            return tablaServicios;
        }
         
        public List<Tuple<string, string>> ObtenerAmenidadDelInmueble(string idInmueble)
        {

            List<Tuple<string, string>> amenidadesInmueble = new List<Tuple<string, string>>();
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            amenidadesInmueble = inmuebleSQL.ObtenerAmenidadesDelInmueble(idInmueble);

            return amenidadesInmueble;
        }

        public void InsertarServicioxInmueble(string idInmueble, string idservicio)
        {
            ServiciosSQL ServiciosSQL = new ServiciosSQL();
            ServiciosSQL.EjecutarProcedureServicioxInmueble(idInmueble, idservicio);
        }

        public void EliminarServicioxInmueble(string idInmueble, string idservicio)
        {
            ServiciosSQL ServiciosSQL = new ServiciosSQL();
            ServiciosSQL.EjecutarEliminarServicioxInmueble(idInmueble, idservicio);
        }

        public void InsertarAmeindadxInmueble(string idInmueble, string idamenidad)
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            inmuebleSQL.AsociarAmenidadAInmueble(idInmueble, idamenidad);
        }

        public void EliminarAmenidadAInmueble(string idInmueble, string idamenidad)
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            inmuebleSQL.EliminarAmenidadAInmueble(idInmueble,idamenidad);
        }

        public DataTable ObtenerDatosInmueble(string idInmueble)
        {
            DataTable inmueble = new DataTable();
            InmuebleSQL inmuebleSQL = new InmuebleSQL();
            inmueble = inmuebleSQL.ObtenerDatosInmueble(idInmueble);
            return inmueble;
        }

        public string ObtenerNombreCategoriaPorId(string idCategoria)
        {
            String id = "";
            InmuebleSQL inmuebleSQL = new InmuebleSQL();
            id = inmuebleSQL.ObtenerNombreCategoriaPorId(idCategoria);
            return id;
        }

        public bool EditarInmueble(Entidades.Inmueble inmueble, string categoria,string IdUsuario)
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            bool valor = inmuebleSQL.EditarInmueble(inmueble, categoria,IdUsuario);
            return valor;
        }

        public string InsertarInmueble(Entidades.Inmueble inmueble, string categoria, string rutas, List<string> servicios, List<string> amenidades, string IdUsuario, List<string> politicas, List<string> despoliticas) 
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();
            string idInmueble = inmuebleSQL.InsertarInmueble(inmueble, categoria, "", IdUsuario);
            
            ServiciosSQL ServiciosSQL = new ServiciosSQL();
            foreach (string idservicio in servicios)
            {
                ServiciosSQL.EjecutarProcedureServicioxInmueble(idInmueble, idservicio);
            }


            foreach (string idamenidad in amenidades)
            {

                inmuebleSQL.AsociarAmenidadAInmueble(idInmueble,idamenidad);
            }

            for (int i = 0; i < politicas.Count; i++)
            {
                string idPolitica = politicas[i];
                string descripcionPolitica = despoliticas[i];

                inmuebleSQL.InsertarPoliticas(idInmueble, idPolitica, descripcionPolitica);
            }

            return idInmueble;
        }

        public bool InsertarImagenInmueble(string idInmueble, byte[] arregloImagen)
        {
            Datos.InmuebleSQL inmuebleSQL = new Datos.InmuebleSQL();

            bool inserto = inmuebleSQL.InsertarImagenInmueble(idInmueble, arregloImagen);

            return inserto;
        }

        public List<Tuple<string, string>> ObtenerServiciosDelInmueble(string idInmueble)
        {
            Datos.ServiciosSQL serviciosSQL = new Datos.ServiciosSQL();

            List<Tuple<string, string>> serviciosInmueble = new List<Tuple<string, string>>();

            serviciosInmueble = serviciosSQL.ObtenerServiciosDelInmueble(idInmueble);

            return serviciosInmueble;
        }
    }
}
