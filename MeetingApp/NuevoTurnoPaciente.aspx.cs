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
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboEspecialidades();
                CargarComboFormasDePagos();
                //CargarComboObrasSociales();
                Usuario user = (Usuario)Session["Usuario"];
                //txtObraSocial.Text = user.idObraSocial.ToString();
                txtObraSocial.Text = MostrarObraSocial();
                //divProfesionales.Visible = false;
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
                    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Especialidad...", "0"));

                }
                //else
                //{
                //    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar una Especialidad', 'warning')", true);
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
            catch (Exception ex)
            {
                throw new Exception("Error en seleccionar combo " + ex.Message);
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
                    cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Profesional...", "0"));
                    //divProfesionales.Visible = true;
                }
                else
                {
                    if (cmbEspecialidad.SelectedValue != "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'La especialidad no tiene un profesional a cargo', 'warning')", true);
                        cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Profesional...", "0"));
                    }
                    if (cmbEspecialidad.SelectedValue == "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar una especialidad', 'warning')", true);
                        cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Profesional...", "0"));
                    }
                    //divProfesionales.Visible = false;
                    //cmbProfesional.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("No hay Profesional para esta especialidad", "0"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo especialidad por profesional " + ex.Message);
            }
        }

        //CARGAR COMBO FORMAS DE PAGOS
        public void CargarComboFormasDePagos()
        {
            try
            {
                List<FormaPago> listaFormasPagos = new List<FormaPago>();
                listaFormasPagos = _turnoBLL.ObtenerFormasDePagos();
                cmbFormaPago.Items.Clear();

                int indice = 0;
                if (listaFormasPagos.Count > 0)
                {
                    cmbFormaPago.DataSource = listaFormasPagos;
                    cmbFormaPago.DataTextField = "descripcion";
                    cmbFormaPago.DataValueField = "idFormaPago";
                    cmbFormaPago.DataBind();
                    cmbFormaPago.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Forma de pago...", "0"));

                }
                //else
                //{
                //    cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar una Especialidad', 'warning')", true);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error en cargar combo formas de pago " + ex.Message);
            }
        }

        //Metodo para mostrar la obra social en txt
        public string MostrarObraSocial()
        {
            Usuario user = (Usuario)Session["Usuario"];
            string obraSocial = "";
            //int id = 0;
            List<ObraSocial> listaObra = _obraSocialBLL.ObtenerObraSocial();
            foreach (ObraSocial item in listaObra)
            {
                if (user.idObraSocial == item.idObraSocial)
                {
                    obraSocial = item.descripcion;
                }                
            }
            return obraSocial;            
        }

        //CARGAR COMBO OBRAS SOCIALES
        //public void CargarComboObrasSociales()
        //{
        //    try
        //    {
        //        List<ObraSocial> listaObraSocial = new List<ObraSocial>();
        //        listaObraSocial = _obraSocialBLL.ObtenerObraSocial();
        //        cmbObraSocial.Items.Clear();

        //        int indice = 0;
        //        if (listaObraSocial.Count > 0)
        //        {
        //            cmbObraSocial.DataSource = listaObraSocial;
        //            cmbObraSocial.DataTextField = "descripcion";
        //            cmbObraSocial.DataValueField = "idObraSocial";
        //            cmbObraSocial.DataBind();
        //            cmbObraSocial.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Obra Social...", "0"));

        //        }
        //        else
        //        {
        //            cmbEspecialidad.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Seleccione Especialidad...", "0"));
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Debe seleccionar una Especialidad', 'warning')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error en cargar combo obras sociales " + ex.Message);
        //    }
        //}

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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'El dia Domingo no esta disponible para la atención', 'warning')", true);
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

                int idHorarioProfesional = int.Parse(cmbProfesional.SelectedValue);
                //int idEspecialidad = int.Parse(cmbEspecialidad.SelectedValue);
                List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf = _horarioBLL.ObtenerHorarioProfesionalDia(idHorarioProfesional, diaEspanol);
                List<ObtenerTurnoDTO> listaTurnosDados = new List<ObtenerTurnoDTO>();
                if (listaHorarioProf.Count>1)
                {
                    listaTurnosDados = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(listaHorarioProf[0].idHorario, dia);
                    listaTurnosDados = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(listaHorarioProf[1].idHorario, dia);
                }
                if (listaHorarioProf.Count > 0)//aca habia un else
                {
                    listaTurnosDados = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(listaHorarioProf[0].idHorario, dia);
                }
                if (!(listaTurnosDados.Count > 0) && !(listaHorarioProf.Count > 0))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'No hay horarios disponibles en ese dia', 'warning')", true);
                    cmbHorarioDisponible.Items.Clear();//limpiamos el combo
                    cmbHorarioDisponible.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Horarios...", "0"));
                    return;
                }
                else
                {
                    List<HorariosDTO> listaHorarioDTO = new List<HorariosDTO>();
                    //filtra la lista cuando tiene 2 horarios
                    if (listaHorarioProf.Count == 2)
                    {
                        listaHorarioDTO = tieneHorarioManianaTarde(listaHorarioProf, listaTurnosDados);
                    }
                    //filtra la lista con 1 horario maniana
                    if (listaHorarioProf.Count == 1 && listaHorarioProf[0].turno == "Mañana")
                    {
                        listaHorarioDTO = tieneHorarioManiana(listaHorarioProf, listaTurnosDados);
                    }
                    //filtra la lista con 1 horario tarde
                    if (listaHorarioProf.Count == 1 && listaHorarioProf[0].turno == "Tarde")
                    {
                        listaHorarioDTO = tieneHorarioTarde(listaHorarioProf, listaTurnosDados);
                    }
                    cmbHorarioDisponible.DataSource = listaHorarioDTO;
                    cmbHorarioDisponible.DataValueField = "idHorario";
                    cmbHorarioDisponible.DataTextField = "Horario";
                    cmbHorarioDisponible.DataBind();

                    //filtrar la lista cuando tiene 1 horario

                    //if (listaHorarioProf[0].turno == "Mañana" || listaHorarioProf[0].turno == "Tarde")
                    //{
                    //    if (listaHorarioProf[0].turno == "Tarde")
                    //    {
                    //        //tarde
                    //        TimeSpan inicioT = TimeSpan.Parse(listaHorarioProf[1].desde);
                    //        TimeSpan finT = TimeSpan.Parse(listaHorarioProf[1].hasta);
                    //        int k = 0;
                    //        while (inicioT < finT)
                    //        {
                    //            HorariosDTO horarioDTO = new HorariosDTO();
                    //            horarioDTO.Horario = inicioT.ToString().Substring(0, 5) + ' ' + "Hs.";
                    //            horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[1].idHorario);
                    //            inicioT += TimeSpan.Parse("01:00");
                    //            bool turnoDado = false;
                    //            for (int i = 0; i < listaTurnosDados.Count; i++)
                    //            {
                    //                if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                    //                {
                    //                    turnoDado = true;
                    //                }
                    //            }
                    //            if (!turnoDado)
                    //            {
                    //                listaHorarioDTO.Add(horarioDTO);
                    //            }
                    //            //k++;
                    //        }

                    //        cmbHorarioDisponible.DataSource = listaHorarioDTO;
                    //        cmbHorarioDisponible.DataValueField = "idHorario";
                    //        cmbHorarioDisponible.DataTextField = "Horario";
                    //        cmbHorarioDisponible.DataBind();
                    //    }
                    //    else if (listaHorarioProf[0].turno == "Mañana")
                    //    {
                    //        //mañana        
                    //        TimeSpan inicioM = TimeSpan.Parse(listaHorarioProf[0].desde);
                    //        TimeSpan finM = TimeSpan.Parse(listaHorarioProf[0].hasta);
                    //        int k = 0;

                    //        while (inicioM < finM)
                    //        {
                    //            HorariosDTO horarioDTO = new HorariosDTO();
                    //            horarioDTO.Horario = inicioM.ToString().Substring(0, 5) + ' ' + "Hs.";
                    //            horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[0].idHorario);

                    //            inicioM += TimeSpan.Parse("01:00");
                    //            bool turnoDado = false;
                    //            for (int i = 0; i < listaTurnosDados.Count; i++)
                    //            {
                    //                if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                    //                {
                    //                    turnoDado = true;
                    //                }
                    //            }
                    //            if (!turnoDado)
                    //            {
                    //                listaHorarioDTO.Add(horarioDTO);
                    //            }
                    //            k++;
                    //        }
                    //        cmbHorarioDisponible.DataSource = listaHorarioDTO;
                    //        cmbHorarioDisponible.DataValueField = "idHorario";
                    //        cmbHorarioDisponible.DataTextField = "Horario";
                    //        cmbHorarioDisponible.DataBind();
                    //    }

                    //}
                    //if ((listaHorarioProf.Count > 1))
                    //{
                    //    if (listaHorarioProf[1].turno == "Tarde")
                    //    {
                    //        //tarde
                    //        TimeSpan inicioT = TimeSpan.Parse(listaHorarioProf[1].desde);
                    //        TimeSpan finT = TimeSpan.Parse(listaHorarioProf[1].hasta);

                    //        while (inicioT < finT)
                    //        {
                    //            HorariosDTO horarioDTO = new HorariosDTO();
                    //            horarioDTO.Horario = inicioT.ToString().Substring(0, 5) + ' ' + "Hs.";
                    //            inicioT += TimeSpan.Parse("01:00");
                    //            bool turnoDado = false;
                    //            for (int i = 0; i < listaTurnosDados.Count; i++)
                    //            {
                    //                if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                    //                {
                    //                    turnoDado = true;
                    //                }
                    //            }
                    //            if (!turnoDado)
                    //            {
                    //                listaHorarioDTO.Add(horarioDTO);
                    //            }
                    //        }

                    //        cmbHorarioDisponible.DataSource = listaHorarioDTO;
                    //        cmbHorarioDisponible.DataValueField = "Horario";
                    //        cmbHorarioDisponible.DataTextField = "Horario";
                    //        cmbHorarioDisponible.DataBind();
                    //    }
                    //}

                }//cierre else

            }
        }

        //metodo para insertar el horario en turno y retornamos un Turno
        public Turno InsertarTurno()
        {
            try
            {
                Usuario user = (Usuario)Session["Usuario"];

                Turno turno = new Turno();
                turno.fechaSolicitud = DateTime.UtcNow;
                turno.idEspecialidad = int.Parse(cmbEspecialidad.SelectedValue);
                turno.idHorarioProfesional = int.Parse(cmbHorarioDisponible.SelectedValue);
                turno.fechaTurno = txtCalendario.Value;
                turno.horaTurno = cmbHorarioDisponible.SelectedItem.Text;
                turno.idFormaPago = int.Parse(cmbFormaPago.SelectedValue);
                turno.idObraSocial = user.idObraSocial;
                turno.descripcion = txtMotivo.Text.Trim();

                //Turno turnoNuevo = (Turno)Session["nuevoTurno"];
                Session["nuevoTurno"] = turno;
                return turno;
            }
            catch (Exception)
            {
                return null;
            }
                

        }

        //boton para reservar el turno nuevo
        protected void btnReservarTurno_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVaciosTurno())
            {                
                panelConfirmarTurno.Visible = true;

                Turno turno = InsertarTurno();
                if (turno != null)
                {
                    //datos de la modal
                    txtFecha.Text = turno.fechaTurno;
                    txtHora.Text = turno.horaTurno;
                    txtFormaPago.Text = turno.idFormaPago.ToString();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'No se pudo insertar un nuevo turno', 'warning')", true);
                }
            }          

        }

        public List<HorariosDTO> tieneHorarioManianaTarde(List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf, List<ObtenerTurnoDTO> listaTurnosDados)
        {
            if (listaHorarioProf == null || listaHorarioProf.Count != 2)
            {
                //mensaje de vacio
                return null;
            }
            List<HorariosDTO> listaHorarioDTO = new List<HorariosDTO>();

            TimeSpan inicioM = TimeSpan.Parse(listaHorarioProf[0].desde);
            TimeSpan finM = TimeSpan.Parse(listaHorarioProf[0].hasta);
            TimeSpan inicioT = TimeSpan.Parse(listaHorarioProf[1].desde);
            TimeSpan finT = TimeSpan.Parse(listaHorarioProf[1].hasta);
            //int k = 0;
            while (inicioM < finM)
            {
                HorariosDTO horarioDTO = new HorariosDTO();
                horarioDTO.Horario = inicioM.ToString().Substring(0, 5);
                horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[0].idHorario);

                inicioM += TimeSpan.Parse("01:00");
                bool turnoDado = false;
                for (int i = 0; i < listaTurnosDados.Count; i++)
                {
                    if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                    {
                        turnoDado = true;
                    }
                }
                if (!turnoDado)
                {
                    listaHorarioDTO.Add(horarioDTO);
                }
                //k++;
            }
            while (inicioT < finT)
            {
                HorariosDTO horarioDTO = new HorariosDTO();
                horarioDTO.Horario = inicioT.ToString().Substring(0, 5);
                horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[1].idHorario);
                inicioT += TimeSpan.Parse("01:00");
                bool turnoDado = false;
                for (int i = 0; i < listaTurnosDados.Count; i++)
                {
                    if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                    {
                        turnoDado = true;
                    }
                }
                if (!turnoDado)
                {
                    listaHorarioDTO.Add(horarioDTO);
                }
                //k++;
            }
            return listaHorarioDTO;
        }


        public List<HorariosDTO> tieneHorarioTarde(List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf, List<ObtenerTurnoDTO> listaTurnosDados)
        {
            List<HorariosDTO> listaHorarioDTO = new List<HorariosDTO>();
            if (listaHorarioProf[0].turno == "Tarde")
            {
                //tarde
                TimeSpan inicioT = TimeSpan.Parse(listaHorarioProf[1].desde);
                TimeSpan finT = TimeSpan.Parse(listaHorarioProf[1].hasta);
                //int k = 0;
                while (inicioT < finT)
                {
                    HorariosDTO horarioDTO = new HorariosDTO();
                    horarioDTO.Horario = inicioT.ToString().Substring(0, 5);
                    horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[1].idHorario);
                    inicioT += TimeSpan.Parse("01:00");
                    bool turnoDado = false;
                    for (int i = 0; i < listaTurnosDados.Count; i++)
                    {
                        if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                        {
                            turnoDado = true;
                        }
                    }
                    if (!turnoDado)
                    {
                        listaHorarioDTO.Add(horarioDTO);
                    }
                    //k++;
                }
            }
            return listaHorarioDTO;
        }



        public List<HorariosDTO> tieneHorarioManiana(List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf, List<ObtenerTurnoDTO> listaTurnosDados)
        {
            List<HorariosDTO> listaHorarioDTO = new List<HorariosDTO>();
            if (listaHorarioProf[0].turno == "Mañana")
            {
                //mañana        
                TimeSpan inicioM = TimeSpan.Parse(listaHorarioProf[0].desde);
                TimeSpan finM = TimeSpan.Parse(listaHorarioProf[0].hasta);
                //int k = 0;

                while (inicioM < finM)
                {
                    HorariosDTO horarioDTO = new HorariosDTO();
                    horarioDTO.Horario = inicioM.ToString().Substring(0, 5);
                    horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[0].idHorario);

                    inicioM += TimeSpan.Parse("01:00");
                    bool turnoDado = false;
                    for (int i = 0; i < listaTurnosDados.Count; i++)
                    {
                        if (horarioDTO.Horario == listaTurnosDados[i].horaTurno)
                        {
                            turnoDado = true;
                        }
                    }
                    if (!turnoDado)
                    {
                        listaHorarioDTO.Add(horarioDTO);
                    }
                    //k++;
                }
            }
            return listaHorarioDTO;
        }


        //cerrar modal con cruz
        public void CerrarModalTurno(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelConfirmarTurno.Visible = false;
        }

        //confirma turno
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            Turno turno = (Turno)Session["nuevoTurno"];
            bool result = _turnoBLL.InsertarTurno(turno);
            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'El turno se genero correctamente', 'success')", true);
                //limpiar campos
                panelConfirmarTurno.Visible = false;
            }
        }

        public bool ValidarCamposVaciosTurno()
        {
            if (cmbEspecialidad.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar especialidad', 'warning')", true);
                return false;
            }
            if (cmbProfesional.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar profesional', 'warning')", true);
                return false;
            }
            if (txtCalendario.Value.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar fecha', 'warning')", true);
                return false;
            }
            if (cmbHorarioDisponible.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar horario', 'warning')", true);
                return false;
            }
            if (cmbFormaPago.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar forma de pago', 'warning')", true);
                return false;
            }
            if (txtMotivo.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Completar un motivo', 'warning')", true);
                return false;
            }
            return true;
        }



    }
}