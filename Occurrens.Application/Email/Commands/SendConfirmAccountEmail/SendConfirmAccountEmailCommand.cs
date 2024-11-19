using MediatR;

namespace Occurrens.Application.Email.Commands.SendConfirmAccountEmail;

public sealed record SendConfirmAccountEmailCommand(Guid UserId) : IRequest;