using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class Sub
    {
        public int ID { get; set; }
        public string SubName { get; set; }


        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string SubUserID { get; set; }
        public virtual ApplicationUser SubUser { get; set; }

    }
}