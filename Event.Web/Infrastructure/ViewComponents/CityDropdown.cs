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
    public class CityDropdown : ViewComponent
    {

        public CityDropdown(AppDBContext db)
        {
            this.db = db;
        }

        public AppDBContext db { get; set; }

        public HtmlContentViewComponentResult Invoke(int provinceId)
        {

            var cities = db.Cities.Where(x=>x.provinceId==provinceId)
                                     .Select(x => new { x.Id, x.Title })
                                     .ToDictionary(z => z.Id, x => x.Title);

            string result = "";
            foreach (var c in cities)
            {
                result += $"<option value={c.Key}>{c.Value}</option>";
            }
            return new HtmlContentViewComponentResult(new HtmlString(result));

        }

    }
}
