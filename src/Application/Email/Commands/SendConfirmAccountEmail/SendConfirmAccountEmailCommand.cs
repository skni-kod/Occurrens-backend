using MediatR;

namespace Application.Email.Commands.SendConfirmAccountEmail;

public record SendConfirmAccountEmailCommand(Guid UserId) : IRequest;