using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event.Infrastructure.Data;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity;
using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Web.Models.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Event.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEventRepository eventrepo,IMapper mapper)
        {
            EventRepository = eventrepo;

        }


        public IEventRepository EventRepository { get; set; }
        

        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> Index()
        {
            var result = EventRepository.GetAll().Include(x=>x.City).Take(12).ToList();
            
            var model = new HomeViewModel { Events = result };
            
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

       


    }
}
