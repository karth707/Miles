using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NavigationWebApplication
{
    public partial class _Default : Page
    {
        DistanceServiceReference.Service1Client distanceClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            distanceClient = new DistanceServiceReference.Service1Client();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = distanceClient.GetDistance(this.start.Text, this.end.Text);
            
        }
    }
}