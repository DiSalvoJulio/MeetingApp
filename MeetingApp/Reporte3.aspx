<%@ Page Title="Turnos cancelados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte3.aspx.cs" Inherits="MeetingApp.Reporte3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="text-align: center">Turnos cancelados</h1>
        <hr />
        <h3>Listado de turnos cancelados con filtros de fecha mínima y fecha máxima</h3>
        <h4 class="mt-5">Seleccionar Fechas</h4>
        <div class="form-row">
            <%--  FECHA--%>
            <div class="form-group col-md-3">
                <input type="date" runat="server" class="form-control" name="dtpFecha1" id="dtpFecha1" required>
                Desde
            </div>
            <div class="form-group col-md-3">
                <input type="date" runat="server" class="form-control" name="dtpFecha2" id="dtpFecha2" required>Hasta
            </div>
            <%--  BOTON CONSULTAR --%>
            <div class="form-group col-md-3">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" onclick="btnConsultar_Click"/>
            </div>
          <%--  BOTON LIMPIAR GRILLA --%>
            <div class="form-group col-md-3">
                <asp:Button ID="btnLimpiarGrilla" runat="server" Text="Limpiar" CssClass="btn btn-outline-success" onclick="btnLimpiarGrilla_Click"/>
                <button ID="btnImprimir" disabled="disabled" class="btn btn-info ml-3" runat="server" onclick="return pdf()">Imprimir</button>
            </div>
        </div>

        <!--Tabla turnos-->
        <div id="IdTurnosCancelados" class="table mt-4">            
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <div id="print">
            <asp:GridView ID="gvTurnosCancelados" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover"  >
                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                <Columns>                   
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                    <%--<asp:BoundField DataField="descripcion" HeaderText="Descripcion" />--%>
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <%--<asp:BoundField DataField="especialidad" HeaderText="Especialidad" />--%>
                    <%--<asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCancelarTurno" CommandName="Cancelar" CommandArgument='<%# Eval("idTurno") %>' Text="Cancelar turno" CssClass="btn btn-danger" />                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>  
            </asp:GridView>  
                </div>
            <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>



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
    </script>
</asp:Content>
