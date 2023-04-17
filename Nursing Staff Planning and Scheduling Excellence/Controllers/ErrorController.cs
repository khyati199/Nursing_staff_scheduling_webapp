using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult HttpError404(string error)
        {
            ViewBag.Description = error;
            return View("Error");
        }

        public ActionResult HttpError500(string error)
        {
            ViewBag.Description = error;
            return View("Error");
        }


        public ActionResult General(string error)
        {
            ViewBag.Description = error;
            return View("Error");

        }
    }
}