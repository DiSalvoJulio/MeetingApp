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

        //public static void CargarComboEspecialidades()
        //{
        //    try
        //    {
        //        List<Especialidad> listaEspecialidad = new List<Especialidad>();
        //        listaEspecialidad = _especialidadesDAL.ObtenerEspecialidades();
        //        cmbProfesion.Items.Clear();

        //        int indice = 0;
        //        if (listaEspecialidad.Count > 0)
        //        {
        //            //cmbRubros es el ID del ASP
        //            cmbProfesion.DataSource = listaEspecialidad;
        //            cmbProfesion.DataTextField = "descripcion";
        //            cmbProfesion.DataValueField = "idEspecialidad";
        //            cmbProfesion.DataBind();
        //            cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
        //            //cmbProfesion.Items[0].Attributes = false;
        //        }
        //        else
        //        {
        //            cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error en cargar combo especialidad " + ex.Message);
        //    }
        //}
    }
}
