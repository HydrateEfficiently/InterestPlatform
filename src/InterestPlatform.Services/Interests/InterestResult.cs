using AutoMapper;
using InterestPlatform.Data.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class InterestResult
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public InterestResult(Interest interest)
        {
            Mapper.CreateMap<Interest, InterestResult>();
            Mapper.Map(interest, this);
        }
    }
}
