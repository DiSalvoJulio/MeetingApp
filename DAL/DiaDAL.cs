using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DiaDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public List<Dia> ObtenerDias()
        {
            try
            {
                string procedure = "sp_ObtenerDias";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;

                List<Dia> listaDias = new List<Dia>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dia dia = new Dia();
                        dia.idDia = int.Parse(dr["idDia"].ToString());
                        dia.descripcion = dr["descripcion"].ToString();
                        listaDias.Add(dia);
                    }
                    return listaDias;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar dia DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }
    }
}
