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

        //insertar turno nuevo
        public bool InsertarTurno(Turno turno)
        {
            try
            {
                string procedure = "sp_InsertarTurno";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", turno.descripcion);
                comando.Parameters.AddWithValue("@horaTurno", turno.horaTurno);
                comando.Parameters.AddWithValue("@fechaSolicitud", turno.fechaSolicitud);
                comando.Parameters.AddWithValue("@idFormaPago", turno.idFormaPago);
                comando.Parameters.AddWithValue("@idUsuarioPaciente", turno.idUsuarioPaciente);
                comando.Parameters.AddWithValue("@idHorarioProfesional", turno.idHorarioProfesional);
                comando.Parameters.AddWithValue("@fechaTurno", turno.fechaTurno);
                comando.Parameters.AddWithValue("@idObraSocial", turno.idObraSocial);
                comando.Parameters.AddWithValue("@idEspecialidad", turno.idEspecialidad);

                comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar Turno " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

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
        public List<ObtenerTurnoDTO> ObtenerTurnoPorProfesionalYEspecialidad(int idHorarioProfesional, DateTime dia)
        {
            try
            {
                string procedure = "sp_ObtenerTurnosDTO";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idHorarioProfesional", idHorarioProfesional);
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


        //obtener formas de pago
        public List<FormaPago> ObtenerFormasDePagos()
        {
            List<FormaPago> listaFormasPago = new List<FormaPago>();
            try
            {
                string procedure = "sp_ObtenerFormasDePago";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FormaPago formaPago = new FormaPago();
                        formaPago.idFormaPago = Convert.ToInt32(dr["idFormaPago"]);
                        formaPago.descripcion = dr["descripcion"].ToString();

                        listaFormasPago.Add(formaPago);
                    }
                    return listaFormasPago;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Obtener Formas de Pago DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //obtener un turno por id
        public ObtenerTurnoIdDTO ObtenerTurnoId(int idTurno)
        {
            try
            {
                string procedure = "sp_ObtenerTurnoId";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idTurno", idTurno);
                comando.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    ObtenerTurnoIdDTO obtenerTurno = new ObtenerTurnoIdDTO();
                    while (dr.Read())
                    {
                        //obtProf.idProfesional = int.Parse(dr["idUsuario"].ToString());
                        //obtProf.NombreApellido = dr["Profesional"].ToString();
                        if (!dr.IsDBNull(0)) //asigna el primer campo de la tabla a lo que se obteiene por GET
                        {
                            obtenerTurno.idTurno = dr.GetInt32(0);
                        }
                        if (!dr.IsDBNull(1))
                        {
                            obtenerTurno.dia = dr.GetString(1);
                        }
                        if (!dr.IsDBNull(2))
                        {
                            obtenerTurno.fechaTurno = dr.GetDateTime(2);
                        }
                        if (!dr.IsDBNull(3))
                        {
                            obtenerTurno.horaTurno = dr.GetString(3);
                        }
                        if (!dr.IsDBNull(4))
                        {
                            obtenerTurno.descripcion = dr.GetString(4);
                        }
                        if (!dr.IsDBNull(5))
                        {
                            obtenerTurno.especialidad = dr.GetString(5);
                        }
                        if (!dr.IsDBNull(6))
                        {
                            obtenerTurno.profesional = dr.GetString(6);
                        }
                    }
                    return obtenerTurno;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Obtener Turno ID DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }
               

        //cancelar el turno
        public bool CancelarTurno(int idTurno)
        {
            try
            {
                string procedure = "sp_CancelarTurno";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idTurno", idTurno);

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
                throw new Exception("Error en Cancelar DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }

        //OBTENER TURNOS POR FECHAS
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosPorFecha(DateTime fecha)
        {
            try
            {
                string proc = "sp_ObtenerTurnosPorFechas";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = proc;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaMin", fecha);                
                comando.ExecuteNonQuery();

                List<ObtenerTurnosActivosPorFechasDTO> lista = new List<ObtenerTurnosActivosPorFechasDTO>();


                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosActivosPorFechasDTO obtenerActivos = new ObtenerTurnosActivosPorFechasDTO();
                        obtenerActivos.fecha = (dr["Fecha"]).ToString().Substring(0, 10);
                        obtenerActivos.hora = dr["Hora"].ToString();
                        obtenerActivos.paciente = dr["Paciente"].ToString();
                        obtenerActivos.obraSocial = dr["Obra Social"].ToString();
                        obtenerActivos.estado = dr["Estado"].ToString() == "True" ? obtenerActivos.estado = "Activo" : obtenerActivos.estado = "Cancelado";

                        lista.Add(obtenerActivos);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en obtenerActivos " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }


        //turnos atendidos
        public bool ActualizarAtencionTurno(int idTurno, bool atencion)
        {
            try
            {
                string procedure = "sp_ActualizarAtencionTurno";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idTurno", idTurno);
                comando.Parameters.AddWithValue("@atencion", atencion);

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
                throw new Exception("Error en actualizar atencion turno " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }


        //private List<String> cual(DateTime desde ,DateTime hasta,string hora)
        //{
        //    List<String> horarios = new List<string>();


        //    while (desde<hasta) {

        //        if (hora != desde.ToString("hh:mm"))
        //        {

        //            horarios.Add(desde.ToString("hh:mm"));
        //        }
        //        desde.AddHours(1);
            
        //    }

        //    return horarios;

        //}

        //class horariosDisp
        //{
        //    public DateTime fecha { get; set; }
        //    public string hora { get; set; }
        //    public int idpro { get; set; }

        //    public string nombre { get; set; }
        //    public string apellido { get; set; }

        //    public DateTime desde { get; set; }
        //    public DateTime hasta { get; set; }

        //}

        //class horarios
        //{
        //    public DateTime fecha { get; set; }
        //    public List<String> hora { get; set; }
            

        //    public string nombre { get; set; }
        //    public string apellido { get; set; }

          

        //}

        //private void a()
        //{
        //    List<horariosDisp> hd = new List<horariosDisp>();
        //    horariosDisp h = new horariosDisp();

        //    h.fecha = DateTime.Now;
        //    h.hora = "10:00";
        //    h.idpro = 1;
        //    h.nombre = "a";
        //    h.apellido = "b";
        //    h.desde = DateTime.Parse("09:00");
        //    h.hasta = DateTime.Parse("13:00");

        //    hd.Add(h);

        //    List<horarios> h2 = new List<horarios>();
        //    foreach(var a in hd)
        //    {
        //        List<String> horas = new List<String>();

        //        while (a.desde < a.hasta)
        //        {

        //            if (a.hora != a.desde.ToString("hh:mm"))
        //            {

        //                horas.Add(a.desde.ToString("hh:mm"));
        //            }
        //            a.desde.AddHours(1);

        //        }

        //        h2.Add(new horarios{
                
        //            fecha=a.fecha,
        //            hora=horas,
        //            nombre=a.nombre,
        //            apellido=a.apellido

        //        });


        //    }

        //    List<string> ho = new List<string>();

            

           // string hor = "23:59";
           //foreach(var a in  )
           // {
           //     if(DateTime.Parse(a.hora))
                

           // }


        //}


    }
}
