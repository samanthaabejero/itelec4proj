﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Software
        public ActionResult Index()
        {
            return View();
        }

        // GET: Software/Course
        public ActionResult Course()
        {
            return View();
        }

        // GET: Software/Student
        public ActionResult Student()
        {
            return View();
        }
    }
}