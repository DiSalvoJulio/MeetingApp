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
    public partial class ObrasSociales : System.Web.UI.Page
    {
        ObraSocialBLL _obraSocialBLL = new ObraSocialBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Usuario user = (Usuario)Session["Usuario"];
                CargarObrasSociales();//carga la grilla al inicio
            }
        }

        //METODO INSERTAR
        public void InsertarObraSocial()
        {
            ObraSocial obraSocial = new ObraSocial();
            obraSocial.descripcion = txtObraSocial.Text;            

            if (txtObraSocial.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo obra social')", true);
                txtObraSocial.Focus();
                return;
            }
            else
            {
                if (_obraSocialBLL.ValidarNombreObraSocial(obraSocial))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta Especialidad ya existe!')", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'El nombre de obra social ya existe!', 'warning')", true);
                    return;

                }
                else
                {
                    _obraSocialBLL.InsertarObraSocial(obraSocial);
                    txtObraSocial.Text = "";
                }
            }
        }

        //CONFIRMA OBRA SOCIAL
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarObraSocial();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Inserto la Obra Social!', 'success')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo insertar la Obra Social', 'error')", true);
            }

            CargarObrasSociales();
        }

        //CARGAR GRILLA OBRA SOCIAL
        public void CargarObrasSociales()
        {
            List<ObraSocial> obraS = _obraSocialBLL.ObtenerObraSocial();
            GVObrasSociales.DataSource = obraS;
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
            GVObrasSociales.DataBind();

        }

        //MODIFICAR OBRA SOCIAL
        public void ActualizarObraSocial()
        {
            ObraSocial obraS = new ObraSocial();
            obraS.descripcion = txtActualizarObraSocial.Text;
            obraS.idObraSocial = (int)ViewState["idObraSocial"];

            if (_obraSocialBLL.ValidarNombreObraSocial(obraS))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Cuidado!', 'Este nombre de Obra Social ya existe!', 'warning')", true);
                //return;
            }
            else
            {
                _obraSocialBLL.ActualizarObraSocial(obraS);
            }

        }


        //ACCIONES EN LA GRILLA
        protected void GVObrasSociales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idObraSocial = Convert.ToInt32(e.CommandArgument);
            ViewState["idObraSocial"] = idObraSocial;

            if (e.CommandName.Equals("Modificar"))
            {
                panelModificar.Visible = true;
                //solo cargamos campos de la modal
                ObraSocial obraS = _obraSocialBLL.SeleccionarIdObraSocial(int.Parse(ViewState["idObraSocial"].ToString()));
                txtActualizarObraSocial.Text = obraS.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                panelEliminar.Visible = true;
                ObraSocial obraS = _obraSocialBLL.SeleccionarIdObraSocial(int.Parse(ViewState["idObraSocial"].ToString()));
                txtEliminar.Text = obraS.descripcion.ToString();
                txtEliminar.Enabled = false;
            }
        }

        //BOTON CERRAR MODAL
        protected void btnCancelarObraSocial_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = false;
        }

        //cerrar modal con cruz
        public void CerrarModalObraSocial(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelModificar.Visible = false;
        }

        //BOTON PARA ACTUALIZAR LA OBRA SOCIAL
        protected void btnConfirmarObraSocial_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarObraSocial();
                panelModificar.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se Actualizo la Obra Social!', 'success')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo actualizar la Obra Social', 'error')", true);
            }

            CargarObrasSociales();
        }

        //BOTON AGREGAR NUEVA OBRA SOCIAL
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            divAgregarObraSocial.Visible = true;
            btnAgregar.Visible = false;
        }

        //Finaliza el agregar la obra social
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            divAgregarObraSocial.Visible = false;
            btnAgregar.Visible = true;
        }

        //ELIMINAR ESPECIALIDAD
        public void EliminarObraSocial()
        {
            ObraSocial obraS = new ObraSocial();
            obraS.idObraSocial = (int)ViewState["idObraSocial"];

            _obraSocialBLL.EliminarObraSocial(obraS);

        }

        //ELIMINAR OBRA SOCIAL
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            panelEliminar.Visible = true;
        }

        //cerrar modal eliminar con cruz
        public void CerrarModalEliminar(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelEliminar.Visible = false;
        }

        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            panelEliminar.Visible = false;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarObraSocial();
                panelEliminar.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Exito!', 'Se elimino la Obra Social!', 'success')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Error!', 'No se pudo eliminar la Obra Social!', 'error')", true);
            }

            CargarObrasSociales();
        }    


    }
}