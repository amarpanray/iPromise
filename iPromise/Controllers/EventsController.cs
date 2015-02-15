using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iPromise.Models;

namespace iPromise.Controllers
{
    public class EventsController : Controller
    {
        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            //  ViewBag.Message = "Create an Event.";
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventModels model)
        {
            if (ModelState.IsValid)
            {
                model.Create();
                //return RedirectToAction("ViewEvent", "Home", new { id = model.Create()});
                return RedirectToAction("All", "Events");
            }
           // return View(model);
            return RedirectToAction("All", "Events");
        }

        [HttpPost]
        public ActionResult PostQuestion(EventModels model, int id)
        {
            if (ModelState.IsValid)
            {
                model.GetEventByID(id);
                model.PostQuestionToEvent();
                return RedirectToAction("ViewEvent", "Home", new { id });
            }
            return View(model);
        }
        public ActionResult CreateContact()
        {
            //  ViewBag.Message = "Create an Event.";
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(CreateContactModel model)
        {
            if (ModelState.IsValid)
            {
                model.Create();
                return RedirectToAction("CreateContact", "Home");
            }
            return View(model);
        }

        public ActionResult ViewContact(string id)
        {
            return View();
        }

        public ActionResult ViewEvent(int id)
        {
            var model = new EventModel();
            model.GetEvent(id);
            return View(model);
        }





        public ActionResult All()
        {
            var model = new EventModels();
            model.GetEventsAll();
            return View(model);
        }






    }
}
