<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte4.aspx.cs" Inherits="MeetingApp.Reportes.Reporte4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="color: red; text-align: center">Reporte 4</h1>
        <hr />
        <h3 class="mb-5">Listado de pacientes que solicitaron mas de un turno por mes</h3>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Seleccionar mes" CssClass="mr-3"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cmbMes" runat="server" CssClass="btn btn-info dropdown-toggle col-auto mt-1 mr-5" AutoPostBack="false">
                <asp:ListItem Text="Meses..." Value="0"></asp:ListItem>
                <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary col-auto mt-1 ml-5 mr-5" onclick="btnConsultar_Click"/>
        </td>
        <td>
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-success col-auto mt-1 ml-5" onclick="btnLimpiar_Click"/>
            <button ID="btnImprimir" disabled="disabled" class="btn btn-info ml-3" runat="server" onclick="return pdf()">Imprimir</button>
        </td>

        <!--Tabla turnos-->
        <div id="IdTurnos" class="table mt-4">            
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <div id="print">
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover"  >
                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                <Columns>                   
                    <%--<asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="hora" HeaderText="Hora" />--%>                    
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="cantidadTurnos" HeaderText="Cantidad de turnos" />                   
                    
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
