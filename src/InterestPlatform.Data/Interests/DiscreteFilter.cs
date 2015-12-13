using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class DiscreteFilter : Filter
    {
        public virtual ICollection<DiscreteFilterOption> Options { get; set; }

        [InverseProperty("DiscreteFilters")]
        public override Interest Interest { get; set; }
    }
}
