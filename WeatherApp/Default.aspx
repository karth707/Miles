<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeatherApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Weather Service</h2>
        <p class="lead">This service gives the weather of a location.</p>
        <p> The input is the zipcode of the location and the output is the weather for the next 5 days</p>        
    </div>
     
    <div class="row">
        <div class="col-md-4">
            <p>The Wsdl for the Weather Service:</p>
            <p><a href="http://localhost:49644/Service1.svc?wsdl">http://localhost:49644/Service1.svc?wsdl</a></p>
        </div>
        <div class="col-md-4">
            <p>Give the Zipcode of the location as the input.</p>
            <p>Zipcode : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
            <p><asp:Button ID="Button1" runat="server" Text="GetWeather" OnClick="Button1_Click" /></p>
            <p>City: <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
            <p>State: <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
            <p>Forecasts:</p>
            <div class="forecast" style="height: 579px">
                <p><asp:Label ID="Label3" runat="server" Text=""></asp:Label></p> 
            </div>                        
        </div>        
    </div>

</asp:Content>
