using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherParkViewModel
    {
        public ParkModel Park { get; set; }
        public List<ForecastModel> Forecast { get; set; }
    }
}