using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Filters
{
    public interface IFilterService
    {
        Task CreateAsync(int interestId, CreateFilterRequest request);
    }
}
