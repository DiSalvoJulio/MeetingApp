using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entidades;
using Entidades.DTOs;

namespace BLL
{
    public class ProfesionalBLL
    {
        ProfesionalDAL _profesionalDAL = new ProfesionalDAL();


        public void ActualizarDatosProfesional(Usuario user)
        {
            _profesionalDAL.ActualizarDatosProfesional(user);
        }

        public List<ObtenerProfesionalDTO> BuscarProfesional()
        {
            return _profesionalDAL.BuscarProfesional();
        }

    }
}
