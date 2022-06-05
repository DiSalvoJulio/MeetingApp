using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace MeetingApp
{
    public partial class ActualizarPassword : System.Web.UI.Page
    {
        RegistrarBLL _registrarBLL = new RegistrarBLL();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            string pass = txtPass.Text;
            string pass2 = txtPass2.Text;

            if (pass!=pass2)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Las contraseñas deben ser iguales', 'warning')", true);
            }
            else
            {
                int result = _registrarBLL.RecuperarCuenta(Convert.ToInt32(id), pass);
                if (result == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'No se pudo blanquear la clave', 'warning')", true);
                }
                else
                {                  

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se blanqueo la clave', 'success')", true);   
                
                }
            }




        }

    }
}