using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DALs
{
    public class SurveyDAL : ISurveyDAL
    {
        private string connectionString;

        public SurveyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddSurvey(SurveyModel survey)
        {
            bool output= false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES(@parkCode, @email, @state, @activity)", conn);
                    cmd.Parameters.AddWithValue("parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("email", survey.Email);
                    cmd.Parameters.AddWithValue("state", survey.State);
                    cmd.Parameters.AddWithValue("activity", survey.ActivityLevel);
                 
                    cmd.ExecuteNonQuery();
                    output = true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return output;
        }

        public List<SurveyModel> GetAllSurveys()
        {
            List<SurveyModel> surveys = new List<SurveyModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(survey_result.surveyId) as voteCount, park.parkName, park.parkCode 
                                                       FROM survey_result INNER JOIN park
                                                       ON park.parkCode=survey_result.parkCode
                                                       GROUP BY park.parkName, park.parkCode
                                                       ORDER BY voteCount DESC", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SurveyModel survey = new SurveyModel();
                        survey.ParkCode = Convert.ToString(reader["parkCode"]);
                        survey.VoteCount = Convert.ToInt32(reader["voteCount"]);
                        survey.ParkName = Convert.ToString(reader["parkName"]);
                        surveys.Add(survey);
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return surveys;
        }
    }
}