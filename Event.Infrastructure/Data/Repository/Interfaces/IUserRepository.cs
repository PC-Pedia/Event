using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Service.Data.Repository.Interfaces
{
    public interface IUserRepository:IRepository<AppUser>
    {
        IQueryable<Ewent> GetEvents(string name);

        AppUser GetByname(string name);

        
    }
}
