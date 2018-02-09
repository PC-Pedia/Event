using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Model.EntityModels.Ewent> Events { get; set; }

    }
}
