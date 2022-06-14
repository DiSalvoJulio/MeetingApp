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

        public List<Referencia> ObtenerReferencias()
        {
            return _pacienteDAL.ObtenerReferencias();
        }

        public List<ObtenerTurnosPacienteDTO> ObtenerTurnosPaciente(int idPaciente)
        {
            return _pacienteDAL.ObtenerTurnosPaciente(idPaciente);
        }

        public List<ObtenerTurnosPacienteDTO> ObtenerTurnosHistoricosPaciente(int idPaciente)
        {
            return _pacienteDAL.ObtenerTurnosHistoricosPaciente(idPaciente);
        }

    }
}
