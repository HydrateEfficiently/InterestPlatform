using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Posts
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        // Foreign Keys To

        [Required]
        public int InterestId { get; set; }

        [InverseProperty("Posts")]
        public Interest Interest { get; set; }


        // Foreign Keys From

        public virtual ICollection<DiscreteFilterField> DiscreteFilterFields { get; set; }

        public virtual ICollection<ContinuousFilterField> ContinuousFilterFields { get; set; }

        public virtual ICollection<SwitchFilterField> SwitchFilterFields { get; set; }
    }
}
