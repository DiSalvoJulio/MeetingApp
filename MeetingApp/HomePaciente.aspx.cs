using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class HomePaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cerrar sesion en todos las paginas
                if (Session["Usuario"]==null)
                {
                    Session["Usuario"] = null;
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                    Response.Redirect("InicioSesion.aspx");
                }
            }

            //cerrar sesion en todos las paginas
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("InicioSesion.aspx");
            }
        }



    }
}