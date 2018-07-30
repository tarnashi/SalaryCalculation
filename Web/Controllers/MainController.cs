using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Abstract;

namespace Web.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly IStaffService _staff;
        private readonly IAccessService _access;

        public MainController(IStaffService staffService, IAccessService accessService)
        {
            _staff = staffService;
            _access = accessService;
        }

        [HttpGet]
        public ActionResult ProfilePage()
        {
            var worker = _staff.GetWorkerByEmail(HttpContext.User.Identity.Name);
            ViewData["subordinates"] = _staff.GetActiveSubordinates(worker.Id);
            return View(worker);
        }

        [HttpGet]
        public ActionResult ShowProfile(int id)
        {
            if (!_access.MayViewProfile(HttpContext.User.Identity.Name, id))
                return RedirectToAction("Login", "Account");

            var worker = _staff.GetWorkerById(id);
            ViewData["subordinates"] = _staff.GetActiveSubordinates(worker.Id);
            return View("ProfilePage", worker);
        }
    }
}