using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Infrastructure.Data;
using Event.Infrastructure.Data.Repository.Interfaces;
using System.Linq;

namespace Event.Infrastructure.Data.Repository.SQLRepositories
{
    public class PurchaseRepository :IPurchaseRepository
    {
        public PurchaseRepository(AppDBContext dbContext)
        {
            Db = dbContext;
        }

        public AppDBContext Db { get; set; }

        public Purchase Add(Purchase item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Purchase item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Purchase Edit(Purchase item)
        {
            throw new NotImplementedException();
        }

        public Purchase Get(Purchase item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
