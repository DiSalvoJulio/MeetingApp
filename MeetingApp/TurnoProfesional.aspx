<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnoProfesional.aspx.cs" Inherits="MeetingApp.TurnoProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="text-align: center">Nuevo Turno</h1>
        <hr />
        <div class="row"> <%--ESTA BIEEEEEEEEEEEEEEEN--%>
            <div class="form-group col-md-4">
                <%--DNI--%>
                <asp:Label ID="Label4" runat="server" Text="Ingrese el D.N.I. del paciente"></asp:Label>
                <asp:TextBox ID="txtDniBuscar" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10" required="true"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mt-4">
                <%--BUSCAR--%>
                <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar paciente" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
            </div>
            <hr />
        </div>
        <div class="row">
            <div class="form-group col-md-4">
                <%--DATOS--%>
                <asp:Label ID="Label1" runat="server" Text="Apellido y Nombre"></asp:Label>
                <asp:TextBox ID="txtDatos" name="txtDatos" runat="server" placeholder="Datos" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <%--OBRA SOCIAL--%>
                <asp:Label ID="Label2" runat="server" Text="Obra social"></asp:Label>
                <asp:TextBox ID="txtObraSocial" name="txtObraSocial" runat="server" placeholder="Obra Social" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-4 mt-4">
                <%--LIMPIAR DATOS--%>
                <asp:Button ID="btnLimpiarDatos" runat="server" Text="Limpiar datos" OnClick="btnLimpiarDatos_Click" CssClass="btn btn-success" />
            </div>
        </div>
        <hr />
        <%--------********************************************------%>
        <div class="row mt-2">
            <div class="form-group col-md-4">
                <%--ESPECIALIDAD--%>
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad"></asp:Label>
                <asp:TextBox ID="txtEspecialidad" name="txtEspecialidad" runat="server" placeholder="Especialidad" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <%--NOMBRE PROFESIONAL--%>
                <asp:Label ID="Nombre" runat="server" Text="Profesional"></asp:Label>
                <asp:TextBox ID="txtProfesional" name="txtProfesional" runat="server" placeholder="Profesional" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div class="row mt-2">
            <%--CALENDARIO--%>
            <div class="form-group col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Calendario"></asp:Label>
            <input runat="server" type="date" class="form-control" id="txtCalendario">
                </div>
            <div class="form-group col-md-2">
                <%--MOSTRAR HORARIOS--%>
                <asp:Label ID="Label5" runat="server" Text="Mostrar"></asp:Label>
            <asp:Button Text="Mostrar horarios" ID="btnMostrarHorarios" class="btn btn-info" runat="server" onclick="btnMostrarHorarios_Click"/>
                </div>

            <asp:UpdatePanel runat="server">
            <ContentTemplate>
            <div class="form-group col-md-5">
                <%--HORARIOS--%>
                <asp:Label ID="Label6" runat="server" Text="Horario"></asp:Label>
            <asp:DropDownList ID="cmbHorarioDisponible" runat="server" CssClass="btn btn-primary" AutoPostBack="false">
                <asp:ListItem Text="Horarios..."></asp:ListItem>
            </asp:DropDownList>  
                </div>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnMostrarHorarios" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>


        <%--FORMA DE PAGO--%>
        <div class="row mt-2">
            <div class="form-group col-md-3">
                <asp:Label ID="Label7" runat="server" Text="Forma de pago"></asp:Label>
            <asp:DropDownList ID="cmbFormaPago" runat="server" CssClass="btn btn-primary" AutoPostBack="false">  
                <asp:ListItem Text="Forma de pago..."></asp:ListItem>
            </asp:DropDownList>
                </div>
            <div class="form-group">
            <%--<h5 class="mt-1 col-sm-3">Motivo del turno</h5>--%>
                <asp:Label ID="Label8" runat="server" Text="Motivo del turno"></asp:Label>
            <asp:TextBox runat="server" TextMode="MultiLine" Width="180%" ID="txtMotivo"></asp:TextBox>
                </div>
        </div>

        <div class="form-row" style="justify-content: start;">
        <asp:Button Text="Reservar turno" ID="btnReservarTurno" class="btn btn-danger mt-3 mb-3" runat="server" onclick="btnReservarTurno_Click"/>
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
                        <div class="modal-body col-auto">
                            <%--CODIGO CUERPO MODAL--%>
                            <%--<div class="mb-3 row">
                                DIA
                                <h4 class="col-sm-1 mr-2">Dia:</h4>
                                <asp:Label ID="lblDia" Text="" CssClass="h5 col-auto mt-1 ml-2" runat="server"></asp:Label>
                            </div>--%>
                           <%--FECHA--%>                            
                                <div class="mb-3 row">
                                    <h4 class="col-auto">Fecha:</h4>
                                    <asp:Label runat="server" ID="lblFecha" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;"></asp:Label>
                                </div>
                            <%--HORA--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Hora:</h4>
                                    <asp:Label ID="lblHora" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;" runat="server"></asp:Label>
                                </div>
                            <%--DESCRIPCION--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Descripcion:</h4>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;"></asp:Label>
                                </div>
                            <%--PACIENTE--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Paciente:</h4>
                                    <asp:Label ID="lblPaciente" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;" runat="server"></asp:Label>
                                </div>
                            <%--OBRA SOCIAL--%>
                            <div class="row mb-3">
                                <h4 class="col-auto">Obra Social:</h4>
                                    <asp:Label ID="lblObraSocial" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;" runat="server"></asp:Label>
                                </div> 
                            <%--FORMA PAGO--%>
                            <div class="row mb-3">
                                <h4 class="col-auto">Forma de Pago:</h4>
                                    <asp:Label ID="lblFormaPago" Text="" CssClass="h5 col-auto mt-1 ml-1" style="color:blue;" runat="server"></asp:Label>
                                </div>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>                        
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" onclick="btnCancelar_Click"/>
                            <asp:Button ID="btnConfirmarTurno" Text="Confirmar" runat="server" type="button" class="btn btn-primary" onclick="btnConfirmarTurno_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>






         <%-- VALIDA QUE NO SE PUEDA SELECCIONAR FECHA ANTERIOR--%>
        <script>            
            let date = new Date();
            date.setDate(date.getDate() + 1);//agrega 1 dia para no seleccionar el dia de hoy en calendario
            const fecha = date.toISOString().split(":");
            const fechaPartida = fecha[0].split("T");
            const inputDate = document.getElementById("<%: txtCalendario.ClientID %>");

            let min = document.createAttribute("min")
            min.value = fechaPartida[0]
            console.log(inputDate)
            inputDate.setAttributeNode(min)
        </script>  


        <%--fin container--%>
    </div>
</asp:Content>
