using Event.Service.Data;
using Event.Service.Data.Repository.Interfaces;
using Event.Model.EntityModels;
using Event.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Service.Data.Repository.SQLRepositories;

namespace Event.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public abstract class UserBaseController:BaseController
    {

    }
}
