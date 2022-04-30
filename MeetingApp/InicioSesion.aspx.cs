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
        RegistrarBLL _registrarBLL = new RegistrarBLL();        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Remove("Login");            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {           
            Usuario usu = _registrarBLL.UsuarioSesion(txtUsuario.Text, txtPass.Text);

            if (usu != null)
            {               
                if (usu.idRol == 2)
                {//paciente
                    //Session["Usuario"] = usu;
                    //Response.Redirect("DatosPaciente.aspx");
                    Session["Usuario"] = usu;
                    if (usu.telefono == null || usu.telefono.Equals("") || usu.direccion == null || usu.direccion.Equals("") || usu.ocupacion == null || usu.ocupacion.Equals("") || usu.idReferencia == 0 || usu.idReferencia.Equals(""))
                    {
                        Response.Redirect("DatosPaciente.aspx");
                    }
                    else
                    {   //FALTA HACER EL HOME DE PACIENTE
                        Response.Redirect("HomePaciente.aspx");
                    }

                }
                else if(usu.idRol ==3)
                {//profesional
                    Session["Usuario"] = usu;
                    //Response.Redirect("DatosProfesional.aspx");
                    if (usu.telefono == null || usu.telefono.Equals("") || usu.direccion == null || usu.direccion.Equals(""))
                    {
                        Response.Redirect("DatosProfesional.aspx");                        
                    }
                    else
                    {   //FALTA HACER EL HOME DE PROFESIONAL                       
                        Response.Redirect("HomeProfesional.aspx");
                    }
                }
                else if(usu.idRol == 1)
                {
                    Session["Usuario"] = usu;
                    //Response.Redirect("Gestiones/Default.aspx");
                    Response.Redirect("Gestiones/Especialidades.aspx");
                    //Response.Redirect("Gestiones/ObrasSociales.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Usuario Existente!')", true);
            }
        }
    }
}