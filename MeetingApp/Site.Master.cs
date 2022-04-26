using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para cerrar la session
            //if (Session["Login"] != null)
            //{
            //    string usuario = Session["Login"].ToString();
            //    //lblBienvenida.Text = "Bienvenido/a " + usuario;
            //}
            //else
            //{
            //    Response.Redirect("InicioSesion.aspx");
            //}
            Usuario user = (Usuario)Session["Usuario"];

            if (user.idRol == 1) //administrador
            {
                tabEspecialidades.Visible = true; //son los id que estan en la sidebar en los li
                tabObrasSociales.Visible = true;
                tabCerrarSesion.Visible = true;

                tabHomePaciente.Visible = false;
                tabHomeProfesional.Visible = false;
                tabDatosPaciente.Visible = false;
                tabDatosProfesional.Visible = false;
                tabTurno.Visible = false;
                tabMisTurno.Visible = false;
                tabReportes.Visible = false;
            }
            else if (user.idRol == 2)//paciente
            {
                tabHomePaciente.Visible = true;
                tabTurno.Visible = true;
                tabMisTurno.Visible = true;
                tabCerrarSesion.Visible = true;
                tabDatosPaciente.Visible = true;

                tabEspecialidades.Visible = false;
                tabObrasSociales.Visible = false;
                tabHomeProfesional.Visible = false;
                tabDatosProfesional.Visible = false;
                tabReportes.Visible = false;
            }
            else //profesional
            {
                tabHomeProfesional.Visible = true;
                tabTurno.Visible = true;
                tabMisTurno.Visible = true;
                tabCerrarSesion.Visible = true;
                tabDatosProfesional.Visible = true;
                tabReportes.Visible = true;

                tabEspecialidades.Visible = false;
                tabObrasSociales.Visible = false;
                tabHomePaciente.Visible = false;
                tabDatosPaciente.Visible = false;
            }

        }
    }
}