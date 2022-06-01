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
    public class TurnoBLL
    {
        TurnoDAL _turnoDAL = new TurnoDAL();

        public List<Usuario> ObtenerProfesionalesXEspecialidad(int idEspecialidad)
        {
            return _turnoDAL.ObtenerProfesionalesXEspecialidad(idEspecialidad);
        }

        public List<ObtenerTurnoDTO> ObtenerTurnoPorProfesionalYEspecialidad(int idHorarioProfesional, DateTime dia)
        {
            return _turnoDAL.ObtenerTurnoPorProfesionalYEspecialidad(idHorarioProfesional, dia);
        }

        public bool InsertarTurno(Turno turno)
        {
           return _turnoDAL.InsertarTurno(turno);
        }

        public List<FormaPago> ObtenerFormasDePagos()
        {
            return _turnoDAL.ObtenerFormasDePagos();
        }

        public ObtenerTurnoIdDTO ObtenerTurnoId(int idTurno)
        {
            return _turnoDAL.ObtenerTurnoId(idTurno);
        }

        //public bool CancelarTurno(Turno turno)
        //{
        //    return _turnoDAL.CancelarTurno(turno);
        //}

        public bool CancelarTurno(int idTurno)
        {
            return _turnoDAL.CancelarTurno(idTurno);
        }



    }
}
