using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Interests
{
    public abstract class Filter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int InterestId { get; set; }
        
        [InverseProperty("Filters")]
        public virtual Interest Interest { get; set; }
    }
}
