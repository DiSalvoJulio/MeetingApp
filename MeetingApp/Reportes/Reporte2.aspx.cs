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
    public partial class Reporte2 : System.Web.UI.Page
    {
        ReporteBLL _reporteBLL = new ReporteBLL();

        //int[] cantPagos = new int[4];
        //string[] nombres = new string[4];

        protected void Page_Load(object sender, EventArgs e)
        {
            divGrafico.Visible = false;//sacamos que no se muestre el div
            if (!IsPostBack)
            {
                
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
                
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbMes.SelectedValue=="0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe seleccionar un Mes')", true);
                return;
            }
            else
            {
                obtenerDatos();
                
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMes.SelectedValue = "0";
            divGrafico.Visible = false;
        }

        public void obtenerDatos()
        {
            Usuario profesional = (Usuario)Session["Usuario"];
            int idProfesional = profesional.idUsuario;


            int[] cantPagos = new int[4];
            string[] nombres = new string[4];
            int cont = 0;
            int mes = int.Parse(cmbMes.SelectedValue);
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerFormasDePagosDTO> pagosPorMes = _reporteBLL.ObtenerFormasDePagos(idProfesional, mes);
            for (int i = 0; i < pagosPorMes.Count; i++)
            {
                cantPagos[cont] = pagosPorMes[i].cantidad;
                nombres[cont] = pagosPorMes[i].descripcion;
                cont++;

            }
            if (pagosPorMes.Count > 0)//cantPagos[cont]==0
            {
                gf_formasPagos.Series["Serie"].Points.DataBindXY(nombres, cantPagos);
                divGrafico.Visible = true;
                //btnImprimir.Visible = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('No hay datos para este Mes')", true);
                divGrafico.Visible = false;
                //btnImprimir.Disabled = true;
            }
        }


    }
}