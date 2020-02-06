using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWithLogging.Logging;

//using Anotar.Serilog;

namespace WebAppWithLogging.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //LogTo.Information("Index action called...");
            Logger.Info("Index action called...");
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //LogTo.Information("About action called...");
            Logger.Info("About action called...");
            return View();
        }

        public ActionResult Contact()
        {
            //LogTo.Information("Contact action called...");
            Logger.Fatal("You are making a fatal mistake here...");
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}