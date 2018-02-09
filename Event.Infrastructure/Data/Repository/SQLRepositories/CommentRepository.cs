using System;
using System.Collections.Generic;
using System.Text;
using Event.Model.EntityModels;
using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Infrastructure.Data;
using System.Linq;

namespace Event.Infrastructure.Data.Repository.SQLRepositories
{
    public class CommentRepository : ICommentRepository
    {

        public CommentRepository(AppDBContext dbcontext)
        {
            Db = dbcontext;
        }

        public AppDBContext Db { get; set; }

        public Comments Add(Comments item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Comments item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Comments Edit(Comments item)
        {
            throw new NotImplementedException();
        }

        public Comments Get(Comments item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comments> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comments GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
