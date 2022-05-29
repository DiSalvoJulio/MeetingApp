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
    public partial class TurnoProfesional : System.Web.UI.Page
    {
        PacienteBLL _pacienteBLL = new PacienteBLL();
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
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
            txtDniBuscar.Text = "";
            txtDatos.Text = "";
            txtObraSocial.Text = "";
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




    }
}