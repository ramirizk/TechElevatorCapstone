using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Models;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class WeatherModelTests
    {
        [TestMethod]
        public void ConvertTemperature_GivenFarenheit_GetExpectedCelsius()
        {
            WeatherModel weather = new WeatherModel();
            weather.High = 78;
            weather.Low = 60;

            weather.ConvertTemperature();

            Assert.AreEqual(26, weather.High);
            Assert.AreEqual(false, weather.TemperatureIsFarenheit);
            Assert.AreEqual(16, weather.Low);
        }

        [TestMethod]
        public void ConvertTemperature_GivenCelsiu_GetExpectedFarenheit()
        {
            WeatherModel weather = new WeatherModel();
            weather.High = 26;
            weather.Low = 16;
            weather.TemperatureIsFarenheit = false;

            weather.ConvertTemperature();

            Assert.AreEqual(79, weather.High);
            Assert.AreEqual(true, weather.TemperatureIsFarenheit);
            Assert.AreEqual(61, weather.Low);
        }
    }
}
