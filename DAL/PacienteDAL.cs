﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public static class PacienteDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();


        public static void ActualizarDatosPaciente(Usuario user)
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






    }
}
