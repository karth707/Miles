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

namespace NavigationWcfService
{   
    public class Service1 : IService1
    {
        private static String API_KEY = "AIzaSyDDZjOK5uhwbe_infKfinmjE9x26hQMUIg";

        public distance GetDistance(String start, String end)
        {
            string url = @"https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" +
              start + "&destinations=" + end +
              "&mode=driving&sensor=false&language=en-EN&units=imperial" + "&key=" + API_KEY;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            distance d = new distance();
            d.dist = "0 mi";

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                d.dist =  distance[0].ChildNodes[1].InnerText;
                return d;
            }
            return d;
        }       
    }
}
