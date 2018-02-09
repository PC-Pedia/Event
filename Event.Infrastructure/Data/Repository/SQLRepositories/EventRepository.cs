using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Infrastructure.Data;
using Event.Infrastructure.Data.Repository.Interfaces;
using System.Threading.Tasks;
using System.Linq;


namespace Event.Infrastructure.Data.Repository.SQLRepositories
{
    public class EventRepository : IEventRepository
    {
        public EventRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public AppDBContext Db { get; set; }

        
        public Ewent Add(Model.EntityModels.Ewent item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Model.EntityModels.Ewent item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Ewent Edit(Model.EntityModels.Ewent item)
        {
            throw new NotImplementedException();
        }

        public Ewent Get(Model.EntityModels.Ewent item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Model.EntityModels.Ewent> GetAll()
        {
            return Db.Events.OrderByDescending(x=>x.Createdate).AsQueryable();
        }

        public Ewent GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
