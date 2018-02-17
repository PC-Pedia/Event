using Event.Service.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace Event.Web.Infrastructure.ViewComponents
{
    public class ProvinceDropdown:ViewComponent
    {

        public ProvinceDropdown(AppDBContext db)
        {
            this.db = db;
        }

        public AppDBContext db { get; set; }

        public HtmlContentViewComponentResult Invoke()
        {
            
            var provinces = db.Provinces.Select(x => new { x.Id, x.Title })
                                        .ToDictionary(z => z.Id, x => x.Title);

            string result = "";
            foreach (var p in provinces)
            {
                result += $"<option value={p.Key}>{p.Value}</option>";
            }
            return new HtmlContentViewComponentResult(new HtmlString(result));

        }

    }
}
