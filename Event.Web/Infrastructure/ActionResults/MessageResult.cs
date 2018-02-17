using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace Event.Web.Infrastructure.ActionResults
{
    public class MessageResult : IActionResult
    {
        
        public MessageResult(IEnumerable<string> body, MessageType type)
        {
            Body = body.ToArray();
            Type = type.ToString();
            IsSuccess = type == MessageType.success ? true : false;
        }

        public MessageResult(string body, MessageType type)
        {
            Body=new string[] { body };
            Type = type.ToString();
            IsSuccess = type == MessageType.success ? true : false;
        }

        public string[] Body { get; set; }
        public string Type { get; set; }
        public bool IsSuccess { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var result = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(new { body = Body, type = Type, isSuccess=IsSuccess }));

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
