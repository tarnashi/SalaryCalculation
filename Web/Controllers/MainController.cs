using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Abstract;

namespace Web.Controllers
{
    public class MainController : Controller
    {
        private readonly IStaffService _staff;

        public MainController(IStaffService staffService)
        {
            _staff = staffService;
        }

        public ActionResult Profile()
        {
            var worker = _staff.GetWorkerByEmail(HttpContext.User.Identity.Name);
            ViewData["subordinates"] = _staff.GetActiveSubordinates(worker.Id);
            return View(worker);
        }
    }
}