using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Filters
{
    public class FilterFieldRequest
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public FilterType FilterType { get; set; }

        public bool Enabled { get; set; }

        public int OptionId { get; set; }

        public int MinimumValue { get; set; }

        public int MaximumValue { get; set; }
    }
}
