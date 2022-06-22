using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ObtenerAtendidosPorObraSocialDTO
    {
        public int? idTurno { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string paciente { get; set; }
        public string obraSocial { get; set; }
        public string atencion { get; set; }
    }
}
