using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantastyka.Models;

namespace Fantastyka.Controllers
{
    public class SurveyController : Controller
    {
        public ActionResult Survey()
        {
            var newModel = new SurveyModel()
            {
                Hidden = true
            };
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Survey(SurveyModel model)
        {
            if (Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                ModelState.Clear();
                var text = model.Name + " " + model.Email + " " + model.Author + " " + model.Title + " " + model.Readed + " " + model.TimesReaded + " " + model.Rating + " " + model.Publisher;
                var newMOdel = new SurveyModel()
                {
                    Hidden = false,
                    Result = text
                };
                return View(newMOdel);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Clear(SurveyModel model)
        {
            return Survey();
        }
    }
}