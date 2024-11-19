using MediatR;
using Occurrens.Domain.AuthTokens;

namespace Occurrens.Application.Account.Command.RefreshToken;

public sealed record RefreshTokenCommand(string? RefreshToken) : IRequest<JsonWebToken>;