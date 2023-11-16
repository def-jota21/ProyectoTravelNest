using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Negocio_Comentarios
    {
        public DataTable ListarComentarioPendientesAnfitrion(string idDueno)
        {
            DataTable dtComentarioPendientesAnfitrion = new DataTable();

            string strNombreSP = "ListarComentarioPendientesAnfitrion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@idAnfitrion", idDueno));

            dtComentarioPendientesAnfitrion = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtComentarioPendientesAnfitrion;
        }

        public void realizarComentarioaHuesped(string idAnfitrion, string idHuesped, string Comentario, int limpieza, int calificion, int idReservacion)
        {
            string strNombreSP = "comentarioAHuesped";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@idAnfitrion", idAnfitrion));
            lstParametros.Add(new SqlParameter("@idHuesped", idHuesped));
            lstParametros.Add(new SqlParameter("@Comentario", Comentario));
            lstParametros.Add(new SqlParameter("@Limpieza", limpieza));
            lstParametros.Add(new SqlParameter("@Calificacion", calificion));
            lstParametros.Add(new SqlParameter("@idReservacion", idReservacion));

            Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
        }

        public DataTable ListarComentarioPendientesHuesped(string idHuesped)
        {
            DataTable dtComentarioPendientesHuesped = new DataTable();

            string strNombreSP = "ListarComentarioPendientesHuesped";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@idHuesped", idHuesped));

            dtComentarioPendientesHuesped = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dtComentarioPendientesHuesped;
        }

        public void realizarComentarioaAnfitrion(string idAnfitrion, string idHuespedAutor, string Comentario, int comunicacion, int calificion, int idReservacion)
        {
            string strNombreSP = "comentarioAAnfitrion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@idAnfitrion", idAnfitrion));
            lstParametros.Add(new SqlParameter("@idHuesped", idHuespedAutor));
            lstParametros.Add(new SqlParameter("@Comentario", Comentario));
            lstParametros.Add(new SqlParameter("@Comunicacion", comunicacion));
            lstParametros.Add(new SqlParameter("@Calificacion", calificion));
            lstParametros.Add(new SqlParameter("@idReservacion", idReservacion));

            Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
        }

        // Pagina Comentarios y calificacion
        public DataTable getInfoUsuario(string IdUsuario)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "ComentarioCalificacion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Info"));
            lstParametros.Add(new SqlParameter("@IdUsuarioDestinado", IdUsuario));
            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }

        public DataTable cargarComentarios(string IdUsuario)
        {
            DataTable dt = new DataTable();
            string strNombreSP = "ComentarioCalificacion";
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@Opcion", "Comentario"));
            lstParametros.Add(new SqlParameter("@IdUsuarioDestinado", IdUsuario));
            dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

            return dt;
        }
    }
}
