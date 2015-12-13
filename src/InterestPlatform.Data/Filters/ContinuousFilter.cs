using InterestPlatform.Data.Interests;
using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class ContinuousFilter : Filter
    {
        public int MinimumValue { get; set; }

        public int MaximumValue { get; set; }


        // Foreign Keys To

        [InverseProperty("ContinuousFilters")]
        public override Interest Interest { get; set; }
    }
}
