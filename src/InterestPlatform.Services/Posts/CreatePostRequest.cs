using InterestPlatform.Data.Filters;
using InterestPlatform.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Posts
{
    public class CreatePostRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int InterestId { get; set; }

        public IList<FilterFieldRequest> FitlerFields { get; set; }
    }
}
