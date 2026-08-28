using Microsoft.AspNetCore.Mvc;
using Gradjevinska_firmaLibrary.DataProvider;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OsobaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveOsobe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetOsobe()
        {
            var osobe = await OsobaDataProvider.VratiSveOsobeAsync();

            if (osobe.IsError)
            {
                return StatusCode(osobe.Error.StatusCode,osobe.Error.Message);
            }

            return Ok(osobe.Data);
        }
    }
}
