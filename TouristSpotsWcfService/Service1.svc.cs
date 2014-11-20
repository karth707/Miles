using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace TouristSpotsWcfService
{    
    public class Service1 : IService1
    {
        private static String API_KEY = "AIzaSyDDZjOK5uhwbe_infKfinmjE9x26hQMUIg";
        private static String RADIUS = "4000";                                                       //in meters
        private static String TYPES = "museum|night_club|art_gallery|park|zoo|movie_theater";
        private static int NO_SPOTS = 10;

        public string GetTouristSpots(String latitude, String longitude)
        {
            String url = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location="
                + latitude + "," + longitude + "&radius=" + RADIUS + "&types=" + TYPES + "&key=" + API_KEY;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            String touristSpots = "n/a";

            XmlDocument touristSpotsXml = new XmlDocument();
            XmlNode root = touristSpotsXml.CreateElement("tourist_Spots");
            touristSpotsXml.AppendChild(root);
            try
            {
                for (int i = 0; i < NO_SPOTS; i++)
                {
                    XmlNode spot = touristSpotsXml.CreateElement("spot");
                    XmlNode name = touristSpotsXml.CreateElement("name");
                    name.InnerText = xmldoc.GetElementsByTagName("result")[i].ChildNodes[0].InnerText;
                    spot.AppendChild(name);
                    XmlNode vicinity = touristSpotsXml.CreateElement("vicinity");
                    vicinity.InnerText = xmldoc.GetElementsByTagName("result")[i].ChildNodes[1].InnerText;
                    spot.AppendChild(vicinity);
                    XmlNode type = touristSpotsXml.CreateElement("type");
                    type.InnerText = xmldoc.GetElementsByTagName("result")[i].ChildNodes[2].InnerText;
                    spot.AppendChild(type);
                    root.AppendChild(spot);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ ex.StackTrace);
            }

            touristSpots = touristSpotsXml.InnerXml.ToString();

            return touristSpots;
        }        
    }
}
