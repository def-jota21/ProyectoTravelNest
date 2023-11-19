using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocios
{
    public class Politicas
    {
        ConexionSQL conexionBD = new ConexionSQL();

        int? idPolitica = null;

        string titulo = null;
        string contenido = null;
        string textoAdicional = null;

        string instruccion = null;

        #region "Propiedades"

        public int? IdPolitica { get => idPolitica; set => idPolitica = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string TextoAdicional { get => textoAdicional; set => textoAdicional = value; }
        public string Instruccion { get => instruccion; set => instruccion = value; }

        #endregion

        #region "Metodos"

        public DataSet ObtenerPoliticasDesdeBD()
        {
            Instruccion = "Read";
            return conexionBD.ObtenerPoliticas(Instruccion);
        }

        public DataSet ObtenerPoliticaPorID()
        {
            Instruccion = "ReadID";
            return conexionBD.ObtenerPoliticasPorID(Instruccion, idPolitica);
        }

        public void CRUDPoliticas()
        {
            conexionBD.CRUDPoliticas(IdPolitica, Titulo, Contenido, TextoAdicional, Instruccion);
        }

        public void ValidarEdicion()
        {
            if (string.IsNullOrEmpty(IdPolitica?.ToString()) || string.IsNullOrEmpty(Titulo) ||
                                                                string.IsNullOrEmpty(Contenido) ||
                                                                string.IsNullOrEmpty(TextoAdicional))
            {
                throw new Exception("Todos los campos son obligatorios!");
            }

        }

        #endregion
    }
}
