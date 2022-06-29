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
        <%--<link href="InicioSesion.css" rel="stylesheet" />--%>
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
<body style="background-color: #666666;>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-43">Recuperar Contraseña
                    </span>


                    <div class="wrap-input100 validate-input" data-validate="Email requerido: ejemplo@abc.com">
                        <%--<input class="input100" type="text" ID="txtUsuario" name="email" runat="server"/>--%>
                       <%-- <asp:TextBox ID="txtUsuario" runat="server" placeholder="Email o D.N.I." CssClass="input100" pattern="[A-Za-z0-9]{4,20}" title="El Nombre de Usuario solo puede contener numeros y letras. Un minimo de 8 caracteres y un maximo de 20"/>--%>
                        <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="input100" MaxLength="50" required="true"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <%--<span class="label-input100">Email o D.N.I.</span>--%>
                    </div>                 

              


                    <div class="container-login100-form-btn">                       
                    
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="login100-form-btn" onclick="btnEnviar_Click"/>
                    </div>

                    <div class="text-center p-t-46 p-b-20">
                       
                        <a href="InicioSesion.aspx" class="login100-form-btn" style="background-color:lightseagreen;">Volver a Inicio sesión</a>
                    </div>

                    <%--<div class="text-center p-t-46 p-b-20">
                        <span class="txt2">or sign up using
                        </span>
                    </div>--%>

                    <%--<div class="login100-form-social flex-c-m">
                        <a href="#" class="login100-form-social-item flex-c-m bg1 m-r-5">
                            <i class="fa fa-facebook-f" aria-hidden="true"></i>
                        </a>

                        <a href="#" class="login100-form-social-item flex-c-m bg2 m-r-5">
                            <i class="fa fa-twitter" aria-hidden="true"></i>
                        </a>
                    </div>--%>
                </form>

                <div class="login100-more" style="background-image: url('Login/images/bg-01.jpg');">
                </div>
            </div>
        </div>
    </div>

    <%--<form id="recuperar" runat="server">
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

            <div class="">
                <div class="row">
                    <div class="form-group col-md-5">
                        <%--EMAIL
                        <asp:Label ID="email" runat="server" Text="Completar email de su cuenta"></asp:Label>
                        <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" placeholder="Email" Type="email" CssClass="form-control" MaxLength="50" required="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-5 mt-4">
                        <%--ENVIAR
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" onclick="btnEnviar_Click"/>
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
