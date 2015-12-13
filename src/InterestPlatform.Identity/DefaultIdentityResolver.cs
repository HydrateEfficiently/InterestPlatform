using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using System.Security.Claims;

namespace InterestPlatform.Identity
{
    public class DefaultIdentityResolver : IIdentityResolver
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultIdentityResolver(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ClaimsPrincipal Resolve()
        {
            if (_contextAccessor == null || _contextAccessor.HttpContext == null)
            {
                return ClaimsPrincipal.Current;
            }

            return _contextAccessor.HttpContext.User;
        }

        public string GetUserName()
        {
            return Resolve()?.GetUserName();
        }
        public string GetUserId()
        {
            return Resolve()?.GetUserId();
        }

        public bool IsSignedIn()
        {
            var user = Resolve();
            return user != null && user.IsSignedIn();
        }
    }
}
