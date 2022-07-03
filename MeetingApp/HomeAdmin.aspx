<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="MeetingApp.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        body{
            /*background-color:#96b5d4;*/
            background-color:white;
            /*background-image:url(images/adminHome4.jpg);
            background-size:cover;
            background-size:1300px;*/        
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 style="text-align: center">Home</h1>
        <hr />       
       <div class="col mb-4">
                <div class="">
                    <img src="images/adminHome4.jpg" class="" style="width:1075px;height:550px" alt="...">                    
                </div>
            </div>
    </div>
</asp:Content>
