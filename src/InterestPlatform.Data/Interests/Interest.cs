using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public class Interest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Filter> Filters { get; set; }
    }
}
