using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace MeetingApp.Gestiones
{
    public partial class Especialidades : System.Web.UI.Page
    {
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Usuario user = (Usuario)Session["Usuario"];
                CargarEspecialidades();//carga la grilla al inicio
            }
        }

        //METODO INSERTAR
        public void InsertarEspecialidad()
        {
            Especialidad especialidad = new Especialidad();
            especialidad.descripcion = txtEspecialidad.Text;
            _especialidadBLL.InsertarEspecialidad(especialidad);
            CargarEspecialidades();//actualiza la grilla
        }

        //CONFIRMA ESPECIALIDAD
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Especialidad espe = new Especialidad();
            espe.descripcion = txtEspecialidad.Text;

            if (txtEspecialidad.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo especialidad')", true);
                txtEspecialidad.Focus();
            }
            else
            {
                if (_especialidadBLL.ValidarNombreEspecialidad(espe))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta Especialidad ya existe!')", true);
                }
                else
                {
                    InsertarEspecialidad();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Especialidad Agregada con Exito')", true);
                    txtEspecialidad.Text = "";
                }
            }
        }

        //CARGAR GRILLA ESPECIALIDAD
        public void CargarEspecialidades()
        {
            List<Especialidad> espe = _especialidadBLL.ObtenerEspecialidades();
            GVEspecialidades.DataSource = espe;
            //for (int i = 0; i < rubros.Count; i++)
            //{
            //    if (rubros[i].activo)
            //    {
            //        rubros[i].activoString = "✔";
            //    }
            //    else
            //    {
            //        rubros[i].activoString = "❌";

            //    }
            //}
            GVEspecialidades.DataBind();

        }

        //MODIFICAR ESPECIALIDAD
        public bool ActualizarEspecialidad()
        {
            Especialidad espe = new Especialidad();
            espe.descripcion = txtActualizarEspecialidad.Text;
            espe.idEspecialidad = (int)ViewState["idEspecialidad"];

            if (_especialidadBLL.ValidarNombreEspecialidad(espe))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Este nombre de especialidad ya existe!')", true);
                return false;
            }
            else
            {
                _especialidadBLL.ActualizarEspecialidad(espe);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Exito!', 'Se Modifico la Especialidad!', 'success') </script>");
                return true;

            }

        }

        //ACCIONES EN LA GRILLA
        protected void GVEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(e.CommandArgument);
            ViewState["idEspecialidad"] = idEspecialidad;

            if (e.CommandName.Equals("Modificar"))
            {
                //solo cargamos campos de la modal
                Especialidad espe = _especialidadBLL.SeleccionarIdEspecialidad(int.Parse(ViewState["idEspecialidad"].ToString()));
                txtActualizarEspecialidad.Text = espe.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                Especialidad espe = _especialidadBLL.SeleccionarIdEspecialidad(int.Parse(ViewState["idEspecialidad"].ToString()));
            }
        }

        //BOTON MODIFICAR EN LA GRILLA
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = true;
        }

        //BOTON CERRAR MODAL
        protected void btnCancelarEspecialidad_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = false;
        }

        //cerrar modal con cruz
        public void CerrarModalEspecialidad(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelModificar.Visible = false;
        }

        //BOTON PARA ACTUALIZAR LA ESPECIALIDAD
        protected void btnConfirmarEspecialidad_Click(object sender, EventArgs e)
        {
            if (ActualizarEspecialidad())
            {
                panelModificar.Visible = false;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            divAgregarEspecialidad.Visible = true;
            btnAgregar.Visible = false;
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            divAgregarEspecialidad.Visible = false;
            btnAgregar.Visible = true;
        }

        //MODIFICAR ESPECIALIDAD
        public bool EliminarEspecialidad()
        {
            Especialidad espe = new Especialidad();
            espe.idEspecialidad = (int)ViewState["idEspecialidad"];

            _especialidadBLL.EliminarEspecialidad(espe);

            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Exito!', 'Se Modifico la Especialidad!', 'success') </script>");

            return true;

        }

        //ELIMINAR ESPECIALIDAD
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEspecialidad();
        }


    }
}