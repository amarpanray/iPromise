using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using iPromise.BusinessLogics;


namespace iPromise.Models
{
    public class CreateContactModel
    {
        public string firstname { get; set; }
        public string middleInitial { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime dateofbirth { get; set; }

        public void Create()
        {
            Contact _conctact = new Contact(firstname, middleInitial, lastname, dateofbirth, email);
            new DataServices.Dataservice().CreateContact(_conctact);
        }
    }
}