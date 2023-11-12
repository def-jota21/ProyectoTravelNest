using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
    public class Neg_Reservaciones
    {
        public DataTable ObtenerReservaciones(int IdUsuario)
        {
            string spName = "SP_ObtenerReservaciones";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));

            Datos.ConexionSQL connection = new Datos.ConexionSQL();
            DataTable reservaciones = connection.ExecuteSPWithDT(spName, parameters);

            return reservaciones;
        }
    }
}
