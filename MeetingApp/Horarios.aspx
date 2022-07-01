<%@ Page Title="Horarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Horarios.aspx.cs" Inherits="MeetingApp.Horarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Horarios.css" rel="stylesheet" />
    <div class="container">
        <h1 style="text-align: center">Horarios</h1>
        <hr />
        <h5>Seleccione un profesional al cual se le asignara el horario de atencion</h5>
        <asp:Label ID="Label1" runat="server" Text="Profesional" CssClass="mr-3"></asp:Label>
        <asp:DropDownList ID="cmbProfesional" runat="server" CssClass="btn btn-primary dropdown-toggle col-auto mt-1" AutoPostBack="true" OnSelectedIndexChanged="cmbProfesional_SelectedIndexChanged">
        </asp:DropDownList>
        <!--Tabla horario-->
        <div id="IdTablaHorario" class="table mt-4">
            <%--<h5 class="mt-5">Tabla de horarios</h5>--%>
            <%-- <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
            <asp:GridView ID="gvHorario" runat="server" AutoGenerateColumns="False" CssClass="table text-center table-hover" OnRowCommand="gvHorario_RowCommand" >
                <HeaderStyle BackColor="#3E64FF" ForeColor="White" />
                    <RowStyle BackColor="#D6DBDF" ForeColor="#333333" />
                <Columns>
                    <%--<asp:BoundField DataField="idArticulo" HeaderText="ARTICULO" />--%>
                    <asp:BoundField DataField="dia" HeaderText="Dia" />
                    <asp:BoundField DataField="turno" HeaderText="Turno" />
                    <asp:BoundField DataField="inicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="fin" HeaderText="Fin" />
                    <asp:BoundField DataField="profesional" HeaderText="Profesional" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnEditarHorario" CommandName="Modificar" CommandArgument='<%# Eval("idHorario") %>' Text="Modificar" CssClass="btn btn-info" />

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
        <div class="mb-5">
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
                        <asp:DropDownList ID="cmbDias" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto" AutoPostBack="false">
                        </asp:DropDownList>
                    </td>
                    <td class="text-center">
                        <div>
                            <asp:Label ID="lblDesdeMañana" runat="server" Text="Inicio"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbDesdeMañana" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
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
                            <asp:Label ID="lblHastaMañana" runat="server" Text="Fin"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbHastaMañana" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
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
                            <asp:Label ID="lblDesdeTarde" runat="server" Text="Inicio"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbDesdeTarde" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
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
                            <asp:Label ID="lblHastaTarde" runat="server" Text="Fin"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="cmbHastaTarde" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
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
                            <h3 class="modal-title mr-1" style="margin-left: auto">Horario:</h3>
                            <asp:Label CssClass="h3 ml-2" Text="" ID="lblHorario" runat="server"></asp:Label>
                            <hr />
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalHorario">
                                x</button>
                        </div>
                        <div class="modal-body">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="mb-3 row">
                                <h4 class="col-sm-1">Dia:</h4>
                                <asp:Label ID="lblDia" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>
                            </div>
                            <%--MAÑANA--%>
                            <div class="text-center row" id="divHorarioMañana" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="cmbMañana1" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
                                       <%-- <asp:ListItem Text="--:--" Value="0"></asp:ListItem>--%>
                                        <asp:ListItem Text="07:00" Value="07:00"></asp:ListItem>
                                        <asp:ListItem Text="08:00" Value="08:00"></asp:ListItem>
                                        <asp:ListItem Text="09:00" Value="09:00"></asp:ListItem>
                                        <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                        <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                        <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                        <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="cmbMañana2" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
                                        <%--<asp:ListItem Text="--:--" Value="0"></asp:ListItem>--%>
                                        <asp:ListItem Text="07:00" Value="07:00"></asp:ListItem>
                                        <asp:ListItem Text="08:00" Value="08:00"></asp:ListItem>
                                        <asp:ListItem Text="09:00" Value="09:00"></asp:ListItem>
                                        <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                        <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                        <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                        <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--FIN MAÑANA--%>

                            <%--TARDE--%>
                            <div class="text-center row" id="divHorarioTarde" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="cmbTarde1" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
                                      <%--  <asp:ListItem Text="--:--" Value="0"></asp:ListItem>--%>
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
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="cmbTarde2" runat="server" CssClass="btn btn-outline-dark dropdown-toggle col-auto mt-1" AutoPostBack="false">
                                       <%-- <asp:ListItem Text="--:--" Value="0"></asp:ListItem>--%>
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
                            </div>
                            <%--FIN TARDE--%>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnSalirModalActualizar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" OnClick="btnSalirModalActualizar_Click" />
                            <asp:Button ID="btnActualizar" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnActualizar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>


        <!-- MODAL HORARIO ELIMINAR-->
        <asp:Panel runat="server" ID="panelEliminarHorario" Visible="false">
            <div class="modal fade show" tabindex="-1" aria-hidden="true" style="display: block;">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content w-75" style="margin-left: 12.5%">
                        <div class="modal-header">
                            <h3 class="modal-title" style="margin-left: auto">¿Esta seguro de eliminar el horario?</h3>
                            <hr id="hrContent">
                            <button runat="server" class="close" data-bs-dismiss="modal" aria-label="Close"
                                onserverclick="CerrarModalEliminar">
                                x</button>
                        </div>
                        <div class="modal-body col-md-8">
                            <%--CODIGO CUERPO MODAL--%>
                            <div class="mb-3 row">
                                <h4 class="col-sm-1 mr-2">Dia:</h4>
                                <asp:Label ID="lblDiaEliminar" Text="" CssClass="h5 col-sm-2 mt-1 ml-2" runat="server"></asp:Label>
                            </div>
                            <%--MAÑANA--%>
                            <div class="text-center row" id="divHorarioEliminarMañana" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblMañanaDesdeEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblMañanaHastaEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                            </div>
                            <%--FIN MAÑANA--%>

                            <%--TARDE--%>
                            <div class="text-center row" id="divHorarioEliminarTarde" runat="server">
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Inicio"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblTardeDesdeEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                                <div class="col-sm-1">
                                    <asp:Label runat="server" Text="Fin"></asp:Label>
                                </div>
                                <div class="col-sm-3">

                                    <asp:Label ID="lblTardeHastaEliminar" Text="" CssClass="h5 col-sm-2 mt-1" runat="server"></asp:Label>

                                </div>
                            </div>
                            <%--FIN TARDE--%>
                            <%--CIERRE CUERPO MODAL--%>
                        </div>
                        <!--Fin Body Modal-->
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelarEliminar" Text="Cancelar" runat="server" type="button" class="btn btn-danger" OnClick="btnCancelarEliminar_Click" />
                            <asp:Button ID="btnConfirmarEliminar" Text="Confirmar" runat="server" type="button" class="btn btn-primary" OnClick="btnConfirmarEliminar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-backdrop fade show"></div>
        </asp:Panel>
    </div>
    <%-- FIN CONTAINER--%>
</asp:Content>
