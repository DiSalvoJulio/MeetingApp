<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="MeetingApp.Gestiones.Horarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Horarios.css" rel="stylesheet" />
    <div class="container">
        <h1 style="color: red; text-align: center">Horarios</h1>
        <hr />
        <h5>Seleccione un profesional al cual se le asignara el horario de atencion</h5>
        <asp:Label ID="Label1" runat="server" Text="Profesional"></asp:Label>
        <asp:DropDownList ID="cmbProfesional" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="true" OnSelectedIndexChanged="cmbProfesional_SelectedIndexChanged">            
        </asp:DropDownList>
        <!--Tabla horario-->
        <div id="IdTablaHorario">
            <%--<h5 class="mt-5">Tabla de horarios</h5>--%>
           <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
                    <asp:GridView ID="gvHorario" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mt-5" OnRowCommand="gvHorario_RowCommand">
                        <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                        <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                        <Columns>
                            <%--<asp:BoundField DataField="idArticulo" HeaderText="ARTICULO" />--%>
                            <asp:BoundField DataField="dia" HeaderText="Dia" />
                            <asp:BoundField DataField="turno" HeaderText="Turno" />
                            <asp:BoundField DataField="inicio" HeaderText="Inicio" />
                            <asp:BoundField DataField="fin" HeaderText="Fin" />
                            <asp:BoundField DataField="profesional" HeaderText="Profesional" />
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEditarHorario" CommandName="Modificar" CommandArgument='<%# Eval("idHorario") %>' Text="Modificar" CssClass="btn btn-success" />

                                    <asp:Button runat="server" ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("idHorario") %>' Text="Eliminar" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <%--<asp:Table ID="tblCarro" runat="server" Width="82px">
                </asp:Table>--%>
           <%--     </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
        <!--Fin Tabla horario-->
        <h5 class="mt-5">Crear horarios de atencion</h5>
        <%-- TABLA 2--%>
        <div>
            <table class="tabla">
                <tr>
                    <%-- TITULOS--%>
                    <th>DIAS</th>
                    <th>TURNO MAÑANA</th>
                    <th>TURNO TARDE</th>
                    <th>ACCIONES</th>
                </tr>
                <tr>
                    <td class="text-center">
                        <asp:DropDownList ID="cmbDias" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="text-center">
                        <div>
                            <asp:Label ID="lblLunesDesdeMañana" runat="server" Text="Inicio"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbDesdeMañana" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="true">
                                <asp:ListItem Text="--:--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="07:00" Value="07:00"></asp:ListItem>
                                <asp:ListItem Text="08:00" Value="08:00"></asp:ListItem>
                                <asp:ListItem Text="09:00" Value="09:00"></asp:ListItem>
                                <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblLunesHasta" runat="server" Text="Fin"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbHastaMañana" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="true">
                                <asp:ListItem Text="--:--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="07:00" Value="07:00"></asp:ListItem>
                                <asp:ListItem Text="08:00" Value="08:00"></asp:ListItem>
                                <asp:ListItem Text="09:00" Value="09:00"></asp:ListItem>
                                <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="text-center">
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Inicio"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbDesdeTarde" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="true">
                                <asp:ListItem Text="--:--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                                <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                                <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                                <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                                <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                                <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                                <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="Label4" runat="server" Text="Fin"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbHastaTarde" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="true">
                                <asp:ListItem Text="--:--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                                <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                                <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                                <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                                <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                                <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                                <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="text-center">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary col-auto mt-1" OnClick="btnAceptar_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <!-- MODAL HORARIOS ACTUALIZAR-->
        <asp:Panel runat="server" ID="panelModificarHorario" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">HORARIO POR DIA</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalHorario">
                                x</button>
                        </div>
                        <div class="modal-body col-md-10">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="row">
                                <asp:Label CssClass="col-6" ID="Label2" runat="server" Text="Especialidad"></asp:Label>
                                <asp:TextBox runat="server" ID="txtActualizarEspecialidad" CssClass="form-control col-6" placeholder=""></asp:TextBox>
                                <%--<asp:DropDownList ID="cmbProfesion" runat="server" CssClass="btn btn-outline-info dropdown-toggle col-6" onClientClick="verDrop()" AutoPostBack="true">
                            </asp:DropDownList>--%>
                            </div>

                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarEspecialidad" Text="Cancelar" runat="server" type="button" class="btn btn-danger" />
                            <asp:Button ID="btnConfirmarEspecialidad" Text="Confirmar" runat="server" type="button" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>

        <!-- MODAL HORARIO ELIMINAR-->
        <asp:Panel runat="server" ID="panelEliminar" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de eliminar la especialidad?</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalEliminar">
                                x</button>
                        </div>
                        <div class="modal-body col-md-8">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="row">
                                <asp:Label CssClass="col-6" ID="Label5" runat="server" Text="Especialidad"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEliminar" CssClass="form-control col-6" placeholder=""></asp:TextBox>
                            </div>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarEliminar" Text="Cancelar" runat="server" type="button" class="btn btn-danger"  />
                            <asp:Button ID="btnConfirmarEliminar" Text="Confirmar" runat="server" type="button" class="btn btn-primary"  />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>


    </div>
    <%-- FIN CONTAINER--%>
</asp:Content>
