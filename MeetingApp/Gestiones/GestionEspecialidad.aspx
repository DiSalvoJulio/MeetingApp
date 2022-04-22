<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEspecialidad.aspx.cs" Inherits="MeetingApp.Gestiones.GestionEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="GestionEspecialidad.css" rel="stylesheet" />
     <%-- SECCION 1--%>
    <section class="content-header">
        <h1 style="color: red; text-align: center">Gestiones</h1>
    </section>
    <%-- SECCION 2--%>
    <div class="container w-75">
        <hr class="color: red;" />
        <div class="row">
            <div class="alinear">
                <h4>Administraciones</h4>
                <h4>Acciones</h4>
            </div>
        </div>
        <hr />
         <%--ESPECIALIDADES--%>
        <div class="row">
            <div class="alinear">
                <h4>Profesiones</h4>
                <asp:Button ID="btnModificarProfesiones" Text="Modificar" runat="server" CssClass="btn btn-info" OnClick="btnModificarProfesiones_Click" />
            </div>
        </div>
        <hr />
        <!-- MODAL PROFESIONES -->
    <asp:Panel runat="server" ID="panelProfesiones" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content w-75" style="margin-left: 12.5%">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Profesiones</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalProfesiones">
                        </button>
                    </div>
                    <div class="modal-body col-md-10">
                        <%--CODIGO CUERPO MODAL--%>
                        <div class="row">
                            <asp:Label CssClass="col-6" ID="Label3" runat="server" Text="Profesion"></asp:Label>
                    <%--    </div>--%>
                        <%--                            <br />--%>
                       <%-- <div class="row">--%>
                            <asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-6" onClientClick="verDrop()" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>

                        <%--CIERRE CUERPO MODAL--%>
                    </div>
                    <!--Fin Body Modal-->
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarProfesiones" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                        <asp:Button ID="btnConfirmarProfesiones" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-backdrop fade show"></div>
    </asp:Panel>
    <%--FIN MODAL PROFESIONES---------------------------------------------------%>


        </div>
</asp:Content>
