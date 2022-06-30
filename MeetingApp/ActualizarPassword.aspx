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
    <%--<link href="ActualizarPassword.css" rel="stylesheet" />--%>
    <title>Actualizar Password</title>
     <link href="Login/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="Login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/bootstrap/css/bootstrap.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/animate/animate.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/css-hamburgers/hamburgers.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/animsition/css/animsition.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/select2/select2.min.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/vendor/daterangepicker/daterangepicker.css"/>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="Login/css/util.css"/>
    <link rel="stylesheet" type="text/css" href="Login/css/main.css"/>
    
    <!--===============================================================================================-->
</head>
<body style="background-color: #666666;">
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-43">Ingresar contraseñas nuevas
                    </span>                     
                    <%--CONTRASENIA--%>
                     <div class="wrap-input100 validate-input" data-validate="Contraseña requerida">
                       <%-- <input class="input100" type="password" id="txtPass" name="pass" runat="server"/>--%>
                        <asp:TextBox ID="txtPass" runat="server" placeholder="Contraseña" CssClass="input100" Type="password" required="True" MinLength="7" MaxLength="20"/>
                        <span class="focus-input100"></span>
                        <%--<span class="label-input100">Contraseña</span>--%>
                    </div>
                    <%--CONTRASENIA 2--%>
                    <div class="wrap-input100 validate-input" data-validate="Contraseña requerida">
                       <%-- <input class="input100" type="password" id="txtPass" name="pass" runat="server"/>--%>
                        <asp:TextBox ID="txtPass2" runat="server" placeholder="Repetir contraseña" CssClass="input100" Type="password" required="True" MinLength="7" MaxLength="20"/>
                        <span class="focus-input100"></span>
                        <%--<span class="label-input100">Contraseña</span>--%>
                    </div>            
                    <%--CONFIRMAR--%>
                    <div class="container-login100-form-btn mt-4">     
                        <asp:Button ID="btnConfirmar" runat="server" Text="Enviar" CssClass="login100-form-btn" onclick="btnConfirmar_Click"/>
                    </div>
                    <%--VOLVER A INICIO--%>
                    <div class="text-center p-t-46 p-b-20">
                        <a href="InicioSesion.aspx" class="login100-form-btn" style="background-color:lightseagreen;">Volver a Inicio sesión</a>
                    </div>                
                </form>
                <div class="login100-more" style="background-image: url('Login/images/bg-01.jpg');">
                </div>
            </div>
        </div>
    </div>


    <%--<form id="form1" runat="server">
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
                    <div class="form-group col-md-5">
                        EMAIL
                        <asp:Label ID="email" runat="server" Text="Completar email de su cuenta"></asp:Label>
                        <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="mr-5">
                        CONTRASENIA
                        <asp:Label ID="lblContra" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" placeholder="Contraseña" type="password" MinLength="7" MaxLength="20" required="true"></asp:TextBox>
                    </div>
                    <div class="mr-5">
                        CONTRASENIA
                        <asp:Label ID="lblContra2" runat="server" Text="Repetir Contraseña:"></asp:Label>
                        <asp:TextBox ID="txtPass2" CssClass="form-control" runat="server" placeholder="Repetir Contraseña" type="password" MinLength="7" MaxLength="20" required="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-5 mt-4">
                        ENVIAR
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-primary" OnClick="btnConfirmar_Click"/>
                    </div>
                </div>
                <h5 class="mt-1">Se enviara un email para recuperar su cuenta, revise su casilla de correo.</h5>
            </div>

            <div class="volver mt-5">
                <a href="InicioSesion.aspx" class="btn btn-info">Volver a Inicio sesión</a>
            </div>
        </div>
    </form>--%>

    <!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
</body>
</html>
