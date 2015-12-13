using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public class DiscreteFilterOption
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiscreteFilterId { get; set; }
        
        [InverseProperty("Options")]
        public virtual DiscreteFilter DescreteFilter { get; set; }
    }
}
