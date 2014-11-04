using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace GeocodeWebApplication
{
    public partial class _Default : Page
    {
        GeocodeServiceReference.Service1Client geocodeClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            geocodeClient = new GeocodeServiceReference.Service1Client();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String inputLocation = this.TextBox1.Text;
            String latlong = geocodeClient.GetLatLon(inputLocation);
            XmlDocument latLonDoc = new XmlDocument();
            latLonDoc.LoadXml(latlong);
            XmlNodeList locationXml = latLonDoc.GetElementsByTagName("location");
            XmlNodeList formattedAddressXml = latLonDoc.GetElementsByTagName("formatted_address");
            this.Label1.Text = locationXml[0].ChildNodes[0].InnerText;
            this.Label2.Text = locationXml[0].ChildNodes[1].InnerText;
            this.Label3.Text = formattedAddressXml[0].InnerText;
        }
    }
}