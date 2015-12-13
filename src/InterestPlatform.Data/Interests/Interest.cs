using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class Interest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // Foreign Keys To

        [Required]
        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }


        // Foreign Keys From

        public virtual ICollection<DiscreteFilter> DiscreteFilters { get; set; }

        public virtual ICollection<ContinuousFilter> ContinuousFilters { get; set; }

        public virtual ICollection<SwitchFilter> SwitchFilters { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

    }
}
