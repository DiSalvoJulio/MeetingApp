<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTurnoPaciente.aspx.cs" Inherits="MeetingApp.NuevoTurnoPaciente" Culture="es-MX" UICulture="es" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        console.log(19);
        $(document).ready(function () {
            $('#txtCalendario').datepicker({
                format: 'mm/dd/yyyy',
                startDate: '-3d',
                language: 'es',
                autoclose: false
            });
        });
    </script>
    <div class="container">
        <h1 style="color: red; text-align: center">Nuevo Turno</h1>
        <hr />

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <%--combo especialidades--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione una Especialidad</h5>
                    <%-- <asp:Label ID="Label1" runat="server" Text="Especialidad" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbEspecialidad" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="true" OnSelectedIndexChanged="cmbEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div class="row mt-5" id="divProfesionales" runat="server">
                    <%--combo profesionales--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione un Profesional</h5>
                    <%-- <asp:Label ID="Label2" runat="server" Text="Profesional" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbProfesional" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="true">
                        <asp:ListItem Text="Seleccione Profesional..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--calendario para ver los dias--%>
        <%--<asp:TextBox type="date" runat="server" class="form-control col-3 mt-5" ID="txtCalendario"></asp:TextBox>--%>
        <div class="row">
            <input runat="server" type="date" class="form-control col-3 mt-5 ml-3 mr-5" id="txtCalendario">
            <asp:Button Text="Mostrar Horarios" ID="btnMostrarHorarios" class="btn btn-info col-sm-3 mt-5 ml-5" runat="server" OnClick="btnMostrarHorarios_Click" />
        </div>


        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row mt-5" id="divHorariosDisponibles" runat="server">
                    <%--combo horarios--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione un Horario</h5>
                    <%-- <asp:Label ID="Label2" runat="server" Text="Profesional" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbHorarioDisponible" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="false">
                        <asp:ListItem Text="Seleccione Horario..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMostrarHorarios" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>



        <asp:Button Text="Reservar Turno" class="btn btn-danger mt-5" runat="server" />



        <%--importar un datepicker y tenerlo en español--%>
        <%--<script>
            document.getElementById('#txtCalendario').value = new Date().toDateInputValue();
            $(document).ready(function () {
                $('#txtCalendario').val(new Date().toDateInputValue());
            });
        </script>--%>
        <%--<script type="text/javascript">
            $("#txtCalendario").datepicker({
                format: 'mm/dd/yyyy',
                startDate: '-3d',
                language: 'es',
                autoclose: false
            });
        </script>--%>
        <%--        <script>
            $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: '< Ant',
                nextText: 'Sig >',
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
            $(function () {
                $("#txtCalendario").datepicker();
            });
        </script>--%>
    </div>
    <%--FIN CONTAINER--%>
</asp:Content>
