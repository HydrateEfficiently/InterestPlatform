using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class DiscreteFilterField : FilterField<DiscreteFilter>
    {
        public string Options { get; set; }


        // Foreign Key To

        [InverseProperty("DiscreteFilterFields")]
        public override Post Post { get; set; }

        public override DiscreteFilter Filter { get; set; }
    }
}
