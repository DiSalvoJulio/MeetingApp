using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MeetingApp.Gestiones
{
    public partial class Default : System.Web.UI.Page
    {
        RegistrarBLL _registrarBLL = new RegistrarBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["Usuario"];
                CargarComboEspecialidades();
            }
        }

        #region MODAL HORARIO
        //ver modal
        protected void btnModificarHorarios_Click(object sender, EventArgs e)
        {
            panelHorarios.Visible = true;

        }

        //cerrar modal con cruz
        public void CerrarModalHorarios(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelHorarios.Visible = false;
        }
        #endregion

        #region MODAL PROFESIONES
        protected void btnModificarProfesiones_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelProfesiones.Visible = true;
        }

        //cerrar modal con cruz
        public void CerrarModalProfesiones(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelProfesiones.Visible = false;
        }

        //COMBO ESPECIALIDADES
        public void CargarComboEspecialidades()
        {
            try
            {
                List<Especialidad> listaEspecialidad = new List<Especialidad>();
                listaEspecialidad = _registrarBLL.ObtenerEspecialidades();
                cmbProfesion.Items.Clear();

                int indice = 0;
                if (listaEspecialidad.Count > 0)
                {
                    //cmbRubros es el ID del ASP
                    cmbProfesion.DataSource = listaEspecialidad;
                    cmbProfesion.DataTextField = "descripcion";
                    cmbProfesion.DataValueField = "idEspecialidad";
                    cmbProfesion.DataBind();
                    cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                    //cmbProfesion.Items[0].Attributes = false;
                }
                else
                {
                    cmbProfesion.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error en cargar combo especialidad " + ex.Message);
            }
        }

        #endregion

        #region MODAL OBRAS SOCIALES
        protected void btnModificarObrasSociales_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelObrasSociales.Visible = true;
        }
        //cerrar modal con cruz
        public void CerrarModalObrasSociales(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelObrasSociales.Visible = false;
        }
        #endregion

        #region MODAL PACIENTES
        protected void btnModificarPacientes_Click(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelPacientes.Visible = true;
        }
        //cerrar modal con cruz
        public void CerrarModalPacientes(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelPacientes.Visible = false;
        }

        #endregion

       
    }

}
