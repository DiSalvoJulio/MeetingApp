﻿using System;
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
    public partial class Reporte3 : System.Web.UI.Page
    {
        ReporteBLL _reporteBLL = new ReporteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        //CARGAR GRILLA TURNOS ACTIVOS
        public void CargarGrillaTurnosActivos()
        {
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerTurnosActivosPorFechasDTO> turnosCancelados = _reporteBLL.ObtenerTurnosCanceladosPorFechas(DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
            gvTurnosCancelados.DataSource = turnosCancelados;
            gvTurnosCancelados.DataBind();
        }

        //boton consultar turnos activos
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //DateTime fecha1, fecha2 = DateTime.Today;
            DateTime fecha1 = new DateTime();
            DateTime fecha2 = new DateTime();
            fecha1 = DateTime.Parse(dtpFecha1.Value);
            fecha2 = DateTime.Parse(dtpFecha2.Value);
            ViewState["fecha1"] = fecha1;
            ViewState["fecha2"] = fecha2;
            //txtVentaTotalDiaria.Text = Convert.ToInt32(CalcularTotalPorFecha(ReportesBLL.VentaEntreFechas(fecha1, fecha2))).ToString();

            //este viewstate es el creado en el metodo
            List<ObtenerTurnosActivosPorFechasDTO> turnosCancelados = _reporteBLL.ObtenerTurnosCanceladosPorFechas(DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()));
            if (turnosCancelados.Count > 0)
            {
                CargarGrillaTurnosActivos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró turno cancelado entre esas fechas')", true);
            }
        }

        //boton para limpiar la grilla
        protected void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            gvTurnosCancelados.DataSource = null;
            gvTurnosCancelados.DataBind();
        }


    }
}