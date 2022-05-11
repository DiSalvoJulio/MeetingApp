using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class DiaBLL
    {
        DiaDAL _diaDALL = new DiaDAL();
        public List<Dia> ObtenerDias()
        {
            return _diaDALL.ObtenerDias();
        }
    }
}
