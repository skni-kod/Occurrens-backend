using Application.Email.Responses;
using MediatR;

namespace Application.Email.Commands.SendResetPasswordEmail;

public record SendResetPasswordEmailCommand(
    string Email
    ) : IRequest<SendResetPasswordEmailResponse>;