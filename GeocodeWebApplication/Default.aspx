<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeocodeWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Geocode Data Service</h2>
        <p class="lead">This service gives the the latitude and longitude of a location.</p>
        <p> The input is the lication and the output is latitude and longitude.</p>        
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>The Wsdl for the geocode data application:</p>
            <p><a href="http://localhost:49477/Service1.svc?wsdl">http://localhost:49477/Service1.svc?wsdl</a></p>
        </div>
        <div class="col-md-4">
            <p>Give the location as the input.</p>
            <p>Location : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" /></p>
            <p>Formatted Address: </p>
            <p><asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
            <p>Latitide: </p>
            <p><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
            <p>Longitude: </p>
            <p><asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
                                         
        </div>        
    </div>

</asp:Content>
