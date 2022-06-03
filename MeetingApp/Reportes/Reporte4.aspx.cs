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
                //btnLimpiar.Enabled = false;
            }
        }

        //CARGAR GRILLA TURNOS ACTIVOS
        public void CargarGrillaTurnos()
        {
            int mes = int.Parse(cmbMes.SelectedValue);
            ViewState["mes"] = mes;
            
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(mes);
                
            gvTurnos.DataSource = turnosPorMes;
            gvTurnos.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {           

            int mes = int.Parse(cmbMes.SelectedValue);
            ViewState["mes"] = mes;
            //este viewstate es el creado en el metodo
            List<ObtenerTurnosPorMesDTO> turnosPorMes = _reporteBLL.ObtenerTurnosPorMes(mes);
                
            if (turnosPorMes.Count > 0)
            {
                CargarGrillaTurnos();
                btnLimpiar.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró un paciente que tenga mas de un turno por el mes seleccionado')", true);
                btnLimpiar.Enabled = true;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
        }

        






    }
}