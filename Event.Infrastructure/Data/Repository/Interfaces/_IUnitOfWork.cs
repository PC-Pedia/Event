using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Infrastructure.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
       IEventRepository EventRepository { get;  }
       IEventCategoryRepository EventCategoryRepository { get;  }
       IPurchaseRepository PurchaseRepository { get;  }
       ICommentRepository CommentRepository { get; }
       IUserRepository UserRepository { get; }
    }
}
