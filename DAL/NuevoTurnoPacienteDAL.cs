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
    public class NuevoTurnoPacienteDAL
    {
        //private static SqlDataReader dr = null;
        //private static DataTable dt = new DataTable();
        //private static SqlCommand comando = new SqlCommand();

        //public List<Usuario> ObtenerProfesionalesXEspecialidad(int idEspecialidad)
        //{
        //    try
        //    {
        //        string procedure = "sp_ObtenerProfesionalXEspecialidad";
        //        comando.Connection = Conexion.AbrirConexion();
        //        comando.CommandText = procedure;
        //        comando.Parameters.Clear();
        //        comando.CommandType = CommandType.StoredProcedure;
        //        comando.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
        //        comando.ExecuteNonQuery();

        //        List<Usuario> listaProfesionales = new List<Usuario>();

        //        using (SqlDataReader dr = comando.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                Usuario prof = new Usuario();
        //                prof.idUsuario = int.Parse(dr["IdProfesional"].ToString());
        //                prof.apellido = dr["Profesional"].ToString();   
        //                //prof.nombre = dr["Nombre"].ToString();
        //                listaProfesionales.Add(prof);
        //            }
        //            return listaProfesionales;
        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Error en cargar ProfesionalesXEspecialidad DAL " + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.CerrarConexion();
        //    }
        //}






    }
}
