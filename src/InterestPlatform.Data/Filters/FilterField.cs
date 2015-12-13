using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data.Filters
{
    public abstract class FilterField<TFilter> where TFilter : Filter
    {
        public int Id { get; set; }


        // Foreign Keys To

        public int PostId { get; set; }

        public abstract Post Post { get; set; }

        public int? FilterId { get; set; }

        public abstract TFilter Filter { get; set; }
    }
}
