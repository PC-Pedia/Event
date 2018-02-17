using Event.Service.Data;
using Event.Service.Data.Repository.Interfaces;
using Event.Model.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Service.Data.Repository.SQLRepositories
{
    public class EventCategoryRepository : IEventCategoryRepository
    {

        public EventCategoryRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public IQueryable<EventCategory> DataSource
        {
            get => Db.Categories.Include(x => x.Events);
        }

        public AppDBContext Db { get; set; }

        public async Task Add(EventCategory item)
        {
            await Db.Categories.AddAsync(item);
        }

        public Task Delete(EventCategory item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var result = await Db.Categories.FindAsync(id);
            Db.Categories.Remove(result);
            await Db.SaveChangesAsync();

        }

        public Task Edit(EventCategory item)
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

        public Task<EventCategory> GetById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
