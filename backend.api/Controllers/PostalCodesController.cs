#region

using backend.Infra.Repositories.Interfaces;
using backend.services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace backend.Controllers;

[ApiController]
[Route("api")]
[EnableCors("AllowAll")]
public class PostalCodesController : ControllerBase
{
    /*
     * TODO:
     * 1. Get the postal code from the query string
     * 2. Search for the postal code in postcodes.io/postcodes/{postcode}
     * 3. Calculate Km distance between the postal code and the airport
     * 4. Convert the distance to miles
     * 5. Return object with all data
     */

    private readonly IPostalCodesRepository _repository;
    private readonly ICallPostCodes _postCodes;

    public PostalCodesController(IPostalCodesRepository repository,
        ICallPostCodes postCodes)
    {
        _repository = repository;
        _postCodes = postCodes;
    }

    [HttpGet("postalcodes")]
    public async Task<IActionResult> GetLastThreePostalCodes()
    {
        return Ok(await _repository.GetLastThreeAsync());
    }

    [HttpPost("postalcodes/{postalCode}")]
    public async Task<IActionResult> GetPostalCode(string postalCode)
    {
        var postCodeService = await _postCodes.ExecuteAsync(postalCode);
        await _repository.AddAsync(postCodeService);

        return Ok(postCodeService);
    }
}