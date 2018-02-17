using Event.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Service.Data.Repository.Interfaces
{
    public interface IRepository<T>  
    {
        //This property load all related data because lazyloading currentlly in not supported by EFCore
        IQueryable<T> DataSource { get;}

        IQueryable<T> GetAll();
        T Get(T item);
        Task<T> GetById(int id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(T item);
        Task DeleteById(int id);    
    }
}
