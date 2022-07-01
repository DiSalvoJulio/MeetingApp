using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ObtenerHorarioDTO
    {
        public int idHorario { get; set; }
        public int idDia { get; set; }
        public string dia { get; set; }
        public string turno { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public string profesional { get; set; }
    }
}
