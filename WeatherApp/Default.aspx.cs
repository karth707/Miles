using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WeatherApp
{
    public partial class _Default : Page
    {
        //WeatherServiceReference.Service1Client client;
        WeatherServiceReferenceRem.Service1Client client;
        String zipcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            //client = new WeatherServiceReference.Service1Client();
            client = new WeatherServiceReferenceRem.Service1Client();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            zipcode = this.TextBox1.Text.ToString();
            XmlDocument document = new XmlDocument();
            document.LoadXml(client.GetWeather(zipcode));
            XmlNodeList city = document.GetElementsByTagName("city");
            XmlNode cityNode = city.Item(0);

            XmlNodeList state = document.GetElementsByTagName("state");
            XmlNode stateNode = state.Item(0);

            this.Label1.Text = cityNode.InnerText;
            this.Label2.Text = stateNode.InnerText;

            List<String> forecastStrings = new List<String>();
            XmlNodeList forecasts = document.GetElementsByTagName("forecast");
            this.Label3.Text = "";
            foreach (XmlNode forecast in forecasts)
            {
                this.Label3.Text = this.Label3.Text + forecast.InnerText + "<br>";
            }
        }
    }
}