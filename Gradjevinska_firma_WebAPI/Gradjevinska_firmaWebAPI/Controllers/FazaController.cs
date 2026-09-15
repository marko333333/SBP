using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FazaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveFaze")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveFaze()
        {
            var result = await FazaDataProvider.VratiSveFazeAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFazeProjekta/{projekatId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiFazeProjekta(int projekatId)
        {
            var result = await FazaDataProvider.VratiFazeProjektaAsync(projekatId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajFazu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajFazu([FromBody] FazaView f)
        {
            var result = await FazaDataProvider.DodajFazuAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFazu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiFazu(int id)
        {
            var result =await FazaDataProvider.VratiFazuAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniFazu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniFazu([FromBody] FazaView f)
        {
            var result =await FazaDataProvider.IzmeniFazuAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiFazu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiFazu(int id)
        {
            var result = await FazaDataProvider.ObrisiFazuAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode,result.Error.Message);

            return Ok(result.Data);
        }
    }
}
