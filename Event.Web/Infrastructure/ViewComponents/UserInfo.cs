using Event.Service.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Event.Web.Infrastructure.ViewComponents
{
    public class UserInfo:ViewComponent
    {
        public UserInfo(IUserRepository userRepo)
        {
            UserRepo = userRepo;
        }

        public IUserRepository UserRepo { get; set; }

        public IViewComponentResult Invoke()
        {
            var Model = UserRepo.GetByname(User.Identity.Name);
            return View(Model);
        }
    }
}
