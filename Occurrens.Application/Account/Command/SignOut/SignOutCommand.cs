using MediatR;

namespace Occurrens.Application.Account.Command.SignOut;

public sealed record SignOutCommand(string RefreshToken) : IRequest;
