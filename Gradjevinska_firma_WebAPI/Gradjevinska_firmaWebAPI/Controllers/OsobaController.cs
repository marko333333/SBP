using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> VratiSveOsobe()
        {
            var osobe = await OsobaDataProvider.VratiSveOsobeAsync();

            if (osobe.IsError)
            {
                return StatusCode(osobe.Error.StatusCode,osobe.Error.Message);
            }

            return Ok(osobe.Data);
        }

        [HttpGet]
        [Route("VratiOsobu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiOsobu(int id)
        {
            var osobe = await OsobaDataProvider.VratiOsobuAsync(id);

            if (osobe.IsError)
            {
                return StatusCode(osobe.Error.StatusCode, osobe.Error.Message);
            }

            return Ok(osobe.Data);
        }

        [HttpDelete]
        [Route("ObrisiOsobu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiOsobu(int id)
        {
            var result = await OsobaDataProvider.ObrisiOsobuAsync(id);

            if (result.IsError)
            {
                return StatusCode(
                    result.Error.StatusCode,
                    result.Error.Message);
            }

            return Ok(result.Data);
        }

    }
}
