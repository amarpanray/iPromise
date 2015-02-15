using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iPromise.Models;

namespace iPromise.Controllers
{
    public class HomeController : Controller
    {       
       
        /// <summary>
        /// On va laisser tout ce qui au bas de ce commentaire comme c'est!
        /// </summary>
        /// <returns></returns>
        //public ActionResult Index()
        //{
        //   // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
        //    var model = new EventModel();
        //    model.GetAllEvents();
        //    return View(model);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
