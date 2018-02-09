using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Createdate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime Createdate { get; set; }
    }
}
