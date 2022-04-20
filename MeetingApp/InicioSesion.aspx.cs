using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Remove("Login");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {           
            Usuario usu = RegistrarBLL.UsuarioSesion(txtUsuario.Text, txtPass.Text);

            if (usu != null)
            {               
                if (usu.idRol == 2)
                {//paciente
                    Session["Usuario"] = usu;
                    Response.Redirect("DatosPaciente.aspx");
                    //Session["Usuario"] = usu;
                    //if (usu.ocupacion == null)
                    //{
                    //    Response.Redirect("DatosPaciente.aspx");
                    //}
                    //else
                    //{   //FALTA HACER EL HOME DE PACIENTE
                    //    Response.Redirect("HomePaciente.aspx");
                    //}

                }
                else
                {//profesional
                    Session["Usuario"] = usu;
                    Response.Redirect("DatosProfesional.aspx");
                    //if (usu.matricula == null)
                    //{
                    //    Response.Redirect("DatosProfesional.aspx");
                    //}
                    //else
                    //{   //FALTA HACER EL HOME DE PROFESIONAL
                    //    Response.Redirect("HomeProfesional.aspx");
                    //}

                }               
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Usuario Existente!')", true);
            }
        }
    }
}