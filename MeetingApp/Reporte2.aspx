<%@ Page Title="Formas de pago" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte2.aspx.cs" Inherits="MeetingApp.Reporte2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3 style="color: red; text-align: center">Reporte 2</h3>
        <hr />
        <h5 class="mb-5">Listado de formas de pago mas utilizadas por mes</h5>
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
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary col-auto mt-1 ml-5 mr-5" OnClick="btnConsultar_Click" />
        </td>
        <td>
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-success col-auto mt-1 ml-5" OnClick="btnLimpiar_Click" />
            <button id="btnImprimir" class="btn btn-info ml-3" runat="server" onclick="return pdf()">Imprimir</button>
        </td>
        <br />


        <%--GRAFICO--%>

        <div class="mt-5" id="divGrafico" runat="server" visible="false">
            <div id="print">
                <asp:Chart ID="gf_formasPagos" runat="server" Height="336px" Width="497px">
                    <Series>
                        <asp:Series Name="Serie" ChartArea="ChartArea"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea"></asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Text="Cantidad por Mes" />
                    </Titles>
                </asp:Chart>
            </div>
        </div>

        <%--<div>
            <h5 class="ml-5">Medios de pagos</h5>
        </div>--%>


        <%--FIN GRAFICO--%>


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
