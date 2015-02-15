using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{     
        public interface ILike
        {
            int _Like { get; set; }
            int _Dislike { get; set; }

            void Like();
            void Dislike();
        }    
}