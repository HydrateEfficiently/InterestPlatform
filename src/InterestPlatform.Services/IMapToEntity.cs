using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services
{
    public interface IMapToEntity<TEntity>
    {
        TEntity ToEntity();
    }
}
