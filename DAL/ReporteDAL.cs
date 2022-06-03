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
    public class ReporteDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();


        //REPORTE 1
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosActivosPorFechas(DateTime fecha1, DateTime fecha2)
        {
            try
            {
                string proc = "sp_Rep1_TurnosActivosPorFechas";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = proc;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaMin", fecha1);
                comando.Parameters.AddWithValue("@fechaMax", fecha2);
                comando.ExecuteNonQuery();

                List<ObtenerTurnosActivosPorFechasDTO> lista = new List<ObtenerTurnosActivosPorFechasDTO>();


                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosActivosPorFechasDTO obtenerActivos = new ObtenerTurnosActivosPorFechasDTO();
                        obtenerActivos.fecha = (dr["Fecha"]).ToString().Substring(0,10);
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

        //REPORTE 2
        public List<ObtenerFormasDePagosDTO> ObtenerFormasDePagos(int mes)
        {
            
            try
            {
                string proc = "sp_rep2_FormasDePagoAgrupadasPorMes";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = proc;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@mes", mes);
                comando.ExecuteNonQuery();

                List<ObtenerFormasDePagosDTO> lista = new List<ObtenerFormasDePagosDTO>();


                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerFormasDePagosDTO obtenerTurnos = new ObtenerFormasDePagosDTO();                        

                        obtenerTurnos.cantidad = int.Parse(dr["Cantidad"].ToString());
                        obtenerTurnos.descripcion = dr["descripcion"].ToString();

                        lista.Add(obtenerTurnos);                        
                    
                    }
                }
                return lista;
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



        //REPORTE 3
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosCanceladosPorFechas(DateTime fecha1, DateTime fecha2)
        {
            try
            {
                string proc = "sp_Rep3_TurnosCanceladosPorFechas";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = proc;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaMin", fecha1);
                comando.Parameters.AddWithValue("@fechaMax", fecha2);
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
                throw new Exception("Error en obtenerCancelados " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }


        //REPORTE 4
        public List<ObtenerTurnosPorMesDTO> ObtenerTurnosPorMes(int mes)
        {
            try
            {
                string proc = "sp_Rep4_PacientesPorMes";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = proc;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@mes", mes);                
                comando.ExecuteNonQuery();

                List<ObtenerTurnosPorMesDTO> lista = new List<ObtenerTurnosPorMesDTO>();


                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObtenerTurnosPorMesDTO obtenerTurnos = new ObtenerTurnosPorMesDTO();
                        obtenerTurnos.paciente = dr["Paciente"].ToString();
                        obtenerTurnos.cantidadTurnos = int.Parse(dr["CantidadTurnos"].ToString());                        

                        lista.Add(obtenerTurnos);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en obtener cantidad de pacientes por mes " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }





    }
}
