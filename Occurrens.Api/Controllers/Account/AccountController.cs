﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Occurrens.Application.Account.Command.ConfirmAccount;
using Occurrens.Application.Account.Command.RefreshToken;
using Occurrens.Application.Account.Command.ResetPassword;
using Occurrens.Application.Account.Command.SignIn;
using Occurrens.Application.Account.Command.SignOut;
using Occurrens.Application.Account.Command.SignUp;
using Occurrens.Application.Email.Commands.SendResetPasswordEmail;

namespace Occurrens.Api.Controllers.Account;

[ApiController]
[Route("api/account")]

public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
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
    /// Sign in
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        var cookie = new CookieOptions
        {
            HttpOnly = true,
            Expires = response.RefreshToken.Expires
        };
        
        Response.Cookies.Append("refresh-token", response.RefreshToken.Token, cookie);

        return Ok(response);
    }
    
    /// <summary>
    /// Sign out
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("sign-out")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignOut(CancellationToken cancellationToken)
    {
        var refreshToken = Request.Cookies["refresh-token"];

        await _mediator.Send(new SignOutCommand(refreshToken), cancellationToken);
        
        Response.Cookies.Delete("refresh-token");

        return Ok();
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
    /// Refresh token
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
    {
        var refreshToken = Request.Cookies["refresh-token"];
        var response = await _mediator.Send(new RefreshTokenCommand(refreshToken), cancellationToken);
        
        var cookie = new CookieOptions
        {
            HttpOnly = true,
            Expires = response.RefreshToken.Expires
        };
        
        Response.Cookies.Append("refresh-token", response.RefreshToken.Token, cookie);
        
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
    
    /// <summary>
    /// Reset password
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}