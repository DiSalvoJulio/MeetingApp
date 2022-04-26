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
            _obraSocialBLL.InsertarObraSocial(obraSocial);
            CargarObrasSociales();//actualiza la grilla
        }

        //CONFIRMA OBRA SOCIAL
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ObraSocial obraS = new ObraSocial();
            obraS.descripcion = txtObraSocial.Text;

            if (txtObraSocial.Text.Equals(""))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Debe completar campo obra social')", true);
                txtObraSocial.Focus();
            }
            else
            {
                if (_obraSocialBLL.ValidarNombreObraSocial(obraS))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Esta Obra Social ya existe!')", true);
                }
                else
                {
                    InsertarObraSocial();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Obra Social Agregada con Exito')", true);
                    txtObraSocial.Text = "";
                }
            }
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
        public bool ActualizarObraSocial()
        {
            ObraSocial obraS = new ObraSocial();
            obraS.descripcion = txtActualizarObraSocial.Text;
            obraS.idObraSocial = (int)ViewState["idObraSocial"];

            if (_obraSocialBLL.ValidarNombreObraSocial(obraS))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Este nombre de Obra Social ya existe!')", true);
                return false;
            }
            else
            {
                _obraSocialBLL.ActualizarObraSocial(obraS);
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> swal('Exito!', 'Se Modifico la Obra Social!', 'success') </script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "swal('Se Modifico la Obra Social!')", true);
                return true;
                CargarObrasSociales();
            }

        }


        //ACCIONES EN LA GRILLA
        protected void GVObrasSociales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idObraSocial = Convert.ToInt32(e.CommandArgument);
            ViewState["idObraSocial"] = idObraSocial;

            if (e.CommandName.Equals("Modificar"))
            {
                //solo cargamos campos de la modal
                ObraSocial espe = _obraSocialBLL.SeleccionarIdObraSocial(int.Parse(ViewState["idObraSocial"].ToString()));
                txtActualizarObraSocial.Text = espe.descripcion.ToString();
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                //eliminar
            }
        }

        //Finaliza el agregar la obra social
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            divAgregarObraSocial.Visible = false;
            btnAgregar.Visible = true;
        }

        //BOTON MODIFICAR EN LA GRILLA
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = true;
        }

        //ELIMINAR OBRA SOCIAL
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        //cerrar modal con cruz
        public void CerrarModalObraSocial(object sender, EventArgs e)
        {
            //ID DEL PANEL DE LA MODAL
            panelModificar.Visible = false;
        }

        //BOTON CERRAR MODAL
        protected void btnCancelarObraSocial_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = false;
        }

        //BOTON PARA ACTUALIZAR LA OBRA SOCIAL
        protected void btnConfirmarObraSocial_Click(object sender, EventArgs e)
        {
            if (ActualizarObraSocial())
            {
                panelModificar.Visible = false;
               
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            divAgregarObraSocial.Visible = true;
            btnAgregar.Visible = false;
        }
    }
}