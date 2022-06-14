<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnosPaciente.aspx.cs" Inherits="MeetingApp.MisTurnosPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .scrolling-table-container {
            height: 378px;
            overflow-y: auto;
            overflow-x: hidden;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Mis Turnos</h1>
        <hr />

        <div class="row" style="justify-content: center;">
            <div class="form-group col-md-4 mt-4">
                <%--BUSCAR PROXIMOS--%>
                <asp:Button ID="btnProximos" runat="server" Text="Ver turnos proximos" OnClick="btnProximos_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--BUSCAR HISTORICOS--%>
                <asp:Button ID="btnHistoricos" runat="server" Text="ver turnos historicos" onclick="btnHistoricos_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--VOLVER--%>
                <asp:Button ID="btnVolver" runat="server" Text="Volver a Busqueda" onclick="btnVolver_Click" CssClass="btn btn-outline-success" />
            </div>
        </div>
        
        <!--Tabla turnos PROXIMOS-->
        <div id="divProximos" runat="server" visible="false">
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
        <div class="scrolling-table-container mt-4">            
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
        </div>
            <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>

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
                               <%-- DIA--%>
                                <h4 class="col-sm-1 mr-2">Dia:</h4>
                                <asp:Label ID="lblDia" Text="" CssClass="h5 col-sm-2 mt-1 ml-2" runat="server"></asp:Label>
                            </div>
                           <%--FECHA--%>                            
                                <div class="mb-3 row">
                                    <h4 class="col-sm-1 mr-5">Fecha:</h4>
                                    <asp:Label runat="server" ID="lblFecha" Text="" CssClass="h5 col-sm-2 mt-1 ml-2"></asp:Label>
                                </div>
                            <%--HORA--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-1 mr-4">Hora:</h4>
                                    <asp:Label ID="lblHora" Text="" CssClass="h5 col-sm-2 mt-1 ml-4" runat="server"></asp:Label>
                                </div>
                            <%--DESCRIPCION--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-3 mr-5">Descripcion:</h4>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="" CssClass="h5 col-sm-2 mt-1 ml-4"></asp:Label>
                                </div>
                            <%--ESPECIALIDAD--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-3 mr-5">Especialidad:</h4>
                                    <asp:Label ID="lblEspecialidad" Text="" CssClass="h5 col-sm-2 mt-1 ml-4" runat="server"></asp:Label>
                                </div>
                            <%--PROFESIONAL--%>
                            <div class="row mb-3">
                                <h4 class="col-sm-3 mr-5">Profesional:</h4>
                                    <asp:Label ID="lblProfesional" Text="" CssClass="h5 col-auto mt-1 ml-4" runat="server"></asp:Label>
                                </div>   
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelar" Text="Volver" runat="server" type="button" class="btn btn-info" onclick="btnCancelar_Click"/>
                            <asp:Button ID="btnConfirmarCancelado" Text="Confirmar" runat="server" type="button" class="btn btn-primary" onclick="btnConfirmarCancelado_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>

            </div>
        <%--CIERRE PROXIMOS--%>






        <!--Tabla turnos HISTORICOS-->
        <div id="divHistoricos" runat="server" visible="false">
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
        <div class="scrolling-table-container mt-4">            
            <asp:GridView ID="gvTurnosHistoricos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover"  >
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
                    <%--<asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
  
            </asp:GridView>           
        </div>
            <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>

        </div>
        <%--CIERRE DIV HISTORICOS--%>



        <%--fin container--%>
    </div>
</asp:Content>
