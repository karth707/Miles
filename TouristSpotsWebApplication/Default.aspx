﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TouristSpotsWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Tourist Places Service</h2>
        <p class="lead">This service gives a list of tourist places for a particular location.</p>
        <p> The input is latitude and longitude.</p>        
    </div>

    <div class="row">
        <div class="">
            <p>The Wsdl for the geocode data application:</p>
            <p><a href="http://localhost:50363/Service1.svc?wsdl">http://localhost:50363/Service1.svc?wsdl</a></p>
        </div>
        <div class="" style="height: 956px">
            <p>Give the location as the input.</p>
            <p>Latitude : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
            <p>Longitude : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" /></p>
            <p>List of Locations: </p>            
            <p><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>                                         
        </div>        
    </div>

</asp:Content>
