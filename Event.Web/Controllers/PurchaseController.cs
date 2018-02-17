using Event.Service.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Service.HttpClient;
using RestSharp;
using Microsoft.AspNetCore.Authorization;
using Event.Web.Infrastructure.ActionResults;
using Event.Model.EntityModels;

namespace Event.Web.Controllers
{
    public class PurchaseController : BaseController
    {
        public PurchaseController( IEventRepository eventRepo, IPurchaseRepository purchaseRepo) 
        {
            EventRepo = eventRepo;
            PurchaseRepo = purchaseRepo;
        }

        public IEventRepository EventRepo { get; set; }
        public IPurchaseRepository PurchaseRepo { get; set; }

        [Authorize]
        public async  Task<IActionResult> Pay(int id,byte count=1)
        {
            var eventt =await EventRepo.GetById(id);
            if(eventt.TickLeft >= count)
            {
                var purchase = new Purchase();
                purchase.UserId = currentUser.Id;
                purchase.Count = count;
                purchase.EventId = eventt.Id;

                try
                {
                    await PurchaseRepo.Add(purchase);
                    return message(MessageType.success);
                }

                catch
                {
                    return message(MessageType.danger);
                }
                
            }

            return message("ظرفیت کمتر از تعداد درخواست شماست", MessageType.danger);
            
        }

        public EmptyResult ConfirmPay()
        {
            return new EmptyResult();
        }
    }
}
