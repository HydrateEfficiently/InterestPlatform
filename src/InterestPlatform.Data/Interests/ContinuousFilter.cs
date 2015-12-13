using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class ContinuousFilter : Filter
    {
        public int MinimumValue { get; set; }

        public int MaximumValue { get; set; }

        [InverseProperty("ContinuousFilters")]
        public override Interest Interest { get; set; }
    }
}
