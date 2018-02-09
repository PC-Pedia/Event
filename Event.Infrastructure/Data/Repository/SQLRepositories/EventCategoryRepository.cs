using Event.Infrastructure.Data;
using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Event.Infrastructure.Data.Repository.SQLRepositories
{
    public class EventCategoryRepository : IEventCategoryRepository
    {

        public EventCategoryRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public AppDBContext Db { get; set; }


        public EventCategory Add(EventCategory item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EventCategory item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public EventCategory Edit(EventCategory item)
        {
            throw new NotImplementedException();
        }

        public EventCategory Get(EventCategory item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EventCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public EventCategory GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
