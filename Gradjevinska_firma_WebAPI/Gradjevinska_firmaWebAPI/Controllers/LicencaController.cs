using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicencaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveLicence")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveLicence()
        {
            var licence = await LicencaDataProvider.VratiSveLicenceAsync();

            if (licence.IsError)
            {
                return StatusCode(licence.Error.StatusCode, licence.Error.Message);
            }

            return Ok(licence.Data);
        }

        [HttpGet]
        [Route("VratiLicenceOsobe/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiLicenceOsobe(int idOsobe)
        {
            var result = await LicencaDataProvider.VratiLicenceOsobeAsync(idOsobe);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
