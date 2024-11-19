using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Occurrens.Application.Persistance.Interfaces.CurrentUser;

namespace Occurrens.Infrastructure.Persistance.CurrentUserService.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }


    public Guid UserId()
    {
        var claims = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(claims))
        {
            return Guid.Empty;
        }

        var parseToGuid = Guid.TryParse(claims, out var userId);

        if (!parseToGuid || userId == Guid.Empty)
        {
            return Guid.Empty;
        }

        return userId;
    }
}