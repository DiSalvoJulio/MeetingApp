<%@ Page Title="Pacientes por obra social" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte5.aspx.cs" Inherits="MeetingApp.Reporte5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="text-align: center">Obras sociales</h1>
        <hr />
        <h3 class="mb-5">Listado de pacientes atendidos por obra social - (fecha minima y maxima)</h3>
        <div class="form-row">
            <%--FECHA 1 --%>
            <div class="form-group col-md-2">
                <input type="date" runat="server" class="form-control" name="dtpFecha1" id="dtpFecha1" required>
                Desde
            </div>
            <%--FECHA 2 --%>
            <div class="form-group col-md-2">
                <input type="date" runat="server" class="form-control" name="dtpFecha2" id="dtpFecha2" required>Hasta
            </div>
            <div class="form-group col-md-3">
                <%--OBRAS SOCIALES--%>
                <%--<asp:Label ID="Label3" runat="server" Text="Obra social"></asp:Label>--%>             
                <asp:DropDownList ID="cmbObraSocial" runat="server" CssClass="btn btn-outline-primary dropdown-toggle col-8" onClientClick="verDrop()" AutoPostBack="false">
                    <asp:ListItem Text="Seleccionar..."></asp:ListItem>
                </asp:DropDownList>  
            </div>
            <div class="form-group col-md-2">
                <%--BOTON CONSULTAR--%>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary col-auto" OnClick="btnConsultar_Click" />
            </div>
            <div class="form-group col-md-1">
                <%--BOTON LIMPIAR--%>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-success" OnClick="btnLimpiar_Click" /> 
            </div>
            <div class="form-group col-md-1">
                <%--BOTON IMPRIMIR--%>                
                <button id="btnImprimir" disabled="disabled" class="btn btn-info" runat="server" onclick="return pdf()">Imprimir</button>
            </div>
        </div>

        <!--Tabla turnos-->
        <div id="IdTurnos" class="table mt-4">
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <div id="print">
                <asp:GridView ID="gvTurnosAtendidos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover">
                    <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="hora" HeaderText="Hora" />                   
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="obraSocial" HeaderText="Obra Social" />
                    <asp:BoundField DataField="atencion" HeaderText="Estado" />

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
