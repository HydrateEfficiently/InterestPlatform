using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class SwitchFilter : Filter
    {
        [InverseProperty("SwitchFilters")]
        public override Interest Interest { get; set; }
    }
}
