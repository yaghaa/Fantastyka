using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fantastyka.Controllers
{
    public class SurveyController : Controller
    {
        public ActionResult Survey()
        {
            return View();
        }
    }
}