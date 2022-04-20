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
    public static class ProfesionalBLL
    {
        public static void ActualizarDatosProfesional(Usuario user)
        {
            DAL.ProfesionalDAL.ActualizarDatosProfesional(user);
        }




    }
}
