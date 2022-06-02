<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte1.aspx.cs" Inherits="MeetingApp.Reportes.Reporte1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Reporte 1</h1>
        <hr />
        <h5>Seleccionar Fechas</h5>
        <div class="form-row">
            <%--  FECHA--%>
            <div class="form-group col-md-3">
                <input type="date" runat="server" class="form-control" name="dtpFecha1" id="dtpFecha1" required>
                Desde
            </div>
            <div class="form-group col-md-3">
                <input type="date" runat="server" class="form-control" name="dtpFecha2" id="dtpFecha2" required>Hasta
            </div>
            <%--  BOTON CONSULTAR --%>
            <div class="form-group col-md-3">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" onclick="btnConsultar_Click"/>
            </div>
          <%--  BOTON LIMPIAR GRILLA --%>
            <div class="form-group col-md-3">
                <asp:Button ID="btnLimpiarGrilla" runat="server" Text="Limpiar" CssClass="btn btn-outline-success" onclick="btnLimpiarGrilla_Click"/>
            </div>
        </div>

        <!--Tabla turnos-->
        <div id="IdTurnosActivos" class="table mt-4">            
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <asp:GridView ID="gvTurnosActivos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover"  >
                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                <Columns>                   
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                    <%--<asp:BoundField DataField="descripcion" HeaderText="Descripcion" />--%>
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <%--<asp:BoundField DataField="especialidad" HeaderText="Especialidad" />--%>
                    <%--<asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>  
            </asp:GridView>           
            <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>


        <%--fin container--%>
    </div>
</asp:Content>
