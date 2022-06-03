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
    public partial class TurnoProfesional : System.Web.UI.Page
    {
        PacienteBLL _pacienteBLL = new PacienteBLL();
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        HorarioBLL _horarioBLL = new HorarioBLL();
        TurnoBLL _turnoBLL = new TurnoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario profesional = (Usuario)Session["Usuario"];
                btnLimpiarDatos.Enabled = false;
                txtEspecialidad.Text = MostrarEspecialidad();
                txtProfesional.Text = profesional.apellido + ' ' + profesional.nombre;
                CargarComboFormasDePagos();
            }
        }

        //metodo para buscar el paciente
        public bool BuscarPaciente()
        {
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);

            if (paciente != null)
            {
                Session["idUsuario"] = paciente.idUsuario;//usuario almacenado en session
                Session["User"] = paciente;
                CargarDatosPaciente(paciente);
                return true;
            }
            else
            {
                return false;
            }

        }

        //bucar el paciente para asignar turno
        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarPaciente())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se encontro un Paciente!', 'success')", true);
                    txtDniBuscar.Enabled = false;
                    btnBuscarPaciente.Enabled = false;
                    btnLimpiarDatos.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo encontrar un paciente', 'error')", true);
                    txtDniBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Buscar Paciente " + ex.Message);
            }
        }

        //Metodo para mostrar la obra social en txt
        public string MostrarObraSocial()
        {
            string dni = txtDniBuscar.Text;
            Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);
            string obraSocial = "";
            
            List<ObraSocial> listaObra = _obraSocialBLL.ObtenerObraSocial();
            foreach (ObraSocial item in listaObra)
            {
                if (paciente.idObraSocial == item.idObraSocial)
                {
                    obraSocial = item.descripcion;
                }
            }
            return obraSocial;
        }

        //metodo para cargar campo paciente
        private void CargarDatosPaciente(Usuario paciente)
        {
            //paciente = _pacienteBLL.BuscarPacienteDni(dni);
            txtDatos.Text = paciente.apellido + ' ' + paciente.nombre;
            txtObraSocial.Text = MostrarObraSocial();

        }

        //limpiar datos del paciente
        private void LimpiarDatos()
        {
            //int indice = 0;
            txtDniBuscar.Text = "";
            txtDatos.Text = "";
            txtObraSocial.Text = "";
            txtMotivo.Text = "";
            txtCalendario.Value = "";
            cmbFormaPago.SelectedValue = "0";
            //cmbHorarioDisponible.SelectedValue = "Horarios...";
            //cmbHorarioDisponible.Text = "Horarios...";
            //cmbFormaPago.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Forma de pago...", "0"));
            //cmbHorarioDisponible.Items.Insert(indice, new System.Web.UI.WebControls.ListItem("Horarios...", "0"));

        }

        protected void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            txtDniBuscar.Enabled = true;
            btnBuscarPaciente.Enabled = true;
            btnLimpiarDatos.Enabled = false;
            
        }

        //Metodo para mostrar la especialidad en txt
        public string MostrarEspecialidad()
        {
            //string dni = txtDniBuscar.Text;
            Usuario profesional = (Usuario)Session["Usuario"];
            string especialidad = "";
            
            List<Especialidad> listaEspe = _especialidadBLL.ObtenerEspecialidades();
            foreach (Especialidad item in listaEspe)
            {
                if (profesional.idEspecialidad == item.idEspecialidad)
                {
                    especialidad = item.descripcion;
                }
            }
            return especialidad;
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


        //mostrar horarios
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

                Usuario profesional = (Usuario)Session["Usuario"];

                //VER POR QUE NO SACA LA HORA CARGADA
                //int idHorarioProfesional = int.Parse(cmbProfesional.SelectedValue);
                int idHorarioProfesional = profesional.idUsuario;
                //int idEspecialidad = int.Parse(cmbEspecialidad.SelectedValue);
                List<ObtenerHorarioProfesionalDiaDTO> listaHorarioProf = _horarioBLL.ObtenerHorarioProfesionalDia(idHorarioProfesional, diaEspanol);
                List<ObtenerTurnoDTO> listaTurnosDados = new List<ObtenerTurnoDTO>();
                List<ObtenerTurnoDTO> List2 = new List<ObtenerTurnoDTO>();


                if (listaHorarioProf.Count == 2)
                {
                    listaTurnosDados = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(listaHorarioProf[0].idHorario, dia);
                    List2 = _turnoBLL.ObtenerTurnoPorProfesionalYEspecialidad(listaHorarioProf[1].idHorario, dia);
                    listaTurnosDados = listaTurnosDados.Concat<ObtenerTurnoDTO>(List2).ToList();
                    //hay que concatenar las Listas para que no muestre horarios reservados
                }
                if (listaHorarioProf.Count == 1)//aca habia un else
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
                    //crear lista horario
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
                    //List<HorariosDTO> listaNueva = listaHorarioDTO;
                    Session["Horario"] = listaHorarioDTO;



                }//cierre else

            }
        }

        public string horaSeleccionada()
        {
            List<HorariosDTO> horario = (List<HorariosDTO>)Session["Horario"];
            string hora = "";
            foreach (HorariosDTO item in horario)
            {
                if (cmbHorarioDisponible.SelectedItem.Text == item.Horario)
                {
                    hora = item.Horario;
                }
            }
            return hora;
        }


        //metodo para insertar el horario en turno y retornamos un Turno
        public Turno InsertarTurno()
        {
            try
            {
                Usuario user = (Usuario)Session["Usuario"];//USUARIO PROFESIONAL
                Usuario paciente = (Usuario)Session["User"];//USUARIO PACIENTE


                Turno turno = new Turno();
                turno.fechaSolicitud = DateTime.UtcNow;
                turno.idEspecialidad = user.idEspecialidad;
                turno.idHorarioProfesional = int.Parse(cmbHorarioDisponible.SelectedValue.Split('-')[1]);
                //con split separamos con gion cada posicion del arreglo,y el [1] que seria la segunda posicion del arreglo.
                turno.idUsuarioPaciente = paciente.idUsuario;
                turno.fechaTurno = txtCalendario.Value;
                //turno.horaTurno = cmbHorarioDisponible.SelectedValue;
                //turno.horaTurno = Convert.ToString(cmbHorarioDisponible.SelectedValue);

                turno.horaTurno = horaSeleccionada();
                turno.idFormaPago = int.Parse(cmbFormaPago.SelectedValue);
                turno.idObraSocial = paciente.idObraSocial;
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


        //boton para reservar el turno nuevo MODAL
        protected void btnReservarTurno_Click(object sender, EventArgs e)
        {
            Usuario paciente = (Usuario)Session["User"];//USUARIO PACIENTE
            if (ValidarCamposVaciosTurno())
            {
                panelConfirmarTurno.Visible = true;

                Turno turno = InsertarTurno();
                if (turno != null)
                {
                    //datos de la modal
                    //lblDia.Text = turno.descripcion;
                    lblFecha.Text = turno.fechaTurno;
                    lblHora.Text = turno.horaTurno;
                    lblDescripcion.Text = turno.descripcion;
                    lblPaciente.Text = paciente.apellido+ ' ' +paciente.nombre;
                    lblObraSocial.Text = MostrarObraSocial();
                    lblFormaPago.Text = MostrarFormaPago();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'No se pudo insertar un nuevo turno', 'warning')", true);

                }
            }

        }

        //recorrido de horarios de maniana y tarde
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
            int k = 1;//variable de recorrido del combo
            while (inicioM < finM)
            {
                HorariosDTO horarioDTO = new HorariosDTO();
                horarioDTO.Horario = inicioM.ToString().Substring(0, 5);
                //horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[0].idHorario);
                horarioDTO.idHorario = k.ToString() + "-" + listaHorarioProf[0].idHorario;//k agrega un valor a cada item del combobox

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
                k++;//en cada while le asigna un nuevo valor para obtener el value distinto del id
            }
            while (inicioT < finT)
            {
                HorariosDTO horarioDTO = new HorariosDTO();
                horarioDTO.Horario = inicioT.ToString().Substring(0, 5);
                //horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[1].idHorario);
                horarioDTO.idHorario = k.ToString() + "-" + listaHorarioProf[1].idHorario;
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
                k++;
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
                int k = 1;
                while (inicioT < finT)
                {
                    HorariosDTO horarioDTO = new HorariosDTO();
                    horarioDTO.Horario = inicioT.ToString().Substring(0, 5);
                    //horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[1].idHorario);
                    horarioDTO.idHorario = k.ToString() + "-" + listaHorarioProf[1].idHorario;
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
                    k++;
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

                int k = 1;

                while (inicioM < finM)
                {
                    HorariosDTO horarioDTO = new HorariosDTO();
                    horarioDTO.Horario = inicioM.ToString().Substring(0, 5);
                    //horarioDTO.idHorario = Convert.ToInt32(listaHorarioProf[0].idHorario);
                    horarioDTO.idHorario = k.ToString() + "-" + listaHorarioProf[0].idHorario;

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
                    k++;
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
        

        //salir de la modal confirma el turno
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelConfirmarTurno.Visible = false;
        }

        //confirma turno
        protected void btnConfirmarTurno_Click(object sender, EventArgs e)
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

        //Metodo para mostrar la forma de pago en modal
        public string MostrarFormaPago()
        {
            //string dni = txtDniBuscar.Text;
            //Usuario paciente = _pacienteBLL.BuscarPacienteDni(dni);
            string formaPago = "";

            List<FormaPago> lista = _turnoBLL.ObtenerFormasDePagos();
            foreach (FormaPago item in lista)
            {
                if (cmbFormaPago.SelectedIndex == item.idFormaPago)
                {
                    formaPago = item.descripcion;
                }
            }
            return formaPago;
        }

        public bool ValidarCamposVaciosTurno()
        {
            //if (cmbEspecialidad.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar especialidad', 'warning')", true);
            //    return false;
            //}
            //if (cmbProfesional.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Alerta!', 'Seleccionar profesional', 'warning')", true);
            //    return false;
            //}
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