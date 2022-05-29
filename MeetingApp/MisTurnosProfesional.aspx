<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnosProfesional.aspx.cs" Inherits="MeetingApp.MisTurnosProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Mis Turnos</h1>
        <hr />
        <div class="row">
            <div class="form-group col-md-4">
                <%--DNI--%>
                <asp:Label ID="Label4" runat="server" Text="Ingrese el D.N.I. del paciente"></asp:Label>
                <asp:TextBox ID="txtDniBuscar" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10" required="true"></asp:TextBox>
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--BUSCAR--%>
                <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar paciente" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--LIMPIAR DATOS--%>
                <asp:Button ID="btnLimpiarDatos" runat="server" Text="Limpiar datos" CssClass="btn btn-success" OnClick="btnLimpiarDatos_Click" />
            </div>
        </div>
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
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />                    
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

        <%--fin container--%>
    </div>
</asp:Content>
