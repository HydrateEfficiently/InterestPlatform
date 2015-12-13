using InterestPlatform.Data.Interests;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Foreign Keys To

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
