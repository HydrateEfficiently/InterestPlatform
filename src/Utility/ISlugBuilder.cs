using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utility
{
    public interface ISlugBuilder
    {
        ISlugBuilder Add(Guid input);

        ISlugBuilder Add(long input);

        ISlugBuilder Add(int input);

        ISlugBuilder Add(string input);
    }
}
