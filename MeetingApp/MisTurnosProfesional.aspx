<%@ Page Title="Mis Turnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisTurnosProfesional.aspx.cs" Inherits="MeetingApp.MisTurnosProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .scrolling-table-container {
            height: 300px;
            overflow-y: auto;
            overflow-x: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1 style="text-align: center">Mis Turnos</h1>
        <hr />
        <div class="row col-auto" style="justify-content: center;">
            <div class="form-group col-auto mt-4">
                <%--BUSCAR POR DNI--%>
                <asp:Button ID="btnDivPorDni" runat="server" Text="Buscar por DNI" OnClick="btnDivPorDni_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-auto mt-4">
                <%--BUSCAR POR FECHA PARA CANCELAR--%>
                <asp:Button ID="btnDivCancelarPorFecha" runat="server" Text="Cancelar por Fecha" OnClick="btnDivCancelarPorFecha_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-auto mt-4">
                <%--BUSCAR POR FECHA MARCAR ATENDIDOS--%>
                <asp:Button ID="btnDivPorFecha" runat="server" Text="Marcar Atendidos" OnClick="btnDivPorFecha_Click" CssClass="btn btn-primary" />
            </div>
            <div class="form-group col-auto mt-4">
                <%--VOLVER--%>
                <asp:Button ID="btnVolver" runat="server" Text="Volver a Busqueda" OnClick="btnVolver_Click" CssClass="btn btn-outline-danger" />
            </div>
        </div>

        <div class="divPorDNI" id="divPorDNI" runat="server" visible="false">

            <div class="row">
                <div class="form-group col-md-4">
                    <%--DNI--%>
                    <asp:Label ID="Label4" runat="server" Text="Ingrese el D.N.I. del paciente"></asp:Label>
                    <asp:TextBox ID="txtDniBuscar" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--BUSCAR--%>
                    <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar paciente" OnClick="btnBuscarPaciente_Click" CssClass="btn btn-primary" />
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--LIMPIAR DATOS--%>
                    <asp:Button ID="btnLimpiarDatos" runat="server" Text="Limpiar datos" CssClass="btn btn-success" OnClick="btnLimpiarDatos_Click" />
                </div>
            </div>
            <h5>Buscar turnos activos por DNI del paciente</h5>
            <hr />
            <!--Tabla turnos-->
            <section>
                <%--<asp:UpdatePanel runat="server">
                    <ContentTemplate>--%>
                        <div class="scrolling-table-container">
                            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover" OnRowCommand="gvTurnos_RowCommand" Style="overflow-y: scroll; height: 15em">
                                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                                <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="fechaTurno" HeaderText="Fecha" />
                                    <asp:BoundField DataField="horaTurno" HeaderText="Hora" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </section>

            <!-- MODAL CANCELAR TURNO-->
            <asp:Panel runat="server" ID="panelCancelarTurno" Visible="false">
                <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content w-75" style="margin-left: 12.5%">
                            <div class="modal-header">
                                <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de dar de Baja el Turno?</h3>
                                <hr id="hrContent">
                                <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                    onserverclick="CerrarModalCancelar">
                                    x</button>
                            </div>
                            <div class="modal-body col-auto">
                                <%--CODIGO CUERPO MODAL--%>
                                <div class="mb-3 row">
                                    <%--DIA--%>
                                    <h4 class="col-auto">Dia:</h4>
                                    <asp:Label ID="lblDia" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--FECHA--%>
                                <div class="mb-3 row">
                                    <h4 class="col-auto">Fecha:</h4>
                                    <asp:Label runat="server" ID="lblFecha" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;"></asp:Label>
                                </div>
                                <%--HORA--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Hora:</h4>
                                    <asp:Label ID="lblHora" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--DESCRIPCION--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Descripcion:</h4>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;"></asp:Label>
                                </div>
                                <%--PACIENTE--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Paciente:</h4>
                                    <asp:Label ID="lblPaciente" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--OBRA SOCIAL--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Obra Social:</h4>
                                    <asp:Label ID="lblObraSocial" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>

                                <%--CIERRE CUERPO MODAL--%>
                            </div>
                            <!--Fin Body Modal-->
                            <div class="modal-footer">
                                <asp:Button ID="btnCancelar" Text="Volver" runat="server" type="button" class="btn btn-info" OnClick="btnCancelar_Click" />
                                <asp:Button ID="btnConfirmarCancelado" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnConfirmarCancelado_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-backdrop fade show"></div>
            </asp:Panel>

        </div>
        <%--CIERRE DIV POR DNI--%>





        <%--CANCELAR TURNOS POR FECHAS--%>
        <div class="" id="divCancelarPorFecha" runat="server" visible="false">
            <div class="row">
                <div class="form-group col-md-4">
                    <%--FECHA--%>
                    <asp:Label ID="Label2" runat="server" Text="Ingrese fecha de busqueda"></asp:Label>                    
                    <input type="date" runat="server" class="form-control" name="dtpCancelarFecha" id="dtpCancelarPorFecha">
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--BUSCAR--%>
                    <asp:Button ID="btnCancelarPorFecha" runat="server" Text="Buscar Turnos" CssClass="btn btn-primary" OnClick="btnCancelarPorFecha_Click" />
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--LIMPIAR DATOS--%>
                    <asp:Button ID="btnLimpiarCancelarPorFecha" runat="server" Text="Limpiar datos" OnClick="btnLimpiarCancelarPorFecha_Click" CssClass="btn btn-success" />                  
                </div>
            </div>
            <h5>Buscar turnos activos por fecha</h5>
            <hr />
            <!--Tabla turnos por fecha-->
            <section>
                <%--<div id="print">--%>
                    <%--<asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>
                            <div class="scrolling-table-container">
                                <asp:GridView ID="gvCancelarPorFecha" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover" OnRowCommand="gvCancelarPorFecha_RowCommand" Style="overflow-y: scroll; height: 15em">
                                    <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                                    <Columns>                                       
                                    <asp:BoundField DataField="fechaTurno" HeaderText="Fecha" />
                                    <asp:BoundField DataField="horaTurno" HeaderText="Hora" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                <%--</div>--%>
            </section>         

            <!-- MODAL CANCELAR TURNO POR FECHA-->
            <asp:Panel runat="server" ID="panelCancelarPorFecha" Visible="false">
                <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content w-75" style="margin-left: 12.5%">
                            <div class="modal-header">
                                <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de dar de Baja el Turno?</h3>
                                <hr id="hrContent">
                                <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                    onserverclick="CerrarModalCancelarPorFecha">
                                    x</button>
                            </div>
                            <div class="modal-body col-auto">
                                <%--CODIGO CUERPO MODAL--%>
                                <div class="mb-3 row">
                                    <%--DIA--%>
                                    <h4 class="col-auto">Dia:</h4>
                                    <asp:Label ID="lblDiaCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--FECHA--%>
                                <div class="mb-3 row">
                                    <h4 class="col-auto">Fecha:</h4>
                                    <asp:Label runat="server" ID="lblFechaCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;"></asp:Label>
                                </div>
                                <%--HORA--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Hora:</h4>
                                    <asp:Label ID="lblHoraCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--DESCRIPCION--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Descripcion:</h4>
                                    <asp:Label ID="lblDescrCancelar" runat="server" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;"></asp:Label>
                                </div>
                                <%--PACIENTE--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Paciente:</h4>
                                    <asp:Label ID="lblPacienteCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--OBRA SOCIAL--%>
                                <div class="row mb-3">
                                    <h4 class="col-auto">Obra Social:</h4>
                                    <asp:Label ID="lblObraSocCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>
                                <%--ESTADO--%>
                                <%--<div class="row mb-3">
                                    <h4 class="col-auto">Estado:</h4>
                                    <asp:Label ID="lblEstadoCancelar" Text="" CssClass="h5 col-auto mt-1 ml-1" Style="color: blue;" runat="server"></asp:Label>
                                </div>--%>

                                <%--CIERRE CUERPO MODAL--%>
                            </div>
                            <!--Fin Body Modal-->
                            <div class="modal-footer">
                                <asp:Button ID="btnVolverCancelar" Text="Volver" runat="server" type="button" class="btn btn-info" OnClick="btnVolverCancelar_Click" />
                                <asp:Button ID="btnConfirmarCancelarPorFecha" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnConfirmarCancelarPorFecha_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-backdrop fade show"></div>
            </asp:Panel>
        </div>
        <%--CIERRE DIV CANCELAR POR FECHA--%>



        <%--TURNOS ATENDIDOS POR FECHAS--%>
        <div class="" id="divPorFecha" runat="server" visible="false">
            <div class="row">
                <div class="form-group col-md-4">
                    <%--FECHA--%>
                    <asp:Label ID="Label1" runat="server" Text="Ingrese fecha de busqueda"></asp:Label>
                    <%--<asp:TextBox ID="TextBox1" name="txtDniBuscar" runat="server" placeholder="D.N.I." CssClass="form-control" MinLength="7" MaxLength="10" required="true"></asp:TextBox>--%>
                    <input type="date" runat="server" class="form-control" name="dtpFecha" id="dtpFecha">
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--BUSCAR--%>
                    <asp:Button ID="btnBuscarTurnosPorFecha" runat="server" Text="Buscar Turnos" CssClass="btn btn-primary" OnClick="btnBuscarTurnosPorFecha_Click" />
                </div>
                <div class="form-group col-md-4 mt-4">
                    <%--LIMPIAR DATOS--%>
                    <asp:Button ID="btnLimpiarDatosPorFecha" runat="server" Text="Limpiar datos" OnClick="btnLimpiarDatosPorFecha_Click" CssClass="btn btn-success" />
                    <button id="btnImprimir" class="btn btn-info ml-5" runat="server" onclick="return pdf()">Imprimir</button>
                </div>
            </div>
            <h5>Buscar turnos por fecha para marcar como atendidos o no atendidos</h5>
            <hr />
            <!--Tabla turnos por fecha-->
            <section>
                <div id="print">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="scrolling-table-container">
                                <asp:GridView ID="gvTurnosPorFecha" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover" OnRowCommand="gvTurnosPorFecha_RowCommand" Style="overflow-y: scroll; height: 15em">
                                    <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="idTurno" HeaderText="id" HeaderStyle-CssClass="d-none" ItemStyle-CssClass="d-none" />
                                        <asp:BoundField DataField="fechaTurno" HeaderText="Fecha" />
                                        <asp:BoundField DataField="horaTurno" HeaderText="Hora" />
                                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                                        <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                                        <asp:BoundField DataField="estado" HeaderText="Estado" HeaderStyle-CssClass="d-none" ItemStyle-CssClass="d-none" />
                                        <asp:BoundField DataField="atencion" HeaderText="Estado" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <p style="color:white;">
                                                    Todos
                                                <asp:CheckBox ID="chkTodos" runat="server" AutoPostBack="true" OnCheckedChanged="chkTodos_CheckedChanged" />
                                                </p>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <p>
                                                    <%--Atencion--%>
                                                    <asp:CheckBox ID="chkAtencion" runat="server" OnCheckedChanged="chkAtencion_CheckedChanged" />
                                                </p>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnImprimir" CommandName="Imprimir" CommandArgument='<%# Eval("idTurno") %>' Text="Imprimir turno" CssClass="btn btn-info" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </section>


            <div class="row mr-2" style="justify-content: end;">
                <%--CONFIRMAR CAMBIOS--%>
                <asp:Button ID="btnConfirmarAtencion" runat="server" Text="Actualizar atencion" CssClass="btn btn-outline-primary" OnClick="btnConfirmarAtencion_Click" />
            </div>

        </div>
        <%--CIERRE DIV POR FECHA--%>



        <%--fin container--%>
    </div>

    <style type="text/css">
        @media screen {
            #printSection {
                display: none;
            }
        }

        @media print {
            body > *:not(#printSection) {
                display: none;
            }

            #printSection, #printSection * {
                visibility: visible;
            }

            #printSection {
                position: absolute;
                left: 0;
                top: 0;
            }
        }
    </style>

    <script>
        function pdf() {
            var elem = document.getElementById('print');
            var domClone = elem.cloneNode(true);
            var $printSection = document.createElement("div");
            $printSection.id = "printSection";
            $printSection.appendChild(domClone);
            document.body.insertBefore($printSection, document.body.firstChild);

            window.print();

            // Clean up print section for future use
            var oldElem = document.getElementById("printSection");
            if (oldElem != null) { oldElem.parentNode.removeChild(oldElem); }
            //oldElem.remove() not supported by IE

            return true;
        }


        <%-- VALIDA QUE NO SE PUEDA SELECCIONAR FECHA ANTERIOR--%>
        
            let date = new Date();
            date.setDate(date.getDate() + 1);//agrega 1 dia para no seleccionar el dia de hoy en calendario
            const fecha = date.toISOString().split(":");
            const fechaPartida = fecha[0].split("T");
            const inputDate = document.getElementById("<%: dtpCancelarPorFecha.ClientID %>");

            let min = document.createAttribute("min")
            min.value = fechaPartida[0]
            console.log(inputDate)
            inputDate.setAttributeNode(min)
   

    </script>
</asp:Content>
