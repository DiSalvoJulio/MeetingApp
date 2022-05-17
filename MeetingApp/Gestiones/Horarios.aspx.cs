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
                listaProfesional = _profesionalBLL.ObtenerListaProfesionales();
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

            List<ObtenerHorarioDTO> ListaObtenerHorarios = _horarioBLL.ObtenerHorarios(int.Parse(cmbProfesional.SelectedValue));
            bool turnoYaExiste = false;
            //validar con la consulta la tabla del profesional horario comparar 
            for (int i = 0; i < ListaObtenerHorarios.Count; i++)
            {
                string dia = "";
                if (cmbDias.Text == "1")
                {
                    dia = "Lunes";
                }
                if (cmbDias.Text == "2")
                {
                    dia = "Martes";
                }
                if (cmbDias.Text == "3")
                {
                    dia = "Miercoles";
                }
                if (cmbDias.Text == "4")
                {
                    dia = "Jueves";
                }
                if (cmbDias.Text == "5")
                {
                    dia = "Viernes";
                }
                if (cmbDias.Text == "6")
                {
                    dia = "Sabado";
                }
                if (ListaObtenerHorarios[i].dia == dia)
                {
                    string turno = "";
                    if (cmbDesdeMañana.SelectedIndex > 0 && cmbHastaMañana.SelectedIndex > 0)
                    {
                        turno = "mañana";
                    }
                    if (cmbDesdeTarde.SelectedIndex > 0 && cmbHastaTarde.SelectedIndex > 0)
                    {
                        turno = "tarde";
                    }
                    if (ListaObtenerHorarios[i].turno.ToLower() == turno)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'El profesional ya tiene un horario en ese turno', 'warning')", true);
                        turnoYaExiste = true;
                        break;
                    }
                }
            }

            if (!turnoYaExiste)
            {
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
            }

            return listaHorarios;
        }

        //CORTAR HORA PARA HACER RESTA Y CALCULAR LA CANTIDAD DE TURNOS
        public string RecortarHorario(string hora)
        {
            if (hora.Length == 1) return "0"; // 0 return "0"
            string nuevaHora = hora.Substring(0, 2);
            return nuevaHora;
        }

        //BOTON DE CARGA DE HORARIOS
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProfesional.SelectedValue != "0")//valida la seleccion del profesional
                {
                    if (!ValidarMañanaOTarde())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debse Ingresar al menos un horario mañana o tarde', 'warning')", true);
                        return;
                    }
                    if (ValidarDesdehasta())//valida fecha inicio anterior a fecha fin
                    {
                        CargarHorarioPorDia();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Horario cargado!', 'success')", true);
                        LimpiarCombosHorarios();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar un profesional para cargar un horario', 'warning')", true);
                }
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
                //ocultar divs
                divHorarioMañana.Visible = false;
                divHorarioTarde.Visible = false;

                //solo cargamos campos de la modal
                ObtenerHorarioDTO horarios = _horarioBLL.ObtenerHorarioId(int.Parse(ViewState["idHorario"].ToString()));
                lblHorario.Text = horarios.turno.ToString();
                lblDia.Text = horarios.dia;
                if (horarios.turno == "Mañana")
                {
                    divHorarioMañana.Visible = true;
                    cmbMañana1.SelectedValue = horarios.inicio;
                    cmbMañana2.SelectedValue = horarios.fin;
                }
                if (horarios.turno == "Tarde")
                {
                    divHorarioTarde.Visible = true;
                    cmbTarde1.SelectedValue = horarios.inicio;
                    cmbTarde2.SelectedValue = horarios.fin;
                }

                //txtActualizarEspecialidad.Text = horario.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                //BOTON ELIMINAR EN LA GRILLA
                panelEliminarHorario.Visible = true;
                //ocultar divs
                divHorarioEliminarMañana.Visible = false;
                divHorarioEliminarTarde.Visible = false;

                //solo cargamos campos de la modal
                ObtenerHorarioDTO horarios = _horarioBLL.ObtenerHorarioId(int.Parse(ViewState["idHorario"].ToString()));
                lblHorario.Text = horarios.turno.ToString();
                lblDiaEliminar.Text = horarios.dia;

                if (horarios.turno == "Mañana")
                {
                    divHorarioEliminarMañana.Visible = true;
                    lblMañanaDesdeEliminar.Text = horarios.inicio;
                    lblMañanaHastaEliminar.Text = horarios.fin;
                }
                if (horarios.turno == "Tarde")
                {
                    divHorarioEliminarTarde.Visible = true;
                    lblTardeDesdeEliminar.Text = horarios.inicio;
                    lblTardeHastaEliminar.Text = horarios.fin;
                }
            }
        }

        //cargar tabla con horarios
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

        //limpiar los combos de horarios
        public void LimpiarCombosHorarios()
        {
            cmbDesdeMañana.SelectedValue = "0";
            cmbHastaMañana.SelectedValue = "0";
            cmbDesdeTarde.SelectedValue = "0";
            cmbHastaTarde.SelectedValue = "0";
        }

        //vaciar tabla horarios
        public void VaciarTablaHorarios()
        {
            cmbProfesional.SelectedValue = "0";
            gvHorario.DataSource = null;
            gvHorario.DataBind();
        }

        //metodo actualizar horario
        public void ActualizarHorario()
        {
            Horario nuevoHorario = new Horario();
            nuevoHorario.idHorario = int.Parse(ViewState["idHorario"].ToString());

            if (lblHorario.Text.ToString().Trim() == "Mañana")
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

        //BOTON ACTUALIZAR
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarHorario();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Actualizo el horario!', 'success')", true);
                panelModificarHorario.Visible = false;
                CargarTablaHorario();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar horario " + ex.Message);
            }
        }

        //cerrar modal actualizar
        protected void btnSalirModalActualizar_Click(object sender, EventArgs e)
        {
            panelModificarHorario.Visible = false;
        }

        //metodo eliminar horario
        public void EliminarHorario()
        {
            Horario horario = new Horario();
            horario.idHorario = int.Parse(ViewState["idHorario"].ToString());
            _horarioBLL.EliminarHorario(horario);
        }

        //boton eliminar horario
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarHorario();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Elimino el horario!', 'success')", true);
                panelEliminarHorario.Visible = false;
                CargarTablaHorario();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar horario " + ex.Message);
            }
        }

        //cerrar modal eliminar
        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            panelEliminarHorario.Visible = false;
        }

        //validar que Hora de Inicio sea anterior a Hora Fin
        public bool ValidarDesdehasta()
        {
            //if (cmbDesdeMañana.SelectedValue=="0" && cmbHastaMañana.SelectedValue=="0")
            //{

            //}
            int desdeM = int.Parse(RecortarHorario(cmbDesdeMañana.Text));
            int hastaM = int.Parse(RecortarHorario(cmbHastaMañana.Text));
            int desdeT = int.Parse(RecortarHorario(cmbHastaTarde.Text));
            int hastaT = int.Parse(RecortarHorario(cmbHastaTarde.Text));

            if (desdeM > hastaM)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'Hora de Inicio debe ser anterior a Hora Fin', 'error')", true);
                return false;
            }
            if (desdeT < hastaT)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'Hora de Inicio debe ser anterior a Hora Fin', 'error')", true);
                return false;
            }
            return true;
        }

        public bool ValidarMañanaOTarde()
        {
            int desdeM = int.Parse(RecortarHorario(cmbDesdeMañana.SelectedValue));
            int hastaM = int.Parse(RecortarHorario(cmbHastaMañana.SelectedValue));
            int desdeT = int.Parse(RecortarHorario(cmbDesdeTarde.SelectedValue));
            int hastaT = int.Parse(RecortarHorario(cmbHastaTarde.SelectedValue));

            if ((desdeM == 0 && hastaM == 0) || (desdeT == 0 && hastaT == 0))
            {                
                return false;
            }
            return true;
        }

    }
}