using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace Event.Web.Infrastructure.Filters
{
    public class ActionExecutionTime :Attribute, IActionFilter
    {
        public Stopwatch timer { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = new Stopwatch();
            timer.Start();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            context.Result = new JsonResult(timer.ElapsedMilliseconds);
        }
    }
}
