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
    public class HorarioDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public void InsertarHorario(Horario horario)
        {
            try
            {
                string procedure = "sp_InsertarHorario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@desde", horario.desde);
                comando.Parameters.AddWithValue("@hasta", horario.hasta);
                comando.Parameters.AddWithValue("@cantidad", horario.cantidad);
                comando.Parameters.AddWithValue("@idDia", horario.idDia);
                comando.Parameters.AddWithValue("@idUsuarioProfesional", horario.idUsuarioProfesional);
                comando.Parameters.AddWithValue("@turno", horario.turno);
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar Horario " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        public List<ObtenerHorarioDTO> ObtenerHorarios(int id)
        {
            try
            {
                string procedure = "sp_ObtenerHorarios";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idProfesional", id);
                comando.CommandType = CommandType.StoredProcedure;

                List<ObtenerHorarioDTO> ListaObtenerHorarios = new List<ObtenerHorarioDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerHorarioDTO obtenerHorarios = new ObtenerHorarioDTO();
                        //obtProf.idProfesional = int.Parse(dr["idUsuario"].ToString());
                        //obtProf.NombreApellido = dr["Profesional"].ToString();
                        if (!dr.IsDBNull(0)) //asigna el primer campo de la tabla a lo que se obteiene por GET
                        {
                            obtenerHorarios.idHorario = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            obtenerHorarios.dia = dr.GetString(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            obtenerHorarios.turno = dr.GetString(2);
                        }
                        if (!dr.IsDBNull(3))
                        {
                            obtenerHorarios.inicio = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            obtenerHorarios.fin = dr.GetString(4);
                        }
                        if (!dr.IsDBNull(5))
                        {
                            obtenerHorarios.profesional = dr.GetString(5);
                        }
                        ListaObtenerHorarios.Add(obtenerHorarios);
                    }
                    return ListaObtenerHorarios;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Buscar Horario DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        public void ActualizarHorario(int id, string desde, string hasta)
        {
            try
            {
                string procedure = "sp_ActualizarHorario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idHorario", id);
                comando.Parameters.AddWithValue("@desde", desde);
                comando.Parameters.AddWithValue("@hasta", hasta);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Actualizar Horario DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        public ObtenerHorarioDTO ObtenerHorarioId(int idHorario)
        {
            try
            {
                string procedure = "sp_ObtenerHorarioId";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idHorario", idHorario);
                comando.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    ObtenerHorarioDTO obtenerHorario = new ObtenerHorarioDTO();
                    while (dr.Read())
                    {
                        //obtProf.idProfesional = int.Parse(dr["idUsuario"].ToString());
                        //obtProf.NombreApellido = dr["Profesional"].ToString();
                        if (!dr.IsDBNull(0)) //asigna el primer campo de la tabla a lo que se obteiene por GET
                        {
                            obtenerHorario.dia = dr.GetString(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            obtenerHorario.turno = dr.GetString(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            obtenerHorario.inicio = dr.GetString(2);
                        }
                        if (!dr.IsDBNull(3))
                        {
                            obtenerHorario.fin = dr.GetString(3);
                        }
                    }
                    return obtenerHorario;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Buscar Horario DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        //ELIMINAR HORARIO
        public void EliminarHorario(Horario horario)
        {
            try
            {
                string procedure = "sp_EliminarHorario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idHorario", horario.idHorario);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en eliminar horario DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //VALIDAR HORARIO
        public bool ValidarHorario(Horario horario)
        {
            try
            {
                string procedure = "sp_ValidarHorario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idDia", horario.idDia);
                comando.Parameters.AddWithValue("@turno", horario.turno);

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
                throw new Exception("Error en validar horario DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        public List<ObtenerHorarioProfesionalDiaDTO> ObtenerHorarioProfesionalDia(int idProfesional, string dia)
        {
            try
            {
                string procedure = "sp_ObtenerHorarioPorProfesionalYDia";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idProfesional", idProfesional);
                comando.Parameters.AddWithValue("@dia", dia);
                comando.ExecuteNonQuery();

                List<ObtenerHorarioProfesionalDiaDTO> listaHorarios = new List<ObtenerHorarioProfesionalDiaDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerHorarioProfesionalDiaDTO horario = new ObtenerHorarioProfesionalDiaDTO();
                        horario.idHorario = Convert.ToInt32(dr["idHorario"]);
                        horario.desde = dr["desde"].ToString();
                        horario.hasta = dr["hasta"].ToString();
                        horario.cantidad = Convert.ToInt32(dr["cantidad"]);
                        horario.idProfesional = Convert.ToInt32(dr["idProfesional"]);
                        horario.dia = dr["dia"].ToString();
                        horario.turno = dr["turno"].ToString();
                        listaHorarios.Add(horario);
                    }
                    return listaHorarios;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar HorarioProfesionalDia DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


    }
}
