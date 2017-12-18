using Data.Entity;
using Data.Repository;
using Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController<Stuff>
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}