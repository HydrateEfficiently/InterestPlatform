using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class Subscription
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [InverseProperty("Subscriptions")]
        public ApplicationUser User { get; set; }

        public int InterestId { get; set; }

        [InverseProperty("Subscriptions")]
        public Interest Interest { get; set; }
    }
}
