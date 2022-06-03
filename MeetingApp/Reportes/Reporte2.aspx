<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte2.aspx.cs" Inherits="MeetingApp.Reportes.Reporte2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Reporte 2</h1>
        <hr />
        <h3 class="mb-5">Listado de formas de pago mas utilizadas por mes</h3>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Seleccionar mes" CssClass="mr-3"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cmbMes" runat="server" CssClass="btn btn-info dropdown-toggle col-auto mt-1 mr-5" AutoPostBack="false">
                <asp:ListItem Text="Meses..." Value="0"></asp:ListItem>
                <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary col-auto mt-1 ml-5 mr-5" onclick="btnConsultar_Click"/>
        </td>
        <td>
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-success col-auto mt-1 ml-5" onclick="btnLimpiar_Click"/>
        </td>


        <%--fin container--%>
    </div>
</asp:Content>
