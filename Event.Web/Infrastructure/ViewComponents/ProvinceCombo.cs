using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ViewComponents;


namespace Event.Web.Infrastructure.ViewComponents
{
    public class ProvinceCombo : ViewComponent
    {
        public ProvinceCombo(AppDBContext db)
        {
            this.db = db;
        }

        public AppDBContext db { get; set; }

        public IViewComponentResult Invoke(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "Province";

            var provinces = db.Provinces.Select(x => new { x.Id, x.Title })
                                        .ToDictionary(z=>z.Id,x=>x.Title);
            ViewBag.Name=name;
            return View(provinces);
            
        }
    }
}
