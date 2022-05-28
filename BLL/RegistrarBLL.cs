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
    public class RegistrarBLL
    {
        private RegistrarDAL registrarDAL = new RegistrarDAL();
        public void InsertarUsuario(Usuario usuario)
        {
            registrarDAL.InsertarUsuario(usuario);
        }

        public List<Usuario> ConsultarUsuarios()
        {
            return registrarDAL.ConsultarUsuarios();
        }

        //inicio sesion
        public Usuario UsuarioSesion(string usuario, string pass)
        {
            return registrarDAL.UsuarioSesion(usuario, pass);
        }

        //COMBO ESPECIALIDADES
        public List<Especialidad> ObtenerEspecialidades()
        {
            return registrarDAL.ObtenerEspecialidades();
        }

        //combo referencias
        public List<Referencia> ObtenerReferencias()
        {
            return registrarDAL.ObtenerReferencias();
        }

    }
}
