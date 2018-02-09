using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Event.Web.Infrastructure.Filters
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary
                 (
                     new EmptyModelMetadataProvider(),
                     new ModelStateDictionary()
                 )
                { Model = context.HttpContext.Request.Path }
            };
        }
    }
}
