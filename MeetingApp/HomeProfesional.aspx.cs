﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MeetingApp
{
    public partial class HomeProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cerrar sesion en todos las paginas
            if (Session["Usuario"] == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
        }
    }
}