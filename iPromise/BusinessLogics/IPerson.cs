using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{
     interface IPerson
    {
         string firstname { get; set; }
         string middleInitial { get; set; }        
         string lastname { get; set; }
        // string email { get; set; }

         DateTime dateofbirth { get; set; } 

    }
}