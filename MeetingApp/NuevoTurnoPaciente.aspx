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
                    <%--combo especialidades--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione una especialidad</h5>
                    <%-- <asp:Label ID="Label1" runat="server" Text="Especialidad" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbEspecialidad" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="true" OnSelectedIndexChanged="cmbEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div class="row mt-5" id="divProfesionales" runat="server">
                    <%--combo profesionales--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione un profesional</h5>
                    <%-- <asp:Label ID="Label2" runat="server" Text="Profesional" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbProfesional" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="true">
                        <asp:ListItem Text="Seleccione profesional..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--calendario para ver los dias--%>
        <%--<asp:TextBox type="date" runat="server" class="form-control col-3 mt-5" ID="txtCalendario"></asp:TextBox>--%>
        <div class="row">
            <input runat="server" type="date" class="form-control col-3 mt-5 ml-3 mr-5" id="txtCalendario">
            <asp:Button Text="Mostrar horarios" ID="btnMostrarHorarios" class="btn btn-info col-sm-3 mt-5 ml-5" runat="server" OnClick="btnMostrarHorarios_Click" />
        </div>


        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row mt-5" id="divHorariosDisponibles" runat="server">
                    <%--combo horarios--%>
                    <h5 class="mr-3 mt-1 col-sm-4">Seleccione un horario</h5>
                    <%-- <asp:Label ID="Label2" runat="server" Text="Profesional" CssClass="mr-3"></asp:Label>--%>
                    <asp:DropDownList ID="cmbHorarioDisponible" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="false">
                        <asp:ListItem Text="Seleccione horario..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMostrarHorarios" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <%--FORMA DE PAGO--%>
        <div class="row mt-5">
            <%--combo especialidades--%>
            <h5 class="mr-3 mt-1 col-sm-4">Forma de pago</h5>
            <%-- <asp:Label ID="Label1" runat="server" Text="Especialidad" CssClass="mr-3"></asp:Label>--%>
            <asp:DropDownList ID="cmbFormaPago" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="false">
                <asp:ListItem Text="Forma de pago..."></asp:ListItem>
            </asp:DropDownList>
        </div>

        <%--OBRA SOCIAL--%>
        <div class="row mt-5">
            <%--combo obras sociales--%>
            <h5 class="mr-3 mt-1 col-sm-4">Obra social</h5>
            <%-- <asp:Label ID="Label1" runat="server" Text="Especialidad" CssClass="mr-3"></asp:Label>--%>
            <asp:TextBox ID="txtObraSocial" name="txtObraSocial" runat="server" placeholder="Obra social" CssClass="form-control col-sm-3" Enabled="false"></asp:TextBox>
            <%--<asp:DropDownList ID="cmbObraSocial" runat="server" CssClass="btn btn-primary col-sm-3 mt-1" AutoPostBack="false">
                <asp:ListItem Text="Obra Social..."></asp:ListItem>
            </asp:DropDownList>--%>
        </div>

        <div class="mt-5">
            <h5 class="mr-3 mt-1 col-sm-4">Motivo del turno</h5>
            <asp:TextBox runat="server" TextMode="MultiLine" Width="60%" ID="txtMotivo"></asp:TextBox>
        </div>

        <div class="form-row" style="justify-content: center;">
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
                            <asp:Label ID="txtFecha" runat="server" Text="Fecha" CssClass="mr-3"></asp:Label>
                            <asp:Label ID="txtHora" runat="server" Text="Hora" CssClass="mr-3"></asp:Label>
                            <asp:Label ID="txtFormaPago" runat="server" Text="Forma Pago" CssClass="mr-3"></asp:Label>


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
            let date = new Date();
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
