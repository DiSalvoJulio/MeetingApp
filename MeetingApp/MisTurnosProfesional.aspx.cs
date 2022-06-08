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
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
                Usuario profesional = (Usuario)Session["Usuario"];
                btnLimpiarDatos.Enabled = false;

                btnImprimir.Disabled = true;

                //CargarGrillaTurnos();                    
                //txtEspecialidad.Text = MostrarEspecialidad();
                //txtProfesional.Text = profesional.apellido + ' ' + profesional.nombre;
                //CargarComboFormasDePagos();                
            }
            btnImprimir.Disabled = true;
        }

        //metodo para buscar el paciente
        public bool BuscarPaciente()
        {
            if (txtDniBuscar.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar un D.N.I')", true);
                return false;
            }
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);

            if (paciente != null)
            {
                Session["idUsuario"] = paciente.idUsuario;//usuario almacenado en session
                Session["User"] = paciente;
                
                CargarGrillaTurnos(idProfesional,dni);
                Session["dni"] = dni;
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
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);
            try
            {
                if (BuscarPaciente())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se encontro un Paciente!', 'success')", true);
                    txtDniBuscar.Enabled = false;
                    btnBuscarPaciente.Enabled = false;
                    btnLimpiarDatos.Enabled = true;
                    CargarGrillaTurnos(idProfesional, dni);
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
            //btnLimpiarDatos.Enabled = false;
            
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
            int idTurno = Convert.ToInt32(e.CommandArgument);
            ViewState["idTurno"] = idTurno;

            if (e.CommandName.Equals("Cancelar"))
            {
                //BOTON CANCELAR TURNO EN LA GRILLA
                panelCancelarTurno.Visible = true;

                //solo cargamos campos de la modal

                ObtenerTurnoIdDTO turnos = _turnoBLL.ObtenerTurnoId(int.Parse(ViewState["idTurno"].ToString()));

                lblDia.Text = turnos.dia;
                lblFecha.Text = turnos.fechaTurno.ToString().Substring(0, 10);
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

        protected void btnConfirmarCancelado_Click(object sender, EventArgs e)
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);
            //se cancela el turno
            if (CancelarTurno())
            {
                panelCancelarTurno.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se canceló el turno!', 'success')", true);
                CargarGrillaTurnos(idProfesional,dni);
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


        //metodo para cargar grilla de turnos
        public void CargarGrillaTurnosPorFecha(int idProfesional, DateTime fecha)
        {
            //ViewState["fecha"] = fecha;
            List<ObtenerTurnosProfesionalDTO> turnos = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, fecha);

            gvTurnosPorFecha.DataSource = turnos;            

            gvTurnosPorFecha.DataBind();
        }

        protected void btnBuscarTurnosPorFecha_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha no puede estar vacia')", true);
                return;
            }
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            DateTime fecha = DateTime.Parse(dtpFecha.Value);
            ViewState["fecha"] = fecha;

            List<ObtenerTurnosProfesionalDTO> turnosPorFecha = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, DateTime.Parse(ViewState["fecha"].ToString()));

            if (turnosPorFecha.Count>0)
            {
                CargarGrillaTurnosPorFecha(idProfesional, fecha);
                dtpFecha.Disabled = true;
                btnBuscarTurnosPorFecha.Enabled = false;
                btnImprimir.Disabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró turno/s en esta fecha')", true);
            }

            //Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);
            //try
            //{
            //    //if (BuscarPaciente())
            //    //{
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'turnos!', 'success')", true);
            //        //txtDniBuscar.Enabled = false;
            //        //btnBuscarPaciente.Enabled = false;
            //        //btnLimpiarDatos.Enabled = true;
            //        CargarGrillaTurnosPorFecha(idProfesional, fecha);
            //    //}
            //    //else
            //    //{
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo encontrar', 'error')", true);
            //        dtpFecha.Focus();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error en Buscar Paciente " + ex.Message);
            //}
        }

        protected void gvTurnosPorFecha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idTurno = Convert.ToInt32(e.CommandArgument);
            ViewState["idTurno"] = idTurno;

            if (e.CommandName.Equals("Imprimir"))
            {
                //BOTON CANCELAR TURNO EN LA GRILLA
                //panelCancelarTurno.Visible = true;

                //solo cargamos campos de la modal

                ObtenerTurnoIdDTO turnos = _turnoBLL.ObtenerTurnoId(int.Parse(ViewState["idTurno"].ToString()));

                //lblDia.Text = turnos.dia;
                //lblFecha.Text = turnos.fechaTurno.ToString().Substring(0, 10);
                //lblHora.Text = turnos.horaTurno;
                //lblDescripcion.Text = turnos.descripcion;
                //lblEspecialidad.Text = turnos.especialidad;
                //lblProfesional.Text = turnos.profesional;

            }
        }

        protected void btnDivPorDni_Click(object sender, EventArgs e)
        {
            //se llama por el ID del div
            divPorDNI.Visible = true;
            btnDivPorDni.Visible = false;
            btnDivPorFecha.Visible = false;
        }

        protected void btnDivPorFecha_Click(object sender, EventArgs e)
        {
            //se llama por el ID del div
            divPorFecha.Visible = true;
            btnDivPorDni.Visible = false;
            btnDivPorFecha.Visible = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            divPorDNI.Visible = false;
            divPorFecha.Visible = false;
            btnDivPorDni.Visible = true;
            btnDivPorFecha.Visible = true;
            txtDniBuscar.Text = "";
            dtpFecha.Value = "";
        }

        //boton que limpia lo de buscar por fecha
        protected void btnLimpiarDatosPorFecha_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = "";
            dtpFecha.Disabled = false;
            btnBuscarTurnosPorFecha.Enabled = true;
            gvTurnosPorFecha.DataSource = null;
            gvTurnosPorFecha.DataBind();
        }



    }
}