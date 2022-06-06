<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTurnoPaciente.aspx.cs" Inherits="MeetingApp.NuevoTurnoPaciente" Culture="es-MX" UICulture="es" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Nuevo Turno</h1>
        <hr />

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                <div class="form-group mt-2">
                    <%--combo especialidades--%>
                    <%--<h5 class="mr-3 mt-1">Seleccione una especialidad</h5>--%>
                     <asp:Label ID="Lbel1" runat="server" Text="Seleccione una especialidad" CssClass=""></asp:Label>
                    <asp:DropDownList ID="cmbEspecialidad" runat="server" CssClass="btn btn-primary form-control col-sm-9 mt-1" AutoPostBack="true" OnSelectedIndexChanged="cmbEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group mt-2 mr-5">
                <%--<div class="mt-5" id="divProfesionales" runat="server">--%>
                    <%--combo profesionales--%>
                    <%--<h5 class="mr-3 mt-1">Seleccione un profesional</h5>--%>
                     <asp:Label ID="La2" runat="server" Text="Seleccione un profesional" CssClass=""></asp:Label>
                    <asp:DropDownList ID="cmbProfesional" runat="server" CssClass="btn btn-primary form-control col-sm-10 mt-1" AutoPostBack="true">
                        <asp:ListItem Text="Profesional..."></asp:ListItem>
                    </asp:DropDownList>
                <%--</div>--%>
                </div>
                    </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <%--calendario para ver los dias--%>
        <%--<asp:TextBox type="date" runat="server" class="form-control col-3 mt-5" ID="txtCalendario"></asp:TextBox>--%>
        <div class="row">
            <input runat="server" type="date" class="form-control col-3 mt-4 mr-5" id="txtCalendario">
            <asp:Button Text="Mostrar horarios" ID="btnMostrarHorarios" class="btn btn-info col-sm-3 mt-4 ml-5" runat="server" OnClick="btnMostrarHorarios_Click" />
        </div>

        <div class="row">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-group mt-4 mr-5" id="divHorariosDisponibles" runat="server">
                    <%--combo horarios--%>
                    <%--<h5 class="mr-3 mt-1 col-sm-4">Seleccione un horario</h5>--%>
                     <asp:Label ID="Label2" runat="server" Text="Seleccione un horario" CssClass="mr-3"></asp:Label>
                    <asp:DropDownList ID="cmbHorarioDisponible" runat="server" CssClass="btn btn-primary form-control col-sm-12" AutoPostBack="false">
                        <asp:ListItem Text="Horario..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMostrarHorarios" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <%--FORMA DE PAGO--%>
        <div class="form-group mt-4 ml-5">
            <%--combo especialidades--%>
            <%--<h5 class="mr-3 mt-1 col-sm-4">Forma de pago</h5>--%>
             <asp:Label ID="Label1" runat="server" Text="Forma de pago" CssClass=""></asp:Label>
            <asp:DropDownList ID="cmbFormaPago" runat="server" CssClass="btn btn-primary form-control col-sm-12" AutoPostBack="false">
                <asp:ListItem Text="Forma de pago..."></asp:ListItem>
            </asp:DropDownList>
        </div>
            </div>

        <%--OBRA SOCIAL--%>
        <div class="row">
        <div class="form-group mt-4 mr-5 col-md-3">
            <%--combo obras sociales--%>
            <%--<h5 class="mr-3 mt-1 col-sm-4">Obra social</h5>--%>
             <asp:Label ID="lblOb" runat="server" Text="Obra social" CssClass=""></asp:Label>
            <asp:TextBox ID="txtObraSocial" name="txtObraSocial" runat="server" placeholder="Obra social" CssClass="form-control col-auto" Enabled="false"></asp:TextBox>
            <%--<asp:DropDownList ID="cmbObraSocial" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="false">
                <asp:ListItem Text="Obra Social..."></asp:ListItem>
            </asp:DropDownList>--%>
        </div>

        <div class="form-group mt-2 ml-5">
            <%--<h5 class="mr-3 mt-1 col-auto">Motivo del turno</h5>--%>
            <asp:Label ID="Label3" runat="server" Text="Motivo del turno" CssClass="mr-3"></asp:Label>
            <asp:TextBox runat="server" TextMode="MultiLine" Width="200%" CssClass="form-control" ID="txtMotivo"></asp:TextBox>
        </div>
            </div>

        <div class="row" style="justify-content: center;">
            <asp:Button Text="Reservar turno" ID="btnReservarTurno" class="btn btn-danger mt-5" runat="server" OnClick="btnReservarTurno_Click" />
        </div>

        <%--MODAL PARA CONFIRMAR EL TURNO--%>
        <asp:Panel runat="server" ID="panelConfirmarTurno" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">Detalle del turno</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalTurno">
                                x</button>
                        </div>
                        <div class="modal-body col-md-8">
                            <%--CODIGO CUERPO MODAL--%>
                            <%--<div class="mb-3 row">
                                DIA
                                <h4 class="col-sm-1 mr-2">Dia:</h4>
                                <asp:Label ID="lblDia" Text="" CssClass="h5 col-auto mt-1 ml-2" runat="server"></asp:Label>
                            </div>--%>
                           <%--FECHA--%>                            
                                <div class="mb-3 row">
                                    <h4 class="col-sm-1 mr-5">Fecha:</h4>
                                    <asp:Label runat="server" ID="lblFecha" Text="" CssClass="h5 col-auto mt-1 ml-2"></asp:Label>
                                </div>
                            <%--HORA--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-1 mr-4">Hora:</h4>
                                    <asp:Label ID="lblHora" Text="" CssClass="h5 col-auto mt-1 ml-4" runat="server"></asp:Label>
                                </div>
                            <%--DESCRIPCION--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-3 mr-5">Descripcion:</h4>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="" CssClass="h5 col-auto mt-1 ml-2"></asp:Label>
                                </div>
                            <%--PACIENTE--%>
                                <div class="row mb-3">
                                    <h4 class="col-sm-3 mr-2">Paciente:</h4>
                                    <asp:Label ID="lblPaciente" Text="" CssClass="h5 col-auto mt-1 ml-2" runat="server"></asp:Label>
                                </div>
                            <%--OBRA SOCIAL--%>
                            <div class="row mb-3">
                                <h4 class="col-auto">Obra Social:</h4>
                                    <asp:Label ID="lblObraSocial" Text="" CssClass="h5 col-auto mt-1" runat="server"></asp:Label>
                                </div> 
                            <%--FORMA PAGO--%>
                            <div class="row mb-3">
                                <h4 class="col-auto">Forma de Pago:</h4>
                                    <asp:Label ID="lblFormaPago" Text="" CssClass="h5 col-auto mt-1" runat="server"></asp:Label>
                                </div>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarEliminar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                            <asp:Button ID="btnConfirmarEliminar" Text="Confirmar" runat="server" type="button" class="btn btn-primary" onclick="btnConfirmarEliminar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>





        <%-- VALIDA QUE NO SE PUEDA SELECCIONAR FECHA ANTERIOR--%>
        <script>           
                       
            let date = new Date();//crea la fecha de hoy
            date.setDate(date.getDate() + 1);//agrega 1 dia para no seleccionar el dia de hoy en calendario
            const fecha = date.toISOString().split(":");
            const fechaPartida = fecha[0].split("T");
            const inputDate = document.getElementById("<%: txtCalendario.ClientID %>");

            let min = document.createAttribute("min")
            min.value = fechaPartida[0]
            console.log(inputDate)
            inputDate.setAttributeNode(min)
        </script>

    </div>
    <%--FIN CONTAINER--%>
</asp:Content>
