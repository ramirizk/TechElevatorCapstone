using Capstone.Web.DALs;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        private IParksDAL parksDAL;
        private const string Session_ParkCode = "session_parkcode";
        private const string Session_ParkName = "session_parkname";

        public ParksController(IParksDAL parksDAL)
        {
            this.parksDAL = parksDAL;
        }

        public ActionResult ParksList()
        {
            return View("ParksList", parksDAL.GetParks());
        }

        public ActionResult Detail(string parkCode, string parkName)
        {
            Session[Session_ParkCode] = parkCode;
            Session[Session_ParkName] = parkName;
            ParkModel park = parksDAL.GetPark(parkCode);
            if (park != null)
            {
                return View("Detail", park);
            }else
            {
                return new HttpNotFoundResult();
            }
            
        }        
    }
}