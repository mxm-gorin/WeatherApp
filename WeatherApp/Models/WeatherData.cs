using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Temperature { get; set; }

        public string TempratureMax { get; set; }

        public string TemperatureMin { get; set; }

        public string Conditions { get; set; }
        
        public string Humidity { get; set; }

        public string WindSpeed { get; set; }

    }
}