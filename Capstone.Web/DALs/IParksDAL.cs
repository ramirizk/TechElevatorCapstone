using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DALs
{
    public interface IParksDAL
    {
        List<ParkModel> GetParks();
        ParkModel GetPark(string parkCode);
    }
}
