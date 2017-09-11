﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luna.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // GET: Member/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}