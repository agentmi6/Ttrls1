using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class Favorites
    {
        [Key]
        public int FavID { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int TutorialID { get; set; }
        public virtual Tutorial Tutorial { get; set; }
    }
}