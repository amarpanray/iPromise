using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{
    public class Contact:IPerson
    {    
       // private string _middleinitial;
        public Contact(string firstname, string middleInitial, string lastname, DateTime dateofbirth,string email)
        {
            this.firstname = firstname;
            this.middleInitial = middleInitial;
            this.lastname =lastname ;
            this.dateofbirth = dateofbirth;

            this.email = email;
        }

        #region Implementation of IPerson
        public string firstname { get; set; }
        public string middleInitial { get; set; }      
        public string lastname { get; set; }
        public DateTime dateofbirth { get; set; }
        #endregion


        public string email { get; set; } 
        


    }
}