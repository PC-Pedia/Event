using AutoMapper;
using Event.Service.Data;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event.Web.Models.ViewModels;
using Event.Web.Infrastructure.ActionResults;
using Event.Service.Data.Repository.Interfaces;

namespace Event.Web.Controllers
{
    public class AccountController:BaseController
    {
        public AccountController(IUserRepository userRepo, UserManager<AppUser> userMGR,SignInManager<AppUser> signinMGR)
        {
            userManager = userMGR;
            signinManager = signinMGR;
            UserRepo = UserRepo;
        }

        public AppDBContext db { get; set; }
        public UserManager<AppUser> userManager { get; set; }
        public SignInManager<AppUser> signinManager { get; set; }
        public IUserRepository UserRepo { get; set; }



        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model,string Returnurl)
        {

            if(ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    await signinManager.SignOutAsync();

                    await signinManager.SignInAsync(user, true, null);
 
                    IList<string> roles = await userManager.GetRolesAsync(user);

                    if (!string.IsNullOrEmpty(Returnurl))
                        return Redirect(Returnurl);

                    if (roles.Contains("Administrator"))
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    else
                        return new MessageResult($"خوش اومدی {user.UserName}", MessageType.success);
                   
                }

            }

            return new MessageResult("نام کاربری یا رمز عبور اشتباه ", MessageType.danger);



        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser { SignupDate = DateTime.Now, UserName = model.UserName, PhoneNumber = model.PhoneNumber, CityId = model.cityId };
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
