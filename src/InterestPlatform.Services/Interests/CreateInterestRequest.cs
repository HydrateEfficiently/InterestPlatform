using AutoMapper;
using InterestPlatform.Data.Interests;
using InterestPlatform.Services.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class CreateInterestRequest : IMapToEntity<Interest>
    {
        public string Name { get; set; }

        public IEnumerable<CreateFilterRequest> Filters { get; set; } = Enumerable.Empty<CreateFilterRequest>();

        public Interest ToEntity()
        {
            Mapper.CreateMap<CreateInterestRequest, Interest>();
            return Mapper.Map<CreateInterestRequest, Interest>(this);
        }
    }
}
