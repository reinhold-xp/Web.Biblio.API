using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Biblio.ASP_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Swagger()
        {
            ViewBag.Message = "Swagger UI ";
            return View();
        }
    }
}
