using MediatR;
using Occurrens.Application.Email.Responses;

namespace Occurrens.Application.Email.Commands.SendResetPasswordEmail;

public sealed record SendResetPasswordEmailCommand(
    string Email
    ) : IRequest<SendResetPasswordEmailResponse>;