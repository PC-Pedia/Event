using Event.Service.Data;
using Event.Service.Data.Repository.Interfaces;
using Event.Model.EntityModels;
using Event.Web.Areas.Models.ViewModels;
using Event.Web.Controllers;
using Event.Web.Infrastructure.ActionResults;
using Event.Web.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;

namespace Event.Web.Areas.User.Controllers
{

    public class HomeController : UserBaseController
    {

        public HomeController(IPurchaseRepository purchaseRepo,
            IHostingEnvironment env,
            IUserRepository userRepo,
            IEventRepository eventRepo,
            ICommentRepository commentRepo,
            AppDBContext db)
        {
            EventRepo = eventRepo;
            PurchaseRepp = purchaseRepo;
            Env = env;
            CommentRepo = commentRepo;
            this.db = db;
        }

        public IUserRepository UserRepo {get;set;}
        public IEventRepository EventRepo { get; set; }
        public IHostingEnvironment Env { get; set; }
        public IPurchaseRepository PurchaseRepp { get; set; }
        public ICommentRepository CommentRepo { get; set; }

        public AppDBContext db { get; set; }

        public IActionResult UserInfo() => PartialView(currentUser);

        private EventSearchModel Search(EventSearchModel model)
        {
            var query = EventRepo.GetAll().Where(x => x.UserId == currentUser.Id);

            if (!string.IsNullOrEmpty(model.SearchTitle))
                query = query.Where(x => x.Title.Contains(model.SearchTitle));

            if (model.SearchProvinceId.HasValue)
                query = query.Where(x => x.City.provinceId == model.SearchProvinceId);

            if (model.SearchCityId.HasValue)
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

        public async Task<IActionResult> Index()
        {
            var model = new MainViewModel();
            model.User = currentUser;
            model.EventSearchModel = Search(model.EventSearchModel);

            model.Purchases = await PurchaseRepp.GetAll().Where(x=>x.UserId==currentUser.Id).ToListAsync();
            model.Comments = await CommentRepo.GetAll().Where(x => x.UserId == currentUser.Id).ToListAsync();

            return View(model);
        }

        public IActionResult List(EventSearchModel model)
        {
            System.Threading.Thread.Sleep(5000);

            var result = Search(model);

            return PartialView(result);
        }

        public IActionResult Create() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Create(Ewent model,IFormFile file)
        {
            model.HasImage = false;

            if(file != null)
            {
                model.HasImage = true;

                if (file.Length > 3000000)
                    ModelState.AddModelError("", "حجم عکس بالاس");
                if (file.ContentType != "image/jpeg" || file.ContentType != "image/png")
                    ModelState.AddModelError("", "نوع فایل ارسال شده اشتباهه");
            }

            if(ModelState.IsValid)
            {

                try
                {
                    
                    var result = await SaveImage(file,model.Guid.ToString());
                    model.UserId = currentUser.Id;
                    await EventRepo.Add(model);
                    return message("با موفقیت ثبت شد", MessageType.success);

                }
                catch (Exception ex)
                {
                    return message("موقع ثبت اطلاعات خطایی رخ داد", MessageType.danger);
                }
            }
            else
            {
                return message(ModelState);
            }
           
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await EventRepo.DeleteById(id);
                return message(MessageType.success);
            }
            catch (Exception e)
            {
                return message(MessageType.danger);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await EventRepo.GetById(id);
            
            ViewBag.Cities =await db.Cities
                .Select(x=>new SelectListItem {Text=x.Title,Value=x.Id.ToString() })
                .ToListAsync();

            ViewBag.Categories =await db.Categories
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() })
                .ToListAsync();
            
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ewent model)
        {
            if(ModelState.IsValid)
            { 
                try
                {
                    await EventRepo.Edit(model);
                    return message(MessageType.success);
                }

                catch(Exception e)
                {
                    return message(MessageType.danger);
                }
            }

            return message(ModelState);

        }

        private async Task<bool> SaveImage(IFormFile file,string filename)
        {
            try
            {
                string FolderPath = $"{Env.ContentRootPath}/images/Events/{filename}";
                using (var stream = new FileStream(FolderPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return true;
            }

            catch
            {
                return false;
            }
            
        }
    }
}
