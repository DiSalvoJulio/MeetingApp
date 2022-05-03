using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();

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

        //BUSCAR USUARIO
        public Usuario BuscarUsuarioDni(string dni)
        {
            Usuario u = null;
            //string passEncriptada = DAL.EncryptKeys.EncriptarPassword(pass, "Keys");
            try
            {
                string procedure = "sp_ObtenerUsuario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@dato", dni);

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    u = BuscarUsuario(dr);
                }                
                return u;
            }
            catch (Exception ex)
            {               
                throw new Exception("Error en Buscar Usuario DAL " + ex.Message);            
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }





    }
}
