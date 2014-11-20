<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NavigationWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Navigation Service</h2>
        <p class="lead">This service gives distance between the two locations and displays a map for navigation.</p>
        <p> The input is the names of the start and end points of travel</p>        
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>The Wsdl for the navigation application:</p>
            <p><a href="http://10.1.11.146:10021/Service1.svc?wsdl">http://10.1.11.146:10021/Service1.svc?wsdl</a></p>
        </div>
        <div class="col-md-4">
            <p>Give the location as the input.</p>
            <p>Start : <asp:TextBox ID="start" runat="server"></asp:TextBox></p>
            <p>End : <asp:TextBox ID="end" runat="server"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="Get Distance" OnClick="Button1_Click"/></p>
            <p>Distance: </p><asp:Label ID="Label1" runat="server"></asp:Label>
                                                
        </div>        
    </div>

</asp:Content>

