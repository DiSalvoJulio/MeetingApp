using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        public int idTurno { get; set; }
        public string descripcion { get; set; }
        public string horaTurno { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public bool activo { get; set; }
        public int idFormaPago { get; set; }
        public int idUsuarioPaciente { get; set; }
        public int idHorarioProfesional { get; set; }
        public int idEspecialidad { get; set; }
        public string fechaTurno { get; set; }
        public int idObraSocial { get; set; }
        public bool atencion { get; set; }
    }
}
