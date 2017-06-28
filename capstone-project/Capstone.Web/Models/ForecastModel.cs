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
    }
}