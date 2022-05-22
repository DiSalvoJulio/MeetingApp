using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ObtenerTurnoDTO
    {
        public int idTurno { get; set; }
        public string descripcion { get; set; }
        public string horaTurno { get; set; }
        public DateTime fechaSolicitud { get; set; }               
        public string profesional { get; set; }
        public string paciente { get; set; }
        public string especialidad { get; set; }
    }
}
