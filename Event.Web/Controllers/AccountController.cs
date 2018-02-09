using AutoMapper;
using Event.Infrastructure.Data;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event.Web.Models.ViewModels;
using Event.Web.Infrastructure.ActionResults;

namespace Event.Web.Controllers
{
    public class AccountController:BaseController
    {
        public AccountController(UserManager<AppUser> userMGR,SignInManager<AppUser> signinMGR)
        {
            userManager = userMGR;
            signinManager = signinMGR;
          
        }

        public AppDBContext db { get; set; }
        public UserManager<AppUser> userManager { get; set; }
        public SignInManager<AppUser> signinManager { get; set; }


        public IActionResult Login() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if(ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    await signinManager.SignOutAsync();

                    await signinManager.SignInAsync(user, true, null);


                    if (true)
                    {
                        IList<string> roles = await userManager.GetRolesAsync(user);

                        if (roles.Contains("Administrator"))
                            return RedirectToAction("Index", "Admin", new { area = "Admin" });
                        else
                            return new MessageResult($"خوش اومدی {user.UserName}", MessageType.success);
                    }
                }

            }

            return new MessageResult("نام کاربری یا رمز عبور اشتباه ", MessageType.danger);



        }



        public IActionResult Signup() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Signup(SignupModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName, PhoneNumber = model.PhoneNumber, CityId = model.cityId };
                await userManager.AddPasswordAsync(user, model.Password);
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await signinManager.SignInAsync(user,true,null);
                    return new MessageResult("با موفقیت انجام شد", MessageType.success);
                }
                   

                return new MessageResult("خطا", MessageType.danger);
            }

            return View();
            
        }


        public async Task<IActionResult> Signout()
        {
            await signinManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
