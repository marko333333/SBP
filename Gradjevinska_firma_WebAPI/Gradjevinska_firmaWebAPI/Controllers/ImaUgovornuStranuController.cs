using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
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
        public async Task<IActionResult> VratiSveUgovorneStrane()
        {
            var result = await ImaUgovornuStranuDataProvider.VratiSveUgovorneStraneAsync();

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
        public async Task<IActionResult> VratiUgovorneStraneOsobe(int idOsobe)
        {
            var result =await ImaUgovornuStranuDataProvider.VratiUgovorneStraneOsobeAsync(idOsobe);

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
        public async Task<IActionResult> VratiUgovorneStraneUgovora(int idUgovora)
        {
            var result =await ImaUgovornuStranuDataProvider.VratiUgovorneStraneUgovoraAsync(idUgovora);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajUgovornuStranu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajUgovornuStranu([FromBody] ImaUgovornuStranuView s)
        {
            var result = await ImaUgovornuStranuDataProvider.DodajUgovornuStranuAsync(s);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiUgovornuStranu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiUgovornuStranu(int id)
        {
            var result = await ImaUgovornuStranuDataProvider.VratiUgovornuStranuAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniUgovornuStranu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniUgovornuStranu([FromBody] ImaUgovornuStranuView s)
        {
            var result = await ImaUgovornuStranuDataProvider.IzmeniUgovornuStranuAsync(s);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiUgovornuStranu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiUgovornuStranu(int id)
        {
            var result = await ImaUgovornuStranuDataProvider.ObrisiUgovornuStranuAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

    }
}
