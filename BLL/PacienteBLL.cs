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
    public class PacienteBLL
    {
        PacienteDAL _pacienteDAL = new PacienteDAL();

        public void ActualizarDatosPaciente(Usuario user)
        {
            _pacienteDAL.ActualizarDatosPaciente(user);
        }

        public Usuario BuscarPacienteDni(string dni)
        {
            return _pacienteDAL.BuscarPacienteDni(dni);
        }



    }
}
