<%@ Page Title="DatosPaciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosPaciente.aspx.cs" Inherits="MeetingApp.DatosPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
 
    <div class="container">
    <%-- SECCION 1--%>
    <section class="content-header">
        <h1 style="color: red; text-align: center">Mis Datos</h1>
    </section>
    <%-- SECCION 2--%>
        <hr class="color: red;" />
        <div class="form-row">
            <div class="form-group col-md-6">
                <%--APELLIDO--%>
                <asp:Label ID="lblApellido" runat="server" Text="Apellido/s"></asp:Label>
                <asp:TextBox ID="txtApellido" name="txtApellido" runat="server" placeholder="Apellido/s" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--NOMBRE--%>
                <asp:Label ID="Nombre" runat="server" Text="Nombre/s"></asp:Label>
                <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" placeholder="Nombre/s" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--DNI--%>
                <asp:Label ID="dni" runat="server" Text="D.N.I."></asp:Label>
                <asp:TextBox ID="txtDni" name="txtDni" runat="server" placeholder="D.N.I." CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--FECHA NACIMIENTO--%>
                <asp:Label ID="fechaNac" runat="server" Text="Fecha de nacimiento"></asp:Label>
                <asp:TextBox ID="txtFecNac" name="txtFecNac" runat="server" placeholder="Fecha de nacimiento" Type="date" CssClass="form-control" OnkeyDown="Letras()" MaxLength="10"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--EMAIL--%>
                <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" OnkeyDown="" MaxLength="50"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--EDAD--%>
                <asp:Label ID="Label1" runat="server" Text="Edad"></asp:Label>
                <asp:TextBox ID="txtEdad" name="txtEdad" runat="server" placeholder="Edad" CssClass="form-control" OnkeyDown="" MaxLength="40"></asp:TextBox>
            </div>            
            <div class="form-group col-md-6">
                <%--TELEFONO O CELULAR--%>
                <asp:Label ID="telefono" runat="server" Text="Telefono o Celular"></asp:Label>
                <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" placeholder="Telefono o celular" CssClass="form-control" OnkeyDown="Numeros()" MaxLength="15"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--DIRECCION--%>
                <asp:Label ID="direccion" runat="server" Text="Direccion - Nro"></asp:Label>
                <asp:TextBox ID="txtDireccion" name="txtDireccion" runat="server" placeholder="Direccion - Nro" CssClass="form-control" OnkeyDown="" MaxLength="50"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--OBRA SOCIAL--%>
                <asp:Label ID="Label4" runat="server" Text="Obra Social"></asp:Label>
                <br />
                <asp:DropDownList ID="cmbObraSocial" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-12" onClientClick="verDrop()" AutoPostBack="false">               
                </asp:DropDownList>        
            </div>
            <div class="form-group col-md-6">
                <%--OCUPACION--%>
                <asp:Label ID="Label3" runat="server" Text="Ocupacion"></asp:Label>
                <asp:TextBox ID="txtOcupacion" name="txtOcupacion" runat="server" placeholder="Ocupacion" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--REFERENCIAS--%>
                <asp:Label ID="lblReferencias" runat="server" Text="Referencia de como llego al profesional"></asp:Label>
                <br />
                <asp:DropDownList ID="cmbReferencias" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-12" onClientClick="verDrop()" AutoPostBack="false">               
                </asp:DropDownList>        
            </div>
            <div class="form-group col-md-6">
                <%--FECHA INGRESO--%>
                <asp:Label ID="Ingreso" runat="server" Text="Fecha de Ingreso"></asp:Label>
                <asp:TextBox ID="txtIngreso" name="txtIngreso" runat="server" placeholder="Fecha de Ingreso" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
            </div>
        </div>
        <%--cierre del row--%>
        
        <div class="form-row" style="justify-content: flex-end;">
            <div class="form-group mt-2">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-success" />
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" OnClientClick="test()" />
            </div>
        </div>
    </div>
    <%--SECCION 3 GRILLA--%>   

    
</asp:Content>
