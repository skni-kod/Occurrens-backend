using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Occurrens.Application.DoctorWorkPlace.Commands.AddDoctorWorkPlace;
using Occurrens.Application.DoctorWorkPlace.Commands.DeleteDoctorWorkPlace;
using Occurrens.Application.DoctorWorkPlace.Commands.UpdateDoctorWorkPlace;
using Occurrens.Application.DoctorWorkPlace.Dto;
using Occurrens.Application.DoctorWorkPlace.Queries.GetWorkPlacesForSpecificDoctor;
using Occurrens.Domain.Roles;

namespace Occurrens.Api.Controllers.DoctorWorkPlace;

[ApiController]
[Route("api/doctor-work-place")]
public class DoctorWorkPlaceController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorWorkPlaceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all doctor work places
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("get-doctor-work-place/{DoctorId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DisplayDoctorWorkPlaceDto>>> GetDoctorWorkPlaces([FromRoute] GetWorkPlacesForSpecificDoctorQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);

        return Ok(response);
    }
    
    /// <summary>
    /// Add doctor work place 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("add-doctor-work-place")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddDoctorWorkPlace([FromBody] AddDoctorWorkPlaceCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Update doctor work place
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("update-doctor-work-place")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateDoctorWorkPlace([FromBody] UpdateDoctorWorkPlaceCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Delete doctor work place
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("delete-doctor-work-place")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDoctorWorkPlace([FromBody] DeleteDoctorWorkPlaceCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}