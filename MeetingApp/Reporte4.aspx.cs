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

            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
                
            gvTurnos.DataSource = turnosPorMes;
            gvTurnos.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;

            //validamos que la fecha inicio sea anterior a la fecha fin
            DateTime fecha1 = DateTime.Parse(dtpFecha1.Value);//26/01 00:00
            DateTime fecha2 = DateTime.Parse(dtpFecha2.Value);//26/01 00:00

            if (fecha1.Date > fecha2.Date)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha (Desde) debe ser anterior a la fecha (Hasta)')", true);
                dtpFecha1.Focus();
                return;
            }

            ViewState["fecha1"] = fecha1;
            ViewState["fecha2"] = fecha2;

            //este viewstate es el creado en el metodo
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
                
            if (turnosPorMes.Count > 0)
            {
                CargarGrillaTurnos();
                btnLimpiar.Enabled = true;
                btnImprimir.Disabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró un paciente que tenga mas de un turno entre las fechas seleccionadas')", true);
                btnLimpiar.Enabled = true;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
            dtpFecha1.Value = "";
            dtpFecha2.Value = "";
            btnImprimir.Disabled = true;
        }

        






    }
}