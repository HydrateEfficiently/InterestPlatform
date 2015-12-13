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

        public IEnumerable<Tuple<FilterType, int>> OrderedFilterTypesAndIds { get; set; }

        public Dictionary<int, DiscreteFilter> DiscreteFiltersById { get; set; }

        public Dictionary<int, ContinuousFilter> ContinuousFiltersById { get; set; }

        public Dictionary<int, SwitchFilter> SwitchFiltersById { get; set; }

        public InterestResult(Interest interest)
        {
            Mapper.CreateMap<Interest, InterestResult>();
            Mapper.Map(interest, this);

            OrderedFilterTypesAndIds = SelectOrderingFields(interest.DiscreteFilters, FilterType.Discrete)
                .Concat(SelectOrderingFields(interest.ContinuousFilters, FilterType.Continuous))
                .Concat(SelectOrderingFields(interest.DiscreteFilters, FilterType.Discrete))
                .OrderBy(f => f.Order)
                .Select(f => new Tuple<FilterType, int>(f.FilterType, f.Id));

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
