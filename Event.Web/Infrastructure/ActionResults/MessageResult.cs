using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace Event.Web.Infrastructure.ActionResults
{
    public class MessageResult : IActionResult
    {
        public MessageResult(string body, MessageType messageType)
        {
            Body = body;
            Type = messageType.ToString();
        }
        
        public string Body { get; set; }
        public string Type { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var result = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(new { body = Body, type = Type }));

            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "application/json";
            return context.HttpContext.Response.Body.WriteAsync(result, 0, result.Length);
        }
    }


    public enum MessageType
    {
        success = 1,
        danger = 2,
        warning = 3,
        info = 4
    }
}
