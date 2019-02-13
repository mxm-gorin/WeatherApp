using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.Services.DataProviders.Contract;

namespace WeatherApp.Services.DataProviders.Concrete
{
    public class OpenWeatherMapProvider : IDataProvider
    {
        const string Url = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units={2}";
        const string Units = "metric";
        const string AppId = "b2635d2bf54a5d77be5c74e537ea4dac";

        public WeatherData GetData(string city)
        {
            using (var client = new WebClient())
            {
                var apiUrl = string.Format(Url, city, AppId, Units);
                
                try
                {
                    var data = client.DownloadString(apiUrl);
                    dynamic jsonData = JsonConvert.DeserializeObject(data);
                    string countryCode = jsonData.sys.country;

                    var weatherData = new WeatherData
                    {
                        City = jsonData.name,
                        Country = CountryCodeConverter.ConvertTwoLetterCodeToName(countryCode),
                        Temperature = jsonData.main.temp,
                        TempratureMax = jsonData.main.temp_max,
                        TemperatureMin = jsonData.main.temp_min,
                        Conditions = jsonData.weather[0].description,
                        Humidity = jsonData.main.humidity,
                        WindSpeed = jsonData.wind.speed
                    };

                    return weatherData;
                }
                catch
                {
                    return new WeatherData()
                    {
                        City = "Not found",
                        Country = "Not found",
                        Temperature = "Not found",
                        TempratureMax = "Not found",
                        TemperatureMin = "Not found",
                        Conditions = "Not found",
                        Humidity = "Not found",
                        WindSpeed = "Not found"
                    };
                }
            }
        }
    }
}