using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Service.Data.Repository.Interfaces;
using Event.Service.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Event.Service.Data.Repository.SQLRepositories
{
    public class CommentRepository : ICommentRepository
    {

        public CommentRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public IQueryable<Comments> DataSource
        {
            get =>
                   Db.Comments
                   .Include(x => x.User)
                   .Include(x => x.Event);
                
        }

        public AppDBContext Db { get; set; }

        public Task Add(Comments item)
        {
            throw new NotImplementedException();
        }

        public  Task Delete(Comments item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            var result = await Db.Comments.FindAsync(id);
            Db.Comments.Remove(result);
            await Db.SaveChangesAsync();
            
        }

        public async Task Edit(Comments item)
        {
            throw new NotImplementedException();
        }

        public Comments Get(Comments item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comments> GetAll()
        {
            return DataSource;
        }

        public Task<Comments> GetById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
