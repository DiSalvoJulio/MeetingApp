﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="MeetingApp.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <link href="Registrar.css" rel="stylesheet" />
    <title>Registrar</title>
</head>
<body class="content">
    <form id="form1" runat="server">
        <%-- SECCION 1--%>
        <section class="content-header mt-5">
            <h1 style="color: red; text-align: center">Registrarme!</h1>
        </section>
        <%-- SECCION 2--%>
        <div class="container">
            <hr class="color: red;" />
            <div class="row">
                <div class="form-group col-md-6 mt-3">
                    <%--APELLIDO--%>
                    <asp:Label ID="Apellido" runat="server" Text="Apellido/s"></asp:Label>
                    <asp:TextBox ID="txtApellido" name="txtApellido" runat="server" placeholder="Apellido/s" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--NOMBRE--%>
                    <asp:Label ID="Nombre" runat="server" Text="Nombre/s"></asp:Label>
                    <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" placeholder="Nombre/s" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--DNI--%>
                    <asp:Label ID="dni" runat="server" Text="D.N.I."></asp:Label>
                    <asp:TextBox ID="txtDni" name="txtDni" runat="server" placeholder="D.N.I." CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--FECHA NACIMIENTO--%>
                    <asp:Label ID="fechaNac" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    <asp:TextBox ID="txtFecNac" name="txtFecNac" runat="server" placeholder="Fecha de nacimiento" Type="date" CssClass="form-control" OnkeyDown="Letras()" MaxLength="10"></asp:TextBox>
                </div>
                <%--   <div class="form-group col-md-6">
                TELEFONO O CELULAR
                <asp:Label ID="telefono" runat="server" Text="Telefono o Celular"></asp:Label>
                <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" placeholder="Telefono o celular" CssClass="form-control" OnkeyDown="Letras()" MaxLength="10"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                DIRECCION
                <asp:Label ID="direccion" runat="server" Text="Direccion - Nro"></asp:Label>
                <asp:TextBox ID="txtDireccion" name="txtDireccion" runat="server" placeholder="Direccion - Nro" CssClass="form-control" OnkeyDown="Letras()" MaxLength="10"></asp:TextBox>
            </div>--%>
                <div class="form-group col-md-4 mt-3">
                    <%--EMAIL--%>
                    <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" MaxLength="50"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 mt-3">
                    <%--CONTRASEñA--%>
                    <asp:Label ID="Pass" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass" name="txtPass" runat="server" placeholder="Contraseña" type="password" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 mt-3">
                    <%--REPERTIR CONTRASEñA--%>
                    <asp:Label ID="pass2" runat="server" Text="Repetir Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass2" name="txtPass2" runat="server" placeholder="Repetir Contraseña" type="password" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
                </div>
            </div>
            <%--cierre del row--%>

            <div class="row">
                <%--<asp:UpdatePanel runat="server"> </asp:UpdatePanel>--%>

                <div class="form-group col-md-12 mt-5">
                    <div class="custom-control custom-switch">
                        <%--<input type="checkbox" class="custom-control-input" id="customSwitch1">--%>
                        <asp:CheckBox ID="chkProfesional" runat="server" OnCheckedChanged="chkProfesional_CheckedChanged" AutoPostBack="true" />
                        <label class="custom-control-label" for="customSwitch1">Soy Profesional.</label>
                    </div>
                    <%--<asp:RadioButton ID="Profesional" runat="server" Checked="false" Text="Si" GroupName="rol" />--%>
                    <%--<asp:Label ID="Label2" runat="server" Text="Soy Profesional."></asp:Label>--%>
                    <%-- <asp:RadioButton ID="Mozo" runat="server" Text="No" GroupName="rol" />--%>
                </div>
                <%--<div id="divEsProfesional" runat="server" visible="true">--%>
                <div class="form-group col-6 mt-3">
                    <%--PROFESION--%>
                    <asp:Label ID="Label1" runat="server" Text="Profesion"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-12" onClientClick="verDrop()">
                        <%--<asp:ListItem Selected="True"> </asp:ListItem>   --%>                
                    </asp:DropDownList>              
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--MATRICULA--%>
                    <asp:Label ID="Label3" runat="server" Text="Matricula"></asp:Label>
                    <asp:TextBox ID="txtMatricula" name="txtMatricula" runat="server" placeholder="Matricula" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
                </div>
                <%--</div>--%>
            </div>
            <div class="modal-header mt-5" style="padding: 1rem 0rem !important; border: none;">
                <a href="InicioSesion.aspx" class="btn btn-dark">Atras</a>
                <div>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <%--<div class="row">
                <div class="form-group col-md-1 mt-5">
                    <a href="InicioSesion.aspx" class="btn btn-dark">Atras</a>
                </div>
                <div class="col-md-8">
                </div>
                <div class="form-group col-md-3 mt-5">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
                </div>
            </div>--%>
        </div>
        <%--SECCION 3 GRILLA--%>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
