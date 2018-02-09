//using Event.Model.EntityModels;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Event.Infrastructure.Data.Repository.Interfaces;

//namespace Event.Infrastructure.Data.Repository.SQLRepositories
//{
//    public class EFUnitOfWork:IUnitOfWork
//    {

//        public EFUnitOfWork(AppDBContext dbContext,IServiceProvider serviceProvider)
//        {
//            DatabaseContext = dbContext;
//            ServiceContainer = serviceProvider;
//        }
              
//        public IServiceProvider ServiceContainer { get; set; }
//        public AppDBContext DatabaseContext { get; set; }

//        public IEventRepository EventRepository { get { return ; } }
//        public IEventCategoryRepository EventCategoryRepository { get { return new EventCategoryRepository(DatabaseContext); } }
//        public IPurchaseRepository PurchaseRepository { get { return new PurchaseRepository(DatabaseContext); } }
//        public ICommentRepository CommentRepository { get { return new CommentRepository(DatabaseContext); } }
//        public IUserRepository UserRepository { get { return new UserRepository(DatabaseContext); } }

//        public bool Save()
//        {
//            DatabaseContext.SaveChanges();
//            return true;
//        }
//    }
//}
