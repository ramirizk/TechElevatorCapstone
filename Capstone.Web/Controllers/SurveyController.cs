using Capstone.Web.DALs;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private IParksDAL parksDAL;
        private const string Session_SurveyTaken = "session_surveytaken";
        private List<SelectListItem> allParks = new List<SelectListItem>();

        public SurveyController(ISurveyDAL surveyDAL, IParksDAL parksDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parksDAL = parksDAL;
        }

        public ActionResult DailySurvey()
        {
            if (Session[Session_SurveyTaken] == null)
            {
                Session[Session_SurveyTaken] = false;
            }
            if ((bool)Session[Session_SurveyTaken])
            {
                List<SurveyModel> allSurveys = surveyDAL.GetAllSurveys();
                ViewBag.SurveyTaken = "Thank You for Taking the Survey Here are Todays Results";
                return RedirectToAction("DisplaySurveys", allSurveys);
            }
            ViewBag.SurveyTaken = "";
            List<ParkModel> parks = parksDAL.GetParks();
            foreach (ParkModel park in parks)
            {
                allParks.Add(new SelectListItem()
                {
                    Text = park.ParkName,
                    Value = park.ParkCode
                });
            }

            ViewBag.ParkNames = allParks;
            ViewBag.States = GetStates();
            ViewBag.Activity = ActivityLevel();

            return View("DailySurvey", new SurveyModel());
        }

        [HttpPost]
        public ActionResult DailySurvey(SurveyModel survey)
        {
            if (ModelState.IsValid)
            {

             
                surveyDAL.AddSurvey(survey);
                Session[Session_SurveyTaken] = true;
                return RedirectToAction("DisplaySurveys",survey);
            }
            else
            {
                List<SelectListItem> allParks = new List<SelectListItem>();
                List<ParkModel> parks = parksDAL.GetParks();
                foreach (ParkModel park in parks)
                {
                    allParks.Add(new SelectListItem()
                    {
                        Text = park.ParkName,
                        Value = park.ParkCode
                    });
                }
                ViewBag.ParkNames = allParks;
                ViewBag.States = GetStates();
                ViewBag.Activity = ActivityLevel();

                return View("DailySurvey",survey);
            }
        }

        public ActionResult DisplaySurveys(SurveyModel survey)
        {
            List<SurveyModel> allSurveys = surveyDAL.GetAllSurveys();
            
            return View("DisplaySurveys", allSurveys);
        }

        private List<SelectListItem> ActivityLevel()
        {
            List<SelectListItem> activity = new List<SelectListItem>();
            for(int i =1; i <= 10; i++)
            {
                activity.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            return activity;
        }

        private List<SelectListItem> GetStates()
        {
            List<SelectListItem> states = new List<SelectListItem>();

            states.Add(new SelectListItem() { Value = "AL", Text = "Alabama" });
            states.Add(new SelectListItem() { Value = "AK", Text = "Alaska" });
            states.Add(new SelectListItem() { Value = "AZ", Text = "Arizona" });
            states.Add(new SelectListItem() { Value = "AR", Text = "Arkansas" });
            states.Add(new SelectListItem() { Value = "CA", Text = "California" });
            states.Add(new SelectListItem() { Value = "CO", Text = "Colorado" });
            states.Add(new SelectListItem() { Value = "CT", Text = "Connecticut" });
            states.Add(new SelectListItem() { Value = "DC", Text = "District of Columbia" });
            states.Add(new SelectListItem() { Value = "DE", Text = "Delaware" });
            states.Add(new SelectListItem() { Value = "FL", Text = "Florida" });
            states.Add(new SelectListItem() { Value = "GA", Text = "Georgia" });
            states.Add(new SelectListItem() { Value = "HI", Text = "Hawaii" });
            states.Add(new SelectListItem() { Value = "ID", Text = "Idaho" });
            states.Add(new SelectListItem() { Value = "IL", Text = "Illinois" });
            states.Add(new SelectListItem() { Value = "IN", Text = "Indiana" });
            states.Add(new SelectListItem() { Value = "IA", Text = "Iowa" });
            states.Add(new SelectListItem() { Value = "KS", Text = "Kansas" });
            states.Add(new SelectListItem() { Value = "KY", Text = "Kentucky" });
            states.Add(new SelectListItem() { Value = "LA", Text = "Louisiana" });
            states.Add(new SelectListItem() { Value = "ME", Text = "Maine" });
            states.Add(new SelectListItem() { Value = "MD", Text = "Maryland" });
            states.Add(new SelectListItem() { Value = "MA", Text = "Massachusetts" });
            states.Add(new SelectListItem() { Value = "MI", Text = "Michigan" });
            states.Add(new SelectListItem() { Value = "MN", Text = "Minnesota" });
            states.Add(new SelectListItem() { Value = "MS", Text = "Mississippi" });
            states.Add(new SelectListItem() { Value = "MO", Text = "Missouri" });
            states.Add(new SelectListItem() { Value = "MT", Text = "Montana" });
            states.Add(new SelectListItem() { Value = "NE", Text = "Nebraska" });
            states.Add(new SelectListItem() { Value = "NV", Text = "Nevada" });
            states.Add(new SelectListItem() { Value = "NH", Text = "New Hampshire" });
            states.Add(new SelectListItem() { Value = "NJ", Text = "New Jersey" });
            states.Add(new SelectListItem() { Value = "NM", Text = "New Mexico" });
            states.Add(new SelectListItem() { Value = "NY", Text = "New York" });
            states.Add(new SelectListItem() { Value = "NC", Text = "North Carolina" });
            states.Add(new SelectListItem() { Value = "ND", Text = "North Dakota" });
            states.Add(new SelectListItem() { Value = "OH", Text = "Ohio" });
            states.Add(new SelectListItem() { Value = "OK", Text = "Oklahoma" });
            states.Add(new SelectListItem() { Value = "OR", Text = "Oregon" });
            states.Add(new SelectListItem() { Value = "PA", Text = "Pennsylvania" });
            states.Add(new SelectListItem() { Value = "RI", Text = "Rhode Island" });
            states.Add(new SelectListItem() { Value = "SC", Text = "South Carolina" });
            states.Add(new SelectListItem() { Value = "SD", Text = "South Dakota" });
            states.Add(new SelectListItem() { Value = "TN", Text = "Tennessee" });
            states.Add(new SelectListItem() { Value = "TX", Text = "Texas" });
            states.Add(new SelectListItem() { Value = "UT", Text = "Utah" });
            states.Add(new SelectListItem() { Value = "VT", Text = "Vermont" });
            states.Add(new SelectListItem() { Value = "VA", Text = "Virginia" });
            states.Add(new SelectListItem() { Value = "WA", Text = "Washington" });
            states.Add(new SelectListItem() { Value = "WV", Text = "West Virginia" });
            states.Add(new SelectListItem() { Value = "WI", Text = "Wisconsin" });
            states.Add(new SelectListItem() { Value = "WY", Text = "Wyoming" });
            return states;
        }
    }
}