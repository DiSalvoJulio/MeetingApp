<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarPassword.aspx.cs" Inherits="MeetingApp.ActualizarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <%--   css link a referencia bootstrap local--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <link href="ActualizarPassword.css" rel="stylesheet" />
    <title>Actualizar Password</title>
</head>
<body class="content">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/js/jquery-3.3.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
            <section class="content-header mt-2">
                <h1 style="color: red; text-align: center">Ingresar contraseñas nuevas</h1>
            </section>
            <hr />

            <div>
                <div class="row">
                    <%--<div class="form-group col-md-5">
                        EMAIL
                        <asp:Label ID="email" runat="server" Text="Completar email de su cuenta"></asp:Label>
                        <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>--%>
                    <div class="mr-5">
                        <%--CONTRASENIA--%>
                        <asp:Label ID="lblContra" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" placeholder="Contraseña" type="password" MinLength="7" MaxLength="20" required="true"></asp:TextBox>
                    </div>
                    <div class="mr-5">
                        <%--CONTRASENIA--%>
                        <asp:Label ID="lblContra2" runat="server" Text="Repetir Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass2" CssClass="form-control" runat="server" placeholder="Repetir Contraseña" type="password" MinLength="7" MaxLength="20" required="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-5 mt-4">
                        <%--ENVIAR--%>
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click"/>
                    </div>
                </div>
                <%--<h5 class="mt-1">Se enviara un email para recuperar su cuenta, revise su casilla de correo.</h5>--%>
            </div>

            <div class="volver mt-5">
                <a href="InicioSesion.aspx" class="btn btn-info">Volver a Inicio sesión</a>
            </div>
        </div>
    </form>
</body>
</html>
