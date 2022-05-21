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
    public class TurnoBLL
    {
        TurnoDAL _turnoDAL = new TurnoDAL();

        public List<Usuario> ObtenerProfesionalesXEspecialidad(int idEspecialidad)
        {
            return _turnoDAL.ObtenerProfesionalesXEspecialidad(idEspecialidad);
        }
    }
}
