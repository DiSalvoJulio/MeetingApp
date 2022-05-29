<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnosPaciente.aspx.cs" Inherits="MeetingApp.MisTurnosPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Mis Turnos</h1>
        <hr />
        
        <!--Tabla turnos-->
        <div id="IdTurnos" class="table mt-4">            
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover" OnRowCommand="gvTurnos_RowCommand" >
                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                <Columns>                   
                    <asp:BoundField DataField="fechaTurno" HeaderText="Fecha" />
                    <asp:BoundField DataField="horaTurno" HeaderText="Hora" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="profesional" HeaderText="Profesional" />
                    <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
  
            </asp:GridView>           
            <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

        <!-- MODAL CANCELAR TURNO-->
        <asp:Panel runat="server" ID="panelCancelarTurno" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de dar de Baja el Turno?</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalCancelar">
                                x</button>
                        </div>
                        <div class="modal-body col-md-8">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="mb-3 row">
                                <h4 class="col-sm-1 mr-2">Dia:</h4>
                                <asp:Label ID="lblDiaEliminar" Text="" CssClass="h5 col-sm-2 mt-1 ml-2" runat="server"></asp:Label>
                            </div>
                            <%--MAÑANA--%>
                            <div class="text-center row" id="divHorarioEliminarMañana" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblMañanaDesdeEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblMañanaHastaEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                            </div>
                            <%--FIN MAÑANA--%>

                            <%--TARDE--%>
                            <div class="text-center row" id="divHorarioEliminarTarde" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblTardeDesdeEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblTardeHastaEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                            </div>
                            <%--FIN TARDE--%>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                            <asp:Button ID="btnConfirmar" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>


        <%--fin container--%>
    </div>
</asp:Content>
