using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class ContinuousFilterField : FilterField<ContinuousFilter>
    {
        public int MinimumValue { get; set; }

        public int MaximumValue { get; set; }


        // Foreign Key To

        [InverseProperty("ContinuousFilterFields")]
        public override Post Post { get; set; }

        public override ContinuousFilter Filter { get; set; }
    }
}
