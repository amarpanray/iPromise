using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPromise.BusinessLogics
{
    public class Answer:ILike
    {
        public int answer_id { get; set; }
        public string answer_description { get; set; }

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