<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="MeetingApp.Gestiones.ObrasSociales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="ObrasSociales.css" rel="stylesheet" />

    <div class="container w-75">
        <%-- SECCION 1--%>
        <section class="content-header">
            <h1 style="color: red; text-align: center">Obras Sociales</h1>
        </section>
        <hr />

        <div class="form-group col-md-6 mt-5">
            <asp:Button ID="btnAgregar" Text="Agregar nueva obra social" runat="server" class="btn-primary" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
        </div>
        <%-- SECCION 2--%>
        <section class="content">
            <div class="row" runat="server" visible="false" id="divAgregarObraSocial">
                <div class="form-group col-md-6 mt-3">
                    <asp:Label Text="Escribir la nueva obra social a agregar" runat="server" />
                    <asp:TextBox ID="txtObraSocial" runat="server" Text="" CssClass="form-control mt-2" placeholder="Nueva obra social..." OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);" />
                </div>
                <div class="form-group col-md-6 mt-5">
                    <asp:Button ID="btnConfirmar" Text="Confirmar" runat="server" CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
                </div>
                <div class="form-group col-md-6 mt-5">
                    <asp:Button ID="btnFinalizar" Text="Finalizar" runat="server" CssClass="btn btn-info" OnClick="btnFinalizar_Click" />
                </div>
            </div>
        </section>
        <%-- SECCION 3 GRILLA--%>
        <div class="row">
            <div class="table col-md-auto mt-3">
                <asp:GridView runat="server" ID="GVObrasSociales" AutoGenerateColumns="false" CssClass="table text-center table-hover" OnRowCommand="GVObrasSociales_RowCommand">
                    <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                    <Columns>
                        <%-- <asp:BoundField DataField="idEspecialidad" HeaderText="ID Espe" />--%>
                        <asp:BoundField DataField="descripcion" HeaderText="OBRA SOCIAL" />
                        <asp:TemplateField HeaderText="ACCIONES">
                            <ItemTemplate>

                                <asp:Button runat="server" ID="btnModificar" CommandName="Modificar" CommandArgument='<%#Eval("idObraSocial")%>' Text="Modificar" CssClass="btn btn-info" />

                                <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%#Eval("idObraSocial")%>' Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <%-- SECCION 4--%>

        <!-- MODAL OBRA SOCIAL -->
        <asp:Panel runat="server" ID="panelModificar" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">Obras Sociales</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalObraSocial">
                                x</button>
                        </div>
                        <div class="modal-body col-md-10">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="row">
                                <asp:Label CssClass="col-6" ID="Label3" runat="server" Text="Obra Social"></asp:Label>
                                <asp:TextBox runat="server" ID="txtActualizarObraSocial" CssClass="form-control col-6" placeholder=""></asp:TextBox>
                                <%--<asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-6" onClientClick="verDrop()" AutoPostBack="true">
                            </asp:DropDownList>--%>
                            </div>

                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarObraSocial" Text="Cancelar" runat="server" type="button" class="btn btn-danger" OnClick="btnCancelarObraSocial_Click" />
                            <asp:Button ID="btnConfirmarObraSocial" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnConfirmarObraSocial_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>

        <!-- MODAL OBRAS SOCIALES ELIMINAR-->
        <asp:Panel runat="server" ID="panelEliminar" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de eliminar la obra social?</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalEliminar">
                                x</button>
                        </div>
                        <div class="modal-body col-md-8">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="row">
                                <asp:Label CssClass="col-6" ID="Label1" runat="server" Text="Obra Social"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEliminar" CssClass="form-control col-6" placeholder=""></asp:TextBox>
                            </div>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarEliminar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" OnClick="btnCancelarEliminar_Click" />
                            <asp:Button ID="btnConfirmarEliminar" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnConfirmarEliminar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>
    </div>

    <%--FIN MODAL OBRAS SOCIALES---------------------------------------------------%>
</asp:Content>
