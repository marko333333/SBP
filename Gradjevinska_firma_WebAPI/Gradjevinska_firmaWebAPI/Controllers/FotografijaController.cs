using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FotografijaController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveFotografije")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveFotografije()
        {
            var result = await FotografijaDataProvider.VratiSveFotografijeAsync();

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFotografijeNapretka/{idNapretka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFotografijeNapretka(int idNapretka)
        {
            var result = await FotografijaDataProvider.VratiFotografijeNapretkaAsync(idNapretka);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajFotografiju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodajFotografiju([FromBody] FotografijaView f)
        {
            var result = await FotografijaDataProvider.DodajFotografijuAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiFotografiju/{napredakId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiFotografiju(int napredakId,[FromQuery] string putanja)
        {
            var result = await FotografijaDataProvider.VratiFotografijuAsync(napredakId, putanja);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniFotografiju/{napredakId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniFotografiju(int napredakId,[FromQuery] string staraPutanja,[FromBody] FotografijaView f)
        {
            var result = await FotografijaDataProvider.IzmeniFotografijuAsync(napredakId,staraPutanja,f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiFotografiju/{napredakId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiFotografiju(int napredakId,[FromQuery] string putanja)
        {
            var result = await FotografijaDataProvider.ObrisiFotografijuAsync(napredakId, putanja);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }
    }
}
