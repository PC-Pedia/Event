using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Event.Model.EntityModels
{
    public class Purchase:BaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public byte Count { get; set; }

        [NotMapped]
        public int Price { get { return Count * Event.Price.Value; } }

        public virtual Ewent Event { get; set; }
        public virtual AppUser User { get; set; }
    }
}
