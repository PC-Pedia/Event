using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Infrastructure.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(T item);
        T GetById(int id);
        T Add(T item);
        T Edit(T item);
        bool Delete(T item);
        bool DeleteById(int id);    
    }
}
