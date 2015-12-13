using AutoMapper;
using InterestPlatform.Data;
using InterestPlatform.Data.Interests;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace InterestPlatform.Services.Interests
{
    public class InterestService : IInterestService
    {

        private readonly ApplicationDbContext _context;
        private readonly ISlugBuilderFactory _slugBuilderFactory;

        public InterestService(
            ApplicationDbContext context,
            ISlugBuilderFactory slugBuilderFactory)
        {
            _context = context;
            _slugBuilderFactory = slugBuilderFactory;
        }

        public InterestResult Get(string path)
        {
            var interest = _context.Interests
                .Where(i => i.Path == path)
                .Include(i => i.DiscreteFilters)
                .Include(i => i.ContinuousFilters)
                .Include(i => i.SwitchFilters)
                .FirstOrDefault();
            return new InterestResult(interest);
        }

        public InterestResult Get(int id)
        {
            var interest = _context.Interests.FirstOrDefault(i => i.Id == id);
            return new InterestResult(interest);
        }

        public async Task<InterestResult> CreateAsync(CreateInterestRequest request)
        {
            var interest = new Interest()
            {
                Name = request.Name,
                Path = _slugBuilderFactory.Create().Add(request.Name).ToString()
            };

            var duplicate = _context.Interests.FirstOrDefault(i => i.Path == interest.Path);
            if (duplicate != null)
            {
                throw new DuplicateUrlException();
            }

            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return Get(interest.Path);
        }

        public async Task CreateFilterAsync(CreateFilterRequest request)
        {
            var interest = GetInterest(request.InterestId);
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
