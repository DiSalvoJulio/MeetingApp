using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace MeetingApp
{
    public partial class NuevoTurnoPaciente : System.Web.UI.Page
    {
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        TurnoBLL _turnoBLL = new TurnoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboEspecialidades();
                divProfesionales.Visible = false;
            }
        }


        //CARGAR COMBO ESPECIALIDADES
        public void CargarComboEspecialidades()
        {
            try
            {
                List<Especialidad> listaEspecialidad = new List<Especialidad>();
                listaEspecialidad = _especialidadBLL.ObtenerEspecialidades();
                cmbEspecialidad.Items.Clear();

                int indice = 0;
                if (listaEspecialidad.Count > 0)
                {
                    cmbEspecialidad.DataSource = listaEspecialidad;
                    cmbEspecialidad.DataTextField = "descripcion";
                    cmbEspecialidad.DataValueField = "idEspecialidad";
                    cmbEspecialidad.DataBind();
                    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));

                }
                //else
                //{
                //    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo especialidad " + ex.Message);
            }
        }

        //combo en cadena - carga la especialidad y al seleccionar carga el combo profesionales
        protected void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idEspecialidad = int.Parse(cmbEspecialidad.SelectedValue);
                CargarComboProfesionalesxEspecialidad(idEspecialidad);
            }
            catch (Exception)
            {
                //programar error
            }
        }

        private void CargarComboProfesionalesxEspecialidad(int idEspecialidad)
        {
            try
            {
                List<Usuario> listaProfesionales = new List<Usuario>();
                listaProfesionales = _turnoBLL.ObtenerProfesionalesXEspecialidad(idEspecialidad);
                cmbProfesional.Items.Clear();

                //int indice = 0;
                if (listaProfesionales.Count > 0)
                {
                    cmbProfesional.DataSource = listaProfesionales;
                    cmbProfesional.DataValueField = "idUsuario";
                    cmbProfesional.DataTextField = "apellido";
                    cmbProfesional.DataBind();
                    divProfesionales.Visible = true;
                }
                else
                {
                    if (cmbProfesional.SelectedValue != "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'La Especialidad no tiene un Profesional a cargo', 'warning')", true);
                    }
                    divProfesionales.Visible = false;
                    //cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("No hay Profesional para esta especialidad", "0"));
                }
            }
            catch (Exception ex)
            {
                //mensaje error
            }
        }

        protected void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHorariosPorProfesional();
        }

        private void CargarHorariosPorProfesional()
        {
            if (txtCalendario.Text.Length != 0)
            {
                string diaEspañol = "";
                if (txtCalendario.Text.Equals(""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar un dia', 'warning')", true);
                    return;
                }
                DateTime dia = Convert.ToDateTime(txtCalendario.Text);
                if (dia.DayOfWeek.ToString() == "Sunday")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'El dia Domingo no se atiende', 'warning')", true);
                    return;
                }
                if (dia.DayOfWeek.ToString() == "Monday")
                {
                    diaEspañol = "Lunes";
                }
                if (dia.DayOfWeek.ToString() == "Tuesday")
                {
                    diaEspañol = "Martes";
                }
                if (dia.DayOfWeek.ToString() == "Wednesday")
                {
                    diaEspañol = "Miercoles";
                }
                if (dia.DayOfWeek.ToString() == "Thursday")
                {
                    diaEspañol = "Jueves";
                }
                if (dia.DayOfWeek.ToString() == "Friday")
                {
                    diaEspañol = "Viernes";
                }
                if (dia.DayOfWeek.ToString() == "Saturday")
                {
                    diaEspañol = "Sabado";
                }


                //int idProfesional = int.Parse(cmbProfesional.SelectedValue);
                //_nuevoTurnoPacienteBLL.ObtenerProfesionalesXEspecialidad(idProfesional, diaEspañol);

                //llamar metodo de la dal
            }
        }



    }
}