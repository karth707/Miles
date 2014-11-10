using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using WeatherWcfService.WeatherWCFService;

namespace WeatherWcfService
{    
    public class Service1 : IService1
    {
        WeatherWCFService.WeatherSoapClient client;

        public Service1()
        {
            client = new WeatherWCFService.WeatherSoapClient();
        }

        public String GetWeather(String zipcode)
        {
            XmlDocument weather = new XmlDocument();
            ForecastReturn forcastReturn = new ForecastReturn();
            forcastReturn = client.GetCityForecastByZIP(zipcode);

            XmlNode root = weather.CreateElement("weather");
            weather.AppendChild(root);
            XmlNode City = weather.CreateElement("city");
            City.InnerText = forcastReturn.City;
            root.AppendChild(City);
            XmlNode State = weather.CreateElement("state");
            State.InnerText = forcastReturn.State;
            root.AppendChild(State);
            XmlNode Forecasts = weather.CreateElement("forecasts");
            root.AppendChild(Forecasts);

            Forecast[] forecasts = forcastReturn.ForecastResult;
            int forecastCount = 0;
            foreach (Forecast forecast in forecasts)
            {
                if (forecastCount == 5)
                {
                    break;
                }
                XmlNode Forecast = weather.CreateElement("forecast");
                    XmlNode Date = weather.CreateElement("date");
                    Date.InnerText = "Date: " + forecast.Date.ToString() + "<br>";
                    Forecast.AppendChild(Date);
                    XmlNode Description = weather.CreateElement("description");
                    Description.InnerText = "Description: " + forecast.Desciption + "<br>" ;
                    Forecast.AppendChild(Description);
                    
                    temp temperature = forecast.Temperatures;
                    XmlNode Temperatures = weather.CreateElement("temperatures");
                        XmlNode MorningLow = weather.CreateElement("morningLow");
                        MorningLow.InnerText = "Temperatures: <br>MorningLow: " +  temperature.MorningLow + "F <br>";
                        Temperatures.AppendChild(MorningLow);
                        XmlNode DayTimeHigh = weather.CreateElement("dayTimeHigh");
                        DayTimeHigh.InnerText = "DaytimeHigh: " + temperature.DaytimeHigh + "F <br>";
                        Temperatures.AppendChild(DayTimeHigh);
                    Forecast.AppendChild(Temperatures);                
                Forecasts.AppendChild(Forecast);
                forecastCount++;
            }
            return weather.OuterXml.ToString();
        }
    }
}
