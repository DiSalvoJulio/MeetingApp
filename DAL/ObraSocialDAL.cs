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
    public class ObraSocialDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

        public void InsertarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                string procedure = "sp_InsertarObraSocial";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", obraSocial.descripcion);
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en Insertar Obra Social " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        public List<ObraSocial> ObtenerObraSocial()
        {
            try
            {
                string procedure = "sp_ObtenerObrasSociales";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;

                List<ObraSocial> listaObraSocial = new List<ObraSocial>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObraSocial obraS = new ObraSocial();
                        obraS.idObraSocial = int.Parse(dr["idObraSocial"].ToString());
                        obraS.descripcion = dr["descripcion"].ToString();
                        listaObraSocial.Add(obraS);
                    }
                    return listaObraSocial;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en cargar ObraSocialDAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }


        public ObraSocial BuscarObraSocial(SqlDataReader dr)
        {
            var obraS = new ObraSocial();
            if (!dr.IsDBNull(0))
            {
                obraS.idObraSocial = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1))
            {
                obraS.descripcion = dr.GetString(1);
            }
            return obraS;
        }

        public ObraSocial SeleccionarIdObraSocial(int obraS)
        {
            ObraSocial obraSocial = new ObraSocial();
            try
            {
                string procedure = "sp_ObtenerIdObraSocial";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idObraSocial", obraS);
                comando.ExecuteNonQuery();
                SqlDataReader dread = comando.ExecuteReader();

                if (dread.Read())
                {
                    obraSocial = BuscarObraSocial(dread);
                }
                Conexion.CerrarConexion();
                return obraSocial;

            }
            catch (Exception ex)
            {
                throw new Exception("Error en obtener id obraSocial " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //VALIDAR NOMBRE OBRA SOCIAL
        public bool ValidarNombreObraSocial(ObraSocial obraS)
        {
            try
            {
                string procedure = "sp_ValidarNombreObraSocial";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@descripcion", obraS.descripcion);

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
                throw new Exception("Error en validar nombre ObraSocial " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //MODIFICAR OBRA SOCIAL
        public void ActualizarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                string procedure = "sp_ActualizarObraSocial";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idObraSocial", obraSocial.idObraSocial);
                comando.Parameters.AddWithValue("@descripcion", obraSocial.descripcion);
                //comando.Parameters.AddWithValue("@activo", rubro.activo);
                comando.ExecuteNonQuery();
                //ExecuteNonQuery: consultar estructura o crear objetos.
            }
            catch (Exception ex)
            {
                throw new Exception("Error en actualizar ObraSocial " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //ELIMINAR OBRA SOCIAL
        public void EliminarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                string procedure = "sp_EliminarObraSocial";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idObraSocial", obraSocial.idObraSocial);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en eliminar obra social " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

    }
}
