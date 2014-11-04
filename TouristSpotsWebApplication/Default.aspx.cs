using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TouristSpotsWebApplication
{
    public partial class _Default : Page
    {
        TouristSpotsServiceReference.Service1Client touristSpotsClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            touristSpotsClient = new TouristSpotsServiceReference.Service1Client();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String latitude = this.TextBox1.Text;
            String longitude = this.TextBox2.Text;
            String Spots = touristSpotsClient.GetTouristSpots(latitude, longitude);

            XmlDocument touristSpotsXml = new XmlDocument();
            touristSpotsXml.LoadXml(Spots);
            XmlNodeList spotsXml = touristSpotsXml.GetElementsByTagName("spot");
            String output = "";
            try
            {
                for (int i = 0; i < spotsXml.Count; i++)
                {
                    String name = spotsXml[i].ChildNodes[0].InnerText;
                    String vicinity = spotsXml[i].ChildNodes[1].InnerText;
                    String type = spotsXml[i].ChildNodes[2].InnerText;
                    output = output + "Tourist Spot "+ i+1 +":<br>"
                                    + "Name: " + name + "<br>"
                                    + "Vicinity: " + vicinity + "<br>"
                                    + "Type: " + type + "<br><br>";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            this.Label1.Text = output;
        }
    }
}