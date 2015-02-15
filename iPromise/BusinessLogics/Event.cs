using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{
    public class Event: ILike
    {
        public Event() { }

        public Event(string name, string description, string location, DateTime date)
        {
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Date = date;
         
        }

        public int event_id { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }       
        public string Location { get; set; }         
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }

        public DateTime? DateCreated { get; set; }

       
       

        #region implementation of ILike
        public int _Like { get; set; }
        public int _Dislike { get; set; }

        public void Like()
        {
            _Like += 1;
        }

        public void Dislike()
        {
            _Dislike -= 1;
        }
        #endregion
    }
}