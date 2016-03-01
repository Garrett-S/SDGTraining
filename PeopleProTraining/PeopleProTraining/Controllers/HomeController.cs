using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeopleProTraining.Models;

namespace PeopleProTraining.Controllers
{
    public class HomeController : Controller
    {
        PeopleProDBContainer db = new PeopleProDBContainer();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}