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

                btnConfirmarAtencion.Visible = false;
                              
            }
            btnImprimir.Disabled = true;
        }

        //boton para volver a ver los 3 botones
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            divPorDNI.Visible = false;
            divPorFecha.Visible = false;
            divCancelarPorFecha.Visible = false;
            btnDivPorDni.Visible = true;
            btnDivCancelarPorFecha.Visible = true;
            //btnCancelarPorFecha.Visible = true;
            btnDivPorFecha.Visible = true;
            txtDniBuscar.Text = "";
            dtpFecha.Value = "";
            dtpCancelarPorFecha.Value = "";
        }


        #region PORDNI        

        //metodo para buscar el paciente
        public bool BuscarPaciente()
        {
            if (txtDniBuscar.Text == "")
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

                CargarGrillaTurnos(idProfesional, dni);
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

            //si no hay turnos activos se muestra el mensaje
            if (turnos.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No hay turnos activos para este paciente')", true);
            }

            gvTurnos.DataSource = turnos;
            //aca va el if del Estado

            gvTurnos.DataBind();
        }


        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //tomar el id turno para cancelarlo
            int idTurno = Convert.ToInt32(e.CommandArgument);
            ViewState["idTurno"] = idTurno;

            if (e.CommandName.Equals("Cancelar"))
            {
                //boton cancelar turno en la grilla (apertura de modal)
                panelCancelarTurno.Visible = true;

                //solo cargamos campos de la modal
                ObtenerTurnoIdProfesionalDTO turnos = _profesionalBLL.ObtenerTurnoIdProfesional(int.Parse(ViewState["idTurno"].ToString()));

                lblDia.Text = turnos.dia;
                lblFecha.Text = turnos.fechaTurno.ToString().Substring(0, 10);
                lblHora.Text = turnos.horaTurno;
                lblDescripcion.Text = turnos.descripcion;
                lblPaciente.Text = turnos.paciente;
                lblObraSocial.Text = turnos.obraSocial;

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
                CargarGrillaTurnos(idProfesional, dni);
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

        protected void btnDivPorDni_Click(object sender, EventArgs e)
        {
            //se llama por el ID del div
            divPorDNI.Visible = true;
            btnDivPorDni.Visible = false;
            btnDivPorFecha.Visible = false;
            btnDivCancelarPorFecha.Visible = false;
        }

        #endregion PORDNI

        #region CANCELARPORFECHA

        //metodo para cargar grilla de turnos
        public void CargarGrillaCancelarPorFecha(int idProfesional, DateTime fecha)
        {
            //ViewState["fecha"] = fecha;
            List<ObtenerTurnosProfesionalDTO> turnos = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, fecha);

            gvCancelarPorFecha.DataSource = turnos;
            //gvTurnosPorFecha.DataKeys = turnos
            gvCancelarPorFecha.DataBind();
        }

        protected void btnDivCancelarPorFecha_Click(object sender, EventArgs e)
        {
            //se llama por el ID del div
            divCancelarPorFecha.Visible = true;
            btnDivPorDni.Visible = false;
            btnDivPorFecha.Visible = false;
            btnDivCancelarPorFecha.Visible = false;
            btnCancelarPorFecha.Visible = true;
        }

        //cerrar modal con cruz
        public void CerrarModalCancelarPorFecha(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelCancelarPorFecha.Visible = false;
        }


        //boton de busqueda por fecha
        protected void btnCancelarPorFecha_Click(object sender, EventArgs e)
        {
            if (dtpCancelarPorFecha.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha no puede estar vacia')", true);
                return;
            }
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            DateTime fecha = DateTime.Parse(dtpCancelarPorFecha.Value);
            ViewState["fecha"] = fecha;

            List<ObtenerTurnosProfesionalDTO> turnosPorFecha = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, DateTime.Parse(ViewState["fecha"].ToString()));

            if (turnosPorFecha.Count > 0)
            {
                CargarGrillaCancelarPorFecha(idProfesional, fecha);
                dtpCancelarPorFecha.Disabled = true;
                btnCancelarPorFecha.Enabled = false;
                //btnImprimir.Disabled = false;
                //btnConfirmarAtencion.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró turno/s en esta fecha')", true);
            }
        }

        //limpiar datos del paciente
        private void LimpiarDatosCancelar()
        {
            dtpCancelarPorFecha.Value = "";
            gvCancelarPorFecha.DataSource = null;
            gvCancelarPorFecha.DataBind();            
        }

        protected void btnLimpiarCancelarPorFecha_Click(object sender, EventArgs e)
        {
            LimpiarDatosCancelar();
            dtpCancelarPorFecha.Value = "";
            dtpCancelarPorFecha.Disabled = false;
            btnCancelarPorFecha.Enabled = true;
            gvCancelarPorFecha.DataSource = null;
            gvCancelarPorFecha.DataBind();
            
        }

        protected void gvCancelarPorFecha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //tomar el id turno para cancelarlo
            int idTurno = Convert.ToInt32(e.CommandArgument);
            ViewState["idTurno"] = idTurno;

            if (e.CommandName.Equals("Cancelar"))
            {
                //boton cancelar turno en la grilla (apertura de modal)
                panelCancelarPorFecha.Visible = true;

                //solo cargamos campos de la modal
                ObtenerTurnoIdProfesionalDTO turnos = _profesionalBLL.ObtenerTurnoIdProfesional(int.Parse(ViewState["idTurno"].ToString()));

                lblDiaCancelar.Text = turnos.dia;
                lblFechaCancelar.Text = turnos.fechaTurno.ToString().Substring(0, 10);
                lblHoraCancelar.Text = turnos.horaTurno;
                lblDescrCancelar.Text = turnos.descripcion;
                lblPacienteCancelar.Text = turnos.paciente;
                lblObraSocCancelar.Text = turnos.obraSocial;

            }
        }

        //salir de la modal
        protected void btnVolverCancelar_Click(object sender, EventArgs e)
        {
            panelCancelarPorFecha.Visible = false;
        }

        //metodo para cancelar el turno
        public bool CancelarTurnoPorFecha()
        {
            try
            {
                int idTurno = (int)ViewState["idTurno"];
                ObtenerTurnoIdDTO turno = _turnoBLL.ObtenerTurnoId(idTurno);
                _turnoBLL.CancelarTurno(idTurno);
                return true;

                //MAIL
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CancelarTurno " + ex.Message);
            }

        }

        //boton que cancela el turno
        protected void btnConfirmarCancelarPorFecha_Click(object sender, EventArgs e)
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            DateTime fecha = DateTime.Parse(dtpCancelarPorFecha.Value);
            ViewState["fecha"] = fecha;
            //se cancela el turno
            if (CancelarTurnoPorFecha())
            {
                panelCancelarPorFecha.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se canceló el turno!', 'success')", true);
                CargarGrillaCancelarPorFecha(idProfesional, fecha);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo cancelar el turno', 'error')", true);
                panelCancelarPorFecha.Visible = false;
            }
        }

        #endregion CANCELARPORFECHA

        #region ATENDIDOS        

        //metodo para cargar grilla de turnos
        public void CargarGrillaTurnosPorFecha(int idProfesional, DateTime fecha)
        {
            //ViewState["fecha"] = fecha;
            List<ObtenerTurnosProfesionalDTO> turnos = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, fecha);

            gvTurnosPorFecha.DataSource = turnos;
            //gvTurnosPorFecha.DataKeys = turnos
            gvTurnosPorFecha.DataBind();
        }

        protected void btnBuscarTurnosPorFecha_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha no puede estar vacia')", true);
                return;
            }
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            DateTime fecha = DateTime.Parse(dtpFecha.Value);
            ViewState["fecha"] = fecha;

            List<ObtenerTurnosProfesionalDTO> turnosPorFecha = _profesionalBLL.ObtenerTurnosPorFecha(idProfesional, DateTime.Parse(ViewState["fecha"].ToString()));

            if (turnosPorFecha.Count > 0)
            {
                CargarGrillaTurnosPorFecha(idProfesional, fecha);
                dtpFecha.Disabled = true;
                btnBuscarTurnosPorFecha.Enabled = false;
                btnImprimir.Disabled = false;
                btnConfirmarAtencion.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró turno/s en esta fecha')", true);
            }

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
            }
        }

        protected void btnDivPorFecha_Click(object sender, EventArgs e)
        {
            //se llama por el ID del div
            divPorFecha.Visible = true;
            btnDivPorDni.Visible = false;
            btnDivPorFecha.Visible = false;
            btnDivCancelarPorFecha.Visible = false;
            btnCancelarPorFecha.Visible = false;
        }

        //boton que limpia lo de buscar por fecha
        protected void btnLimpiarDatosPorFecha_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = "";
            dtpFecha.Disabled = false;
            btnBuscarTurnosPorFecha.Enabled = true;
            gvTurnosPorFecha.DataSource = null;
            gvTurnosPorFecha.DataBind();
            btnConfirmarAtencion.Visible = false;
        }

        //chekbox de atencion para marcar cada casilla de la grilla
        protected void chkAtencion_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkestado = (CheckBox)sender;
            GridViewRow fila = (GridViewRow)chkestado.NamingContainer;
        }

        //marcado de todos y que se seleccionen todas las casillas a la vez
        protected void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chktodos = (CheckBox)gvTurnosPorFecha.HeaderRow.FindControl("chkTodos");//id del front
            foreach (GridViewRow fila in gvTurnosPorFecha.Rows)
            {
                CheckBox row = (CheckBox)fila.FindControl("chkAtencion");//id del front

                if (chktodos.Checked == true)
                {
                    row.Checked = true;
                }
                else
                {
                    row.Checked = false;
                }
            }


        }

        //boton para confirmar turnos atendidos
        protected void btnConfirmarAtencion_Click(object sender, EventArgs e)
        {
            bool existeChecked = false;
            for (int i = 0; i < gvTurnosPorFecha.Rows.Count; i++)
            {
                CheckBox atencion = (CheckBox)gvTurnosPorFecha.Rows[i].Cells[8].FindControl("chkAtencion");
                if (atencion.Checked)
                {
                    existeChecked = true;
                }

            }
            if (!existeChecked)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'No selecciono ningun turno para modificar su estado', 'warning')", true);
                return;

            }



            DateTime fecha = (DateTime)ViewState["fecha"];
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;

            if (AtencionTurnos())
            {
                //panelCancelarTurno.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se actualizo la atencion', 'success')", true);
                CargarGrillaTurnosPorFecha(idProfesional, fecha);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo actualizar la atencion', 'error')", true);
                panelCancelarTurno.Visible = false;
            }
        }


        public bool AtencionTurnos()
        {
            try
            {
                bool atendido = false;
                for (int i = 0; i < gvTurnosPorFecha.Rows.Count; i++)
                {
                    CheckBox atencion = (CheckBox)gvTurnosPorFecha.Rows[i].Cells[8].FindControl("chkAtencion");
                    if (atencion.Checked)
                    {
                        if (gvTurnosPorFecha.Rows[i].Cells[7].Text != "Atendido")
                        {
                            atendido = true;
                        }
                        else
                        {
                            atendido = false;
                        }
                        int id = Convert.ToInt32(gvTurnosPorFecha.Rows[i].Cells[0].Text);
                        _turnoBLL.ActualizarAtencionTurno(id, atendido);
                    }


                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en actualizar atencion " + ex.Message);
            }
        }



        #endregion ATENDIDOS




    }
}