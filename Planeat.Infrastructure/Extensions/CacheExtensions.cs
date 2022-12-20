using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwtToken(this IMemoryCache cache, Guid jwtTokenId, string jwtToken)
        {
            cache.Set(GetJwtTokenKey(jwtTokenId), jwtToken, TimeSpan.FromSeconds(5));
        }

        public static string GetJwtToken(this IMemoryCache cache, Guid jwtTokenId)
        {
            return cache.Get<string>(GetJwtTokenKey(jwtTokenId));
        }

        private static string GetJwtTokenKey(Guid jwtTokenId)
        {
            return $"jwt-{jwtTokenId}";
        }
    }
}
