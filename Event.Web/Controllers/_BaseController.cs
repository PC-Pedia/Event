using AutoMapper;
using Event.Model.EntityModels;
using Event.Service.Data.Repository.Interfaces;
using Event.Web.Infrastructure.ActionResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Web.Controllers
{
    public class BaseController:Controller
    {

        public BaseController()
        {

        }

        //property injvection
        protected IUserRepository UserRepo { get => HttpContext.RequestServices.GetService<IUserRepository>(); }

        protected AppUser currentUser {
            get
            {
                return UserRepo.GetByname(User.Identity.Name);
            }
        }


        public IActionResult message(MessageType type)
        {
            string message = "";
            switch (type)
            {
                case MessageType.success:
                    message = "عملیات با موفقیت انجام شد";
                    break;

                case MessageType.danger:
                    message = "خطایی موقع انجام عملیات رخ داد";
                    break;
                case MessageType.warning:
                    break;
                case MessageType.info:
                    break;
                default:
                    break;
            }

            var result = new MessageResult(message, type);
            return result;
        }

        public IActionResult message(IEnumerable<string> messages,MessageType type)
       {
            var result = new MessageResult(messages, type);
            return result;
       }

        public IActionResult message(string messages, MessageType type)
        {
            var result = new MessageResult(messages, type);
            return result;
        }

        public IActionResult message(ModelStateDictionary modelstate)
        {
            var messages = new List<string>();
            foreach (var values in modelstate.Values)
            {
                foreach (var error in values.Errors)
                {
                    messages.Add(error.ErrorMessage);
                }
                
            }
            var result = new MessageResult(messages, MessageType.danger);
            return result;
        }

    }
}
