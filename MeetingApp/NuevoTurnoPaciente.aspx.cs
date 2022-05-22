using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using Entidades.DTOs;

namespace MeetingApp
{
    public partial class NuevoTurnoPaciente : System.Web.UI.Page
    {
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        TurnoBLL _turnoBLL = new TurnoBLL();
        HorarioBLL _horarioBLL = new HorarioBLL();

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

                int indice = 0;
                if (listaProfesionales.Count > 0)
                {
                    cmbProfesional.DataSource = listaProfesionales;
                    cmbProfesional.DataValueField = "idUsuario";
                    cmbProfesional.DataTextField = "apellido";
                    cmbProfesional.DataBind();
                    cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Profesional...", "0"));
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
           // CargarHorariosPorProfesional();
        }

        private void CargarHorariosPorProfesional()
        {

            
        }

        protected void btnMostrarHorarios_Click(object sender, EventArgs e)
        {
            if (txtCalendario.Value.Length != 0)
            {
                string diaEspanol = "";
                if (txtCalendario.Value.Equals(""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar un dia', 'warning')", true);
                    return;
                }
                DateTime dia = Convert.ToDateTime(txtCalendario.Value);
                if (dia.DayOfWeek.ToString() == "Sunday")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'El dia Domingo no se atiende', 'warning')", true);
                    return;
                }
                if (dia.DayOfWeek.ToString() == "Monday")
                {
                    diaEspanol = "Lunes";
                }
                if (dia.DayOfWeek.ToString() == "Tuesday")
                {
                    diaEspanol = "Martes";
                }
                if (dia.DayOfWeek.ToString() == "Wednesday")
                {
                    diaEspanol = "Miercoles";
                }
                if (dia.DayOfWeek.ToString() == "Thursday")
                {
                    diaEspanol = "Jueves";
                }
                if (dia.DayOfWeek.ToString() == "Friday")
                {
                    diaEspanol = "Viernes";
                }
                if (dia.DayOfWeek.ToString() == "Saturday")
                {
                    diaEspanol = "Sabado";
                }

                int idProfesional = int.Parse(cmbProfesional.SelectedValue);
                int idEspecialidad = int.Parse(cmbEspecialidad.SelectedValue);
                List<ObtenerTurnoDTO> listaTurnosDados = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(idProfesional, idEspecialidad, dia);
                List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf = _horarioBLL.ObtenerHorarioProfesionalDia(idProfesional, diaEspanol);
                

                TimeSpan inicio = TimeSpan.Parse(listaHorarioProf[0].desde);
                TimeSpan fin = TimeSpan.Parse(listaHorarioProf[0].hasta);

                List<HorariosDTO> listaHorarioDTO = new List<HorariosDTO>();
                
                while (inicio < fin)
                {
                    HorariosDTO horarioDTO = new HorariosDTO();
                    horarioDTO.Horario = inicio.ToString().Substring(0,5);
                    //cmbHorarioDisponible.Items.Insert(i, new ListItem(inicio.ToString(), inicio.ToString()));
                    inicio += TimeSpan.Parse("01:00");
                    //i++;
                    bool turnoDado = false;
                    for (int i = 0; i < listaTurnosDados.Count; i++)
                    {
                        if (horarioDTO.Horario==listaTurnosDados[i].horaTurno)
                        {
                            turnoDado = true;
                        }
                    }
                    if (!turnoDado)
                    {
                        listaHorarioDTO.Add(horarioDTO);                        
                    }
                }           

                cmbHorarioDisponible.DataSource = listaHorarioDTO;
                cmbHorarioDisponible.DataValueField = "Horario";
                cmbHorarioDisponible.DataTextField = "Horario";
                cmbHorarioDisponible.DataBind();
               
            }
        }
    }
}