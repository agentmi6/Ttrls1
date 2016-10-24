using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class UserSubscriptionsViewModel
    {
        public List<ApplicationUser> _users { get; set; }
        public List<Sub> _subscriptions { get; set; }

        public List<Tutorial> _TutorialsBySubscriber { get; set; }
    }
}