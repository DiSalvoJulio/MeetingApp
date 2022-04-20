<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MeetingApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- SECCION 1--%>
    <section class="content-header">
        <h1 style="color: red; text-align: center">Nuevo Registro</h1>
    </section>
    <%-- SECCION 2--%>
    <div class="container">
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
                <asp:TextBox ID="txtDni" name="txtDni" runat="server" placeholder="D.N.I." CssClass="form-control" OnkeyDown="" MaxLength="40"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <%--FECHA NACIMIENTO--%>
                <asp:Label ID="fechaNac" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFecNac" name="txtFecNac" runat="server" placeholder="Fecha de nacimiento" Type="date" CssClass="form-control" OnkeyDown="Letras()" MaxLength="10"></asp:TextBox>
            </div>
          <%--  <div class="form-group col-md-6">
                TELEFONO O CELULAR
                <asp:Label ID="telefono" runat="server" Text="Telefono o Celular"></asp:Label>
                <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" placeholder="Telefono o celular" CssClass="form-control" OnkeyDown="Numeros()" MaxLength="15"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                DIRECCION
                <asp:Label ID="direccion" runat="server" Text="Direccion - Nro"></asp:Label>
                <asp:TextBox ID="txtDireccion" name="txtDireccion" runat="server" placeholder="Direccion - Nro" CssClass="form-control" OnkeyDown="" MaxLength="50"></asp:TextBox>
            </div>--%>
            <div class="form-group col-md-4">
                <%--EMAIL--%>
                <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" OnkeyDown="" MaxLength="50"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <%--CONTRASEñA--%>
                <asp:Label ID="Pass" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtPass" name="txtPass" runat="server" placeholder="Contraseña" type="password" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <%--REPERTIR CONTRASEñA--%>
                <asp:Label ID="pass2" runat="server" Text="Repetir Contraseña"></asp:Label>
                <asp:TextBox ID="txtPass2" name="txtPass2" runat="server" placeholder="Repetir Contraseña" type="password" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
            </div>
        </div>
        <%--cierre del row--%>

        <div class="form-row">
            <div class="form-group col-md-12 mt-3">
                <div class="custom-control custom-switch">
                    <input type="checkbox" class="custom-control-input" id="chk" runat="server">
                   <%-- <asp:CheckBox id="check1" runat="server" class="custom-control-input" Checked="TRUE" />--%>
                    <label class="custom-control-label" for="chk">Soy Profesional.</label>
                </div>
                <%--<asp:RadioButton ID="Profesional" runat="server" Checked="false" Text="Si" GroupName="rol" />--%>
                <%--<asp:Label ID="Label2" runat="server" Text="Soy Profesional."></asp:Label>--%>
                <%-- <asp:RadioButton ID="Mozo" runat="server" Text="No" GroupName="rol" />--%>
            </div>
            <%--<div class="form-group col-6">--%>
                <%--PROFESION--%>
                <%--<asp:Label ID="Label1" runat="server" Text="Profesion"></asp:Label>
                <br />
                <asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-12" onClientClick="verDrop()">
                    <asp:ListItem Value="">Seleccionar...</asp:ListItem>
                </asp:DropDownList>--%>
                <%--<asp:TextBox ID="txtProfesion" name="txtProfesion" runat="server" placeholder="Profesion" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>--%>
          <%--  </div>--%>
            <%--<div class="form-group col-md-6">--%>
                <%--MATRICULA--%>
                <%--<asp:Label ID="Label3" runat="server" Text="Matricula"></asp:Label>
                <asp:TextBox ID="txtMatricula" name="txtMatricula" runat="server" placeholder="Matricula" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
            </div>--%>
        <%--</div>--%>
            </div>
       <%-- <div class="form-row" style="justify-content: flex-end;">
            <div class="form-group mt-2">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                <asp:Button ID="btnRegistrarUsuario" runat="server" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnRegistrarUsuario_Click"/>
            </div>
        </div>--%>
    </div>
    <%--SECCION 3 GRILLA--%>
</asp:Content>
