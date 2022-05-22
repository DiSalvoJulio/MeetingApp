using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ObtenerHorarioProfesionalDiaDTO
    {
        public int idHorario { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public int cantidad { get; set; }       
        public int idProfesional { get; set; }
        public string dia { get; set; }
        public string turno { get; set; }

    }
}
