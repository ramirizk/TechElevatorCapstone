using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DALs
{
    public class ParksDAL : IParksDAL
    {
        private readonly string connectionString;

        public ParksDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetParks()
        {
            List<ParkModel> list = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel park = new ParkModel();
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.ParkCode = Convert.ToString(reader["parkCode"]);

                        list.Add(park);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return list;
        }

        public ParkModel GetPark(string parkCode)
        {
            ParkModel park=null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from park where park.parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        park = new ParkModel();                    
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);

                throw;
            }
            return park;
        }
    }
}