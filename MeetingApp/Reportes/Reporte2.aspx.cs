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

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            obtenerDatos();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        public void obtenerDatos()
        {
            int[] cantPagos = new int[4];
            string[] nombres = new string[4];
            int cont = 0;
            int mes = int.Parse(cmbMes.SelectedValue);
            //creamos el viewstate para usar esa fecha seleccionada
            List<ObtenerFormasDePagosDTO> pagosPorMes = _reporteBLL.ObtenerFormasDePagos(mes);
            for (int i = 0; i < pagosPorMes.Count; i++)
            {
                cantPagos[cont] = pagosPorMes[i].cantidad;
                nombres[cont] = pagosPorMes[i].descripcion;
                cont++;

            }
            gf_formasPagos.Series["Serie"].Points.DataBindXY(nombres, cantPagos);
        }


    }
}