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

        public Usuario BuscarProfesionalDni(string dni)
        {
            return _profesionalDAL.BuscarProfesionalDni(dni);
        }

        public void ActualizarDatosProfesional(Usuario user)
        {
            _profesionalDAL.ActualizarDatosProfesional(user);
        }

        public List<ObtenerProfesionalDTO> ObtenerListaProfesionales()
        {
            return _profesionalDAL.ObtenerListaProfesionales();
        }

        public List<Usuario> ObtenerProfesionalId(int id)
        {
            return _profesionalDAL.ObtenerProfesionalId(id);
        }

        public ObtenerTurnoIdProfesionalDTO ObtenerTurnoIdProfesional(int idTurno)
        {
            return _profesionalDAL.ObtenerTurnoIdProfesional(idTurno);
        }

        public List<ObtenerTurnosProfesionalDTO> ObtenerTurnosProfesionalPorPaciente(int idProfesional, string dni)
        {
            return _profesionalDAL.ObtenerTurnosProfesionalPorPaciente(idProfesional,dni);
        }


        public List<ObtenerTurnosProfesionalDTO> ObtenerTurnosPorFecha(int idProfesional, DateTime fecha)
        {
            return _profesionalDAL.ObtenerTurnosPorFecha(idProfesional, fecha);
        }



    }
}
