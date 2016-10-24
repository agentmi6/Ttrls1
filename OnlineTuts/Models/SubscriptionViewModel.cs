using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class SubscriptionViewModel
    {
        public ApplicationUser _user { get; set; }

        public List<ApplicationUser> _Users { get; set; }
    }
}