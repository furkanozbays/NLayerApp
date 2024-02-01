using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;
namespace NLayerApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
    {
        if (response.StatusCode == 204)
        {
            return new ObjectResult(null)
            {
                StatusCode = response.StatusCode
            };
        }
        else
        {
            return response.StatusCode switch
            {
                200 => Ok(response),
                201 => Created("", response),
                400 => BadRequest(response),
                404 => NotFound(response),
                _ => BadRequest(response)
            };
        }
    }
}