using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class CreateFilterRequest
    {
        public int InterestId { get; set; } = 0;

        public string Name { get; set; }

        public FilterType FilterType { get; set; }

        public int MaximumValue { get; set; } = 0;

        public int MinimumValue { get; set; } = 0;

        public string Options { get; set; } = string.Empty;
    }
}
