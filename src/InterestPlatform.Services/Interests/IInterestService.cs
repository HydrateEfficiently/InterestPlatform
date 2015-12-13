using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public interface IInterestService
    {
        InterestResult Get(string path);

        InterestResult Get(int id);

        Task<InterestResult> CreateAsync(CreateInterestRequest request);

        Task CreateFilterAsync(CreateFilterRequest request);

    }
}
