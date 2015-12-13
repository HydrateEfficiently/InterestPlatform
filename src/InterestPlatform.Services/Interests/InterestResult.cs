using AutoMapper;
using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class InterestResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public IEnumerable<Filter> Filters { get; set; }

        public InterestResult(Interest interest)
        {
            Mapper.CreateMap<Interest, InterestResult>();
            Mapper.Map(interest, this);
            Filters = interest.DiscreteFilters.Cast<Filter>()
                .Concat(interest.ContinuousFilters.Cast<Filter>())
                .Concat(interest.SwitchFilters.Cast<Filter>())
                .OrderBy(f => f.Order);
        }
    }
}
