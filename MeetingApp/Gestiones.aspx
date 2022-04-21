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
    <asp:Panel runat="server" ID="panelHorarios" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Horarios</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalHorarios">                       
                        </button>                                          
                    </div>
                    <div class="modal-body">
                        
                    <%--CODIGO CUERPO MODAL--%>  
                        
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
    <%--FIN MODAL HORARIOS-----------------------------------------------------------------------%>


    <!-- MODAL PROFESIONES -->
    <asp:Panel runat="server" ID="panelProfesiones" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Profesiones</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalProfesiones">                       
                        </button>                                          
                    </div>
                    <div class="modal-body">
                        
                    <%--CODIGO CUERPO MODAL--%>  
                        
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
    <%--FIN MODAL PROFESIONES--------------------------------------------------------------------%>


    <!-- MODAL OBRAS SOCIALES -->
     <asp:Panel runat="server" ID="panelObrasSociales" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Obras Sociales</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalObrasSociales">                       
                        </button>                                          
                    </div>
                    <div class="modal-body">
                        
                    <%--CODIGO CUERPO MODAL--%>  
                        
                    </div>
                    <!--Fin Body Modal-->
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarObrasSociales" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                        <asp:Button ID="btnConfirmarObrasSociales" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-backdrop fade show"></div>
    </asp:Panel>
    <%--FIN MODAL OBRAS SOCIALES-----------------------------------------------------------------%>


    <!-- MODAL PACIENTES -->
     <asp:Panel runat="server" ID="panelPacientes" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Pacientes</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onserverclick="CerrarModalPacientes">                       
                        </button>                                          
                    </div>
                    <div class="modal-body">
                        
                    <%--CODIGO CUERPO MODAL--%>  
                        
                    </div>
                    <!--Fin Body Modal-->
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarPacientes" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                        <asp:Button ID="btnConfirmarPacientes" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-backdrop fade show"></div>
    </asp:Panel>
    <%--FIN MODAL PACIENTES----------------------------------------------------------------------%>
    
</asp:Content>
