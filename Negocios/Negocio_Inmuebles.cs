using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocios
{
    public class Negocio_Inmuebles
    {
        public DataTable ListarInmueblesPrincipal()
        { 
             
            DataTable dtInmuebles = new DataTable();

            dtInmuebles = Datos.ConexionSQL.ExecuteQueryTableGeneral("ListarInmueblesPrincipal");
            

            return dtInmuebles;
        
        }//fin de listar inmuebles principal


        public DataTable ListarInformacionInmueble(string idInmueble, string idDueno)
        {
            DataTable dtInfo = new DataTable();

            string strNombreSP = "ListarLugarIndividual";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 1));
            lstParametros.Add(new SqlParameter("@IdInmuble", idInmueble));
            lstParametros.Add(new SqlParameter("@IdUsuario", idDueno));

            dtInfo = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtInfo;
        }

        public DataTable ListarInformacionInmuebleImagenes(string idInmueble, string idDueno)
        {
            DataTable dtInfoImagen = new DataTable();

            string strNombreSP = "ListarLugarIndividual";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 2));
            lstParametros.Add(new SqlParameter("@IdInmuble", idInmueble));
            lstParametros.Add(new SqlParameter("@IdUsuario", idDueno));

            dtInfoImagen = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtInfoImagen;
        }

        public DataTable ListarInformacionInmueblePoliticas(string idInmueble, string idDueno)
        {
            DataTable dtInfoPoliticas = new DataTable();

            string strNombreSP = "ListarLugarIndividual";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 3));
            lstParametros.Add(new SqlParameter("@IdInmuble", idInmueble));
            lstParametros.Add(new SqlParameter("@IdUsuario", idDueno));

            dtInfoPoliticas = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtInfoPoliticas;
        }

        public DataTable ListarInformacionInmuebleReglas(string idInmueble, string idDueno)
        {
            DataTable dtInfoReglas = new DataTable();

            string strNombreSP = "ListarLugarIndividual";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 4));
            lstParametros.Add(new SqlParameter("@IdInmuble", idInmueble));
            lstParametros.Add(new SqlParameter("@IdUsuario", idDueno));

            dtInfoReglas = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtInfoReglas;
        }

        public DataTable ListarFechasOcupadas(string idInmueble)
        {
            DataTable dtFechas = new DataTable();

            string strNombreSP = "ObtenerFechas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdInmueble", idInmueble));
            

            dtFechas = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtFechas;
        }

        public DataTable ListarInmueblesAnfitrion(string idAnfitrion)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "AlojamientosporAnfitrion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdAnfitrion", idAnfitrion));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }
        public DataTable ListarAlojamientosVisitados(string idUsuario)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "AlojamientosVisitados";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdUsuario", idUsuario));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }
        public DataTable ListarAlojamientosReservados(string idUsuario)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "AlojamientosReservados";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdUsuario", idUsuario));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }
        public DataTable ListarInmueblesInactivosAnfitrion(string idAnfitrion)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "AlojamientosInactivoAnfitrion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdAnfitrion", idAnfitrion));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public DataTable ListarPolitica(int idPolitica)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 6));
            lstParametros.Add(new SqlParameter("@idPoliticaxInmueble", idPolitica));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public DataTable ListarPoliticaAsociada(string idInmueble)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 1));
            lstParametros.Add(new SqlParameter("@idInmueble", idInmueble));


            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public DataTable EditarPoliticaAsociada(int idPolitica, string Comentario)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 3));
            lstParametros.Add(new SqlParameter("@idPoliticaxInmueble", idPolitica));
            lstParametros.Add(new SqlParameter("@Comentario", Comentario));

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }


        public DataTable ListarPoliticaNoAsociada(string IdInmueble)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 2));
            lstParametros.Add(new SqlParameter("@idInmueble", IdInmueble));
            

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public void EliminarPolitica(int idPolitica)
        {
             
            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 4));
            lstParametros.Add(new SqlParameter("@idPoliticaxInmueble", idPolitica));

            Datos.ConexionSQL.ExecuteQuery(strNombreSP,lstParametros);

        }

        public void AgregarPolitica(string idPolitica, string Comentario, string idInmueble)
        {

            string strNombreSP = "MantenimientoPoliticas";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 5));
            lstParametros.Add(new SqlParameter("@idInmueble", idInmueble));
            lstParametros.Add(new SqlParameter("@NombrePolitica", idPolitica));
            lstParametros.Add(new SqlParameter("@Comentario", Comentario));

            Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);

        }

        public DataTable ListaInmueblesPagina(int pagina, String IdUsuario, String IdInmueble = null)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "ConsultarInmueblesPagina";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@pagina", pagina));
            lstParametros.Add(new SqlParameter("@idUsuario", IdUsuario));
            lstParametros.Add(new SqlParameter("@idInmueble", IdInmueble));

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public List<Inmueble> ListaInmuebleIndividual(String IdUsuario, String IdInmueble)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "ConsultarInmueblesIndividual";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@idUsuario", IdUsuario));
            lstParametros.Add(new SqlParameter("@idInmueble", IdInmueble));

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            List<Inmueble> inmuebles = new List<Inmueble>();
            foreach (DataRow dr in dt.Rows)
            {
                Inmueble inmueble = new Inmueble();
                inmueble.IdInmueble = dr["IdInmueble"].ToString();
                inmueble.Nombre = dr["Nombre"].ToString();
                inmueble.Descripcion = dr["Descripcion"].ToString();
                inmueble.Calificacion = Convert.ToInt32(dr["Calificacion"]);
                inmueble.Precio = float.Parse(dr["Precio"].ToString());
                inmueble.Imagen = dr["Imagen"] != DBNull.Value ? (byte[])dr["Imagen"] : null;


                inmuebles.Add(inmueble);
            }

            return inmuebles;
        }

        public DataTable ListarInformacionInmuebleServicios(string idInmueble)
        {
            DataTable dtInfoPoliticas = new DataTable();

            string strNombreSP = "ListarInformacionServiciosInmueble";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", 1));
            lstParametros.Add(new SqlParameter("@IdInmuble", idInmueble));

            dtInfoPoliticas = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtInfoPoliticas;
        }

        public DataTable comentariosInmueble(String IdInmueble)
        {
            DataTable dt = new DataTable();

            string strNombreSP = "comentariosInmueble";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@IdInmueble", IdInmueble));

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();

            string strNombreSP = "CRUDCategorias";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Accion", 1));

            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public void agregarCategorias(String Categoria)
        {

            try
            {
                string strNombreSP = "CRUDCategorias";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@Accion", 2));
                lstParametros.Add(new SqlParameter("@Categoria", Categoria));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
