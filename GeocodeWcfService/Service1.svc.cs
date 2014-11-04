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

namespace GeocodeWcfService
{    
    public class Service1 : IService1
    {
        private static String API_KEY = "AIzaSyDDZjOK5uhwbe_infKfinmjE9x26hQMUIg";
       
        public string GetLatLon(String location)
        {
            String url = "https://maps.googleapis.com/maps/api/geocode/xml?address="
                + location + "&key=" + API_KEY;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            
            
            String latLon = "n/a";

            if (xmldoc.GetElementsByTagName("GeocodeResponse")[0].ChildNodes[0].InnerText == "OK")
            {                
                XmlDocument geometry = new XmlDocument();
                XmlNode root = geometry.CreateElement("geometry");
                geometry.AppendChild(root);

                XmlNode formAddress = geometry.CreateElement("formatted_address");
                formAddress.InnerText = xmldoc.GetElementsByTagName("formatted_address")[0].InnerText;
                root.AppendChild(formAddress);

                XmlNode geoCoordinates = geometry.CreateElement("location");
                geoCoordinates.InnerXml = xmldoc.GetElementsByTagName("location")[0].InnerXml;
                root.AppendChild(geoCoordinates);

                latLon = geometry.OuterXml.ToString();               
                //latLon = xmlLocation[0].OuterXml.ToString();
            }
            return latLon;
        }       
    }
}
