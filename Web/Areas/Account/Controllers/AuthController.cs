﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        // GET: Account/Auth
        public ActionResult Index()
        {
            return View();
        }
    }
}