using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Service.Data;
using Event.Service.Data.Repository.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Event.Service.Data.Repository.SQLRepositories
{
    public class EventRepository : IEventRepository
    {
        public EventRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public AppDBContext Db { get; set; }

        //data With all related stuffs 
        public IQueryable<Ewent> DataSource
        {  get => 
                Db.Events.Include(x=>x.City)
                .Include(x=>x.User)
                .Include(x=>x.Category)
                .Include(x=>x.Purchases) ;
        }

        public async Task Add(Ewent item)
        {
            await Db.Events.AddAsync(item);
            await Db.SaveChangesAsync();
        }

        public Task Delete(Model.EntityModels.Ewent item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var result = await Db.Events.FindAsync(id);
            Db.Events.Remove(result);
            await Db.SaveChangesAsync();

        }

        public async Task Edit(Ewent item)
        {
            Db.Update(item);
            await Db.SaveChangesAsync();

        }

        public Ewent Get(Ewent item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ewent> GetAll()
        {
            return DataSource.Where(x=>x.Status == Model.EventStatus.Normal)
                            .OrderByDescending(x=>x.Createdate)
                            .ThenByDescending(x=>x.Id)
                            .AsQueryable();
        }

        public async Task<Ewent> GetById(int id)
        {
            var result = await DataSource.FirstOrDefaultAsync(x=>x.Id==id);
            return result;
        }

        
    }
}
