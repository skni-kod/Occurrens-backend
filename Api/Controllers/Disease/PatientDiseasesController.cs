using Application.Diseases.Queries.GetSelfDiseasesForPatient;
using Core.Account.enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Disease;

[Route("patient-diseases")]
[Authorize(Roles = nameof(UserRoles.Patient))]
public class PatientDiseasesController : ApiController
{
    private readonly IMediator _mediator;

    public PatientDiseasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Method to get self medical history
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetMedicalHistory()
    {
        var query = new GetSelfDiseasesQuery();

        var response = await _mediator.Send(query);

        return response.Match(
            diseasesResponse => Ok(diseasesResponse),
            errors => Problem(errors)
            );
    }
}