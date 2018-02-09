using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Event.Infrastructure.Data
{
    public class Seed
    {
        public Seed(AppDBContext db, IEventRepository eventrepo, SignInManager<IdentityRole<int>> signinManager, UserManager<AppUser> userManager)
        {
            if (!db.Users.Any())
            {
                var user = new AppUser { UserName = "Admin", Email = "Admin@Event.ir", EmailConfirmed = true, PhoneNumber = "09216270450" };
                userManager.AddPasswordAsync(user, "admin");
                var result = userManager.CreateAsync(user);
                db.SaveChanges();

            }


            db.Categories.Add(new EventCategory { Title = "ورزشی" });
            db.Categories.Add(new EventCategory { Title = "عملی" });
            db.Categories.Add(new EventCategory { Title = "اجتماعی" });
            db.Categories.Add(new EventCategory { Title = "مهمانی" });
            db.Categories.Add(new EventCategory { Title = "گردشگری" });
            db.Categories.Add(new EventCategory { Title = "پزشکی" });
            db.SaveChanges();
        }
    }
}
