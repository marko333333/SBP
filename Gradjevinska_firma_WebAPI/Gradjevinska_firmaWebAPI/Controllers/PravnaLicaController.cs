using Microsoft.AspNetCore.Mvc;
using Gradjevinska_firmaLibrary.DataProvider;
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
        public async Task<IActionResult> GetPravnaLica()
        {
            var pravnaLica = await PravnaLicaDataProvider.VratiSvaPravnaLicaAsync();

            if (pravnaLica.IsError)
            {
                return StatusCode(pravnaLica.Error.StatusCode,pravnaLica.Error.Message);
            }

            return Ok(pravnaLica.Data);
        }
    }
}
