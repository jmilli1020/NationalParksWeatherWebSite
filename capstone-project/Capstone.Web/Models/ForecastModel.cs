using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ForecastModel
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public int ConvertCelsius(int Fahrenheit)
        {
            int celsius = Convert.ToInt32(Convert.ToDecimal(Fahrenheit - 32) * 0.5556m);
            return celsius;
        }

        public string Advice(string forecast)
        {
            string advice ="";
            if (forecast == "cloudy")
            {
                advice = "Enjoy the day! ";
            }
            else if (forecast == "rain")
            {
                advice = "Remember to pack rain gear and wear waterproof shoes. ";
            }
            else if (forecast == "snow")
            {
                advice = "Do you own snowshoes?  Better bring them along! ";
            }
            else if (forecast == "thunderstorms")
            {
                advice = "Thunderstorms are predicted! Please seek shelter and avoid hiking on exposed ridges. ";
            }
            else if (forecast == "sun")
            {
                advice = "Remember to pack sunblock. ";
            }
            if (High >= 75)
            {
                advice += " It's hot out there, bring an extra gallon of water. ";
            }
            if ((High - Low) > 20)
            {
                advice += "Wear breathable layers. ";
            }
            if (Low < 20)
            {
                advice += "Stay inside it's cold out there. ";
            }
            return advice;

        }
    }
}