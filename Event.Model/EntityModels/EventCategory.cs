using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public class EventCategory:BaseEntity
    {
        public String Title { get; set; }

        public virtual ICollection<Ewent> Events { get; set; }
    }
}
