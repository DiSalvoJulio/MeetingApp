<%@ Page Title="Profesional" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profesional.aspx.cs" Inherits="MeetingApp.Profesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Profesional.css" rel="stylesheet" />

     <%-- SECCION 1--%>
    <div class="container">
    <section class="content-header">
        <h1 style="text-align: center">Profesional</h1>
    </section>
        <hr />
        <div class="row">
            <div class="form-group col-md-6">
                <%--DNI--%>
                <asp:Label ID="Label4" runat="server" Text="Ingrese el D.N.I. del Profesional"></asp:Label>
                <asp:TextBox ID="txtDniBuscar" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10" required="true"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mt-4">
                <%--APELLIDO--%>
                <asp:Button ID="btnBuscarProfesional" runat="server" Text="Buscar Profesional" OnClick="btnBuscarProfesional_Click" CssClass="btn btn-primary" />
                <%--<asp:Label ID="Label5" runat="server" Text="Apellido y Nombre"></asp:Label>--%>
                <%--<asp:TextBox ID="TextBox2" name="txtApellido" runat="server" placeholder="Apellido y Nombre" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>--%>
            </div>
        </div> 
        <%--cierre row--%>
        <hr />
        <%-- SECCION 2--%>            
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
                <asp:Label ID="fechaNac" runat="server" Text="Fecha de Nacimiento"></asp:Label>
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
                <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" placeholder="Telefono o celular" CssClass="form-control" OnkeyDown="" MaxLength="15"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--DIRECCION--%>
                <asp:Label ID="direccion" runat="server" Text="Direccion - Nro"></asp:Label>
                <asp:TextBox ID="txtDireccion" name="txtDireccion" runat="server" placeholder="Direccion - Nro" CssClass="form-control" OnkeyDown="" MaxLength="50"></asp:TextBox>
            </div>
            <%--<asp:UpdatePanel runat="server">
                <ContentTemplate> --%>  
            <div class="form-group col-md-4">
                <%--ESPECIALIDAD--%>
                <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                <br />
                <asp:DropDownList ID="cmbEspecialidad" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-12" onClientClick="verDrop()" AutoPostBack="true">  
                    <%--<asp:ListItem Selected="True" Value="" disabled="disabled">Seleccione Especialidad...</asp:ListItem>--%>
                </asp:DropDownList>
                <%--<asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                <asp:TextBox ID="txtEspecialidad" name="txtEspecialidad" runat="server" placeholder="Especialidad" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>--%>
            </div>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            <div class="form-group col-md-4">
                <%--MATRICULA--%>
                <asp:Label ID="Label2" runat="server" Text="Matricula"></asp:Label>
                <asp:TextBox ID="txtMatricula" name="txtMatricula" runat="server" placeholder="Matricula" CssClass="form-control" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
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
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <%--SECCION 3 GRILLA--%>
</asp:Content>
