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
    public partial class DatosProfesional : System.Web.UI.Page
    {
        RegistrarBLL _registrarBLL = new RegistrarBLL();
        ProfesionalBLL _profesionalBLL = new ProfesionalBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["Usuario"];               
                CargarComboEspecialidades();
                CargarCamposProfesional(user);                     
                btnCancelar.Enabled = false;
                btnAceptar.Enabled = false;
            }
        }
        //ver campos vacios
        //(Usuario) Session["Usuario"]
        private void CargarCamposProfesional(Usuario user)
        {
            if (user != null)
            {
                txtApellido.Text = user.apellido;
                txtNombre.Text = user.nombre;
                txtDni.Text = user.dni;
                txtFecNac.Text = user.fechaNacimiento.ToString("yyyy-MM-dd");
                //mostrar fecha desde la bd en front. Esta conversion se hace pq la bd tiene ese formato. año/mes/dia                       
                txtEmail.Text = user.email;
                txtTelefono.Text = user.telefono;
                txtDireccion.Text = user.direccion;
                //int p = int.Parse(user.idEspecialidad.ToString());
                //cmbEspecialidad.SelectedIndex = p - 1;
                cmbEspecialidad.SelectedValue = user.idEspecialidad.ToString();
                txtMatricula.Text = user.matricula;
                txtIngreso.Text = user.fechaIngreso.ToShortDateString();
                txtEdad.Text = user.edad.ToString();
                DesahabilitarCampos();
                CamposNoModificables();
            }
            else
            {
                Response.Redirect("InicioSesion.aspx");
            }

        }

        //Datos que no se deben modificar
        private void CamposNoModificables()
        {
            txtDni.Enabled = false;
            txtEmail.Enabled = false;
            txtEdad.Enabled = false;
            txtIngreso.Enabled = false;
        }

        //Metodo para cancelar campos
        private void DesahabilitarCampos()
        {
            txtApellido.Enabled = false; ;
            txtNombre.Enabled = false;
            txtDni.Enabled = false;
            txtFecNac.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbEspecialidad.Enabled = false;
            txtMatricula.Enabled = false;
            txtIngreso.Enabled = false;
            txtEdad.Enabled = false;
        }

        //Metodo para habilitar campos 
        private void HabilitarCampos()
        {
            txtApellido.Enabled = true; ;
            txtNombre.Enabled = true;
            txtDni.Enabled = true;
            txtFecNac.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            cmbEspecialidad.Enabled = true;
            txtMatricula.Enabled = true;
            txtIngreso.Enabled = true;
            txtEdad.Enabled = true;
            CamposNoModificables();
        }

        public bool ActualizarDatosProfesional()
        {
            Usuario user = (Usuario)Session["Usuario"];
            user.apellido = txtApellido.Text;
            user.nombre = txtNombre.Text;
            user.fechaNacimiento = DateTime.Parse(txtFecNac.Text);
            user.telefono = txtTelefono.Text;
            user.direccion = txtDireccion.Text;
            //user.pass = txtPass.Text;
            user.idEspecialidad = int.Parse(cmbEspecialidad.Text);
            user.matricula = txtMatricula.Text;
           
            if (!CamposVaciosModificar())
            {
                _profesionalBLL.ActualizarDatosProfesional(user);
                DesahabilitarCampos();
                return true;
                //CamposNoModificables();
            }
            else
            {
                return false;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActualizarDatosProfesional())
                {                    
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Datos Actualizados!', 'success')", true);
                    btnCancelar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnModificar.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo actualizar datos', 'error')", true);
                    btnCancelar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnModificar.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en Actualizar Datos " + ex.Message);
            }           
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!CamposVaciosModificar())
            {
                DesahabilitarCampos();
                CamposNoModificables();
                btnCancelar.Enabled = false;
                btnAceptar.Enabled = false;
                btnModificar.Enabled = true;
            }
        }

        //CARGAR COMBO ESPECIALIDADES
        public void CargarComboEspecialidades()
        {
            try
            {
                List<Especialidad> listaEspecialidad = new List<Especialidad>();
                listaEspecialidad = _registrarBLL.ObtenerEspecialidades();
                cmbEspecialidad.Items.Clear();

                int indice = 0;
                if (listaEspecialidad.Count > 0)
                {                  
                    cmbEspecialidad.DataSource = listaEspecialidad;
                    cmbEspecialidad.DataTextField = "descripcion";
                    cmbEspecialidad.DataValueField = "idEspecialidad";
                    cmbEspecialidad.DataBind();
                    //cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                    //cmbEspecialidad.Items[0].Attributes = false;
                }
                else
                {
                    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error en cargar combo especialidad " + ex.Message);
            }
        }


        //VALIDACIONES
        public bool CamposVaciosModificar()
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
            if (txtFecNac.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Fecha Nacimiento')", true);
                txtFecNac.Focus();
                return true;
            }
            //if (txtPass.Text.Equals(""))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Contraseña')", true);
            //    txtPass.Focus();
            //    return true;
            //}
            //if (txtPass2.Text.Equals(""))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo repetir contraseña')", true);
            //    txtPass2.Focus();
            //    return true;
            //}
            //if (txtPass.Text != txtPass2.Text)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Las contraseñas deben ser iguales!')", true);
            //    txtPass.Focus();
            //    return true;
            //}
            if (txtDireccion.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar direccion')", true);
                txtDireccion.Focus();
                return true;
            }
            if (txtTelefono.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Telefono')", true);
                txtTelefono.Focus();
                return true;
            }
            if (txtMatricula.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Matricula')", true);
                txtMatricula.Focus();
                return true;
            }
            if (cmbEspecialidad.SelectedIndex == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Especialidad')", true);
                cmbEspecialidad.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}