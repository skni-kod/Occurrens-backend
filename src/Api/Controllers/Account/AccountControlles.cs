using Application.Account.Commands.ConfirmAccount;
using Application.Account.Commands.SignUp;
using Application.Email.Commands.SendResetPasswordEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Account;

[ApiController]
[Route("api/account")]

public class AccountControlles : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountControlles(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// sign up
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("sign-up")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        
        return Ok(response);
    }

    /// <summary>
    /// confirm account
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("confirm-account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConfirmAccount([FromBody] ConfirmAccountCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Send reset password email
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("send-reset-password-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendResetPasswordEmail([FromBody] SendResetPasswordEmailCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}