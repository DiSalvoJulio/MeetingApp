using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entidades;
using System.Web.UI.WebControls;

namespace BLL
{
    public class EspecialidadBLL
    {
        EspecialidadesDAL _especialidadesDAL = new EspecialidadesDAL();
        public List<Especialidad> ObtenerEspecialidades()
        {
            return _especialidadesDAL.ObtenerEspecialidades();
        }

        public Especialidad SeleccionarIdEspecialidad(int espe)
        {
            return _especialidadesDAL.SeleccionarIdEspecialidad(espe);
        }

        public void InsertarEspecialidad(Especialidad especialidad)
        {
            _especialidadesDAL.InsertarEspecialidad(especialidad);
        }

        public bool ValidarNombreEspecialidad(Especialidad espe)
        {
            return _especialidadesDAL.ValidarNombreEspecialidad(espe);
        }

        public void ActualizarEspecialidad(Especialidad especialidad)
        {
            _especialidadesDAL.ActualizarEspecialidad(especialidad);
        }

    }
}
