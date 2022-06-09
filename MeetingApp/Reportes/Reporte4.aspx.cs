using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using Entidades.DTOs;

namespace MeetingApp.Reportes
{
    public partial class Reporte4 : System.Web.UI.Page
    {
        ReporteBLL _reporteBLL = new ReporteBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
            }
        }

        //CARGAR GRILLA TURNOS ACTIVOS
        public void CargarGrillaTurnos()
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;

            int mes = int.Parse(cmbMes.SelectedValue);
            ViewState["mes"] = mes;
            
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(idProfesional, mes);
                
            gvTurnos.DataSource = turnosPorMes;
            gvTurnos.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;

            if (cmbMes.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe seleccionar un Mes')", true);
                return;
            }
            int mes = int.Parse(cmbMes.SelectedValue);
            ViewState["mes"] = mes;
            //este viewstate es el creado en el metodo
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(idProfesional, mes);
                
            if (turnosPorMes.Count > 0)
            {
                CargarGrillaTurnos();
                btnLimpiar.Enabled = true;
                btnImprimir.Disabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró un paciente que tenga mas de un turno en el (Mes) seleccionado')", true);
                btnLimpiar.Enabled = true;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
            cmbMes.SelectedValue = "0";
            btnImprimir.Disabled = true;
        }

        






    }
}