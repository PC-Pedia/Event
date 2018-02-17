using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Models.ViewModels
{
    public class EventViewModel
    {
        public string Title
        {
            get;set;
        }

        public DateTime Date { get; set; }

        public bool IsFree { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
    }
}
