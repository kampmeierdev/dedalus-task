using DedalusApi.Dtos;
using DedalusApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DedalusApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DenominationController : ControllerBase
{
    private IDenominationService _denominationService;
    public DenominationController(IDenominationService denominationService)
    {
        _denominationService = denominationService;
    }

    /// <summary>
    /// Returns a denomination for an amount.
    /// </summary>
    /// <response code="200">Returns the denomination for the given amount.</response>
    /// <response code="400">If the amount is lesser than 0 or if the amount has more than 2 decimal places.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public ActionResult<DenominationOutput[]> Post(DenominationInput denominationInput)
    {
        try
        {
            var result = _denominationService.Calculate(denominationInput.Amount);
            
            return Ok(result);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
