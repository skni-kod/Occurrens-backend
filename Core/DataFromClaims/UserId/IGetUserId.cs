using System.Security.Claims;

namespace Core.DataFromClaims.UserId;

public interface IGetUserId
{
    ClaimsPrincipal User { get; }
    Guid? UserId { get; } 
}