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

        //BUSCAR USUARIO POR DNI
        public Usuario BuscarUsuario(SqlDataReader dread)
        {
            var usuario = new Usuario();
            if (!dread.IsDBNull(0)) 
                //asigna el primer campo de la tabla a lo que se obteiene por GET
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

        //BUSCAR PROFESIONAL POR DNI
        public Usuario BuscarProfesionalDni(string dni)
        {
            Usuario u = null;
            //string passEncriptada = DAL.EncryptKeys.EncriptarPassword(pass, "Keys");
            try
            {
                string procedure = "sp_ObtenerProfesionalDNI";
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

        public List<ObtenerProfesionalDTO> ObtenerListaProfesionales()
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

        public List<Usuario> ObtenerProfesionalId(int id)
        {
            try
            {
                string procedure = "sp_ObtenerProfesionalId";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idProfesional", id);
                comando.CommandType = CommandType.StoredProcedure;

                List<Usuario> ListaProfesionales = new List<Usuario>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario profesionales = new Usuario();
                        
                        if (!dr.IsDBNull(0)) 
                        {
                            profesionales.idUsuario = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            profesionales.nombre = dr.GetString(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            profesionales.apellido = dr.GetString(2);
                        }
                        //if (!dr.IsDBNull(3))
                        //{
                        //    profesionales.inicio = dr.GetString(3);
                        //}
                        //if (!dr.IsDBNull(4))
                        //{
                        //    profesionales.fin = dr.GetString(4);
                        //}
                        //if (!dr.IsDBNull(5))
                        //{
                        //    profesionales.profesional = dr.GetString(5);
                        //}
                        ListaProfesionales.Add(profesionales);
                    }
                    return ListaProfesionales;
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

        //obtener lista de turnos por paciente
        public List<ObtenerTurnosProfesionalDTO> ObtenerTurnosProfesionalPorPaciente(int idProfesional, string dni)
        {
            try
            {
                string procedure = "sp_ObtenerTurnosProfesionalDTO";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idProfesional", idProfesional);
                comando.Parameters.AddWithValue("@dni", dni);
                comando.ExecuteNonQuery();

                List<ObtenerTurnosProfesionalDTO> listaTurnosDto = new List<ObtenerTurnosProfesionalDTO>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosProfesionalDTO turno = new ObtenerTurnosProfesionalDTO();
                        turno.idTurno = Convert.ToInt32(dr["idTurno"]);
                        //turno.fechaTurno = Convert.ToDateTime(dr["Fecha"]);
                        turno.fechaTurno = dr["Fecha"].ToString().Substring(0,10);//ver como cambiar el mostrado de la fecha
                        turno.horaTurno = dr["Hora"].ToString();
                        turno.descripcion = dr["Descripcion"].ToString();
                        turno.paciente = dr["Paciente"].ToString();                        
                        turno.obraSocial = dr["ObraSocial"].ToString();
                        turno.estado = dr["Estado"].ToString() == "True" ? turno.estado = "Activo" : turno.estado = "Cancelado";
                        
                        listaTurnosDto.Add(turno);
                    }
                    return listaTurnosDto;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar TurnoProfesionalPacienteDto DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


    }
}
