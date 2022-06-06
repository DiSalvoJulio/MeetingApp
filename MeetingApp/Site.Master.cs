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
            Usuario user = (Usuario)Session["Usuario"];
            Session["Login"] = user;            

            if (Session["Login"] != null)
            {
                //string usuario = Session["Login"].ToString();
                lblUsuarioooo.Text = user.nombre + ' ' + user.apellido;
                //lblUsuarioooo.Text = "Bienvenido/a " + user.nombre + ' ' + user.apellido;
            }
            else
            {
                Response.Redirect("InicioSesion.aspx");
            }
            //Usuario user = (Usuario)Session["Usuario"];

            if (user.idRol == 1) //administrador
            {
                tabEspecialidades.Visible = true; //son los id que estan en la sidebar en los li
                tabObrasSociales.Visible = true;
                //tabCerrarSesion.Visible = true;
                tabPreguntas.Visible = true;
                tabPaciente.Visible = true;
                tabProfesional.Visible = true;
                tabHorario.Visible = true;

                tabHomePaciente.Visible = false;
                tabHomeProfesional.Visible = false;
                tabDatosPaciente.Visible = false;
                tabDatosProfesional.Visible = false;
                tabTurnoPaciente.Visible = false;
                tabTurnoProfesional.Visible = false;
                tabMisTurnosPaciente.Visible = false;
                tabMisTurnosProfesional.Visible = false;
                //tabReportes.Visible = false;
                tabReporte1.Visible = false;
                tabReporte2.Visible = false;
                tabReporte3.Visible = false;
                tabReporte4.Visible = false;
            }
            else if (user.idRol == 2)//paciente
            {
                tabHomePaciente.Visible = true;
                tabTurnoPaciente.Visible = true;
                tabMisTurnosPaciente.Visible = true;
                //tabCerrarSesion.Visible = true;
                tabPreguntas.Visible = true;
                tabDatosPaciente.Visible = true;

                tabPaciente.Visible = false;
                tabProfesional.Visible = false;
                tabHorario.Visible = false;
                tabEspecialidades.Visible = false;
                tabObrasSociales.Visible = false;
                tabHomeProfesional.Visible = false;
                tabDatosProfesional.Visible = false;
                //tabReportes.Visible = false;
                tabMisTurnosProfesional.Visible = false;
                tabTurnoProfesional.Visible = false;
                tabReporte1.Visible = false;
                tabReporte2.Visible = false;
                tabReporte3.Visible = false;
                tabReporte4.Visible = false;
            }
            else //profesional
            {
                tabHomeProfesional.Visible = true;
                tabMisTurnosProfesional.Visible = true;
                //tabCerrarSesion.Visible = true;
                tabPreguntas.Visible = true;
                tabDatosProfesional.Visible = true;
                //tabReportes.Visible = true;
                tabTurnoProfesional.Visible = true;
                tabReporte1.Visible = true;
                tabReporte2.Visible = true;
                tabReporte3.Visible = true;
                tabReporte4.Visible = true;


                tabPaciente.Visible = false;
                tabProfesional.Visible = false;
                tabHorario.Visible = false;
                tabTurnoPaciente.Visible = false;
                tabEspecialidades.Visible = false;
                tabObrasSociales.Visible = false;
                tabHomePaciente.Visible = false;
                tabDatosPaciente.Visible = false;
                tabMisTurnosPaciente.Visible = false;
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Session.Abandon();
            Response.Redirect("~/InicioSesion.aspx");
        }
    }
}