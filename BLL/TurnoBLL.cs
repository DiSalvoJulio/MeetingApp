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
    }
}
