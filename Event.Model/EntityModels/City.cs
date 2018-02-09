using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public  class City:BaseEntity
    {
        public string Title { get; set; }
        public int provinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Ewent> Events { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
