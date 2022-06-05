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
    public partial class RecuperarContrasenia : System.Web.UI.Page
    {

        RegistrarBLL _registrarBLL = new RegistrarBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            string emailtxt = txtEmail.Text;

            usuario = _registrarBLL.ObtenerExisteCorreo(emailtxt);
            if (usuario.idUsuario==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Usuario no registrado', 'warning')", true);
            }
            else
            {
                Email email = new Email();
                string mensajeError = "";
                //email.SendEmailRegistro(user.email, persona, user.dni, user.pass, ref mensajeError);
                email.SendEmailRecuperarContrasenia(usuario.email, usuario.nombre, usuario.idUsuario, ref mensajeError);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se encontro Usuario!, Se envio un correo a su Email', 'success')", true);
                //metodo de recuperar

            }




        }
    }
}