using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Event.Web.Infrastructure.Filters
{
    public class AjaxOnly : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers["RequestedWithHeader"] == "XmlHttpRequest")
                context.Result = new StatusCodeResult(404);
            
        }
    }
}
