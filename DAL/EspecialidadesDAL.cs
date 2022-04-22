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
    public class EspecialidadesDAL
    {

        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public List<Especialidad> ObtenerEspecialidades()
        {
            try
            {
                string procedure = "sp_ObtenerEspecialidades";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;

                List<Especialidad> listaEspecialidad = new List<Especialidad>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Especialidad espe = new Especialidad();
                        espe.idEspecialidad = int.Parse(dr["idEspecialidad"].ToString());
                        espe.descripcion = dr["descripcion"].ToString();
                        listaEspecialidad.Add(espe);
                    }
                    return listaEspecialidad;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar especialidadDAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }
    }
}
