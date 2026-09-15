using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PravnaLicaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaPravnaLica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSvaPravnaLica()
        {
            var pravnaLica = await OsobaDataProvider.VratiSvaPravnaLicaAsync();

            if (pravnaLica.IsError)
            {
                return StatusCode(pravnaLica.Error.StatusCode,pravnaLica.Error.Message);
            }

            return Ok(pravnaLica.Data);
        }

        [HttpPost]
        [Route("DodajPravnoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DodajPravnoLice([FromBody] PravnaLicaView p)
        {
            var result = await OsobaDataProvider.DodajPravnoLiceAsync(p);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniPravnoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IzmeniPravnoLice([FromBody] PravnaLicaView p)
        {
            var result = await OsobaDataProvider.IzmeniPravnoLiceAsync(p);

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
