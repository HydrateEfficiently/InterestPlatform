using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class SwitchFilter : Filter
    {
        [InverseProperty("SwitchFilters")]
        public override Interest Interest { get; set; }
    }
}
