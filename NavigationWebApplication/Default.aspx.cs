using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace NavigationWebApplication
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String url = @"http://10.1.11.146:10021/Service1.svc/nav?start=" + this.start.Text + "&end=" + this.end.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            XmlNodeList dist = xmldoc.GetElementsByTagName("dist");
            this.Label1.Text =  dist[0].InnerText;
            
        }
    }
}