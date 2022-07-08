<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="MeetingApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio sesion</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

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
<body style="background-color: #666666;">

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-43">Iniciar sesión
                    </span>


                    <div class="wrap-input100 validate-input" data-validate="Email requerido: ejemplo@abc.com">
                        <%--<input class="input100" type="text" ID="txtUsuario" name="email" runat="server"/>--%>
                        <asp:TextBox ID="txtUsuario" runat="server" placeholder="Email o D.N.I." CssClass="input100" required="True"/>
                        <span class="focus-input100"></span>
                        <%--<span class="label-input100">Email o D.N.I.</span>--%>
                    </div>


                    <div class="wrap-input100 validate-input" data-validate="Contraseña requerida">
                       <%-- <input class="input100" type="password" id="txtPass" name="pass" runat="server"/>--%>
                        <asp:TextBox ID="txtPass" runat="server" placeholder="Contraseña" CssClass="input100" Type="password" required="True"/>
                        <span class="focus-input100"></span>
                        <%--<span class="label-input100">Contraseña</span>--%>
                    </div>

                    <div class="flex-sb-m w-full p-t-3 p-b-32">
                        <%--<div class="contact100-form-checkbox">
                            <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
                            <label class="label-checkbox100" for="ckb1">
                                Remember me
                            </label>
                        </div>--%>

                        <div style="justify-content:flex-end;">
                            <a href="RecuperarContrasenia.aspx" class="txt1">Olvidé mi contraseña?
                            </a>
                        </div>
                    </div>


                    <div class="container-login100-form-btn">                       
                    <asp:Button ID="btnIngresar" type="Button" runat="server" Text="Ingresar" CssClass="login100-form-btn" OnClick="btnIngresar_Click"></asp:Button>
                    </div>

                    <div class="text-center p-t-46 p-b-20">
                        <a href="Registrar.aspx" class="login100-form-btn" style="background-color:lightseagreen;">CREAR CUENTA</a>
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



    <%--<div class="wrapper">
        <div class="formContent col-auto p-5 text-center mt-5">
            <form id="formularioLogin" runat="server">

                <asp:ScriptManager runat="server">
                    <Scripts>
                        <asp:ScriptReference Path="~/js/jquery-3.3.1.min.js" />
                        <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
                    </Scripts>
                </asp:ScriptManager>

                <div class="form-control h-75 text-center mx-auto" style="background-color: powderblue;">
                    <div class="row justify-content-center mb-5">
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
                    <div class="row justify-content-center mt-3">
                        <a href="Registrar.aspx">CREAR CUENTA</a>
                    </div>
                    <div class="row justify-content-center mt-3">
                        <a href="RecuperarContrasenia.aspx">Olvide mi contraseña?</a>
                    </div>
                </div>
            </form>
        </div>

    </div>--%>

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
