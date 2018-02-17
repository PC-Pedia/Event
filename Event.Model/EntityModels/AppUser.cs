using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Model.EntityModels
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime LastLogin { get; set; }

        public DateTime SignupDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public int? CityId { get; set;}

        public ICollection<Ewent> Events { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public virtual City City { get; set; }
    }
}
