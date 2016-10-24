using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class UserTutsViewModel
    {
        public IEnumerable<Tutorial> _tutorials{ get; set; }
        public IEnumerable<ApplicationUser> _users { get; set; }
    }
}