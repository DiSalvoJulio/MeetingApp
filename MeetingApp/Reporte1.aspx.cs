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
    public partial class Reporte1 : System.Web.UI.Page
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
        public void CargarGrillaTurnosActivos()
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerTurnosActivosPorFechasDTO> turnosActivos = _reporteBLL.ObtenerTurnosActivosPorFechas(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
            gvTurnosActivos.DataSource = turnosActivos;
            gvTurnosActivos.DataBind();
        }

        //boton consultar turnos activos
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //validamos que la fecha inicio sea anterior a la fecha fin
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            DateTime fecha1 = DateTime.Parse(dtpFecha1.Value);//26/01 00:00
            DateTime fecha2 = DateTime.Parse(dtpFecha2.Value);//26/01 00:00

            if (fecha1.Date > fecha2.Date)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha (Desde) debe ser anterior a la fecha (Hasta)')", true);
                dtpFecha1.Focus();
                return;
            }
            //DateTime fecha1, fecha2 = DateTime.Today;
            //DateTime fecha1 = new DateTime();
            //DateTime fecha2 = new DateTime();
            //fecha1 = DateTime.Parse(dtpFecha1.Value);
            //fecha2 = DateTime.Parse(dtpFecha2.Value);
            ViewState["fecha1"] = fecha1;
            ViewState["fecha2"] = fecha2;
            //txtVentaTotalDiaria.Text = Convert.ToInt32(CalcularTotalPorFecha(ReportesBLL.VentaEntreFechas(fecha1, fecha2))).ToString();

            //este viewstate es el creado en el metodo
            List<ObtenerTurnosActivosPorFechasDTO> turnosActivos = _reporteBLL.ObtenerTurnosActivosPorFechas(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
            if (turnosActivos.Count > 0)
            {
                CargarGrillaTurnosActivos();
                btnImprimir.Disabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró turno activo entre esas fechas')", true);
                btnImprimir.Disabled = true;
            }
            
        }

        //boton para limpiar la grilla
        protected void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            gvTurnosActivos.DataSource = null;
            gvTurnosActivos.DataBind();
            dtpFecha1.Value = "";
            dtpFecha2.Value = "";
            btnImprimir.Disabled = true;
            
        }
    }
}