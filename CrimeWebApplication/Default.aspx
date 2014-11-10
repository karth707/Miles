<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrimeWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Crime Data Service</h2>
        <p class="lead">This service gives the Crime Data of a location.</p>
        <p> The input is the zipcode of the location and the output is the crime data</p>        
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>The Wsdl for the crime data application:</p>
            <p><a href="http://localhost:51394/Service1.svc?wsdl">http://localhost:51394/Service1.svc?wsdl</a></p>
        </div>
        <div class="col-md-4">
            <p>Give the Zipcode of the location as the input.</p>
            <p>Zipcode : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" /></p>
            <p>CrimeData: </p>
            <p><asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
                                         
        </div>        
    </div>

</asp:Content>
