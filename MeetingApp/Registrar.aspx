<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="MeetingApp.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <%--   css link a referencia bootstrap local--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <%--<script src="js/JavaScript.js"></script>--%>
    <link href="Registrar.css" rel="stylesheet" />
    <title>Registrar</title>
    <link rel="stylesheet" type="text/css" href="Login/css/util.css"/>
    <link rel="stylesheet" type="text/css" href="Login/css/main.css"/>
</head>
<body class="content">

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Scripts/jquery-3.4.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </Scripts>
        </asp:ScriptManager>
        <%-- SECCION 1--%>
        <section class="content-header mt-2">
            <h1 style="text-align: center" class="login100-form-title">Registrarme</h1>
        </section>
        <%-- SECCION 2--%>
        <div class="container">
            <hr class="color: red;" />
            <div class="row">
                <div class="form-group col-md-6 mt-3">
                    <%--APELLIDO--%>
                    <asp:Label ID="Apellido" runat="server" Text="Apellido/s"></asp:Label>
                    <asp:TextBox ID="txtApellido" name="txtApellido" runat="server" placeholder="Apellido/s" CssClass="form-control" MaxLength="40"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ErrorMessage="Debe ingresar solo letras." CssClass="text-danger h5"
                        ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]*$"
                        ></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--NOMBRE--%><script src="js/bootstrap.min.js"></script>
                    <asp:Label ID="Nombre" runat="server" Text="Nombre/s"></asp:Label>
                    <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" placeholder="Nombre/s" CssClass="form-control" MaxLength="40"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        runat="server" ErrorMessage="Debe ingresar solo letras." CssClass="text-danger h5"
                        ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]*$"
                        ></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--DNI--%>
                    <asp:Label ID="dni" runat="server" Text="D.N.I."></asp:Label>
                    <asp:TextBox ID="txtDni" name="txtDni" type="number" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="9"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        runat="server" ErrorMessage="Solo numeros, minimo 7 y maximo 9" CssClass="text-danger h5"
                        ControlToValidate="txtDni" ValidationExpression="^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$"
                        ></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--FECHA NACIMIENTO--%>
                    <asp:Label ID="fechaNac" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    <asp:TextBox ID="txtFecNac" name="txtFecNac" runat="server" placeholder="Fecha de nacimiento" Type="date" CssClass="form-control" MaxLength="10"></asp:TextBox>
                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                        runat="server" ErrorMessage="Debe ingresar fecha correcta" CssClass="text-danger h4"
                        ControlToValidate="txtFecNac" ValidationExpression="^([0]?[1-9]|[1-2][0-9]|[3][0-1])/([0]?[1-9]|[1][0-2])/([1-3][0-9][0-9][0-9])$"
                        ></asp:RegularExpressionValidator>--%>
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
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        runat="server" ErrorMessage="Debe ingresar un email valido." CssClass="text-danger h5"
                        ControlToValidate="txtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                        ></asp:RegularExpressionValidator>
                </div>
                <div class="form-group col-md-4 mt-3">
                    <%--CONTRASEñA--%>
                    <asp:Label ID="Pass" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass" name="txtPass" runat="server" placeholder="Contraseña" type="password" CssClass="form-control" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 mt-3">
                    <%--REPERTIR CONTRASEñA--%>
                    <asp:Label ID="pass2" runat="server" Text="Repetir Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass2" name="txtPass2" runat="server" placeholder="Repetir Contraseña" type="password" CssClass="form-control" MaxLength="40" oninput="maxlengthNumber(this);"></asp:TextBox>
                </div>
            </div>
            <%--cierre del row--%>

            <div class="row">

                <%--  <div class="custom-control custom-switch">
                    <asp:CheckBox ID="chkProfesional" runat="server" OnCheckedChanged="chkProfesional_CheckedChanged" AutoPostBack="true" CssClass="custom-control-input" />
                    <label class="custom-control-label" for="chkProfesional">Soy Profesional.</label>
                </div>--%>

                <div class="form col-12 mt-1">
                    <div class="row">
                        <asp:CheckBox ID="chkProfesional" runat="server" OnCheckedChanged="chkProfesional_CheckedChanged" AutoPostBack="true" CssClass="form mx-3" />
                        <label for="chkProfesional">Soy Profesional.</label>
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
                    <asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-12" onClientClick="verDrop()">
                        <asp:ListItem Selected="True">Seleccione Especialidad...</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-6 mt-3">
                    <%--MATRICULA--%>
                    <asp:Label ID="Label3" runat="server" Text="Matricula"></asp:Label>
                    <asp:TextBox ID="txtMatricula" name="txtMatricula" runat="server" placeholder="Matricula" CssClass="form-control" OnkeyDown="Letras()" MaxLength="40"></asp:TextBox>
                </div>
                <%--</div>--%>
            </div>
            <%--SECCION TERMINOS Y CONDICIONES--%>
            <div class="termi row mt-4">
                <input runat="server" style="opacity: 1;" id="chkTerminos" class="mb-4" type="checkbox" data-required="1" name="chkTerminos" />
                <p style="color: black; padding-left: 20px; margin-bottom: 20px;">Aceptar los <a style="color: blue;" href="TerminosYCondiciones.aspx">Términos y Condiciones</a></p>
            </div>
            <div class="modal-header mt-1" style="padding: 1rem 0rem !important; border: none;">
                <a href="InicioSesion.aspx" class="btn btn-info">Volver a Inicio sesión</a>
                <div>
                    <%--<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />--%>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
                </div>
            </div>


            <%--<div class="form col-md-12 mt-3" style="justify-content:center;">
            <div class="form-check">
                <asp:CheckBox ID="chkTerminos" runat="server" AutoPostBack="false" CssClass="form" />
                <label class="" for="chkTerminos">Aceptar los</label><p>terminos</p>
            </div>
        </div>--%>




            <%--fin container--%>
        </div>

    </form>
    <script src="js/jquery.min.js"></script>
    <%-- <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>--%>
    <script src="js/main.js"></script>

    <script>
            function Letras() {
                let validLetras = 
            }
            
    </script>

</body>
</html>



