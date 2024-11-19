using MediatR;
using Occurrens.Domain.AuthTokens;

namespace Occurrens.Application.Account.Command.SignIn;

public sealed record SignInCommand(
    string Email,
    string Password) : IRequest<JsonWebToken>;