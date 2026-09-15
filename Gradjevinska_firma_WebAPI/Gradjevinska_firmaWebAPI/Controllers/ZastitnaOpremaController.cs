using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZastitnaOpremaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSvuZastitnuOpremu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSvuZastitnuOpremu()
        {
            var result = await ZastitnaOpremaDataProvider.VratiSvuZastitnuOpremuAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiZastitneOpremeFizickogLica/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiZastitneOpremeFizickogLica(int idOsobe)
        {
            var result = await ZastitnaOpremaDataProvider.VratiZastitneOpremeFizickogLicaAsync(idOsobe);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
    }
}
