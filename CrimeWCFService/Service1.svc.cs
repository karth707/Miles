using CrimeWCFService.WeatherServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrimeWCFService
{
   
    public class Service1 : IService1
    {
        WeatherServiceReference.WeatherSoapClient weatherClient;
        Web2TextServiceReference.ServiceClient webStringClient;

        public Service1()
        {
            weatherClient = new WeatherServiceReference.WeatherSoapClient();
            webStringClient = new Web2TextServiceReference.ServiceClient();
        }

        public string GetCrimeData(String zipcode)
        {
            ForecastReturn forcastReturn = new ForecastReturn();                //using weatherService to get state and city name from zipcode
            forcastReturn = weatherClient.GetCityForecastByZIP(zipcode);
            String state = forcastReturn.State;
            String city = forcastReturn.City;

            String url = "http://www.melissadata.com/lookups/CrimeCity.asp?state=" + state + "&CrimeYear=2012&city=" + city;
            String crimeDataPage = webStringClient.GetWebContent(url);

            int startPos = crimeDataPage.LastIndexOf("Tableresultborder") + "Tableresultborder".Length + 1;
            int length = crimeDataPage.IndexOf("</table><br><br>") - startPos - 1;
            string sub = "<table width=\"350\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"Tableresultborder\">"
                + crimeDataPage.Substring(startPos, length) + "</table><br>";
            Console.WriteLine(sub);

            return sub;
        }

    }
}