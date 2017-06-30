using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherViewModel
    {
        public ParkModel Park { get; set; }
        public List<ForecastModel> Forecast { get; set; }
        public bool IsCelcius { get; set; }

        public int ConvertCelsius(int Fahrenheit)
        {
            int celsius = Convert.ToInt32(Convert.ToDecimal(Fahrenheit - 32) * 0.5556m);
            return celsius;
        }
    }
}