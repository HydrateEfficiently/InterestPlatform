using AutoMapper;
using InterestPlatform.Data;
using InterestPlatform.Data.Filters;
using InterestPlatform.Data.Interests;
using InterestPlatform.Identity;
using InterestPlatform.Services.Filters;
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
        private readonly IIdentityResolver _identityResolver;
        private readonly IFilterService _filterService;

        public InterestService(
            ApplicationDbContext context,
            ISlugBuilderFactory slugBuilderFactory,
            IIdentityResolver identityResolver,
            IFilterService filterService)
        {
            _context = context;
            _slugBuilderFactory = slugBuilderFactory;
            _identityResolver = identityResolver;
            _filterService = filterService;
        }

        public InterestResult Get(string path)
        {
            var interest = _context.Interests
                .Where(i => i.Path == path)
                .Include(i => i.DiscreteFilters).ThenInclude(f => f.Options)
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

            interest.CreatedById = _identityResolver.GetUserId();
            interest.CreatedDate = DateTime.UtcNow;

            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            await Task.WhenAll(request.Filters.Select(f => _filterService.CreateAsync(interest.Id, f)));

            return Get(interest.Path);
        }

        #region Helpers

        #endregion
    }
}
