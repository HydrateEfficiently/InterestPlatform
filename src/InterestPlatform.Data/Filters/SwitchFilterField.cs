using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class SwitchFilterField : FilterField<SwitchFilter>
    {
        public bool Enabled { get; set; }


        // Foreign Key To

        [InverseProperty("SwitchFilterFields")]
        public override Post Post { get; set; }

        public override SwitchFilter Filter { get; set; }
    }
}
