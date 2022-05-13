using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using Entidades.DTOs;

namespace BLL
{
    public class HorarioBLL
    {
        HorarioDAL _horarioDAL = new HorarioDAL();

        public void InsertarHorario(Horario horario)
        {
            _horarioDAL.InsertarHorario(horario);
        }
        public List<ObtenerHorarioDTO> ObtenerHorarios(int id)
        {
            return _horarioDAL.ObtenerHorarios(id);
        }

        public void ActualizarHorario(int id, string desde, string hasta)
        {
            _horarioDAL.ActualizarHorario(id, desde, hasta);
        }
        public ObtenerHorarioDTO ObtenerHorarioId(int id)
        {
            return _horarioDAL.ObtenerHorarioId(id);
        }

        public void EliminarHorario(Horario horario)
        {
            _horarioDAL.EliminarHorario(horario);
        }

        public bool ValidarHorario(Horario horario)
        {
            return _horarioDAL.ValidarHorario(horario);
        }


    }
}
