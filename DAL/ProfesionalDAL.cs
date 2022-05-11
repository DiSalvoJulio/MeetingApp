using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Entidades.DTOs;

namespace DAL
{
    public class ProfesionalDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public void ActualizarDatosProfesional(Usuario user)
        {
            try
            {
                string procedure = "sp_ActualizarProfesional";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idUsuario", user.idUsuario);
                comando.Parameters.AddWithValue("@apellido", user.apellido);
                comando.Parameters.AddWithValue("@nombre", user.nombre);
                comando.Parameters.AddWithValue("@fechaNacimiento", user.fechaNacimiento);
                comando.Parameters.AddWithValue("@telefono", user.telefono);
                comando.Parameters.AddWithValue("@direccion", user.direccion);
                //comando.Parameters.AddWithValue("@pass", user.pass);
                comando.Parameters.AddWithValue("@idEspecialidad", user.idEspecialidad);
                comando.Parameters.AddWithValue("@matricula", user.matricula);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Actualizar Profesional DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        public List<ObtenerProfesionalDTO> BuscarProfesional()
        {
            try
            {
                string procedure = "sp_ObtenerProfesional";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;

                List<ObtenerProfesionalDTO> listaProfesional = new List<ObtenerProfesionalDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerProfesionalDTO obtProf = new ObtenerProfesionalDTO();
                        //obtProf.idProfesional = int.Parse(dr["idUsuario"].ToString());
                        //obtProf.NombreApellido = dr["Profesional"].ToString();
                        if (!dr.IsDBNull(0)) //asigna el primer campo de la tabla a lo que se obteiene por GET
                        {
                            obtProf.idProfesional = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            obtProf.NombreApellido = dr.GetString(1);
                        }
                        listaProfesional.Add(obtProf);
                    }
                    return listaProfesional;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Buscar Profesional DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }

    }
}
