using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Interests
{
    public class DuplicateUrlException : Exception
    {
        public DuplicateUrlException() : base() { }
    }
}
