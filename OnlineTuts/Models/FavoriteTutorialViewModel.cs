using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class FavoriteTutorialViewModel
    {    
        public int FavoriteID { get; set; }

        public Tutorial Tutorial { get; set; }
        public List<Tutorial> FavoriteTutorials { get; set; }
    }
}