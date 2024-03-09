using Application.Contracts.DoctorInformationsAnswers.Office;
using Application.Contracts.DoctorInformationsAnswers.Specialization;
using Application.DoctorInformations.Commands.DeleteOffice;
using Application.DoctorInformations.Commands.DeleteSpecialization;
using Application.DoctorInformations.Commands.EditOfficeInfo;
using Application.DoctorInformations.Commands.EditSpecialization;
using Application.DoctorInformations.Commands.SetAddress;
using Application.DoctorInformations.Commands.SetOpenedData;
using Application.DoctorInformations.Commands.SetSpecialization;
using Application.DoctorInformations.Queries.GetSelfInfo;
using Core.Account.enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.SelfDoctorInformations;

[Authorize(Roles = nameof(UserRoles.Doctor))]
[Route("doctor-informations")]
public class SelfDoctorInformationsController : ApiController
{
    private readonly IMediator _mediator;

    public SelfDoctorInformationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Set specialization
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("set-specialization")]
    public async Task<IActionResult> SetSpecialization([FromBody] SetSpecializationCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors) 
            );
    }

    /// <summary>
    /// Set doctor's office address
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("set-address")]
    public async Task<IActionResult> SetAddress([FromBody] SetAddressCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Set date-opened office
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("set-opened-info")]
    public async Task<IActionResult> SetOpenedInfo([FromBody] SetOpenedDataCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Update doctor specialization
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("edit-specialization/{id}")]
    public async Task<IActionResult> EditSpecialization([FromRoute] Guid id, [FromBody] UpdateSpecializationRequest request)
    {
        var command = new EditSpecializationCommand(id, request.Specialization);

        var response = await _mediator.Send(command);

        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Update doctor office info
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("edit-doctor-office-info/{id}")]
    public async Task<IActionResult> EditDoctorOfficeInfo([FromRoute] Guid id, [FromBody] UpdateOfficeInfoRequest request)
    {
        var command = new EditOfficeInfoCommand(
            request.Street,
            request.BuildingNumber,
            request.ApartamentNumber,
            request.PostalCode,
            request.City,
            request.Monday,
            request.Tuesday,
            request.Wednesday,
            request.Thursday,
            request.Fridady,
            request.Saturday,
            request.Sunday,
            id);

        var response = await _mediator.Send(command);
        
        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Delete specialization
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete("delete-specialization/{id}")]
    public async Task<IActionResult> DeleteSpecialization([FromRoute] DeleteSpecializationCommand command)
    {
        var response = await _mediator.Send(command);
        
        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Delete office
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete("delete-office/{id}")]
    public async Task<IActionResult> DeleteOffice([FromRoute] DeleteOfficeCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
            );
    }

    /// <summary>
    /// Get self informations
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> DisplayData()
    {
        var response = await _mediator.Send(new GetSelfInfoQuery());
        
        return response.Match(
            infoResponse => Ok(infoResponse),
            errors => Problem(errors)
        );
    }
}