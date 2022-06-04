<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TerminosYCondiciones.aspx.cs" Inherits="MeetingApp.TerminosYCondiciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>


    <%--   css link a referencia bootstrap local--%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <link href="TerminosYCondiciones.css" rel="stylesheet" />
    <title>Terminos y Condiciones</title>
</head>

<body class="content">
    <form id="terminos" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/js/jquery-3.3.1.min.js" />
                <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
            <section class="content-header mt-2">
                <h1 style="color: red; text-align: center">Términos y Condiciones</h1>
            </section>
            <hr />



            <div class="volver mt-5">
                <a href="Registrar.aspx" class="btn btn-info">Volver</a>
            </div>
        </div>
    </form>
</body>
</html>
