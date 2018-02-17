using Event.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Controllers
{
    public class CommonController:BaseController
    {
        public CommonController(AppDBContext db) 
        {
            this.db = db;
        }

        public AppDBContext db { get; set;}

        
        public JsonResult GetCities(int provinceId)
        {
            var result = db.Cities.Where(x => x.provinceId == provinceId)
                                  .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Title });
            return Json(result);
        }
    }
}
