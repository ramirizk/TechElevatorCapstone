using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DALs
{
    public class WeatherDAL : IWeatherDAL
    {
        private readonly string connectionString;

        public WeatherDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }        

        public List<WeatherModel> GetForecasts(string parkCode)
        {
            List<WeatherModel> forecastList = new List<WeatherModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE weather.parkcode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WeatherModel forecast = new WeatherModel();
                        forecast.ParkCode = Convert.ToString(reader["parkCode"]);
                        forecast.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        forecast.Forecast = Convert.ToString(reader["forecast"]);
                        forecast.High = Convert.ToInt32(reader["high"]);
                        forecast.Low = Convert.ToInt32(reader["Low"]);

                        forecastList.Add(forecast);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return forecastList;
        }
    }
}