using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AugricultureNonPointSourcePollution.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public AugricultureNonPointSourcePollutionEntities2 GetDbContext()
        {
            return new AugricultureNonPointSourcePollutionEntities2();
        }
    }
}
