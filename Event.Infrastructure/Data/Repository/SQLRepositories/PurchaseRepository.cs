using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Service.Data;
using Event.Service.Data.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Event.Service.Data.Repository.SQLRepositories
{
    public class PurchaseRepository :IPurchaseRepository
    {
        public PurchaseRepository(AppDBContext dbContext)
        {
            Db = dbContext;
        }

        public IQueryable<Purchase> DataSource
        {
            get =>
                  Db.Purchases.Include(x => x.User)
                  .Include(x => x.Event);
        }

        public AppDBContext Db { get; set; }

        public async Task Add(Purchase item)
        {
            await Db.AddAsync(item);
            await Db.SaveChangesAsync();
        }

        public Task Delete(Purchase item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var result = await Db.Purchases.FindAsync(id);
            Db.Purchases.Remove(result);
            await Db.SaveChangesAsync();

        }

        public async Task Edit(Purchase item)
        {
            throw new NotImplementedException();
        }

        public Purchase Get(Purchase item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Purchase> GetAll()
        {
            return DataSource;
        }

        public Task<Purchase> GetById(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
