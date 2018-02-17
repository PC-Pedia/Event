using Event.Model.EntityModels;
using Event.Web.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Areas.Models.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            User = new AppUser();
            EventSearchModel = new EventSearchModel();
            Purchases = new List<Purchase>();
            Comments = new List<Comments>();
        } 
        public AppUser User { get; set; }
        public EventSearchModel EventSearchModel { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
