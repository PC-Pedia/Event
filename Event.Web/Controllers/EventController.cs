using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Web.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Web.Controllers
{
    public class EventController:BaseController
    {

        public EventController(IEventRepository eventRepo)
        {
            EventRepo = eventRepo;
        }

        public IEventRepository EventRepo { get; set; }
        

        private EventSearchModel Search(EventSearchModel model)
        {
            var query = EventRepo.GetAll()
                                 .Include(x=>x.City)
                                 .ThenInclude(x=>x.Province)
                                 .AsQueryable();

            if (!string.IsNullOrEmpty(model.SearchTitle))
                query = query.Where(x => x.Title.Contains(model.SearchTitle));

            if (model.SearchProvinceId.HasValue)
                query = query.Where(x => x.City.provinceId == model.SearchProvinceId);

            if(model.SearchCityId.HasValue)
                query = query.Where(x => x.CityId == model.SearchCityId);


            model.TotalItems = query.Count();

            var result = query.OrderBy(x => x.Createdate)
                                .Skip((model.CurrentPage - 1) * model.PageSize)
                                .Take(model.PageSize)
                                //.ToModel()
                                .ToList();

            model.Events = result;

            return model;

        }

        public IActionResult Index(string key)
        {
            var model = new EventSearchModel { SearchTitle = key };
            model = Search(model);

            return View(model);
        }

        public IActionResult List(EventSearchModel model)
        {
            System.Threading.Thread.Sleep(5000);

            var result = Search(model);

            return PartialView(result);
        }
       
    }
}
