using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using iPromise.BusinessLogics;
using iPromise.DataServices;

namespace iPromise.Models
{
    public class EventModel
    {
        private IList<Event> _event;
        public EventModel() 
        {
            _event = new DataServices.Dataservice().EventsAllGet();
        }

        public string event_name { get; set; }
        public string event_description { get; set; }
        public DateTime? event_date { get; set; }
        public string event_location { get; set; }

        public int event_id { get; set; }


        public string question { get; set; }

        public void GetEvent(int id)
        {
           var instance =  (from ev in _event where ev.event_id == id select ev).FirstOrDefault();

           this.event_name = instance.Name;
           this.event_description = instance.Description;
           this.event_date = instance.Date;
           this.event_location = instance.Location;
           this.event_id = instance.event_id;
        }

        public void PostQuestionToEvent()
        {
            Question _question = new Question();
            _question.question_description = this.question;
            new DataServices.Dataservice().PostQuestionToEvent(_question, event_id);
        }

        public IList<Event> _events;


        public void GetAllEvents()
        {
            _events = new DataServices.Dataservice().EventsAllGet();
        }

        //public void PostQuestion(int question_id)
        //{
        //    new DataServices.Dataservice().PostQuestionToEvent(event_id, question_id);
        //}

        [Required(ErrorMessage = "\"Name\" is a required field, and must be specified.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "\"Description\" is a required field, and must be specified.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "\"Location\" is a required field, and must be specified.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "\"Date\" is a required field, and must be specified.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "\"Time\" is a required field, and must be specified.")]
        public DateTime Time { get; set; }


        public int Create()
        {
            Event _event = new Event(Name, Description, Location, Date);
            return new DataServices.Dataservice().CreateEvent(_event);
        }

        //public IList<Event> _events;


        //public void GetAllEvents()
        //{
        //    _events = new DataServices.Dataservice().EventsAllGet();
        //}
        
    }
}