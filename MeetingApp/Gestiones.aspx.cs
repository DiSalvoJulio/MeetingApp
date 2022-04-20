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

        //cerrar modal con cruz
        public void CerrarModalHorarios(object sender, EventArgs e)
        {
            pnlModalHorarios.Visible = false;
        }

        //ver modal
        protected void btnModificarHorarios_Click(object sender, EventArgs e)
        {
            pnlModalHorarios.Visible = true;
        }

        protected void btnModificarProfesiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarObrasSociales_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarPacientes_Click(object sender, EventArgs e)
        {

        }
    }
}