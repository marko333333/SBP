using Gradjevinska_firmaLibrary.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImaUgovornuStranuController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveUgovorneStrane")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetSveUgovorneStrane()
        {
            var result =
                await ImaUgovornuStranuDataProvider.VratiSveUgovorneStraneAsync();

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiUgovorneStraneOsobe/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUgovorneStraneOsobe(int idOsobe)
        {
            var result =
                await ImaUgovornuStranuDataProvider.VratiUgovorneStraneOsobeAsync(idOsobe);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiUgovorneStraneUgovora/{idUgovora}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUgovorneStraneUgovora(int idUgovora)
        {
            var result =
                await ImaUgovornuStranuDataProvider.VratiUgovorneStraneUgovoraAsync(idUgovora);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }
    }
}
