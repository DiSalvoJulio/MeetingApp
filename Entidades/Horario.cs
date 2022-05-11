using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        public int idHorario { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public int cantidad { get; set; }
        public int idDia { get; set; }
        public int idUsuarioProfesional { get; set; }
        public string turno { get; set; }
    }
}
