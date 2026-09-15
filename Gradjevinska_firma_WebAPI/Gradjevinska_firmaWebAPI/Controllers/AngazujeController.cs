using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AngazujeController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvaAngazovanja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSvaAngazovanja()
        {
            var result = await AngazujeDataProvider.VratiSvaAngazovanjaAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiAngazovanjaOpreme/{opremaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazovanjaOpreme(int opremaId)
        {
            var result = await AngazujeDataProvider.VratiAngazovanjaOpremeAsync(opremaId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiAngazovanjaZadatka/{zadatakId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazovanjaZadatka(int zadatakId)
        {
            var result = await AngazujeDataProvider.VratiAngazovanjaZadatkaAsync(zadatakId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajAngazuje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DodajAngazuje([FromBody] AngazujeView a)
        {
            var result = await AngazujeDataProvider.DodajAngazujeAsync(a);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiAngazuje/{zadatakId}/{opremaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VratiAngazuje( int zadatakId, int opremaId)
        {
            var result = await AngazujeDataProvider.VratiAngazujeAsync(zadatakId, opremaId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniAngazuje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IzmeniAngazuje([FromBody] AngazujeView a)
        {
            var result = await AngazujeDataProvider.IzmeniAngazujeAsync(a);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiAngazuje/{zadatakId}/{opremaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiAngazuje(int zadatakId,int opremaId)
        {
            var result = await AngazujeDataProvider.ObrisiAngazujeAsync(zadatakId, opremaId);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }



    }
}
