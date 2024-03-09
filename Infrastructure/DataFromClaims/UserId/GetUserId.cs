using System.Security.Claims;
using Core.DataFromClaims.UserId;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.DataFromClaims.UserId;

public class GetUserId : IGetUserId
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetUserId(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
    
    public Guid? UserId => User is null ? null : (Guid?)Guid.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
}