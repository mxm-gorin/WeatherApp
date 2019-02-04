using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services.DataProviders.Contract
{
    interface IDataProvider
    {
        WeatherData GetData(string city);
    }
}
