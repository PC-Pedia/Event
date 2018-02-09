using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Event.Model.EntityModels
{
    public class Ewent : BaseEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int? Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual EventCategory Category { get; set; }
        public virtual City City{get;set;}
    }
}
