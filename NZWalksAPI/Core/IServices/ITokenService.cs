using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Core.IServices
{
    public interface ITokenService
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
