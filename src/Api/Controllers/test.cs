using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("test")]
public class test : ControllerBase
{
    public async Task<IActionResult> Test()
    {
        return Ok("siema");
    }
}