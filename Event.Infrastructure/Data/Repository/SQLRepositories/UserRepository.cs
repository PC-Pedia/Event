using Event.Service.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Event.Service.Data.Repository.SQLRepositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(AppDBContext dbContext)
        {
            Db = dbContext;
        }

        public AppDBContext Db { get; set; }

        public IQueryable<AppUser> DataSource
        {
            get =>
                   Db.Users.Include(x => x.City)
                   .Include(x=>x.Events)
                   .Include(x => x.Purchases)
                   .Include(x => x.City)
                   .Include(x => x.Comments);
        }


        public Task Delete(AppUser item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var result = await Db.Users.FindAsync(id);
            Db.Users.Remove(result);
            await Db.SaveChangesAsync();

        }

        public async Task Edit(AppUser item)
        {
            throw new NotImplementedException();
        }

        public AppUser Get(AppUser item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AppUser GetByname(string name) => DataSource.FirstOrDefault(x => x.UserName == name);


        public IQueryable<Ewent> GetEvents(string name) => Db.Users.Include(x => x.Events)
                                                             .FirstOrDefault(x => x.UserName == name)
                                                             .Events
                                                             .AsQueryable()
                                                             .Include(x=>x.City);

        Task IRepository<AppUser>.Add(AppUser item)
        {
            throw new NotImplementedException();
        }
    }
}
