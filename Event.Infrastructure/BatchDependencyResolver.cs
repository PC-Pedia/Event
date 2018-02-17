using Event.Service.Data.Repository.Interfaces;
using Event.Service.Data.Repository.SQLRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Event.Service.HttpClient;

namespace Event.Service
{
    //این کلاسو برای resolve  کردن گروهی دیپندنسی ها نوشتم
    public static class BatchDependencyResolver
    {
        public static IServiceCollection AddRepository(this IServiceCollection container)
        {
            //resolving repository dependencies
            container.AddTransient<IEventRepository, EventRepository>();
            container.AddTransient<IEventCategoryRepository, EventCategoryRepository>();
            container.AddTransient<IPurchaseRepository, PurchaseRepository>();
            container.AddTransient<ICommentRepository, CommentRepository>();
            container.AddTransient<IUserRepository, UserRepository>();

            return container;
        }


        public static IServiceCollection AddAblWebClient(this IServiceCollection containger)
        {

            containger.AddTransient<IRestClient, RestClient>();
            containger.AddTransient<IRestRequest, RestRequest>();
            containger.AddTransient<IRestResponse, RestResponse>();
            containger.AddTransient<IAblRestClient, AblRestClient>();

            return containger;
        }

    }
}
