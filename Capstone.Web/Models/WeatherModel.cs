using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string TempatureUnit { get; set; } = "Farenheit";

        public int Convert(int tempF)
        {
            if (TempatureUnit == "Celsius")
            {
                tempF = (int)Math.Round((tempF - 32) * (5.0 / 9.0));

            }
            return tempF;
        }

        private Dictionary<string, string> forecastDescription = new Dictionary<string, string>()
        {
            { "snow", "Snow" },
            { "partlycloudy", "Partly Cloudy"},
            { "cloudy", "Cloudy"},
            { "rain", "Rain"},
            { "sunny", "Sunny"},
            { "thunderstorms", "Thunderstorms"},
        };

        public string GetForecastDescription(string forecast)
        {
            string result = null;

            if (forecastDescription.ContainsKey(forecast))
            {
                result = forecastDescription[forecast];
            }

            return result;
        }

        public List<string> GetForecastModifier()
        {
            List<string> output = new List<string>();
            if(High > 75)
            {
                output.Add("Better bring a Gallon of Water!!");

            }
            if(High-Low > 20)
            {
                output.Add("Might want to wear some breathable layers...");
            }
            if (Low < 20)
            {
                output.Add("BE WARNED: EXPOSURE TO FRIGID TEMPERATURES IS DANGEROUS.");
            }
            return output;
        }
    }
}