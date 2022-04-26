using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class ObraSocialBLL
    {
        ObraSocialDAL _obraSocialDAL = new ObraSocialDAL();

        public List<ObraSocial> ObtenerObraSocial()
        {
            return _obraSocialDAL.ObtenerObraSocial();
        }

        public ObraSocial SeleccionarIdObraSocial(int obraS)
        {
            return _obraSocialDAL.SeleccionarIdObraSocial(obraS);
        }

        public void InsertarObraSocial(ObraSocial obraS)
        {
            _obraSocialDAL.InsertarObraSocial(obraS);
        }

        public bool ValidarNombreObraSocial(ObraSocial obraS)
        {
            return _obraSocialDAL.ValidarNombreObraSocial(obraS);
        }

        public void ActualizarObraSocial(ObraSocial obraS)
        {
            _obraSocialDAL.ActualizarObraSocial(obraS);
        }
    }
}
