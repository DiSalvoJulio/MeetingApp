using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ObtenerTurnoIdDTO
    {
        public int idTurno { get; set; }
        public string dia { get; set; }
        public DateTime fechaTurno { get; set; }
        public string horaTurno { get; set; }
        public string descripcion { get; set; }
        public string especialidad { get; set; }
        public string profesional { get; set; }     
              
    }
}
