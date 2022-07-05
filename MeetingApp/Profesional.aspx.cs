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
    public partial class Profesional : System.Web.UI.Page
    {
        UsuarioBLL _usuarioBLL = new UsuarioBLL();
        ProfesionalBLL _profesionalBLL = new ProfesionalBLL();
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
                DesahabilitarCampos();
                btnEliminarProfesional.Enabled = false;
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificar.Enabled = false;
                VaciarCombo();
            }
        }

        public bool BuscarProfesionalDni()
        {
            string dni = txtDniBuscar.Text;
            //Usuario user = _usuarioBLL.BuscarUsuarioDni(dni);
            Usuario user = _profesionalBLL.BuscarProfesionalDni(dni);
            bool profesional = false;
            if (user == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo encontrar un profesional', 'error')", true);
                profesional = false;
                return profesional;
            }        

            Session["idUsuario"] = user.idUsuario;//usuario almacenado en session guardado en id
            Session["User"] = user;//en este usuario cargo todos los datos 
            CargarComboEspecialidades();          
            CargarCamposProfesional(user);            
            profesional = true;         
            return profesional;

        }

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
                cmbEspecialidad.SelectedValue = user.idEspecialidad.ToString();
                txtMatricula.Text = user.matricula;
                txtIngreso.Text = user.fechaIngreso.ToShortDateString();
                txtEdad.Text = user.edad.ToString();
            }
        }

        //CARGAR COMBO ESPECIALIDADES
        public void CargarComboEspecialidades()
        {
            try
            {
                List<Especialidad> listaEspecialidad = new List<Especialidad>();
                listaEspecialidad = _especialidadBLL.ObtenerEspecialidades();
                cmbEspecialidad.Items.Clear();

                //int indice = 0;
                if (listaEspecialidad.Count > 0)
                {
                    cmbEspecialidad.DataSource = listaEspecialidad;
                    cmbEspecialidad.DataTextField = "descripcion";
                    cmbEspecialidad.DataValueField = "idEspecialidad";
                    cmbEspecialidad.DataBind();
                    //cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0", false));
                    //cmbEspecialidad.Items[0].Attributes = false;
                }
                //else
                //{
                //    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo especialidad " + ex.Message);
            }
        }

        protected void btnBuscarProfesional_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarProfesionalDni())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se encontró un profesional!', 'success')", true);
                    btnModificar.Enabled = true;
                    btnEliminarProfesional.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo encontrar un profesional', 'error')", true);
                    LimpiarCampos();
                    btnModificar.Enabled = false;
                    btnEliminarProfesional.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Buscar Profesional " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DesahabilitarCampos();
            txtDniBuscar.Enabled = true;
            btnBuscarProfesional.Enabled = true;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            txtDniBuscar.Focus();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            txtDniBuscar.Enabled = false;
            btnBuscarProfesional.Enabled = false;
            btnEliminarProfesional.Enabled = false;
        }

        public bool ActualizarDatosProfesional()
        {
            int idUser = (int)Session["idUsuario"];
            Usuario user = (Usuario)Session["User"];
            user.idUsuario = idUser;
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
            }
            else
            {
                return false;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActualizarDatosProfesional())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Datos actualizados!', 'success')", true);
                    btnCancelar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnModificar.Enabled = true;
                    txtDniBuscar.Enabled = true;
                    txtDniBuscar.Text = "";
                    btnBuscarProfesional.Enabled = true;
                    txtDniBuscar.Focus();
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

        private void HabilitarCampos()
        {
            txtApellido.Enabled = true; ;
            txtNombre.Enabled = true;
            txtDni.Enabled = true;
            txtFecNac.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtMatricula.Enabled = true;
            cmbEspecialidad.Enabled = true;
            txtIngreso.Enabled = false;
            txtEdad.Enabled = false;
        }

        private void DesahabilitarCampos()
        {
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtDni.Enabled = false;
            txtFecNac.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtMatricula.Enabled = false;
            cmbEspecialidad.Enabled = false;
            txtIngreso.Enabled = false;
            txtEdad.Enabled = false;
        }

        private void LimpiarCampos()
        {
            txtDniBuscar.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtFecNac.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtMatricula.Text = "";        
            VaciarCombo();            
            txtIngreso.Text = "";
            txtEdad.Text = "";
        }

        public void VaciarCombo()
        {
            int indice = 0;
            cmbEspecialidad.DataSource = null;
            //cmbEspecialidad.DataTextField = "descripcion";
            //cmbEspecialidad.DataValueField = "idEspecialidad";
            cmbEspecialidad.DataBind();
            cmbEspecialidad.Items.Clear();
            cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
            //cmbEspecialidad.SelectedValue = "0";
        }

        public bool CamposVaciosModificar()
        {
            if (txtApellido.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar apellido')", true);
                txtApellido.Focus();
                return true;
            }
            if (txtNombre.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar nombre')", true);
                txtNombre.Focus();
                return true;
            }
            if (txtFecNac.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar fecha nacimiento')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar dirección')", true);
                txtDireccion.Focus();
                return true;
            }
            if (txtTelefono.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar telefono')", true);
                txtTelefono.Focus();
                return true;
            }
            if (cmbEspecialidad.SelectedIndex == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe seleccionar una especialidad')", true);
                cmbEspecialidad.Focus();
                return true;
            }
            if (txtMatricula.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar matricula')", true);
                txtMatricula.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }


        //boton para abrir la modal de eliminar el profesional
        protected void btnEliminarProfesional_Click(object sender, EventArgs e)
        {
            panelEliminarProfesional.Visible = true;
            Usuario user = (Usuario)Session["User"];
            lblApellidoEliminar.Text = user.apellido;
            lblNombreEliminar.Text = user.nombre;
            lblDniEliminar.Text = user.dni;
        }

        //cerrar modal con la cruz
        public void CerrarModalEliminar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelEliminarProfesional.Visible = false;
        }


        //boton volver de la modal
        protected void btnVolverModal_Click(object sender, EventArgs e)
        {
            panelEliminarProfesional.Visible = false;
        }

        //ELIMINAR Profesional
        public void EliminarProfesional()
        {
            Usuario user = (Usuario)Session["User"];         
            _profesionalBLL.EliminarProfesional(user);
        }

        //boton para confirmar la eliminacion del profesional
        protected void btnConfirmarEliminarModal_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarProfesional();
                panelEliminarProfesional.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se eliminó el profesional!', 'success')", true);
                LimpiarCampos();
                DesahabilitarCampos();
                btnEliminarProfesional.Enabled = false;
                txtDniBuscar.Enabled = true;
                btnModificar.Enabled = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo eliminar el profesional', 'error')", true);
                DesahabilitarCampos();
                btnEliminarProfesional.Enabled = false;
                txtDniBuscar.Enabled = true;
                btnModificar.Enabled = false;


            }
        }


    }
}