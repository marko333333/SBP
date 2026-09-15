using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AngazovanController:ControllerBase
    {

        [HttpGet]
        [Route("VratiSveAngazovane")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveAngazovane()
        {
            var result = await AngazovanDataProvider.VratiSveAngazovaneAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
        [HttpGet]
        [Route("VratiAngazovanjaOsobe/{idOsobe}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazovanjaOsobe(int idOsobe)
        {
            var result = await AngazovanDataProvider.VratiAngazovanjaOsobeAsync(idOsobe);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiAngazovanjaZadatka/{idZadatka}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazovanjaZadatka(int idZadatka)
        {
            var result = await AngazovanDataProvider.VratiAngazovanjaZadatkaAsync(idZadatka);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajAngazovan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DodajAngazovan([FromBody] AngazovanView a)
        {
            var result = await AngazovanDataProvider.DodajAngazovanAsync(a);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiAngazovan/{zadatakId}/{osobaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazovan(int zadatakId, int osobaId)
        {
            var result = await AngazovanDataProvider.VratiAngazovanAsync(zadatakId, osobaId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniAngazovan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniAngazovan([FromBody] AngazovanView a)
        {
            var result = await AngazovanDataProvider.IzmeniAngazovanAsync(a);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiAngazovan/{zadatakId}/{osobaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiAngazovan(int zadatakId,int osobaId)
        {
            var result = await AngazovanDataProvider.ObrisiAngazovanAsync(zadatakId, osobaId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }
    }
}
