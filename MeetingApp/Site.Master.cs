using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para cerrar la session
            //if (Session["Login"] != null)
            //{
            //    string usuario = Session["Login"].ToString();
            //    //lblBienvenida.Text = "Bienvenido/a " + usuario;
            //}
            //else
            //{
            //    Response.Redirect("InicioSesion.aspx");
            //}
        }
    }
}