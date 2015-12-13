using AutoMapper;
using InterestPlatform.Data;
using InterestPlatform.Data.Interests;
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
            var interest = _context.Interests.FirstOrDefault(i => i.Path == path);
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
    }
}
