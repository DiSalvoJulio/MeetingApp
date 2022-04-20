﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class RegistrarDAL
    {
        private static SqlDataReader dr = null;
        private static DataTable dt = new DataTable();
        private static SqlCommand comando = new SqlCommand();


        public static void InsertarUsuario(Usuario usuario)
        {
            try
            {
                string procedure = "sp_InsertarUsuario";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@apellido", usuario.apellido);
                comando.Parameters.AddWithValue("@nombre", usuario.nombre);
                comando.Parameters.AddWithValue("@dni", usuario.dni);
                comando.Parameters.AddWithValue("@email", usuario.email);
                comando.Parameters.AddWithValue("@pass", usuario.pass);
                //comando.Parameters.AddWithValue("@pass", EncryptKeys.EncriptarPassword(usuario.pass, "Keys"));                
                //comando.Parameters.AddWithValue("@direccion", usuario.direccion);
                //comando.Parameters.AddWithValue("@telefono", usuario.telefono);
                //comando.Parameters.AddWithValue("@ocupacion", usuario.ocupacion);
                comando.Parameters.AddWithValue("@fechaIngreso", usuario.fechaIngreso);
                comando.Parameters.AddWithValue("@fechaNacimiento", usuario.fechaNacimiento);
                //comando.Parameters.AddWithValue("@matricula", usuario.matricula);
                //comando.Parameters.AddWithValue("@esAdmin", usuario.esAdmin);
                //comando.Parameters.AddWithValue("@cuentaConfirmada", usuario.cuentaConfirmada);
                comando.Parameters.AddWithValue("@idRol", usuario.idRol);
                //comando.Parameters.AddWithValue("@idReferencia", usuario.idReferencia);
                //comando.Parameters.AddWithValue("@idObraSocial", usuario.idObraSocial);
                //comando.Parameters.AddWithValue("@idEspecialidad", usuario.idEspecialidad);
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Error en Insertar Registrar DAL " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }
        }

        //BUSCAR USUARIO ANTES DE INICIAR SESION
        public static Usuario BuscarUsuario(SqlDataReader dread)
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
                usuario.idRol = dread.GetInt32(14);
            }
            if (!dread.IsDBNull(14))
            {
                usuario.idReferencia = dread.GetInt32(14);
            }
            if (!dread.IsDBNull(15))
            {
                usuario.idObraSocial = dread.GetInt32(15);
            }

            return usuario;
        }

        //INICIAR SESION
        public static Usuario UsuarioSesion(string usuario, string pass)
        {
            Usuario u = null;
            //string passEncriptada = DAL.EncryptKeys.EncriptarPassword(pass, "Keys");
            try
            {
                string procedure = "sp_InicioSesion";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@pass", pass);
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
                Conexion.CerrarConexion();
                throw new Exception(ex.Message);
            }
        }

        public static List<Usuario> ConsultarUsuarios()
        {
            try
            {
                string procedure = "sp_ConsultarUsuarios";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;

                List<Usuario> listaUsuarios = new List<Usuario>();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        //usuario.idUsuario = int.Parse(dr["idUsuario"].ToString());
                        usuario.email = dr["email"].ToString();
                        usuario.dni = dr["dni"].ToString();
                        usuario.idRol = int.Parse(dr["idRol"].ToString());
                        listaUsuarios.Add(usuario);
                    }
                    return listaUsuarios;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error en consultar usuario " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion();
            }

        }

        //public static Usuario ObtenerUsuarioId(int usu)
        //{
        //    Usuario usuario = new Usuario();
        //    try
        //    {
        //        string procedure = "sp_ObtenerPacienteId";
        //        comando.Connection = Conexion.AbrirConexion();
        //        comando.CommandText = procedure;
        //        comando.CommandType = CommandType.StoredProcedure;
        //        comando.Parameters.Clear();
        //        comando.Parameters.AddWithValue("@idUsuario", usu);
        //        comando.ExecuteNonQuery();
        //        SqlDataReader dread = comando.ExecuteReader();

        //        if (dread.Read())
        //        {
        //            usuario = BuscarMozo(dread);
        //        }
        //        Conexion.CerrarConexion();
        //        return usuario;

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Ha ocurrido un error " + e);
        //    }
        //    finally
        //    {
        //        Conexion.CerrarConexion();
        //    }
        //}

        public static Usuario ObtenerUsuarioId(int id) // al pasarle el nomnbre de la tabla suscriptor va a devolver lista dinamica cargada con los suscruptores
        {
            try
            {
                string procedure = "sp_ObtenerUsuarioId";
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = procedure;
                comando.Parameters.Clear();
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader dread = comando.ExecuteReader();
                Usuario usuario = null;

                while (dread.Read()) // va leyendo por filas el dataReader y en cada fila va obteniendo y asignando, tantas veces como filas encuentre
                {
                    usuario = new Usuario();
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
                        usuario.idRol = dread.GetInt32(14);
                    }
                    if (!dread.IsDBNull(14))
                    {
                        usuario.idReferencia = dread.GetInt32(14);
                    }
                    if (!dread.IsDBNull(15))
                    {
                        usuario.idObraSocial = dread.GetInt32(15);
                    }

                }
                Conexion.CerrarConexion();
                return usuario;
            }
            catch (Exception)
            {

                throw new Exception("No se puede cargar la lista desde la BD, por algun motivo");
            }
        }




    }
}
