using AutoMapper;
using InterestPlatform.Data;
using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using InterestPlatform.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Filters
{
    public class FilterService : IFilterService
    {
        private readonly ApplicationDbContext _context;
        private readonly IIdentityResolver _identityResolver;

        public FilterService(
            ApplicationDbContext context,
            IIdentityResolver identityResolver)
        {
            _context = context;
            _identityResolver = identityResolver;
        }

        public async Task CreateAsync(int interestId, CreateFilterRequest request)
        {
            var interest = GetInterest(interestId);
            if (interest == null)
            {
                throw new Exception("Interest not found");
            }

            switch (request.FilterType)
            {
                case FilterType.Discrete:
                    await CreateDiscreteFilterAsync(request);
                    break;
                case FilterType.Continuous:
                    await CreateContinuousFilterAsync(request);
                    break;
                case FilterType.Switch:
                    await CreateSwitchFilterAsync(request);
                    break;
                default:
                    throw new Exception("Unhandled Filter Type");
            }

            await _context.SaveChangesAsync();
        }

        #region Helpers

        private Interest GetInterest(int id)
        {
            return _context.Interests.FirstOrDefault(i => i.Id == id);
        }

        private async Task CreateDiscreteFilterAsync(CreateFilterRequest request)
        {
            Mapper.CreateMap<CreateFilterRequest, DiscreteFilter>()
                .ForMember(
                    dest => dest.Options,
                    opts => opts.Ignore());
            var filter = Mapper.Map<CreateFilterRequest, DiscreteFilter>(request);
            _context.DiscreteFilters.Add(filter);
            await _context.SaveChangesAsync();

            foreach (var filterOptionName in request.Options.Split(','))
            {
                var filterOption = new DiscreteFilterOption()
                {
                    DiscreteFilterId = filter.Id,
                    Name = filterOptionName
                };
                _context.DiscreteFilterOptions.Add(filterOption);
            }
            await _context.SaveChangesAsync();
        }

        private async Task CreateContinuousFilterAsync(CreateFilterRequest request)
        {
            Mapper.CreateMap<CreateFilterRequest, ContinuousFilter>();
            var filter = Mapper.Map<CreateFilterRequest, ContinuousFilter>(request);
            _context.ContinuousFilters.Add(filter);
            await _context.SaveChangesAsync();
        }

        private async Task CreateSwitchFilterAsync(CreateFilterRequest request)
        {
            Mapper.CreateMap<CreateFilterRequest, SwitchFilter>();
            var filter = Mapper.Map<CreateFilterRequest, SwitchFilter>(request);
            _context.SwitchFilters.Add(filter);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
