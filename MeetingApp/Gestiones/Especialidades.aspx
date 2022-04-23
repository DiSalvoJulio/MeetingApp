<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="MeetingApp.Gestiones.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Especialidades.css" rel="stylesheet" />

    <div class="container w-75">
    <%-- SECCION 1--%>
    <section class="content-header">
        <h1 style="color: red; text-align: center">Especialidades</h1>
    </section>
    <hr />
    <%-- SECCION 2--%>
    <section class="content">
        <div class="row">
            <div class="form-group col-md-6 mt-3">
                <asp:Label Text="Escribir la nueva Especialidad a agregar" runat="server" />
                <asp:TextBox ID="txtEspecialidad" runat="server" Text="" CssClass="form-control mt-2" placeholder="Nueva Especialidad..." OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);" />
            </div>
            <div class="form-group col-md-6 mt-5">
                <asp:Button ID="btnConfirmar" Text="Confirmar" runat="server" class="btn-primary" CssClass="btn btn-primary" OnClick="btnConfirmar_Click"/>
            </div>
        </div>
    </section>
    <%-- SECCION 3 GRILLA--%>
    <section>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="table col-md-auto mt-3">
                        <asp:GridView runat="server" ID="GVEspecialidades" AutoGenerateColumns="false" CssClass="table text-center table-hover" OnRowCommand="GVEspecialidades_RowCommand">
                            <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                            <Columns>
                               <%-- <asp:BoundField DataField="idEspecialidad" HeaderText="ID Espe" />--%>
                                <asp:BoundField DataField="descripcion" HeaderText="ESPECIALIDAD" />             <asp:TemplateField HeaderText="ACCIONES">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("idEspecialidad") %>' Text="Modificar" CssClass="btn btn-info" OnClientClick="mostrarModal('#modificar');" />
                                        <asp:Button runat="server" ID="btnEliminar" CommandName="DarBaja" CommandArgument='<%# Eval("idEspecialidad") %>' Text="Eliminar" CssClass="btn btn-danger" OnClientClick="mostrarModal('#eliminar');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    <%-- SECCION 4--%>

    <%-- <div class="container w-75">
        <hr class="color: red;" />
        <div class="row">
            <div class="alinear">
                <h4>Administraciones</h4>
                <h4>Acciones</h4>
            </div>
        </div>
        <hr />
         ESPECIALIDADES
        <div class="row">
            <div class="alinear">
                <h4>Profesiones</h4>
                <asp:Button ID="btnModificarProfesiones" Text="Modificar" runat="server" CssClass="btn btn-info" />
            </div>
        </div>
        <hr />--%>
    <!-- MODAL ESPECIALIDADES -->
    <asp:Panel runat="server" ID="modificar" Visible="false">
        <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
            <div class="modal-dialog modal-lg">
                <div class="modal-content w-75" style="margin-left: 12.5%">
                    <div class="modal-header">
                        <h3 class="modal-title" style="margin-left: auto">Profesiones</h3>
                        <hr id="hrContent">
                        <button runat="server" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
                        </button>
                    </div>
                    <div class="modal-body col-md-10">
                        <%--CODIGO CUERPO MODAL--%>
                        <div class="row">
                            <asp:Label CssClass="col-6" ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                            <asp:TextBox runat="server" ID="txtActualizarEspecialidad" CssClass="form-control " placeholder=""></asp:TextBox>
                            <%--<asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-6" onClientClick="verDrop()" AutoPostBack="true">
                            </asp:DropDownList>--%>
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
