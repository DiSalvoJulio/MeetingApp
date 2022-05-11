using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using Entidades.DTOs;

namespace MeetingApp.Gestiones
{
    public partial class Horarios : System.Web.UI.Page
    {
        DiaBLL _diaBLL = new DiaBLL();
        ProfesionalBLL _profesionalBLL = new ProfesionalBLL();
        HorarioBLL _horarioBLL = new HorarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboDias();
                CargarComboProfesional();
                VaciarTablaHorarios();
            }
        }

        //CARGAR COMBO DIAS
        public void CargarComboDias()
        {
            try
            {
                List<Dia> listaDia = new List<Dia>();
                listaDia = _diaBLL.ObtenerDias();
                cmbDias.Items.Clear();

                int indice = 0;
                if (listaDia.Count > 0)
                {
                    cmbDias.DataSource = listaDia;
                    cmbDias.DataTextField = "descripcion";
                    cmbDias.DataValueField = "idDia";
                    cmbDias.DataBind();
                    //cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                    //cmbEspecialidad.Items[0].Attributes = false;
                }
                else
                {
                    cmbDias.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccioar Dias...", "0"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo dia " + ex.Message);
            }
        }

        public void CargarTablaHorario()
        {
            List<ObtenerHorarioDTO> ListaObtenerHorarios = _horarioBLL.ObtenerHorarios(int.Parse(cmbProfesional.SelectedValue));
            if (cmbProfesional.SelectedIndex == 0)
            {
                VaciarTablaHorarios();
                return;
            }
            if (ListaObtenerHorarios.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'El Profesional no tiene horarios cargados', 'warning')", true);
            }
            gvHorario.DataSource = ListaObtenerHorarios;
            gvHorario.DataBind();
        }

        //CARGAR COMBO DIAS
        public void CargarComboProfesional()
        {
            try
            {
                List<ObtenerProfesionalDTO> listaProfesional = new List<ObtenerProfesionalDTO>();
                listaProfesional = _profesionalBLL.BuscarProfesional();
                cmbProfesional.Items.Clear();

                int indice = 0;
                if (listaProfesional.Count > 0)
                {
                    cmbProfesional.DataSource = listaProfesional;
                    cmbProfesional.DataTextField = "NombreApellido";//nombre de la entidad dto
                    cmbProfesional.DataValueField = "idProfesional";
                    cmbProfesional.DataBind();

                    cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccionar...", "0"));

                }
                else
                {
                    cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccionar...", "0"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo profesional " + ex.Message);
            }
        }

        //METODO HORARIOS POR DIA
        public List<Horario> CargarHorarioPorDia()
        {
            List<Horario> listaHorarios = new List<Horario>();
            if (cmbDias.Text == "1" || cmbDias.Text == "2" || cmbDias.Text == "3" || cmbDias.Text == "4" || cmbDias.Text == "5" || cmbDias.Text == "6")
            {
                if (cmbDesdeMañana.SelectedValue != "0" && cmbHastaMañana.SelectedValue != "0")
                {
                    cmbDesdeMañana.Text = cmbDesdeMañana.Items[cmbDesdeMañana.SelectedIndex].ToString();
                    cmbHastaMañana.Text = cmbHastaMañana.Items[cmbHastaMañana.SelectedIndex].ToString();
                    cmbDesdeTarde.Text = cmbDesdeTarde.Items[cmbDesdeTarde.SelectedIndex].ToString();
                    cmbHastaTarde.Text = cmbHastaTarde.Items[cmbHastaTarde.SelectedIndex].ToString();

                    //MAÑANA
                    Horario horarioMañana = new Horario();
                    horarioMañana.desde = cmbDesdeMañana.Text;
                    horarioMañana.hasta = cmbHastaMañana.Text;
                    horarioMañana.idDia = Convert.ToInt32(cmbDias.Text);
                    horarioMañana.idUsuarioProfesional = Convert.ToInt32(cmbProfesional.SelectedValue);
                    horarioMañana.turno = "Mañana";
                    int mañanaHasta = Convert.ToInt32(RecortarHorario(horarioMañana.hasta));
                    int mañanaDesde = Convert.ToInt32(RecortarHorario(horarioMañana.desde));
                    int cantidadMañana = (mañanaHasta - mañanaDesde);
                    horarioMañana.cantidad = cantidadMañana;
                    //horarioMañana.cantidad = CantidadTurnosMañana();
                    //listaHorarios.Add(horarioMañana);

                    _horarioBLL.InsertarHorario(horarioMañana);

                }
                else if (cmbDesdeTarde.SelectedValue == "0" && cmbHastaTarde.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'Debe seleccionar desde y hasta', 'error')", true);
                }

                if (cmbDesdeTarde.SelectedValue != "0" && cmbHastaTarde.SelectedValue != "0")
                {
                    //TARDE
                    Horario horarioTarde = new Horario();
                    horarioTarde.desde = cmbDesdeTarde.Text;
                    horarioTarde.hasta = cmbHastaTarde.Text;
                    horarioTarde.idDia = Convert.ToInt32(cmbDias.Text);
                    horarioTarde.idUsuarioProfesional = Convert.ToInt32(cmbProfesional.SelectedValue);
                    int tardeHasta = Convert.ToInt32(RecortarHorario(horarioTarde.hasta));
                    int tardeDesde = Convert.ToInt32(RecortarHorario(horarioTarde.desde));
                    int cantidadTarde = (tardeHasta - tardeDesde);
                    horarioTarde.cantidad = cantidadTarde;
                    //horarioTarde.cantidad = CantidadTurnosTarde();
                    horarioTarde.turno = "Tarde";
                    //listaHorarios.Add(horarioTarde);

                    _horarioBLL.InsertarHorario(horarioTarde);

                }
                else if (cmbDesdeTarde.SelectedValue == "0" && cmbHastaTarde.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'Debe seleccionar desde y hasta', 'error')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'El Dia Domingo No se puede Cargar', 'error')", true);
            }
            return listaHorarios;
        }

        //CORTAR HORA PARA HACER RESTA Y CALCULAR LA CANTIDAD DE TURNOS
        public string RecortarHorario(string hora)
        {
            string nuevaHora = hora.Substring(0, 2);
            return nuevaHora;
        }

        //BOTON DE CARGA DE HORARIOS
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarHorarioPorDia();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Horario cargado!', 'success')", true);
                LimpiarCombosHorarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar Horario " + ex.Message);
            }
            CargarTablaHorario();
        }

        protected void gvHorario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idHorario = Convert.ToInt32(e.CommandArgument);
            ViewState["idHorario"] = idHorario;

            if (e.CommandName.Equals("Modificar"))
            {
                //BOTON MODIFICAR EN LA GRILLA
                panelModificarHorario.Visible = true;
                horarioMañana.Visible = false;
                horarioTarde.Visible = false;
                //solo cargamos campos de la modal
                ObtenerHorarioDTO horarios = _horarioBLL.ObtenerHorarioId(int.Parse(ViewState["idHorario"].ToString()));
                h3Hora.Text = horarios.turno.ToString();
                lblDia.Text = horarios.dia;
                if (horarios.turno == "Mañana")
                {
                    horarioMañana.Visible = true;
                    cmbMañana1.SelectedValue = horarios.inicio;
                    cmbMañana2.SelectedValue = horarios.fin;
                }
                if (horarios.turno == "Tarde")
                {
                    horarioTarde.Visible = true;
                    cmbTarde1.SelectedValue = horarios.inicio;
                    cmbTarde2.SelectedValue = horarios.fin;
                }

                //txtActualizarEspecialidad.Text = horario.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                panelEliminarHorario.Visible = true;
                ObtenerHorarioDTO horarios = _horarioBLL.ObtenerHorarioId(int.Parse(ViewState["idHorario"].ToString()));
                //h3Hora.Text = horarios.turno.ToString();
                lblDiaEliminar.Text = horarios.dia;
                if (horarios.turno == "Mañana")
                {
                    horarioMañana.Visible = true;
                    lblMañanaDesdeEliminar.Text = horarios.inicio;
                    lblMañanaHastaEliminar.Text = horarios.fin;
                }
                if (horarios.turno == "Tarde")
                {
                    horarioTarde.Visible = true;
                    lblTardeDesdeEliminar.Text = horarios.inicio;
                    lblTardeHastaEliminar.Text = horarios.fin;
                }
            }
        }

        protected void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTablaHorario();
        }

        //cerrar modal con cruz
        public void CerrarModalHorario(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelModificarHorario.Visible = false;
        }


        //cerrar modal con cruz
        public void CerrarModalEliminar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelEliminarHorario.Visible = false;
        }

        public void LimpiarCombosHorarios()
        {
            cmbDesdeMañana.SelectedValue = "0";
            cmbHastaMañana.SelectedValue = "0";
            cmbDesdeTarde.SelectedValue = "0";
            cmbHastaTarde.SelectedValue = "0";
        }

        public void VaciarTablaHorarios()
        {
            cmbProfesional.SelectedValue = "0";
            gvHorario.DataSource = null;
            gvHorario.DataBind();
        }

        public void ActualizarHorario()
        {
            Horario nuevoHorario = new Horario();
            nuevoHorario.idHorario = int.Parse(ViewState["idHorario"].ToString());

            if (h3Hora.Text.ToString().Trim() == "Mañana")
            {
                nuevoHorario.desde = cmbMañana1.SelectedValue.ToString();
                nuevoHorario.hasta = cmbMañana2.SelectedValue.ToString();

                _horarioBLL.ActualizarHorario(nuevoHorario.idHorario, nuevoHorario.desde, nuevoHorario.hasta);
            }
            else
            {
                nuevoHorario.desde = cmbTarde1.SelectedValue.ToString();
                nuevoHorario.hasta = cmbTarde2.SelectedValue.ToString();
                _horarioBLL.ActualizarHorario(nuevoHorario.idHorario, nuevoHorario.desde, nuevoHorario.hasta);
            }
        }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarHorario();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Actualizo el horario!', 'success')", true);
                panelModificarHorario.Visible = false;
                CargarTablaHorario();
            }
            catch (Exception)
            {

            }
        }


    }
}