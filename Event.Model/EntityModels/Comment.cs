using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public class Comments : BaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public virtual Ewent Event { get; set; }
        public virtual AppUser User { get; set; }
    }
}
