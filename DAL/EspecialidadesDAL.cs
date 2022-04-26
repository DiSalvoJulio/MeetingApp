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

        public void InsertarEspecialidad(Especialidad especialidad)
        {
            try
            {
                string procedure = "sp_InsertarEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", especialidad.descripcion);
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar Especialidad " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

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


        public Especialidad BuscarEspecialidad(SqlDataReader dr)
        {
            var espe = new Especialidad();
            if (!dr.IsDBNull(0))
            {
                espe.idEspecialidad = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1))
            {
                espe.descripcion = dr.GetString(1);
            }           
            return espe;
        }

        public Especialidad SeleccionarIdEspecialidad(int espe)
        {
            Especialidad especialidad = new Especialidad();
            try
            {
                string procedure = "sp_ObetenerIdEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idEspecialidad", espe);
                comando.ExecuteNonQuery();
                SqlDataReader dread = comando.ExecuteReader();

                if (dread.Read())
                {
                    especialidad = BuscarEspecialidad(dread);
                }
                Conexion.CerrarConexion();
                return especialidad;

            }
            catch (Exception ex)
            {              
                throw new Exception("Error en obtener id especialidad " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //VALIDAR NOMBRE ESPECIALIDAD
        public bool ValidarNombreEspecialidad(Especialidad espe)
        {
            try
            {
                string procedure = "sp_ValidarNombreEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", espe.descripcion);

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error en validar nombre especialidad " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //MODIFICAR ESPECIALIDAD
        public void ActualizarEspecialidad(Especialidad especialidad)
        {
            try
            {
                string procedure = "sp_ActualizarEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idEspecialidad", especialidad.idEspecialidad);
                comando.Parameters.AddWithValue("@descripcion", especialidad.descripcion);
                //comando.Parameters.AddWithValue("@activo", rubro.activo);
                comando.ExecuteNonQuery();
                //ExecuteNonQuery: consultar estructura o crear objetos.
            }
            catch (Exception ex)
            {
                throw new Exception("Error en actualizar especialidad " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //ELIMINAR ESPECIALIDAD
        public void EliminarEspecialidad(Especialidad especialidad)
        {
            try
            {
                string procedure = "sp_EliminarEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idEspecialidad", especialidad.idEspecialidad);                             
                comando.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw new Exception("Error en eliminar especialidad " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }



    }
}
