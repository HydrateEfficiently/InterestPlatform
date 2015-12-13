using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public interface IInterestService
    {
        InterestResult Get(string path);

        Task<InterestResult> CreateAsync(CreateInterestRequest request);

    }
}
