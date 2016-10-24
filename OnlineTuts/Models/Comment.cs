using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentBody { get; set; }        
        public DateTime CommentDateCreated { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int TutorialID { get; set; }
        public virtual Tutorial Tutorial { get; set; }



    }
}