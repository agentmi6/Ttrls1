using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class UserVideoCommentViewModel
    {        
        public Tutorial _tutorial { get; set; }
        public List<Tutorial> _Tutorials { get; set; }
        public Comment _comment { get; set; }
        public IEnumerable<Comment> _comments { get; set; }
    }
}