using Capstone.Web.DALs;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDAL;
        private IParksDAL parkDAL;
        private const string Session_ParkCode = "session_parkcode";
        private const string Session_ParkName = "session_parkname";
        private const string Session_TemperatureUnit = "session_temperatureunit";        

        public WeatherController(IWeatherDAL weatherDAL,IParksDAL parkDAL)
        {            
            this.weatherDAL = weatherDAL;
            this.parkDAL = parkDAL;
        }
        
        public ActionResult Forecast()
        {
            ViewBag.ParkName = Session[Session_ParkName];
            if ((string)Session[Session_TemperatureUnit] == "Farenheit")
            {
                ViewBag.TemperatureUnitSwitch = "Celsius";
            }
            else if((string)Session[Session_TemperatureUnit] == "Celsius")
            {
                ViewBag.TemperatureUnitSwitch = "Farenheit";
            }else
            {
                ViewBag.TemperatureUnitSwitch = "Celsius";
            }
            
            string parkCode = (string)Session[Session_ParkCode];

            List<WeatherModel> forecasts = weatherDAL.GetForecasts(parkCode);
            foreach(var forecast in forecasts)
            {
                forecast.TempatureUnit = (string) Session[Session_TemperatureUnit];
            }
           
            return View("Forecast", forecasts);
        }

        [HttpPost]
        public ActionResult ForecastResult(string parkCode, string TemperatureUnit)
        {            
            Session[Session_ParkName]=parkDAL.GetPark(parkCode).ParkName;
            Session[Session_ParkCode] = parkCode;
            Session[Session_TemperatureUnit] = TemperatureUnit;

            return RedirectToAction("Forecast");
        }        
    }
}