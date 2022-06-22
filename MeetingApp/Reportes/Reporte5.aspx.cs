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
    public partial class Reporte5 : System.Web.UI.Page
    {
        ReporteBLL _reporteBLL = new ReporteBLL();
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
                CargarComboObrasSociales();
            }
        }

        //CARGAR COMBO OBRAS SOCIALES
        public void CargarComboObrasSociales()
        {
            try
            {
                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();
                listaObrasSociales = _obraSocialBLL.ObtenerObraSocial();
                cmbObraSocial.Items.Clear();

                int indice = 0;
                if (listaObrasSociales.Count > 0)
                {
                    cmbObraSocial.DataSource = listaObrasSociales;
                    cmbObraSocial.DataTextField = "descripcion";
                    cmbObraSocial.DataValueField = "idObraSocial";
                    cmbObraSocial.DataBind();
                    cmbObraSocial.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccionar...", "0"));
                    
                }
                else
                {
                    cmbObraSocial.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccionar...", "0"));
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error en cargar combo obras sociales " + ex.Message);
            }
        }

        //CARGAR GRILLA TURNOS ACTIVOS
        public void CargarGrillaTurnosActivos()
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            int idObraSocial = Convert.ToInt32(cmbObraSocial.SelectedValue);

            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerAtendidosPorObraSocialDTO> turnosPorObraSocial = _reporteBLL.ObtenerTurnosAtendidosPorObraSocial(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()), idObraSocial);

            gvTurnosAtendidos.DataSource = turnosPorObraSocial;
            gvTurnosAtendidos.DataBind();
        }


        //boton consultar datos
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;
            int idObraSocial = Convert.ToInt32(cmbObraSocial.SelectedValue);

            //validamos que la fecha inicio sea anterior a la fecha fin
            DateTime fecha1 = DateTime.Parse(dtpFecha1.Value);//26/01 00:00
            DateTime fecha2 = DateTime.Parse(dtpFecha2.Value);//26/01 00:00

            if (fecha1.Date > fecha2.Date)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('La fecha (Desde) debe ser anterior a la fecha (Hasta)')", true);
                dtpFecha1.Focus();
                return;
            }
            if (cmbObraSocial.SelectedValue== "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe seleccionar una obra social')", true);
                cmbObraSocial.Focus();
                return;
            }

            ViewState["fecha1"] = fecha1;
            ViewState["fecha2"] = fecha2;

            //este viewstate es el creado en el metodo
            List<ObtenerAtendidosPorObraSocialDTO> turnosPorObraSocial = _reporteBLL.ObtenerTurnosAtendidosPorObraSocial(idProfesional, DateTime.Parse(ViewState["fecha1"].ToString()), DateTime.Parse(ViewState["fecha2"].ToString()), idObraSocial);

            if (turnosPorObraSocial.Count > 0)
            {
                CargarGrillaTurnosActivos();
                btnLimpiar.Enabled = true;
                btnImprimir.Disabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No se encontró un turno con la obra social seleccionada')", true);
                btnLimpiar.Enabled = true;
            }
        }

        //limpiar campos
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            gvTurnosAtendidos.DataSource = null;
            gvTurnosAtendidos.DataBind();
            dtpFecha1.Value = "";
            dtpFecha2.Value = "";
            cmbObraSocial.SelectedValue = "0";
            btnImprimir.Disabled = true;
        }


    }
}