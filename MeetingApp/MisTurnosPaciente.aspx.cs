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
        TurnoBLL _turnoBLL = new TurnoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
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
            int idTurno = Convert.ToInt32(e.CommandArgument);
            ViewState["idTurno"] = idTurno;

            if (e.CommandName.Equals("Cancelar"))
            {
                //BOTON CANCELAR TURNO EN LA GRILLA
                panelCancelarTurno.Visible = true;              

                //solo cargamos campos de la modal
               
                ObtenerTurnoIdDTO turnos = _turnoBLL.ObtenerTurnoId(int.Parse(ViewState["idTurno"].ToString()));
                
                lblDia.Text = turnos.dia;
                lblFecha.Text = turnos.fechaTurno.ToString().Substring(0,10);
                lblHora.Text = turnos.horaTurno;
                lblDescripcion.Text = turnos.descripcion;
                lblEspecialidad.Text = turnos.especialidad;
                lblProfesional.Text = turnos.profesional;                    
                
            }
        }

        //cerrar modal con cruz
        public void CerrarModalCancelar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelCancelarTurno.Visible = false;
        }

        //boton cancelar de la modal para cerrarla
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCancelarTurno.Visible = false;
        }

        //boton para aceptar el cancelado del turno
        protected void btnConfirmarCancelado_Click(object sender, EventArgs e)
        {
            //se cancela el turno
            if (CancelarTurno())
            {
                panelCancelarTurno.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se canceló el turno!', 'success')", true);
                CargarGrillaTurnos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo cancelar el turno', 'error')", true);
                panelCancelarTurno.Visible = false;
            }
        }

        //metodo para cancelar el turno
        public bool CancelarTurno()
        {    
            try
            {
                int idTurno = (int)ViewState["idTurno"];
                ObtenerTurnoIdDTO turno = _turnoBLL.ObtenerTurnoId(idTurno);
                _turnoBLL.CancelarTurno(idTurno);
                

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CancelarTurno " + ex.Message);
            }
        
        }




    }
}