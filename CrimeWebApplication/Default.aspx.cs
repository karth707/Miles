using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrimeWebApplication
{
    public partial class _Default : Page
    {
        //CrimeServiceReference.Service1Client crimeClient;
        CrimeServiceReferenceRem.Service1Client crimeClient;
        protected void Page_Load(object sender, EventArgs e)
        {
            //crimeClient = new CrimeServiceReference.Service1Client();
            crimeClient = new CrimeServiceReferenceRem.Service1Client();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = crimeClient.GetCrimeData(this.TextBox1.Text);
        }
    }
}