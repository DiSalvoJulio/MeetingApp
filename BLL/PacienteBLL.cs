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
    public static class PacienteBLL
    {
        public static void ActualizarDatosPaciente(Usuario user)
        {
            DAL.PacienteDAL.ActualizarDatosPaciente(user);
        }




    }
}
