using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace MeetingApp
{
    public partial class Registrar : System.Web.UI.Page
    {
        RegistrarBLL registrarBLL = new RegistrarBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarComboEspecialidades();
                cmbProfesion.Enabled = false;
                txtMatricula.Enabled = false;
            }
        }

        //INSERTAR
        public bool InsertarUsuario()
        {
            try
            {
                Usuario user = new Usuario();
                user.apellido = txtApellido.Text;
                user.nombre = txtNombre.Text;
                user.dni = txtDni.Text;
                DateTime fecha = DateTime.Parse(txtFecNac.Text);
                user.fechaNacimiento = fecha.Date;
                user.fechaIngreso = DateTime.Now;
                user.email = txtEmail.Text;
                user.pass = txtPass.Text;
                user.idRol = chkProfesional.Checked ? 3 : 2;//true profesional sino paciente
                if (chkProfesional.Checked)
                {
                    user.matricula = txtMatricula.Text;
                    user.idEspecialidad = int.Parse(cmbProfesion.SelectedValue);
                }

                registrarBLL.InsertarUsuario(user);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Registro con Exito!', 'Sera redirigido al Login para iniciar sesion', 'success')", true);

                /*Datos del mail que se envia al usuario registrado*/
                string persona = user.nombre + " " +user.apellido;
                Email email = new Email();
                string Usuario = user.email + " o " + user.dni; 
                string mensajeError = "";
                email.SendEmailRegistro(user.email, persona, Usuario, user.pass,ref mensajeError);

                return true;
                

            }
            catch (Exception ex)
            {
                return false;
            }
        }



        //VALIDAR USUARIO
        public bool ExisteUsuario(string email, string dni)
        {
            bool existe = false;
            try
            {
                List<Usuario> listaUsuario = registrarBLL.ConsultarUsuarios();

                foreach (Usuario usu in listaUsuario)
                {//for para validar mail y dni
                    if (usu.email == email || usu.dni == dni)
                    {
                        existe = true;
                        break;
                    }
                }
                return existe;
            }
            catch (Exception ex)
            {
                return existe;
                throw new Exception("Error en consultar usuarios " + ex.Message);
            }
        }

        //REGISTRAR
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposPorRol())
            {
                return;
            }           
            if (!ValidarMayoriaEdad())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'Para registrarse debe ser mayor de 18 años, verifique la fecha de nacimiento', 'warning')", true);
                return;
            }

            //validar si el usuario ya existe
            if (ExisteUsuario(txtEmail.Text, txtDni.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Usuario Existente! El Email ya esta registrado.')", true);
                return;
            }

            try
            {
                if (InsertarUsuario())
                {

                    //var cancellationTokenSource = new CancellationTokenSource();
                    //var cancellationToken = cancellationTokenSource.Token;

                    //Task.Delay(2000).ContinueWith(async (t) =>
                    //{
                    //    Response.Redirect("InicioSesion.aspx", false);
                    //}, cancellationToken);

                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Registro con Exito!', 'Sera redirigido al Login para iniciar sesion', 'success')", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Su registro ha sido exitoso', 'success')", true);
                    LimpiarCampos();

                    //Thread.Sleep(2000);

                    //Response.Redirect("InicioSesion.aspx", false);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo registrar!', 'error')", true);
                    return;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Registrar Usuario " + ex.Message);
            }

        }

        private bool ValidarCamposPorRol()
        {
            bool esValido = true;
            int idRol = chkProfesional.Checked ? 3 : 2;//true profesional sino paciente

            //VALIDAR CAMPOS POR ROL
            if (idRol == 2)
            {//si es paciente valida datos para el paciente
                if (CamposVaciosRegistro())
                {
                    esValido = false;
                }
            }
            else if (idRol == 3)
            {//si es profesional valida datos para el profesional
                if (CamposVaciosRegistro())
                {
                    esValido = false;
                }
                if (CamposVaciosProfesional())
                {
                    esValido = false;
                }
            }
            return esValido;
        }

        //CANCELAR
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Limpiar
        }

        //VALIDAR SI ES PROFESIONAL
        protected void chkProfesional_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfesional.Checked == false)
            {
                cmbProfesion.Enabled = false;
                txtMatricula.Enabled = false;
                cmbProfesion.SelectedIndex = 0;
                txtMatricula.Text = "";
                cmbProfesion.Items.Clear();
                cmbProfesion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));

            }
            else
            {
                cmbProfesion.Enabled = true;
                txtMatricula.Enabled = true;
                chkProfesional.Checked = true;
                CargarComboEspecialidades();
                //chkProfesional.CssClass = "checked";
            }

        }

        //VALIDAR CAMPOS QUE NO ESTEN VACIOS
        public bool CamposVaciosRegistro()
        {
            if (txtApellido.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Apellido')", true);
                txtApellido.Focus();
                return true;
            }
            if (txtNombre.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Nombre')", true);
                txtNombre.Focus();
                return true;
            }
            if (txtDni.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar DNI')", true);
                txtDni.Focus();
                return true;
            }
            if (txtFecNac.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Fecha Nacimiento')", true);
                txtFecNac.Focus();
                return true;
            }
            if (txtEmail.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Email')", true);
                txtEmail.Focus();
                return true;
            }
            if (txtPass.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Contraseña')", true);
                txtPass.Focus();
                return true;
            }
            if (txtPass2.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo repetir contraseña')", true);
                txtPass2.Focus();
                return true;
            }
            if (txtPass.Text != txtPass2.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Las contraseñas deben ser iguales!')", true);
                txtPass.Focus();
                return true;
            }
            if (chkTerminos.Checked==false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe aceptar los Terminos Y condiciones para registrarse')", true);
                chkTerminos.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CamposVaciosProfesional()
        {
            if (cmbProfesion.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe seleccionar una Especialidad')", true);
                cmbProfesion.Focus();
                return true;
            }
            if (txtMatricula.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar la Matricula')", true);
                txtMatricula.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }


        //CARGAR ESPECIALIDADES
        public void CargarComboEspecialidades()
        {
            try
            {
                List<Especialidad> listaEspecialidad = new List<Especialidad>();
                listaEspecialidad = registrarBLL.ObtenerEspecialidades();
                cmbProfesion.Items.Clear();

                int indice = 0;
                if (listaEspecialidad.Count > 0)
                {
                    //cmbProfesion es el ID del ASP
                    cmbProfesion.DataSource = listaEspecialidad;
                    cmbProfesion.DataTextField = "descripcion";
                    cmbProfesion.DataValueField = "idEspecialidad";
                    cmbProfesion.DataBind();
                    cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                    //cmbProfesion.Items[0].Attributes = false;
                }
                else
                {
                    cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo especialidad " + ex.Message);
            }
        }

        public void LimpiarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtFecNac.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtPass2.Text = "";
            chkProfesional.Checked = false;
            cmbProfesion.Items.Clear();
            cmbProfesion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
            cmbProfesion.Enabled = false;
            txtMatricula.Text = "";
            txtMatricula.Enabled = false;
            chkTerminos.Checked = false;
        }


        //validar fecha de nacimiento, usuario mayor de 18 años
        public bool ValidarMayoriaEdad()
        {
            bool esMayor = true;
            DateTime fecha = DateTime.Parse(txtFecNac.Text);
            //fechaNacimiento = fecha.Date;

            if (fecha.AddYears(18)>DateTime.Now)
            {
                esMayor = false;
            }
            else
            {
                esMayor = true;
            }
            return esMayor;
        }




    }
}