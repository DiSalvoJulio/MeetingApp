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
    public partial class Especialidades : System.Web.UI.Page
    {
        EspecialidadBLL _especialidadBLL = new EspecialidadBLL();
        CaracterEspecial caracter = new CaracterEspecial();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Usuario usuario = (Usuario)Session["Usuario"];
                //cerrar sesion en todos las paginas
                if (Session["Usuario"] == null)
                {
                    Session.Abandon();
                    //Response.Redirect("/Gestiones/InicioSesion.aspx");
                }
                //Usuario user = (Usuario)Session["Usuario"];
                CargarEspecialidades();//carga la grilla al inicio
                
            }
        }

        //METODO INSERTAR
        public void InsertarEspecialidad()
        {          
            Especialidad espe = new Especialidad();
            espe.descripcion = caracter.SacarTilde(txtEspecialidad.Text);

            if (txtEspecialidad.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo especialidad')", true);
                txtEspecialidad.Focus();
                return;
            }
            else
            {
                if (_especialidadBLL.ValidarNombreEspecialidad(espe))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta Especialidad ya existe!')", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'El nombre de especialidad ya existe!', 'warning')", true);
                    return;

                }
                else
                {
                    _especialidadBLL.InsertarEspecialidad(espe);                    
                    txtEspecialidad.Text = "";
                }
            }
        }

        //CONFIRMA ESPECIALIDAD
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarEspecialidad();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Inserto la Especialidad!', 'success')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo insertar la Especialidad', 'error')", true);
            }

            CargarEspecialidades();           
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
            espe.descripcion = caracter.SacarTilde(txtActualizarEspecialidad.Text);
            espe.idEspecialidad = (int)ViewState["idEspecialidad"];

            if (txtActualizarEspecialidad.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'El nombre no debe estar vacio', 'warning')", true);
                return false;
            }
            else
            {
                if (_especialidadBLL.ValidarNombreEspecialidad(espe))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'Este nombre de especialidad ya existe!', 'warning')", true);
                    return false;
                }
                else
                {
                    _especialidadBLL.ActualizarEspecialidad(espe);
                    return true;
                }
            }            

        }

        //ACCIONES EN LA GRILLA
        protected void GVEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(e.CommandArgument);
            ViewState["idEspecialidad"] = idEspecialidad;

            if (e.CommandName.Equals("Modificar"))
            {
                //BOTON MODIFICAR EN LA GRILLA
                panelModificar.Visible = true;
                //solo cargamos campos de la modal
                Especialidad espe = _especialidadBLL.SeleccionarIdEspecialidad(int.Parse(ViewState["idEspecialidad"].ToString()));
                txtActualizarEspecialidad.Text = espe.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                panelEliminar.Visible = true;
                Especialidad espe = _especialidadBLL.SeleccionarIdEspecialidad(int.Parse(ViewState["idEspecialidad"].ToString()));
                txtEliminar.Text = espe.descripcion.ToString();
                txtEliminar.Enabled = false;

            }
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
            try
            {
                if (ActualizarEspecialidad())
                {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Actualizo la Especialidad!', 'success')", true);
                    panelModificar.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo actualizar la Especialidad', 'error')", true);
                }                            
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo actualizar la Especialidad', 'error')", true);
                panelModificar.Visible = false;
            }

            CargarEspecialidades();
        }

        //BOTON AGREGAR NUEVA ESPECIALIDAD
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            divAgregarEspecialidad.Visible = true;
            btnAgregar.Visible = false;
        }

        //Finaliza el agregar la especialidad
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            divAgregarEspecialidad.Visible = false;
            btnAgregar.Visible = true;
            txtEspecialidad.Text = "";
        }

        //ELIMINAR ESPECIALIDAD
        public void EliminarEspecialidad()
        {
            Especialidad espe = new Especialidad();
            espe.idEspecialidad = (int)ViewState["idEspecialidad"];

            _especialidadBLL.EliminarEspecialidad(espe);                     

        }

        //ELIMINAR ESPECIALIDAD
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            panelEliminar.Visible = true;
        }

        //cerrar modal con cruz
        public void CerrarModalEliminar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelEliminar.Visible = false;
        }

        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            panelEliminar.Visible = false;
        }

        //ELIMINAR ESPECIALIDAD
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarEspecialidad();                
                panelEliminar.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se elimino la Especialidad!', 'success')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo eliminar la Especialidad!', 'error')", true);                
            }

            CargarEspecialidades();
        }

      
    }
}