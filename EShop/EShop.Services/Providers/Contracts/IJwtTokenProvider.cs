namespace EShop.Services.Providers.Contracts
{
    using Common.Entities;

    using System.Collections.Generic;

    public interface IJwtTokenProvider
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles = null);
    }
}
