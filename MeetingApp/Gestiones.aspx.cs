using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class Gestiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region MODAL HORARIO
        //ver modal
        protected void btnModificarHorarios_Click(object sender, EventArgs e)
        {
            panelHorarios.Visible = true;
        }

        //cerrar modal con cruz
        public void CerrarModalHorarios(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelHorarios.Visible = false;
        }
        #endregion

        #region MODAL PROFESIONES
        protected void btnModificarProfesiones_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelProfesiones.Visible = true;
        }
       
        //cerrar modal con cruz
        public void CerrarModalProfesiones(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelProfesiones.Visible = false;
        }
        #endregion

        #region MODAL OBRAS SOCIALES
        protected void btnModificarObrasSociales_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelObrasSociales.Visible = true;
        }
        //cerrar modal con cruz
        public void CerrarModalObrasSociales(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelObrasSociales.Visible = false;
        }
        #endregion

        #region MODAL PACIENTES
        protected void btnModificarPacientes_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelPacientes.Visible = true;
        }
        //cerrar modal con cruz
        public void CerrarModalPacientes(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelPacientes.Visible = false;
        }
        #endregion

    }
}