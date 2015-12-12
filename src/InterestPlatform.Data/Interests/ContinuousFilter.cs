using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class ContinuousFilter : Filter
    {
        public int MinimumValue { get; set; }

        public int MaximumValue { get; set; }
    }
}
