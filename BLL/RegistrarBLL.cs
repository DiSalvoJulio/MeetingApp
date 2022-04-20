using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entidades;

namespace BLL
{
    public static class RegistrarBLL
    {
        public static void InsertarUsuario(Usuario usuario)
        {
            DAL.RegistrarDAL.InsertarUsuario(usuario);
        }

        public static List<Usuario> ConsultarUsuarios()
        {
            return DAL.RegistrarDAL.ConsultarUsuarios();
        }


        //inicio sesion
        public static Usuario UsuarioSesion(string usuario, string pass)
        {
            return DAL.RegistrarDAL.UsuarioSesion(usuario, pass);
        }

    }
}
