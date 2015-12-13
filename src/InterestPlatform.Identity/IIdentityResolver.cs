using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InterestPlatform.Identity
{
    public interface IIdentityResolver
    {
        ClaimsPrincipal Resolve();

        string GetUserName();

        string GetUserId();

        bool IsSignedIn();
    }
}
