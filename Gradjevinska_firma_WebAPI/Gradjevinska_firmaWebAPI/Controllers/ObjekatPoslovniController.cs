using Gradjevinska_firmaLibrary.DataProvider;
using Gradjevinska_firmaLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Gradjevinska_firmaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjekatPoslovniController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvePoslovneObjekte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> VratiSveKontakte()
        {
            var result = await ObjekatPoslovniDataProvider.VratiObjekteAsync();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiObjektePoslovnogProjekta/{poslovniId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> vratiObjektePoslovnogProjekta(int poslovniId)
        {
            var result = await ObjekatPoslovniDataProvider.VratiObjektePoslovnogProjektaAsync(poslovniId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajPoslovniObjekat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> dodajPoslovniObjekat([FromBody] ObjekatPoslovniView f)
        {
            var result = await ObjekatPoslovniDataProvider.DodajObjekatAsync(f);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("VratiPoslovniObjekat/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> vratiObjekatPoslovni(int id)
        {
            var result = await ObjekatPoslovniDataProvider.vratiObjekatAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniPoslovniObjekat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> izmeniObjekat([FromBody] ObjekatPoslovniView f)
        {
            var result =
                await ObjekatPoslovniDataProvider.izmeniObjekatAsync(f);

            if (result.IsError)
                return StatusCode(
                    result.Error.StatusCode,
                    result.Error.Message);

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiPoslovniObjekat/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> obrisiPoslovniObjekat(int id)
        {
            var result = await ObjekatPoslovniDataProvider.ObrisiObjekatAsync(id);

            if (result.IsError)
                return StatusCode(result.Error.StatusCode, result.Error.Message);

            return Ok(result.Data);
        }
    }
}
