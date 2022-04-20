using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class DatosPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["Usuario"];
                CargarCamposPaciente(user);
                btnCancelar.Enabled = false;
                btnAceptar.Enabled = false;
            }

        }       

        private void CargarCamposPaciente(Usuario user)
        {
            txtApellido.Text = user.apellido;
            txtNombre.Text = user.nombre;
            txtDni.Text = user.dni;            
            txtFecNac.Text = user.fechaNacimiento.ToString("yyyy-MM-dd");//mostrar fecha desde la bd en front. Esta conversion se hace pq la bd tiene ese formato. año/mes/dia                       
            txtEmail.Text = user.email;
            txtTelefono.Text = user.telefono;
            txtDireccion.Text = user.direccion;
            txtOcupacion.Text = user.ocupacion;
            txtReferencia.Text = user.idReferencia.ToString();
            txtIngreso.Text = user.fechaIngreso.ToShortDateString();
            txtEdad.Text = user.edad.ToString();
            DesahabilitarCampos();
            CamposNoModificables();
        }

        //Datos que no se deben modificar
        private void CamposNoModificables()
        {
            txtDni.Enabled = false;
            txtEmail.Enabled = false;
            txtEdad.Enabled = false;
            txtReferencia.Enabled = false;
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
            txtOcupacion.Enabled = false;
            txtReferencia.Enabled = false;
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
            txtOcupacion.Enabled = true;            
            txtIngreso.Enabled = true;
            txtEdad.Enabled = true;
            CamposNoModificables();
        }

        public void ActualizarDatosPaciente()
        {            
            Usuario user = (Usuario)Session["Usuario"];
            user.apellido = txtApellido.Text;
            user.nombre = txtNombre.Text;
            user.fechaNacimiento = DateTime.Parse(txtFecNac.Text);
            user.telefono = txtTelefono.Text;
            user.direccion = txtDireccion.Text;
            //user.pass = txtPass.Text;
            user.ocupacion = txtOcupacion.Text;
            user.idReferencia = int.Parse(txtReferencia.Text);
            if (!CamposVaciosModificar())
            {
                PacienteBLL.ActualizarDatosPaciente(user);
                DesahabilitarCampos();
                //CamposNoModificables();
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
            ActualizarDatosPaciente();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Datos Actualizados')", true);
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
            if (txtOcupacion.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar Ocupacion')", true);
                txtTelefono.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}