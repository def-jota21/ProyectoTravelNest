using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Negocio_Cupon
    {
        public DataTable ListarCuponGestor()
        {
            DataTable listarCupon = new DataTable();
            try
            {
                listarCupon = Datos.ConexionSQL.ExecuteQueryTableGeneral("ObtenerCuponesGestor");
            }
            catch (Exception)
            {

               
            }

            return listarCupon;

        }

        public List<Cupon> ListarCuponHuesped(string idUsuario)
        {
            List<Cupon> cupones = new List<Cupon>();
            try
            {
                string strNombreSP = "ObtenerCuponesHuesped";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@IdHuesped", idUsuario));

                DataTable dataTable = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);

                
                cupones = dataTable.AsEnumerable().Select(row => new Cupon
                {
                    IdCupon = row.Field<string>("IdCupon"),
                    NombreCupon = row.Field<string>("IdCupon"),
                    PorcentajeDescuento = row.Field<int>("PorcentajeDescuento")
                }).ToList();
            }
            catch (Exception)
            {
                
            }

            return cupones;
        }

        public DataTable ListarCuponHuespedP(string idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                string strNombreSP = "ListarCuponesHuesped";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@idHuesped", idUsuario));

                dt = Datos.ConexionSQL.ExecuteQueryTable(strNombreSP, lstParametros);


            }
            catch (Exception)
            {

            }

            return dt;
        }

        public void AgregarCupones(int Cantidad)
        {

            try
            {
                string strNombreSP = "GenerarCupones";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@CantidadCupones", Cantidad));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (Exception)
            {

                
            }
            
        }

        public void UsarCupon(string idCupon, string idUsuario)
        {
            try
            {
                string strNombreSP = "CambiarEstadoCupon";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@IdHuesped", idUsuario));
                lstParametros.Add(new SqlParameter("@IdCupon", idCupon));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (Exception)
            {


            }

        }

        public void ValidarFechasReserva(string idUsuario, string idInmueble, string FechaInicio, string FechaSalida)
        {
            try
            {
                string strNombreSP = "ValidarDisponibilidadAntesReservar";
                List<SqlParameter> lstParametros = new List<SqlParameter>();
                lstParametros.Add(new SqlParameter("@IdUsario", idUsuario));
                lstParametros.Add(new SqlParameter("@IdInmueble", idInmueble));
                lstParametros.Add(new SqlParameter("@FechaEntrada", FechaInicio));
                lstParametros.Add(new SqlParameter("@FechaSalida", FechaSalida));

                Datos.ConexionSQL.ExecuteQuery(strNombreSP, lstParametros);
            }
            catch (Exception)
            {
                    throw;
            }
        }
    }
}
public class Cupon
{
    public string IdCupon { get; set; }
    public string NombreCupon { get; set; }
    public int PorcentajeDescuento { get; set; }
}
