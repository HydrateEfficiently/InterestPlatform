using AutoMapper;
using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using InterestPlatform.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class InterestResult
    {
        private class FilterOrdering
        {
            public int Id;
            public int Order;
            public FilterType FilterType;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public IList<Filter> OrderedFilters { get; set; }

        public Dictionary<int, DiscreteFilter> DiscreteFiltersById { get; set; }

        public Dictionary<int, ContinuousFilter> ContinuousFiltersById { get; set; }

        public Dictionary<int, SwitchFilter> SwitchFiltersById { get; set; }

        public InterestResult(Interest interest)
        {
            Mapper.CreateMap<Interest, InterestResult>();
            Mapper.Map(interest, this);

            OrderedFilters = interest.DiscreteFilters.Cast<Filter>()
                .Concat(interest.ContinuousFilters.Cast<Filter>())
                .Concat(interest.SwitchFilters.Cast<Filter>())
                .OrderBy(f => f.Order)
                .ToList();

            DiscreteFiltersById = interest.DiscreteFilters.ToDictionary(f => f.Id);
            ContinuousFiltersById = interest.ContinuousFilters.ToDictionary(f => f.Id);
            SwitchFiltersById = interest.SwitchFilters.ToDictionary(f => f.Id);
        }

        private IEnumerable<FilterOrdering> SelectOrderingFields(IEnumerable<Filter> filters, FilterType filterType)
        {
            return filters.Select(f => new FilterOrdering()
            {
                Id = f.Id,
                Order = f.Order,
                FilterType = FilterType.Discrete
            });
        }
    }
}
