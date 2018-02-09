using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Models.SearchModels
{
    public class EventSearchModel : Paging
    {
        public List<Ewent> Events { get; set; }
        public string SearchTitle { get; set; }
        public int? SearchCaregoryId { get; set; }
        public int? SearchCityId { get; set; }
        public int? SearchProvinceId { get; set; }
 
    }
}
