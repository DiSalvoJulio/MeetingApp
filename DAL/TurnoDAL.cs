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
    public class TurnoDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        //obtener lista de turnos
        public List<Turno> ObtenerTurnos()
        {
            List<Turno> listaTurnos = new List<Turno>();
            try
            {
                string procedure = "sp_ObtenerTurnos";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Turno turno = new Turno();                        
                        turno.idTurno = Convert.ToInt32(dr["idTurno"]);
                        turno.descripcion = dr["descripcion"].ToString();
                        turno.horaTurno = dr["horaTurno"].ToString();
                        turno.fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]);
                        turno.activo = Convert.ToBoolean(dr["activo"]);
                        turno.idFormaPago = Convert.ToInt32(dr["idTurno"]);
                        turno.idUsuarioPaciente = Convert.ToInt32(dr["idUsuarioPaciente"]);
                        turno.idHorarioProfesional = Convert.ToInt32(dr["idHorarioProfesional"]);

                        listaTurnos.Add(turno);
                    }
                    return listaTurnos;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en Obtener Turno DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //obtener lista de profesionales por especialidad
        public List<Usuario> ObtenerProfesionalesXEspecialidad(int idEspecialidad)
        {
            try
            {
                string procedure = "sp_ObtenerProfesionalXEspecialidad";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                comando.ExecuteNonQuery();

                List<Usuario> listaProfesionales = new List<Usuario>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario prof = new Usuario();
                        prof.idUsuario = int.Parse(dr["IdProfesional"].ToString());
                        prof.apellido = dr["Profesional"].ToString();
                        //dentro del appellido esta concatenado apellido + nombre
                        listaProfesionales.Add(prof);
                    }
                    return listaProfesionales;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar ProfesionalesXEspecialidad DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //obtener lista de profesionales por especialidad
        public List<ObtenerTurnoDTO> ObtenerTurnoPorProfesionalYEspecialidad(int idProfesional, int idEspecialidad, DateTime dia)
        {
            try
            {
                string procedure = "sp_ObtenerTurnosDTO";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                comando.Parameters.AddWithValue("@idProfesional", idProfesional);
                comando.Parameters.AddWithValue("@dia", dia);
                comando.ExecuteNonQuery();

                List<ObtenerTurnoDTO> listaTurnosDto = new List<ObtenerTurnoDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnoDTO turno = new ObtenerTurnoDTO();
                        turno.idTurno = Convert.ToInt32(dr["idTurno"]);
                        turno.descripcion = dr["descripcion"].ToString();
                        turno.horaTurno = dr["horaTurno"].ToString();
                        turno.fechaSolicitud = Convert.ToDateTime(dr["fechaSolicitud"]);                       
                        turno.profesional = dr["Profesional"].ToString();
                        turno.paciente = dr["Paciente"].ToString();
                        turno.especialidad = dr["Especialidad"].ToString();
                        listaTurnosDto.Add(turno);
                    }
                    return listaTurnosDto;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar TurnoDto DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }






    }
}
