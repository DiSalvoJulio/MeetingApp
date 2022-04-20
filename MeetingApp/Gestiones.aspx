<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestiones.aspx.cs" Inherits="MeetingApp.Gestiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Gestiones.css" rel="stylesheet" />
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
        <%--HORARIOS--%>
        <div class="row">
            <div class="alinear">
                <h4>Horarios</h4>
                <asp:Button ID="btnModificarHorarios" Text="Modificar" runat="server" CssClass="btn btn-info" OnClick="btnModificarHorarios_Click" />
            </div>
        </div>
        <hr />
        <%--PROFESIONES--%>
        <div class="row">
            <div class="alinear">
                <h4>Profesiones</h4>
                <asp:Button ID="btnModificarProfesiones" Text="Modificar" runat="server" CssClass="btn btn-info" OnClick="btnModificarProfesiones_Click" />
            </div>
        </div>
        <hr />
        <%--OBRAS SOCIALES--%>
        <div class="row">
            <div class="alinear">
                <h4>Obras sociales</h4>
                <asp:Button ID="btnModificarObrasSociales" Text="Modificar" runat="server" CssClass="btn btn-info" OnClick="btnModificarObrasSociales_Click" />
            </div>
        </div>
        <hr />
        <%--PACIENTES--%>
        <div class="row">
            <div class="alinear">
                <h4>Pacientes</h4>
                <asp:Button ID="btnModificarPacientes" Text="Modificar" runat="server" CssClass="btn btn-info" OnClick="btnModificarPacientes_Click" />
            </div>
        </div>
        <hr />
    </div>

    <!-- Modal HORARIOS -->
    <asp:Panel runat="server" ID="pnlModalHorarios" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Condiciones del Requerimiento</h5>
                        <hr id="hrContent">
                        <button runat="server" class="btn-secondary" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalHorarios">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">                     
                        <div class="row">
                            <%--CONDICONES PUBLICAS--%>
                            <div class="form-group col-md-6" style="margin-bottom: -1rem!important;">
                                <label class="card-header" style="font-size: 1rem;">Condiciones Públicas</label>
                                <ul style="list-style: none; padding: 0;">
                                    <li class="mt-4">
                                        <label>Moneda</label></li>
                                    <li>
                                        <label>Cond Publica</label></li>
                                    <li>
                                        <label>Minimo: 250 Maximo: 600</label></li>
                                </ul>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-md-6 mt-2">
                                <ul style="list-style: none; padding: 0;">
                                    <li>
                                        <label>Moneda</label></li>
                                    <li>
                                        <label>Cond Publica</label></li>
                                    <li>
                                        <label>Minimo: 250 Maximo: 600</label></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!--Fin Body Modal-->
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarHorarios" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                        <asp:Button ID="btnConfirmarHorarios" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-backdrop fade show"></div>

    </asp:Panel>
</asp:Content>
