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
    public partial class MisTurnosPaciente : System.Web.UI.Page
    {
        PacienteBLL _pacienteBLL = new PacienteBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario paciente = (Usuario)Session["Usuario"];
                Session["idPaciente"] = paciente.idUsuario;
                CargarGrillaTurnos();
            }
        }

        //CARGAR GRILLA ESPECIALIDAD
        public void CargarGrillaTurnos()
        {
            Usuario paciente = (Usuario)Session["Usuario"];
            int idPaciente = paciente.idUsuario;
            List<ObtenerTurnosPacienteDTO> turnos = _pacienteBLL.ObtenerTurnosPaciente(idPaciente);
            gvTurnos.DataSource = turnos;
        
            gvTurnos.DataBind();
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idPaciente = Convert.ToInt32(e.CommandArgument);
            ViewState["idPaciente"] = idPaciente;

            if (e.CommandName.Equals("Cancelar"))
            {
                //BOTON MODIFICAR EN LA GRILLA
                panelCancelarTurno.Visible = true;
                //ocultar divs
                //divHorarioMañana.Visible = false;
                //divHorarioTarde.Visible = false;

                //solo cargamos campos de la modal
                //ObtenerTurnosPacienteDTO turnos = _pacienteBLL.ObtenerTurnosPaciente(idPaciente);
                //ObtenerTurnosPacienteDTO turnos = _pacienteBLL.ObtenerTurnosPaciente(int.Parse(ViewState["idPaciente"].ToString()));
                //lblHorario.Text = horarios.turno.ToString();
                //lblDia.Text = horarios.dia;            

                //txtActualizarEspecialidad.Text = horario.descripcion.ToString();
            }
        }

        //cerrar modal con cruz
        public void CerrarModalCancelar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelCancelarTurno.Visible = false;
        }
    }
}