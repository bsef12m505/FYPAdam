﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPAdam.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        public void CheckLogin()
        {
            
        }

        public ActionResult UserDashboard()
        {
            return View();
        }

    }
}
