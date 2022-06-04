<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasenia.aspx.cs" Inherits="MeetingApp.RecuperarContrasenia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <%--   css link a referencia bootstrap local--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <link href="RecuperarContrasenia.css" rel="stylesheet" />
    <title>Recuperar Contrasenia</title>
</head>
<body class="content">
    <form id="recuperar" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/js/jquery-3.3.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
            <section class="content-header mt-2">
                <h1 style="color: red; text-align: center">Recuperar Contraseña</h1>
            </section>
            <hr />

            <div class="datos">
                <div class="row">
                    <div class="form-group col-md-5">
                        <%--EMAIL--%>
                        <asp:Label ID="email" runat="server" Text="Completar email de su cuenta"></asp:Label>
                        <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-5 mt-4">
                        <%--ENVIAR--%>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" />
                    </div>
                </div>
                <h5 class="mt-1">Se enviara un email para recuperar su cuenta, revise su casilla de correo.</h5>
            </div>

            <div class="volver mt-5">
                <a href="InicioSesion.aspx" class="btn btn-info">Volver a Inicio sesión</a>
            </div>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
