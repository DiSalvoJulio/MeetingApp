<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnoProfesional.aspx.cs" Inherits="MeetingApp.TurnoProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Nuevo Turno</h1>
        <hr />
        <div class="row">
            <div class="form-group col-md-4">
                <%--DNI--%>
                <asp:Label ID="Label4" runat="server" Text="Ingrese el D.N.I. del paciente"></asp:Label>
                <asp:TextBox ID="txtDniBuscar" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10" required="true"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mt-4">
                <%--BUSCAR--%>
                <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar paciente" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
            </div>
            <hr />
        </div>
        <div class="row">
            <div class="form-group col-md-4">
                <%--DATOS--%>
                <asp:Label ID="Label1" runat="server" Text="Apellido y Nombre"></asp:Label>
                <asp:TextBox ID="txtDatos" name="txtDatos" runat="server" placeholder="Datos" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <%--OBRA SOCIAL--%>
                <asp:Label ID="Label2" runat="server" Text="Obra social"></asp:Label>
                <asp:TextBox ID="txtObraSocial" name="txtObraSocial" runat="server" placeholder="Obra Social" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--LIMPIAR DATOS--%>
                <asp:Button ID="btnLimpiarDatos" runat="server" Text="Limpiar datos" OnClick="btnLimpiarDatos_Click" CssClass="btn btn-success" />
            </div>
        </div>
        <hr />
        <%--------********************************************------%>
        <div class="row mt-2">
            <div class="form-group col-md-4">
                <%--ESPECIALIDAD--%>
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                <asp:TextBox ID="txtEspecialidad" name="txtEspecialidad" runat="server" placeholder="Especialidad" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <%--NOMBRE PROFESIONAL--%>
                <asp:Label ID="Nombre" runat="server" Text="Profesional"></asp:Label>
                <asp:TextBox ID="txtProfesional" name="txtProfesional" runat="server" placeholder="Profesional" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="row mt-2">
            <div class="form-group col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Calendario"></asp:Label>
            <input runat="server" type="date" class="form-control" id="txtCalendario">
                </div>
            <div class="form-group col-md-2">
                <asp:Label ID="Label5" runat="server" Text="Mostrar"></asp:Label>
            <asp:Button Text="Mostrar horarios" ID="btnMostrarHorarios" class="btn btn-info" runat="server" />
                </div>

            <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <div class="form-group col-md-5">
                <asp:Label ID="Label6" runat="server" Text="Horario"></asp:Label>
            <asp:DropDownList ID="cmbHorarioDisponible" runat="server" CssClass="btn btn-primary" AutoPostBack="false">
                <asp:ListItem Text="Seleccione horario..."></asp:ListItem>
            </asp:DropDownList>  
                </div>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMostrarHorarios" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>

        <div class="row mt-2">
            <div class="form-group col-md-3">
                <asp:Label ID="Label7" runat="server" Text="Forma de pago"></asp:Label>
            <asp:DropDownList ID="cmbFormaPago" runat="server" CssClass="btn btn-primary" AutoPostBack="false">  
                <asp:ListItem Text="Forma de pago..."></asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="form-group">
            <%--<h5 class="mt-1 col-sm-3">Motivo del turno</h5>--%>
                <asp:Label ID="Label8" runat="server" Text="Motivo del turno"></asp:Label>
            <asp:TextBox runat="server" TextMode="MultiLine" Width="180%" ID="txtMotivo"></asp:TextBox>
                </div>
        </div>

        <div class="form-row" style="justify-content: end;">
        <asp:Button Text="Reservar turno" ID="btnReservarTurno" class="btn btn-danger mt-5" runat="server" />
        </div>




        <%--fin container--%>
    </div>
</asp:Content>
