using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public class Province:BaseEntity
    {
        public string Title { get; set; }

        public virtual ICollection<City> cities { get; set; }
    }
}
