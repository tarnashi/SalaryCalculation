﻿using Core.Abstract;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Attributes;

namespace Web.Controllers
{
    [Authorize]
    [CustomAuthorize("superuser")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staff;

        public StaffController(IStaffService staffService)
        {
            _staff = staffService;
        }

        public ActionResult Workers()
        {
            List<WorkerViewModel> workers = _staff.GetWorkers();
            return View(workers);
        }

        public ActionResult AddWorker()
        {
            ViewBag.Positions = _staff.GetPositions();
            var superiors = _staff.GetWorkersMayHaveSubordinates();
            superiors.Insert(0, new WorkerViewModel{Id = 0, FullName = "Нет"});
            ViewBag.Superiors = superiors;
            return View();
        }

        public ActionResult Positions()
        {
            List<PositionViewModel> positions = _staff.GetPositions();
            return View(positions);
        }
    }
}