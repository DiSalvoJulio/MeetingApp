<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="MeetingApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <link href="InicioSesion.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title>Inicio sesion</title>
</head>
<body class="bg-info">
    <div class="wrapper">
        <div class="formContent">
            <form id="formularioLogin" runat="server">

                <asp:ScriptManager runat="server">
                    <Scripts>
                        <asp:ScriptReference Path="~/js/jquery-3.3.1.min.js" />
                        <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
                    </Scripts>
                </asp:ScriptManager>

                <div class="form-control h-75" style="background-color: powderblue;">
                    <div class="col-md-6 text-center mb-5">
                        <asp:Label class="h1" ID="lblBienvenido" runat="server" Text="Login"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="DNI o Email"></asp:Label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Nombre de usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblContra" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" placeholder="Contraseña" type="password"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row justify-content-center">
                        <asp:Button ID="btnIngresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </div>
                    <div class="mt-3">
                        <a href="Registrar.aspx">Registrarme!</a>
                    </div>
                    <div class="mt-5">
                        <a href="RecuperarContrasenia.aspx">Olvide mi contraseña?</a>
                    </div>
                </div>
            </form>
        </div>

    </div>

</body>
</html>
