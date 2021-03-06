﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DALs
{
    public interface ISurveyDAL
    {

        List<SurveyModel>  GetAllSurveys();
        bool AddSurvey(SurveyModel survey);
    }
}
