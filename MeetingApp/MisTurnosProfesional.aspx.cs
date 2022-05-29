using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using Entidades.DTOs;

namespace MeetingApp
{
    public partial class MisTurnosProfesional : System.Web.UI.Page
    {
        PacienteBLL _pacienteBLL = new PacienteBLL();
        ProfesionalBLL _profesionalBLL = new ProfesionalBLL();
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        TurnoBLL _turnoBLL = new TurnoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario profesional = (Usuario)Session["Usuario"];
                btnLimpiarDatos.Enabled = false;
                //CargarGrillaTurnos();
                    
                //txtEspecialidad.Text = MostrarEspecialidad();
                //txtProfesional.Text = profesional.apellido + ' ' + profesional.nombre;
                //CargarComboFormasDePagos();
            }
        }

        //metodo para buscar el paciente
        public bool BuscarPaciente()
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);

            if (paciente != null)
            {
                Session["idUsuario"] = paciente.idUsuario;//usuario almacenado en session
                Session["User"] = paciente;
                
                CargarGrillaTurnos(idProfesional,dni);
                return true;
            }
            else
            {
                return false;
            }

        }

        //boton buscar paciente
        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarPaciente())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se encontro un Paciente!', 'success')", true);
                    txtDniBuscar.Enabled = false;
                    btnBuscarPaciente.Enabled = false;
                    btnLimpiarDatos.Enabled = true;
                    //CargarGrillaTurnos();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo encontrar un paciente', 'error')", true);
                    txtDniBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Buscar Paciente " + ex.Message);
            }
        }

        //limpiar datos del paciente
        private void LimpiarDatos()
        {
            txtDniBuscar.Text = "";
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
            //txtDatos.Text = "";
            //txtObraSocial.Text = "";
        }

        //boton limpiar datos
        protected void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            txtDniBuscar.Enabled = true;
            btnBuscarPaciente.Enabled = true;
            btnLimpiarDatos.Enabled = false;
            
        }

        //metodo para cargar grilla de turnos
        public void CargarGrillaTurnos(int idProfesional, string dni)
        {           
            List<ObtenerTurnosProfesionalDTO> turnos = _profesionalBLL.ObtenerTurnosProfesionalPorPaciente(idProfesional, dni);
            gvTurnos.DataSource = turnos;
            //aca va el if del Estado
            gvTurnos.DataBind();
        }

        //tomar el id turno para cancelarlo
        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }



    }
}