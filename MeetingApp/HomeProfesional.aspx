<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeProfesional.aspx.cs" Inherits="MeetingApp.HomeProfesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <%--<style>
        body{
            background-image:url(images/profesional1.jpg);
            background-size:cover;
        }
    </style>--%>
    <%--<style>
        body{
            background-color:#96b5d4;
            
        }
    </style>--%>
    <link href="HomeProfesional.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="text-align: center">Home</h1>
        <hr />
        <div class="row row-cols-1 row-cols-md-3">
            <div class="col mb-4">
                <div class="card h-100">
                    <img src="images/nuevoturno.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <%--<h5 class="card-title">Nuevo turno</h5>--%>
                        <a class="h5" href="TurnoProfesional.aspx">Asignar turno</a>
                        <%--<p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>--%>
                    </div>
                </div>
            </div>
            <div class="col mb-4">
                <div class="card h-100">
                    <img src="images/misturnos.jpg" class="card-img-top" alt="...">
                    
                    <div class="card-body">
                        <%--<h5 class="card-title">Mis turnos</h5>--%>
                        <a class="h5" href="MisTurnosProfesional.aspx">Turnos asignados</a>
                       <%-- <p class="card-text">This is a short card.</p>--%>
                    </div>
                </div>
            </div>
            <div class="col mb-4">
                <div class="card h-100">
                    <img src="images/misdatos.jpg" class="card-img-top" alt="...">                      
                    <div class="card-body">
                        <%--<h5 class="card-title">Mis datos</h5>--%>
                        <a class="h5" href="DatosProfesional.aspx">Mis datos</a>
                        <%--<p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content.</p>--%>
                    </div>
                </div>
            </div>
            <div class="col mb-4">
                <div class="card h-100">
                    <img src="images/ayuda.jpg" class="card-img-top" alt="...">
                    
                    <div class="card-body">
                        <%--<h5 class="card-title">Ayuda</h5>--%>
                        <a class="h5" href="PreguntasFrecuentes.aspx">Ayuda</a>
                        <%--<p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>--%>
                    </div>
                </div>
            </div>
        </div>


    </div>
  <%-- cierre container--%>
</asp:Content>
