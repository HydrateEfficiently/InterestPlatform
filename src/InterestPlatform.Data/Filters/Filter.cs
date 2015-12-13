using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public abstract class Filter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Order { get; set; }


        // Foreign Keys To

        [Required]
        public int InterestId { get; set; }

        public abstract Interest Interest { get; set; }
    }
}
