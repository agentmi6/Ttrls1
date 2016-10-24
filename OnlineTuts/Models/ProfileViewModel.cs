using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class ProfileViewModel
    {
        public IEnumerable<Tutorial> _tutorials { get; set; }
        public ApplicationUser _user { get; set; }

        public IEnumerable<ApplicationUser> _users { get; set; }

        public IEnumerable<Comment> _comments { get; set; }
        public IEnumerable<Sub> _subs { get; set; }
        public IEnumerable <Favorites> _favorites { get; set; }
    }
}