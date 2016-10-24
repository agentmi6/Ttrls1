using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class Tutorial
    {
        public int TutorialID { get; set; }

        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DateCreated { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
       
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}