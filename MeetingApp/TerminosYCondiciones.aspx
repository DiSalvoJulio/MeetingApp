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
            <%--<section class="content-header mt-2">
                <h1 style="color: red; text-align: center">Términos y Condiciones</h1>
            </section>
            <hr />--%>
            <%--CONTENIDO--%>
            <div class="mt-4">
                <p>
                    <b>Términos y condiciones de Uso del Sitio</b><br />
                    Todos los visitantes a este sitio deberán informarse sobre los Términos y Condiciones que aparecen a continuación. En caso de no estar de acuerdo con los mismos sugerimos no acceder a este sitio, o a cualquier página del mismo. Por el solo hecho de ingresar o hacer uso de este sitio usted (en adelante el "usuario") acepta y se adhiere de forma inmediata a todos y cada uno de los siguientes Términos y Condiciones:
                    <br />
                    <b>Meeting App</b> 
                    <br />
                    Es una empresa que ofrece un servicio para nuestros usuarios y/o visitantes de nuestros sitios web. El servicio ofrecido es diseñado y desarrollado por la empresa: Meeting App, con domicilio en Fructuoso Rivera 34, Ciudad de Córdoba capital, provincia de Córdoba. Meeting App es una sociedad cuya actividad principal consiste en brindar servicios de administración de turnos que se amolda según al área y necesidades del cliente. A fin de facilitar la comunicación y dar respuestas más rápidas y eficientes para la protección de los derechos de usuarios y consumidores.
                    <br />
                    <b>Políticas de privacidad</b>
                    <br />
                    La privacidad de sus datos es de suma importancia para el Meeting App. Por ello hemos desarrollado una Política de Privacidad en la que describimos cómo recolectamos, almacenamos y utilizamos sus datos.
Sus “datos personales” son tratados de acuerdo a lo establecido en la legislación argentina (Ley Nº 25.326 de Protección de Datos Personales y su Decreto Reglamentario N° 1558/2001), que regula los procesos de tratamiento, recolección, almacenamiento, conservación, acceso, transferencia y destrucción de los datos personales.
En caso que Ud. decida de manera voluntaria completar los campos de información personal con los datos mediante los cuales Ud. puede ser identificado, Meeting App los recopilará manteniendo, resguardando y asegurando dicha información de acuerdo con esta política, así como con las leyes, normas y disposiciones correspondientes.
Se informa a Ud. que para el tratamiento de sus datos Meeting App cumplimenta acabadamente con lo normado en el Art. 9 de la Ley 25.326 respecto de la adopción de medidas técnicas y organizativas necesarias para garantizar la seguridad y confidencialidad de sus datos personales, de modo de evitar su adulteración, pérdida, consulta o tratamiento no autorizado.
Ninguno de los datos personales que obran en nuestros registros será transferido o transmitido a terceros, a menos que usted nos hubiere dado explícitamente su consentimiento.
Conforme la Ley de Protección de Datos Personales Nº 25.326, Ud. tiene derecho de acceso, rectificación, actualización y supresión de los datos registrados en las condiciones legalmente establecidas. Para ello, podrá solicitarlo mediante el contacto de este sitio web.
                    <br />
                    <b>Derechos de autor y marcas registradas</b>
                    <br />
                    El diseño y contenido de este sitio se encuentra debidamente protegido conforme lo dispuesto en la Ley 11.723 de propiedad Intelectual, por lo que queda estrictamente prohibido: modificar, copiar, distribuir, transmitir, desplegar, publicar, editar, vender o de cualquier forma explotar el diseño y contenido de este sitio con fines comerciales o privados. Los avisos, frases de propaganda, dibujos, diseños, logotipos, textos, etc. que aparecen en este sitio, son propiedad exclusiva de la empresa Meeting App o de terceros que han autorizado a las mismas para su uso. 
Queda estrictamente prohibido cualquier uso o explotación por cualquier medio, sin el consentimiento previo y por escrito de la Empresa Meeting App y/o de sus legítimos propietarios. La violación de esta prohibición, hará pasibles a sus autores de las sanciones penales previstas en las Leyes 11.723 y 22.362. 
Se deja constancia que las referencias, tanto al contenido de este sitio como a las prohibiciones, son meramente enunciativas y no limitativas.
                    <br />
                    <b>Modificaciones</b>
                    <br />
                    La empresa Meeting App podrá, sin necesidad de aviso previo o comunicación alguna, modificar el contenido y alcance de los presentes Términos y Condiciones en el momento que lo considere necesario.<br />
                    <b>Violación a los términos y condiciones</b>
                    <br />
                    La empresa Meeting App podrá llevar a cabo todas las acciones legales que sean necesarias para remediar cualquier violación a los presentes Términos y Condiciones, incluso el de restringir el acceso a este sitio a determinados usuarios de internet. Ley aplicable y jurisdicción Los usuarios de este sitio acuerdan someterse a la legislación de la República Argentina y a la jurisdicción de los tribunales competentes de la República Argentina.

                </p>
            </div>
            <%--FIN CONTENIDO--%>

            <div class="volver mt-2 mb-2">
                <a href="Registrar.aspx" class="btn btn-info">Volver a Inicio sesión</a>
            </div>
        </div>
    </form>
</body>
</html>
