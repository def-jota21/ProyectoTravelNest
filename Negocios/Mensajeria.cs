using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Mensajeria
    {
        private MensajeriaBD DataMensajeria = new MensajeriaBD();

        public DataSet GetDataReservasActivas(string idUsuarioHuesped, string Instruccion)
        {
            DataSet dsDataReserva = DataMensajeria.GetDataReservas(idUsuarioHuesped, Instruccion);

            // Recorre todas las tablas y filas del DataSet para limpiar los campos que contenegan espacios vacios en ellos.

            foreach (DataTable table in dsDataReserva.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (row[i] != DBNull.Value && row[i] is string)
                        {
                            // Limpia el campo eliminando espacios en blanco al final.
                            row[i] = ((string)row[i]).Trim();
                        }
                    }
                }
            }

            return dsDataReserva;
        }

        public void InsertMessage(string idEmisor, string idReceptor, string mensaje)
        {
            DataMensajeria.InsertMessageToBD(idEmisor, idReceptor, mensaje);
        }

        public DataSet GetMessagesFromBD(string idRecuperado, string idUsuario)
        {
            return DataMensajeria.GetMessagesFromBD(idRecuperado, idUsuario);
        }
    }
}
