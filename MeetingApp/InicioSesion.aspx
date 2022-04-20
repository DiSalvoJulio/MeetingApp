<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="MeetingApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="InicioSesion.css" rel="stylesheet" />
    <title>Inicio sesion</title>
</head>
<body class="bg-info">
    <div class="wrapper">
        <div class="formContent">
            <form id="formularioLogin" runat="server">
                <div class="form-control">
                    <div class="col-md-6 text-center mb-5">
                        <asp:Label class="h1" ID="lblBienvenido" runat="server" Text="Login"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsuario" runat="server" Text="DNI o Email"></asp:Label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" placeholder="Nombre de usuario"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblContra" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Button ID="btnIngresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </div>
                    <div class="mt-3">
                        <a href="Registrar.aspx">Registrarme!</a>
                    </div>
                </div>
            </form>
        </div>
    </div>

</body>
</html>
