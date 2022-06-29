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
    public class PacienteDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public List<Referencia> ObtenerReferencias()
        {
            List<Referencia> listaReferencia = new List<Referencia>();
            try
            {
                string procedure = "sp_ObtenerReferencias";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Referencia rerefencia = new Referencia();
                        //usuario.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        rerefencia.idReferencia = Convert.ToInt32(dr["idReferencia"]);
                        rerefencia.descripcion = dr["descripcion"].ToString();

                        listaReferencia.Add(rerefencia);
                    }
                    return listaReferencia;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en Obtener referencia DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        public void ActualizarDatosPaciente(Usuario user)
        {
            try
            {
                string procedure = "sp_ActualizarPaciente";
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
                comando.Parameters.AddWithValue("@ocupacion", user.ocupacion);
                comando.Parameters.AddWithValue("@referencia", user.idReferencia);
                //comando.Parameters.AddWithValue("@referencia", user.idReferencia);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error en Actualizar Paciente DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        //BUSCAR USUARIO POR DNI
        public Usuario BuscarUsuario(SqlDataReader dread)
        {
            var usuario = new Usuario();
            if (!dread.IsDBNull(0)) //asigna el primer campo de la tabla a lo que se obteiene por GET
            {
                usuario.idUsuario = dread.GetInt32(0);
            }
            if (!dread.IsDBNull(1))
            {
                usuario.apellido = dread.GetString(1);
            }
            if (!dread.IsDBNull(2))
            {
                usuario.nombre = dread.GetString(2);
            }
            if (!dread.IsDBNull(3))
            {
                usuario.dni = dread.GetString(3);
            }
            if (!dread.IsDBNull(4))
            {
                usuario.email = dread.GetString(4);
            }
            if (!dread.IsDBNull(5))
            {
                usuario.pass = dread.GetString(5);
            }
            if (!dread.IsDBNull(6))
            {
                usuario.direccion = dread.GetString(6);
            }
            if (!dread.IsDBNull(7))
            {
                usuario.telefono = dread.GetString(7);
            }
            if (!dread.IsDBNull(8))
            {
                usuario.ocupacion = dread.GetString(8);
            }
            if (!dread.IsDBNull(9))
            {
                usuario.fechaIngreso = dread.GetDateTime(9);
            }
            if (!dread.IsDBNull(10))
            {
                usuario.fechaNacimiento = dread.GetDateTime(10);
            }
            if (!dread.IsDBNull(11))
            {
                usuario.matricula = dread.GetString(11);
            }
            if (!dread.IsDBNull(12))
            {
                usuario.esAdmin = dread.GetBoolean(12);
            }
            if (!dread.IsDBNull(13))
            {
                usuario.cuentaConfirmada = dread.GetBoolean(13);
            }
            if (!dread.IsDBNull(14))
            {
                usuario.idRol = dread.GetInt32(14); //rol
            }
            if (!dread.IsDBNull(15))
            {
                usuario.idReferencia = dread.GetInt32(15);
            }
            //if (!dread.IsDBNull(15))
            //{
            //    usuario.Referencia.idReferencia = dread.GetInt32(15);
            //}
            if (!dread.IsDBNull(16))
            {
                usuario.idObraSocial = dread.GetInt32(16);
            }
            if (!dread.IsDBNull(17))
            {
                usuario.idEspecialidad = dread.GetInt32(17);
            }
            return usuario;
        }

        //BUSCAR PACIENTE POR DNI
        public Usuario BuscarPacienteDni(string dni)
        {
            Usuario u = null;
            //string passEncriptada = DAL.EncryptKeys.EncriptarPassword(pass, "Keys");
            try
            {
                string procedure = "sp_ObtenerPacienteDNI";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@dni", dni);

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    u = BuscarUsuario(dr);
                }
                Conexion.CerrarConexion();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        //obtener TURNOS PROXIMOS
        public List<ObtenerTurnosPacienteDTO> ObtenerTurnosPaciente(int idPaciente)
        {
            try
            {
                string procedure = "sp_ObtenerTurnosProximosPacienteDTO";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                comando.ExecuteNonQuery();

                List<ObtenerTurnosPacienteDTO> listaTurnosDto = new List<ObtenerTurnosPacienteDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosPacienteDTO turno = new ObtenerTurnosPacienteDTO();
                        turno.idTurno = Convert.ToInt32(dr["idTurno"]);
                        //turno.fechaTurno = Convert.ToDateTime(dr["Fecha"]);
                        turno.fechaTurno = dr["Fecha"].ToString().Substring(0,10);
                        turno.horaTurno = dr["Hora"].ToString();
                        turno.descripcion = dr["Descripcion"].ToString();
                        turno.profesional = dr["Profesional"].ToString();
                        turno.especialidad = dr["Especialidad"].ToString();
                        turno.obraSocial = dr["ObraSocial"].ToString();
                        turno.estado = dr["Estado"].ToString() == "True" ? turno.estado = "Activo" : turno.estado = "Cancelado";
                        listaTurnosDto.Add(turno);
                    }
                    return listaTurnosDto;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar TurnoPacienteDto DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //obtener TURNOS HISTORICOS
        public List<ObtenerTurnosPacienteDTO> ObtenerTurnosHistoricosPaciente(int idPaciente)
        {
            try
            {
                string procedure = "sp_ObtenerTurnosPacienteDTO";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPaciente", idPaciente);
                comando.ExecuteNonQuery();

                List<ObtenerTurnosPacienteDTO> listaTurnosDto = new List<ObtenerTurnosPacienteDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosPacienteDTO turno = new ObtenerTurnosPacienteDTO();
                        turno.idTurno = Convert.ToInt32(dr["idTurno"]);
                        //turno.fechaTurno = Convert.ToDateTime(dr["Fecha"]);
                        turno.fechaTurno = dr["Fecha"].ToString().Substring(0, 10);
                        turno.horaTurno = dr["Hora"].ToString();
                        turno.descripcion = dr["Descripcion"].ToString();
                        turno.profesional = dr["Profesional"].ToString();
                        turno.especialidad = dr["Especialidad"].ToString();
                        turno.obraSocial = dr["ObraSocial"].ToString();
                        turno.estado = dr["Estado"].ToString() == "True" ? turno.estado = "Activo" : turno.estado = "Cancelado";
                        turno.atencion = dr["Atencion"].ToString(); //== "True" ? turno.atencion = "Atendido" : turno.atencion = "No Atendido";
                        if (turno.atencion.Equals(null))
                        {
                            turno.atencion = "Sin dato";
                        }
                        if (turno.atencion == "1")
                        {
                            turno.atencion = "Atendido";
                        }
                        if (turno.atencion == "0")
                        {
                            turno.atencion = "No atendido";
                        }
                            //if (dr["Estado"].ToString() == "NULL")
                            //{
                            //    turno.atencion = "Sin dato";
                            //}
                            //if (dr["Estado"].ToString() == "True")
                            //{
                            //    turno.atencion = "Atendido";
                            //}
                            //if (dr["Estado"].ToString() == "False")
                            //{
                            //    turno.atencion = "No atendido";
                            //}


                            listaTurnosDto.Add(turno);
                    }
                    return listaTurnosDto;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar TurnoPacienteDto DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }




    }
}
