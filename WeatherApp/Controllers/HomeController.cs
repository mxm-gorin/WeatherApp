using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services.DataProviders.Concrete;
using WeatherApp.Services.DataProviders.Contract;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            var ip = Request.UserHostAddress;

            return View();
        }

        [HttpPost]
        public ActionResult Weather(string city)
        {
            IDataProvider dataProvider = new OpenWeatherMapProvider();
            
            return View(dataProvider.GetData(city));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}